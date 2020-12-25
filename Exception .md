### Exception 

表示應用程式執行期間發生的錯誤

``` C#

// UI
try
{
    Exception myException = new Exception(ReturnCode.ReturnDictionary[ReturnCode.Name.E0002].Message)
    {
      Source = ReturnCode.ReturnDictionary[ReturnCode.Name.E0002].Code
    }
    throw myException;
}
catch(Exception ex)
{
    ex.Source = uint.TryParse(ex.Source, out uint _uint) ? ex.Source : "2000";
    // 後續錯誤處理
}


// CS
namespace NDP_UE_CS //異常代碼設定
{
    public class ReturnCode
    {
        public enum Name
        {
            E0000,
            E0001,
            E0002
        }
        
        public class CodeMessage
        {
            public string Code { get; set; }
            public string Message { get; set; }
        }
        
        public static Dictionary<Name, CodeMessage> ReturnDictionary = new Dictionaryy<Name, CodeMessage>()
        {
            { Name.E0000, new CodeMessage(){ Code= "0000", Message= "成功" } },
            { Name.E0001, new CodeMessage(){ Code= "0000", Message= "異常" } },
            { Name.E0002, new CodeMessage(){ Code= "0000", Message= "失敗" } },
        }
    }
}

``` 
