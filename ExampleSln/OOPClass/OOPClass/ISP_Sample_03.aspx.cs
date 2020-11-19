using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OOPClass
{
    public partial class ISP_Sample_03 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IDatabaseV1 cust = new CustomerWithRead();

            cust.Add();

            cust.Read();
        }

        // Define other methods and classes here

        interface IDatabase
        {
            void Add();  // 原本的 client 只用的到 Add() 的方法而已
        }

        class Customer : IDatabase
        {
            public void Add()
            {
                Console.WriteLine("Add something");
            }
        }

        // --- ISP + OCP ---
        interface IDatabaseV1 : IDatabase // Gets the Add method
        {
            void Read(); // 全新加入的新 client 才會用到 Read() 方法
        }

        class CustomerWithRead : IDatabase, IDatabaseV1
        {
            public void Add()
            {
                Console.WriteLine("Add something");
            }

            public void Read()
            {
                Console.WriteLine("Read something");
            }
        }
    }
}