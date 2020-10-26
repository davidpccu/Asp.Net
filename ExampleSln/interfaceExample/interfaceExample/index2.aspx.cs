using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace interfaceExample
{
    public partial class index2 : System.Web.UI.Page
    {
        interface IOne
        {
            void ONE();
        }

        interface ITwo
        {
            void TWO();
        }

        interface IThree : IOne
        {
            void THREE();
        }

        interface IFour
        {
            void FOUR();
        }

        interface IFive : IThree
        {
            void FIVE();
        }

        interface IEVEN : ITwo, IFour 
        {

        }

        class ODDEVEN : IEVEN, IFive //Must Implement all the abstract method, in Derived class.  
        {
            public void ONE() //Implementation of Abstract Method.  
            {
                HttpContext.Current.Response.Write("This is ONE<br>");
            }
            public void TWO()
            {
                HttpContext.Current.Response.Write("This is TWO<br>");
            }
            public void THREE()
            {
                HttpContext.Current.Response.Write("This is THERE<br>");
            }
            public void FOUR()
            {
                HttpContext.Current.Response.Write("This is FOUR<br>");
            }
            public void FIVE()
            {
                HttpContext.Current.Response.Write("This is FIVE<br>");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("This is ODD<br>");
            IFive obj1 = new ODDEVEN();
            obj1.ONE();
            obj1.THREE();
            obj1.FIVE();

            Response.Write("<br>This is EVEN");
            IEVEN obj2 = new ODDEVEN();
            obj2.TWO();
            obj2.FOUR();
        }
    }
}