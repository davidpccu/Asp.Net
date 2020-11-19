using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OOPClass
{
    public partial class DIP_Sample_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var o = new Customer(new EmailLogger());
            o.Add();
        }

        // Define other methods and classes here

        class Customer
        {
            private ILogger obj;

            public Customer(ILogger logger)
            {
                obj = logger;
            }

            public virtual void Add()
            {
                try
                {
                    // Database code goes here
                }
                catch (Exception ex)
                {
                    this.obj.Handle(ex.Message.ToString());
                }
            }
        }

        interface ILogger
        {
            void Handle(string error);
        }

        class FileLogger : ILogger
        {
            public void Handle(string error)
            {
                System.IO.File.WriteAllText(@"c:\Error.txt", error);
            }
        }

        class EverViewerLogger : ILogger
        {
            public void Handle(string error)
            {
                // log errors to event viewer
            }
        }

        class EmailLogger : ILogger
        {
            public void Handle(string error)
            {
                // send errors in email
            }
        }
    }
}