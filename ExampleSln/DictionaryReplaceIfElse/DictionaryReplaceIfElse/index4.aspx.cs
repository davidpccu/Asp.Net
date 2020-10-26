using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DictionaryReplaceIfElse
{
    public partial class index4 : System.Web.UI.Page
    {
        //宣告委派
        public delegate bool MyKey(int numUser, string strUser);
        public delegate void MyValue();

        protected void Page_Load(object sender, EventArgs e)
        {
            //使用者輸入的兩個訊息
            int numUser = 12;
            string strUser = "你好";

            //====================== 複合式條件的判斷 ============================
            if ( numUser > 0 && strUser.Length == 2 )//複合式條件
            {
                showFirstMsg();
            }
            //↑↓這兩個if都會執行
            if ( numUser == 12 || strUser.StartsWith("你") )
            {
                showSecondMsg();
            }
            else if ( numUser >= 0 && numUser <= 10 && strUser == "測試" )
            {
                showThirdMsg();
            }



            Dictionary<MyKey, MyValue> d = new Dictionary<MyKey, MyValue>()
            {
              { new MyKey(isFirst), new MyValue(showFirstMsg) },
              { new MyKey(isSecond), new MyValue(showSecondMsg) },
              { new MyKey(isThird), new MyValue(showThirdMsg) }
            };

            //由於可能有多個條件符合，要跑foreach，執行符合的Method
            foreach ( KeyValuePair<MyKey, MyValue> item in d.Where(x => x.Key(numUser, strUser) == true) )
            {
                item.Value.Invoke();
            }
        }

        //把條件抽出成Method
        private bool isFirst(int numUser,string strUser)
        {
            return (numUser > 0 && strUser.Length == 2);
        
        }
        private bool isSecond(int numUser, string strUser)
        {
            return (numUser == 12 || strUser.StartsWith("你"));
        }
        private bool isThird(int numUser, string strUser)
        {
            return (numUser >= 0 && numUser <= 10 && strUser == "測試");
        }

        private void showFirstMsg()
        {
            Response.Write("數字大於0，字串長度等於2");
        }
        private void showSecondMsg()
        {
            Response.Write("數字等於12，字串開頭為'你'");
        }
        private void showThirdMsg()
        {
            Response.Write("數字介於0與10之間，字串等於'測試'");
        }

    }
}