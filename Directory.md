### Directory I/O

公開建立、移動和全面列舉目錄和子目錄的靜態方法。

``` C#
// DataSet to JSON
private static void DStoJSON(DataSet MY_DS, string MY_Filename)
{
    try
    {
        if (!System.IO.Directory.Exists(myFilePath))
        {
            System.IO.Directory.CreateDirectory(myFilePath);
        }
    }
    catch { }

    string wkJson = JsonConvert.SerializeObject(MY_DS, Formatting.Indented);

    string myLogTimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss \"GMT\"zzz");
    CleanOldFile(myFilePath);

    try
    {
        using (StreamWriter outfile = new StreamWriter(myFilePath + @"\" + MY_Filename))
        {
            outfile.Write(wkJson);
        }
    }
    catch (Exception ex)
    {
        System.Diagnostics.EventLog.WriteEntry("DStoJSON", "XLog Error : " + FlattenException(ex).ToString() + "\n Main Error : " + wkJson.ToString());
    }
}

private static void CleanOldFile(string Log_Path)
{
    try
    {
        DirectoryInfo info = new DirectoryInfo(Log_Path);
        FileInfo[] files = info.GetFiles().OrderBy(p => p.CreationTime).ToArray();
        int DeleteCount = 0;

        if (DateTime.Now.Minute < Nth_Minute_Clean) return;
        if (DateTime.Now.Second % Nth_Second_Clean != 0) return;

        if (files.Length > Keep_Old_Log_No)
        {
            DeleteCount = files.Length - Keep_Old_Log_No;
        }
        else
        {
            return;
        }

        try
        {
            for (int i = 0; i < DeleteCount; i++)
            {

                files[i].Delete();

            }
        }
        catch (Exception ex)
        { }
    }
    catch (Exception ex1)
    {
    }
}

```

