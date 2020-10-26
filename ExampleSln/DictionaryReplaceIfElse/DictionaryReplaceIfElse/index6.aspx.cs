using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DictionaryReplaceIfElse
{
    public partial class index6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userInput = "!@#$";//使用者輸入的文字

            Dictionary<Func<string, bool>, Action> d = new Dictionary<Func<string, bool>, Action>() 
            { 
                { (a) => { return a.Equals("蘋果"); }, () => { Response.Write("Apple"); }},
                { (a) => { return a.Equals("香蕉"); }, () => { Response.Write("Banana"); }},
                { (a) => { return a.Equals("櫻桃"); }, () => { Response.Write("Cherry"); }}
            };

            //條件都不符合的情況，抓出前三筆條件判斷都是false的話...
            d.Add(
                (a) => { return d.Take(3).All(x => x.Key.Equals(userInput) == false); },
                () => { Response.Write("字串都不符合條件"); }
            );

            //挑選出Key回傳值為true的Method來執行
            d.Where(x => x.Key(userInput) == true).FirstOrDefault().Value.Invoke();
        }
    }
}