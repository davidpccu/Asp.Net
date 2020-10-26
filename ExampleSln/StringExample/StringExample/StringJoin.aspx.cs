using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StringExample
{
    public partial class StringJoin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] starray = new string[] {
                "Down the way nights are dark",
                "And the sun shines daily on the mountain top",
                "I took a trip on a sailing ship",
                "And when I reached Jamaica",
                "I made a stop"
            };

            string str = String.Join(" ", starray);
            Response.Write(str);
        }
    }
}