using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OOPClass
{
    public partial class ISP_Sample_02 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 將介面分割出來，使用者用不到的(或不開放)method就會報錯
            IWritable Logger = new Logger();
            Logger.Write();
            //Logger.Read(); // not exist
        }

        interface IReadAndWrite : IReadable, IWritable
        {
        }

        interface IReadable
        {
            string Read();
        }

        interface IWritable
        {
            void Write();
        }

        class Logger : IReadAndWrite, IReadable, IWritable
        {
            public string Read() { return ""; }
            public void Write() { }
        }
    }
}