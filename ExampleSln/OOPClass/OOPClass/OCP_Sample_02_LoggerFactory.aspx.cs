using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OOPClass
{
    public partial class OCP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AppEvent myAppEvent = new AppEvent("Log"); //想產生不同Logger傳入指定字串即可
            myAppEvent.GenerateEvent("Test");            // ConsoleLogger: Test
        }

        #region OCP開放封閉原則
        
        // 採用分離與相依的技巧
        public interface ILogger
        {
            void Log(string message);
        }

        public class ConsoleLogger : ILogger
        {
            public void Log(string message)
            {
                HttpContext.Current.Response.Write(string.Format("ConsoleLogger: {0}<br/>", message));
            }
        }

        public class FileLogger : ILogger
        {
            public void Log(string message)
            {
                HttpContext.Current.Response.Write(string.Format("FileLogger: {0}<br/>", message));
            }
        }

        public class AppEvent
        {
            // readonly通常會用在class流程設計，在建構子指派值之後，就不能更改
            private readonly ILogger _Logger;

            public AppEvent(string loggerType)
            {
                this._Logger = LoggerFactory.CreateLogger(loggerType);
            }

            public void GenerateEvent(string message)
            {
                _Logger.Log(message);
            }
        }

        // 工廠模式，傳入一個名稱給他，會想辦法回傳一個物件給你
        public class LoggerFactory
        {
            public static ILogger CreateLogger(string loggerType)
            {
                if(loggerType == "Log")
                    return new ConsoleLogger();
                else if(loggerType == "File")
                    return new FileLogger();
                else
                    throw new NotFiniteNumberException();
            }
        }

        #endregion
    }
}