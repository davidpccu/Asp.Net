using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArrayExample
{
    public partial class index2 : System.Web.UI.Page
    {
        /*
         * 將當前的陣列複製到指定的陣列中
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            int [] myA = { 1, 2, 3, 4, 5 };
            int [] myB = { 6, 7, 8, 9, 10 };

            var myNewArray = new int[myA.Length + myB.Length];
            myA.CopyTo(myNewArray, 0);
            myB.CopyTo(myNewArray, myA.Length);

            foreach ( var item in myNewArray )
            {
                Response.Write( item.ToString() + "<br>");
            }
        }
    }
}