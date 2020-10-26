using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DictionaryReplaceIfElse
{
    public partial class index2 : System.Web.UI.Page
    {
        public delegate bool MyKey(int IntInput);
        public delegate void MyValue();

        protected void Page_Load(object sender, EventArgs e)
        {
            // 使用者輸入的文字
            int IntInput = 14;

            //====================== 但「if 也有判斷數字區間的情況，該怎麼辦呢？」========================
            if ( IntInput >= 1 && IntInput <= 10 ) // 在1到10的區間
            {
                showApple();
            }
            else if ( IntInput >= 11 && IntInput <= 20 ) // 在11到20的區間
            {
                showBanana();
            }
            else if ( IntInput >= 21 && IntInput <= 30 ) // 在21到30的區間
            {
                showCherry();
            }

            Dictionary<MyKey, MyValue> NumsDictionary = new Dictionary<MyKey, MyValue>() 
            { 
                { new MyKey(condition1), new MyValue(showApple) }, //各條件要做的事....
                { new MyKey(condition2), new MyValue(showBanana) },
                { new MyKey(condition3), new MyValue(showCherry) },
            };

            //挑選出Key的回傳值為true的Method來執行
            NumsDictionary.Where(x => x.Key(IntInput) == true).FirstOrDefault().Value.Invoke();
        }

        //把條件抽出成Method
        private bool condition1(int i)
        {
            return ( i >= 1 && i <= 10 );
        }
        private bool condition2(int i)
        {
            return ( i >= 11 && i <= 20 );
        }
        private bool condition3(int i)
        {
            return ( i >= 21 && i <= 30 );
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