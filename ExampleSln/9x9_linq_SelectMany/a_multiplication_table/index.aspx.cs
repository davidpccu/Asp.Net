using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace a_multiplication_table
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //用selectMany來寫9*9乘法表
            int[] ints = Enumerable.Range(1, 9).ToArray();
		    var result = ints.SelectMany(
                i1 => ints, 
                (i2, i3) => string.Format("{0}*{1}={2}", i2, i3, i2*i3) + ((i3==9) ? "<br/>" : ", "));
            Response.Write(string.Join("",result));
        }
    }
}