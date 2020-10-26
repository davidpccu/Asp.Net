using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

delegate void NumberChanger(int n);

namespace Anonymous
{
    public partial class Index : System.Web.UI.Page
    {
        static int num = 10;
        public static void AddNum(int p)
        {
            num += p;
            HttpContext.Current.Response.Write(string.Format("Named Method: {0}", num));
        }

        public static void MultNum(int q)
        {
            num *= q;
            HttpContext.Current.Response.Write(string.Format("Named Method: {0}", num));
        }
        public static int getNum()
        {
            return num;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //create delegate instances using anonymous method
            NumberChanger nc = delegate(int x)
            {
                Response.Write(string.Format("Anonymous Method: {0}", x));
            };

            //calling the delegate using the anonymous method 
            nc(10);

            //instantiating the delegate using the named methods 
            nc = new NumberChanger(AddNum);

            //calling the delegate using the named methods 
            nc(5);

            //instantiating the delegate using another named methods 
            nc = new NumberChanger(MultNum);

            //calling the delegate using the named methods 
            nc(2);
        }
    }
}