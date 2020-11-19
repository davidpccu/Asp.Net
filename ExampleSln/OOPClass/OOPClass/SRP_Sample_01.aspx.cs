using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OOPClass
{
    public partial class SRP : System.Web.UI.Page
    {
        public List<Product> myProduct = new List<Product>();
        public Customer myCustomer { get; set; }
        public SRP() { }

        // SRP 單一責任原則練習
        protected void Page_Load(object sender, EventArgs e)
        {
            // OrderManager
            myProduct.Add(new Product(0, "Tset"));

            myCustomer = new Customer();
            myCustomer.cvUserId = "1234";
            myCustomer.cvUserName = "Owen";

            new Stock().CheckAvailability(myProduct);           //檢查商品庫存
            new Payment().Processing(myCustomer, myProduct);    //進行付款
            new Shipment().SendProduct(myCustomer, myProduct);  //進行送貨處理
        }

        #region SRP 單一責任原則

        public class Product
        {
            public int ProductId { get; set; } // 屬性(Properties)
            public string ProductName { get; set; }

            public Product(int Product_Id, string Product_Name)
            {
                ProductId = Product_Id;
                ProductName = Product_Name;
            }
        }

        public class Customer
        {
            #region Field 宣告

            private string _cvUserId = "";

            private string _cvUserName = "";


            #endregion

            #region Public Properties 設定

            public string cvUserId
            {
                get { return this._cvUserId; }
                set { this._cvUserId = value; }
            }

            public string cvUserName
            {
                get { return this._cvUserName; }
                set { this._cvUserName = value; }
            }

            #endregion
        }

        public class Stock
        {
            public void CheckAvailability(IEnumerable<Product> products) { }
        }

        public class Payment
        {
            public void Processing(Customer customers, IEnumerable<Product> products) { }
        }

        public class Shipment
        {
            public void SendProduct(Customer customers, IEnumerable<Product> products) { }
        }

        #endregion
    }
}