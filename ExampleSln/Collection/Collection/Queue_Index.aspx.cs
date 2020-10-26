using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Collection
{
    public partial class Queue_Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Queue q = new Queue();

            q.Enqueue('A');
            q.Enqueue('M');
            q.Enqueue('G');
            q.Enqueue('W');

            Response.Write("Current queue: <br>");

            foreach ( char c in q )
                Response.Write(c + " ");
            Response.Write("<br>");
            q.Enqueue('V');
            q.Enqueue('H');
            Response.Write("Current queue: <br>");
            foreach ( char c in q )
                Response.Write(c + " ");
            Response.Write("<br>");
            Response.Write("Removing some values <br>");
            char ch = (char)q.Dequeue();
            Response.Write(string.Format("The removed value: {0}", ch));
            ch = (char)q.Dequeue();
            Response.Write(string.Format("The removed value: {0}", ch));
        }
    }
}