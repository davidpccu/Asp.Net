using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DictionaryReplaceIfElse
{
    /*
     * 利用Dictionary集合和委派完整移除if else的分支判斷
     * 原文網址：https://dotblogs.com.tw/shadow/archive/2012/09/25/75039.aspx
     */

    public partial class index : System.Web.UI.Page
    {
        public delegate void DoSomething(); // 宣告委派

        protected void Page_Load(object sender, EventArgs e)
        {
            // 使用者輸入的文字
            string userInput = "櫻桃";

            // 正常的if...else
            if ( userInput == "蘋果" )
            {
                showApple();
            }
            else if ( userInput == "香蕉" )
            {
                showBanana();
            }
            else if ( userInput == "櫻桃" )
            {
                showCherry();
            }

            // 把原本 if 要判斷的條件字串儲存在Key，由於原本的 if 條件本來就不會重覆，正適合當Key
            // 各個Key(條件)要執行的Method就儲存在Value
            Dictionary<string, DoSomething> d = new Dictionary<string, DoSomething>() 
            { 
                { "蘋果", new DoSomething(showApple) },
                { "香蕉", new DoSomething(showBanana) },
                { "櫻桃", new DoSomething(showCherry) }
            };

            // 如果懶得宣告具名委派，寫得更簡潔的話
            //Dictionary<string, Action> d = new Dictionary<string, Action>() 
            //{
            //    { "蘋果", () => { Response.Write("Apple"); } },
            //    { "香蕉", () => { Response.Write("Banana"); } },
            //    { "櫻桃", () => { Response.Write("Cherry"); } }
            //};

            d[userInput].Invoke();//直接挑選要執行的Method來執行
        }

        private void showApple()
        {
            // Do Apple something...
            Response.Write("Apple");
        }
        private void showBanana()
        {
            // Do Banana something...
            Response.Write("Banana");
        }
        private void showCherry()
        {
            // Do Cherry something...
            Response.Write("Cherry");
        }

    }
}