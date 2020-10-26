using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StringExample
{
    public partial class Contains : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string str = "This is test";
            if ( str.Contains("test") )
            {
                Response.Write("The sequence 'test' was found.");
            }
        }
    }
}