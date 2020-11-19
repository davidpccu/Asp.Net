using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OOPClass
{
    public partial class LSP_Sample_02 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* 利用interface實作所需methods
             * Customer繼承這兩個介面
             * Enquiry不繼承Customer，只繼承所需的介面
             * 編譯時期即可看出錯誤(子型別可順利轉換成基底型別)
             */
            List<Customer> Customers = new List<Customer>();
            Customers.Add(new SilverCustomer());
            Customers.Add(new GoldCustomer());
            //Customers.Add(new Enquiry());

            foreach (Customer o in Customers)
            {
                o.Add();
            }
        }

        // Define other methods and classes here
        interface IDiscount
        {
            double getDiscount(double TotalSales);
        }

        interface IDatabase
        {
            void Add();
        }

        class Customer : IDiscount, IDatabase
        {
            public virtual double getDiscount(double TotalSales)
            {
                return TotalSales;
            }

            public virtual void Add()
            {
            }
        }

        class GoldCustomer : Customer
        {
            public override double getDiscount(double TotalSales)
            {
                return base.getDiscount(TotalSales) - 5;
            }

            public override void Add()
            {
                Console.WriteLine("GoldCustomer: Add");
            }
        }

        class SilverCustomer : Customer
        {
            public override double getDiscount(double TotalSales)
            {
                return base.getDiscount(TotalSales) - 5;
            }

            public override void Add()
            {
                Console.WriteLine("SilverCustomer: Add");
            }
        }

        class Enquiry : IDiscount
        {
            public double getDiscount(double TotalSales)
            {
                return TotalSales - 5;
            }
        }
    }
}