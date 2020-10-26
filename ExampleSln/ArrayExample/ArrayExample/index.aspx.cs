using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArrayExample
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 不知道傳遞參數的數量使用的情況。
            index app = new index();
            int myArray = app.AddElements(10,20,30,40,50,60);
            Response.Write(myArray);
        }

        public int AddElements(params int[] arr)
        {
            int sum = 0;
            foreach ( int i in arr )
            {
                sum += i;
            }
            return sum;
        }
    }
}