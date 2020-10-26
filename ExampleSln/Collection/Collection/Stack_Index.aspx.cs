using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Collection
{
    public partial class Stack_Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Stack st = new Stack();

            st.Push('A');
            st.Push('M');
            st.Push('G');
            st.Push('W');

            Response.Write("Current stack: <br>");
            foreach ( char c in st )
            {
                Response.Write(c + " ");
            }
            Response.Write("<br>");

            st.Push('V');
            st.Push('H');
            Response.Write(string.Format("The next poppable value in stack: {0}", st.Peek()));
            Response.Write("Current stack: <br>");
            foreach ( char c in st )
            {
                Response.Write(c + " ");
            }
            Response.Write("<br>");

            Response.Write("Removing values <br>");
            st.Pop();
            st.Pop();
            st.Pop();

            Response.Write("Current stack: <br>");
            foreach ( char c in st )
            {
                Response.Write(c + " ");
            }
        }
    }
}