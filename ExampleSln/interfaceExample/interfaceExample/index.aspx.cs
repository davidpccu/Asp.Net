using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace interfaceExample
{
    public partial class index : System.Web.UI.Page
    {
        interface ITransactions
        {
            void showTransaction();
            double getAmount();
        }

        class Transaction : ITransactions
        {
            private string tCode;
            private string date;
            private double amount;
            public Transaction()
            {
                tCode = " ";
                date = " ";
                amount = 0.0;
            }
            public Transaction(string c, string d, double a)
            {
                tCode = c;
                date = d;
                amount = a;
            }
            public double getAmount()
            {
                return amount;
            }
            public void showTransaction()
            {
                HttpContext.Current.Response.Write(string.Format("Transaction: {0}<br/>", tCode));
                HttpContext.Current.Response.Write(string.Format("Date: {0}<br/>", date));
                HttpContext.Current.Response.Write(string.Format("Amount: {0}<br/>", getAmount()));
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Transaction t1 = new Transaction("001", "8/10/2014", 78900.00);
            Transaction t2 = new Transaction("002", "9/10/2014", 451900.00);
            t1.showTransaction();
            t2.showTransaction();
        }
    }
}