using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DictionaryReplaceIfElse
{
    public partial class index3 : System.Web.UI.Page
    {
        public delegate bool MyKey(int userInput);
        public delegate void MyValue();

        protected void Page_Load(object sender, EventArgs e)
        {
            int userInput = 14;//使用者輸入的文字

            //====================== 多個條件符合的判斷 ============================
            if ( userInput > 0 )
            {
                showPlus();
            }
            if ( userInput >= 1 && userInput <= 10 )//在1到10的區間
            {
                showApple();
            }
            if ( userInput >= 11 && userInput <= 20 )//在11到20的區間
            {
                showBanana();
            }
            if ( userInput >= 21 && userInput <= 30 )//在21到30的區間
            {
                showCherry();
            }

            Dictionary<MyKey, MyValue> d = new Dictionary<MyKey, MyValue>() 
            { 
                { new MyKey(isPlus), new MyValue(showPlus) },
                { new MyKey(condition1), new MyValue(showApple) },
                { new MyKey(condition2), new MyValue(showBanana) },
                { new MyKey(condition3), new MyValue(showCherry) },
            };

            // ※只是把原本的.FirstOrDefault()，改成foreach走訪每筆物件，並在迴圈中執行Method即可
            // 挑選出Key回傳值為true的Method來執行，並注意集合內的物件順序就是Method執行順序
            foreach (KeyValuePair<MyKey,MyValue> item in d.Where(x => x.Key(userInput) == true))
            {
                item.Value.Invoke();
            }
        }

        //把條件抽出成Method
        private bool isPlus(int i)
        {
            return i > 0;
        }
        private bool condition1(int i)
        {
            return (i >= 1 && i <= 10);
        }
        private bool condition2(int i)
        {
            return (i >= 11 && i <= 20);
        }
        private bool condition3(int i)
        {
            return (i >= 21 && i <= 30);
        }

        private void showPlus()
        {
            // Do plus something...
            Response.Write("Plus");
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