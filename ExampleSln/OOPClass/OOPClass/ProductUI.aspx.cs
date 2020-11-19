using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OOPClass //namespace
{
    public partial class ProductUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 類別繼承、建構式、多型
            Product myProduct = new Product();
            Product myProduct2 = new Product(20);
            Name myName = new Name();

            Response.Write(myProduct.Write() + "<br>");   // BaseClass-10
            Response.Write(myProduct2.Write() + "<br>");  // BaseClass-20
            Response.Write(myName.Write() + "<br>");      // DerivedClass-IT
            Response.Write(myName.Log() + "<br><br>");    // Log-Test

            Test myTest = new Test(myProduct);
            Response.Write(myTest.Log() + "<br>"); // cvHeaderTemplate

            myProduct.ProductId = 123;
            Test myTest2 = new Test(myProduct);
            Response.Write(myTest2.Log());      // cvHeaderTemplatecvFooterTemplate
        }
    }

    public class Product //基底類別
    {
        private DateTime myDateTime; //欄位(Field)
        private string _cvHeaderTemplate = "";
        private string _cvFooterTemplate = "";
        private string _cvBodyTemplate = "";

        public int ProductId { get; set; } // 屬性(Properties)
        public string ProductName { get; set; }
        public virtual string cvHeaderTemplate { get; set; }
        public virtual string cvFooterTemplate { get; set; }

        public Product() // 預設(無參數)建構式(Constructor)
        {
            this.ProductId = 10;
        }

        public Product(int Product_Id) //建構函式(Constructor)多載(overloading)
        {
            this.ProductId = Product_Id;

            if (Product_Id == 123)
                cvFooterTemplate = "cvFooterTemplate";
        }

        public virtual string Write() // 方法(Method)
        {
            return "BaseClass-" + ProductId;
        }
    }

    public class Name : Product //衍生類別 繼承基底類別
    {
        public string ProductName { get; set; }

        public Name() : base(1) // 呼叫基底類別建構函式
        {
            base.ProductName = "Test"; //設定基底類別屬性
            base.Write(); //執行基底類別方法
 
            this.ProductName = "IT"; //設定衍生類別屬性
            this.Write(); //執行衍生類別方法
        }

        public override string Write() // 複寫方法
        {
            return "DerivedClass-" + ProductName;
        }

        public string Log()
        {
            return "Log-" + base.ProductName;
        }
    }

    public class Test : Product
    {
        public Test(Product Product_Info) : base(Product_Info.ProductId)
        {
            cvHeaderTemplate = "cvHeaderTemplate";
        }

        public string Log()
        {
            return cvHeaderTemplate + cvFooterTemplate;
        }
    }
}