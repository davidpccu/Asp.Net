using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DictionaryReplaceIfElse
{
    public partial class index5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (d.Keys.Contains(userInput))//防呆
            {
                d[userInput].Invoke();//直接挑選要執行的Method來執行
            }
             * 
            if (d.Any(x=>x.Key(userInput)==true) )//防呆
            {
                //挑選出Key回傳值為true的Method來執行
                d.Where(x => x.Key(userInput) == true).FirstOrDefault().Value.Invoke();
            }
            */

            int userInput = 10000;//使用者輸入的文字

            Dictionary<Func<int, bool>, Action> d = new Dictionary<Func<int, bool>, Action>() 
            { 
                { (a) => { return (a >= 1 && a <= 10); }, () => { Response.Write("Apple"); } },
                { (a) => { return (a >= 11 && a <= 20);}, () => { Response.Write("Banana"); } },
                { (a) => { return (a >= 21 && a <= 30);}, () => { Response.Write("Cherry"); } }
            };

            //條件都不符合的情況，抓出前三筆條件判斷都是false的話...
            d.Add(
                (a) => { return d.Take(3).All(x => x.Key(userInput) == false); },
                () => { Response.Write("數字都不符合條件"); }
            );

            //挑選出Key回傳值為true的Method來執行
            d.Where(x => x.Key(userInput) == true).FirstOrDefault().Value.Invoke();
        }
    }
}