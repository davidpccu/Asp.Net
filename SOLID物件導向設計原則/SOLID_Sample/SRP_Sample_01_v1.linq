<Query Kind="Program" />

void Main()
{
	DataAccess.InsertData();
}

// Define other methods and classes here

class DataAccess
{
	public static void InsertData()
	{
		Console.WriteLine("Data inserted into database successfully");
		Console.WriteLine("Logged Time:" + DateTime.Now.ToLongTimeString() +
			" Log  Data insertion completed successfully");
	}
}