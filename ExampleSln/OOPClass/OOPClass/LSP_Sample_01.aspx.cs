using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OOPClass
{
    public partial class LSP_Sample_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Square o = new Square();
            o.Width = 40;
            // o.Height = 40;
            Response.Write(LSPBehavior.GetArea(o));
        }

        // Define other methods and classes here
        public class LSPBehavior
        {
            public static int GetArea(Rectangle s)
            {
                if (s.Width > 20)
                {
                    s.Width = 20;
                }
                return s.Width * s.Height;
            }
        }

        public class Rectangle
        {
            public virtual int Height { get; set; }
            public virtual int Width { get; set; }
        }

        public class Square : Rectangle
        {
            private int _height;
            private int _width;
            public override int Height
            {
                get { return _height; }
                set { _height = _width = value; }
            }
            public override int Width
            {
                get { return _width; }
                set
                { _width = _height = value; }
            }
        }
    }
}