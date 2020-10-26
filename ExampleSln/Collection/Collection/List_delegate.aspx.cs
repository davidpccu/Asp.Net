using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Collection
{
    public partial class List_delegate : System.Web.UI.Page
    {
        delegate T NumberChanger<T>(T n);
        static int num = 10;
        public static int AddNum(int p)
        {
            num += p;
            return num;
        }

        public static int MultNum(int q)
        {
            num *= q;
            return num;
        }
        public static int getNum()
        {
            return num;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //create delegate instances
            NumberChanger<int> nc1 = new NumberChanger<int>(AddNum);
            NumberChanger<int> nc2 = new NumberChanger<int>(MultNum);

            //calling the methods using the delegate objects
            nc1(25);
            Response.Write(string.Format("Value of Num: {0}", getNum()));
            nc2(5);
            Response.Write(string.Format("Value of Num: {0}", getNum()));
        }
    }
}