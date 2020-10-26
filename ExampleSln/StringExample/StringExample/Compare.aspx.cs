using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StringExample
{
    public partial class Compare : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string str1 = "This is test";
            string str2 = "This is text";

            if ( String.Compare(str1, str2) == 0 )
            {
                Response.Write(str1 + " and " + str2 + " are equal.");
            }
            else
            {
                Response.Write(str1 + " and " + str2 + " are not equal.");
            }
        }
    }
}