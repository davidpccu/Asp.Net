using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OOPClass
{
    // enum 列舉宣告
    public enum MpTicketOrderStatus
    {
        PricingAuto,
        PaymentWarning
    }
    public partial class OrderUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Order myOrder = Order.GetPaymentConditionByCode("21");

            // null 預設值
            if (myOrder == null)
                myOrder = Order.Payment_22_TooManyOrder;

            Response.Write(myOrder.ConditionaName + "-" + myOrder.CurrentTaskDigest + "<br>"); //自動-內容

            Test(new ProductDTO(myOrder));
        }

        private void Test(ProductDTO Order_Calss)
        {
            Response.Write(Order_Calss.Status_No + "-" + Order_Calss.OrderStatus); //0-PricingAuto 
        }
    }

    public class Order
    {
        // 屬性(Properties)
        public int StatusEnum { get; set; }
        public string FlowId { get; set; }
        public string ConditionId { get; set; }
        public string ConditionaName { get; set; }
        public string CurrentTaskDigest { get; set; }

        //建構函式(Constructor)多載(overloading)
        public Order(int Status_Enum, string Flow_Id, string Condition_Id, string Condition_Name)
        {
            StatusEnum        = Status_Enum;
            FlowId            = Flow_Id;
            ConditionId       = Condition_Id;
            ConditionaName    = Condition_Name;
            CurrentTaskDigest = "";
        }
        public Order(int Status_Enum, string Flow_Id, string Condition_Id, string Condition_Name, string Current_Task_Digest)
        {
            StatusEnum        = Status_Enum;
            FlowId            = Flow_Id;
            ConditionId       = Condition_Id;
            ConditionaName    = Condition_Name;
            CurrentTaskDigest = Current_Task_Digest;
        }

        // 靜態方法(Static Method)
        public static Order GetConditionByCode(string Condition_Id)
        {
            Order myCondition = null;

            myCondition = GetPaymentConditionByCode(Condition_Id);

            return myCondition;
        }

        public static Order GetPaymentConditionByCode(string Condition_Id)
        {
            Order myPaymentCondition = null;
            switch (Condition_Id)
            {
                case "21":
                    myPaymentCondition = Payment_21_OverDL;
                    break;
                case "22":
                    myPaymentCondition = Payment_22_TooManyOrder;
                    break;
                default:
                    break;
            }
            return myPaymentCondition;
        }

        public static Order Payment_21_OverDL = new Order((int)MpTicketOrderStatus.PricingAuto, "2", "21", "自動", "內容");
        public static Order Payment_22_TooManyOrder = new Order((int)MpTicketOrderStatus.PaymentWarning, "2", "22", "付款", "內容");

    }

    public class ProductDTO
    {
        // 屬性(Properties)
        public int Status_No { get; set; }
        public string OrderStatus { get; set; }
        public string CurrentFlowId { get; set; }
        public string CurrentTaskId { get; set; }

        //建構函式(Constructor)
        public ProductDTO(Order Order_Class)
        {
            Status_No     = Order_Class.StatusEnum;
            CurrentFlowId = Order_Class.ConditionId;

            switch (Status_No)
            {
                case (int)MpTicketOrderStatus.PricingAuto:
                    OrderStatus = "PricingAuto";
                    CurrentFlowId = "1";
                    CurrentTaskId = "1A";
                    break;
                case (int)MpTicketOrderStatus.PaymentWarning:
                    OrderStatus = "PaymentWarning";
                    CurrentFlowId = "2";
                    CurrentTaskId = "1B";
                    break;
            }
        }
    }
}