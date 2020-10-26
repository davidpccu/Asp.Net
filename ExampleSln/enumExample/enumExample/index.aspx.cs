using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.ComponentModel;
//using System.EnterpriseServices; //不是這個

namespace enumExample
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //經由「列舉值」取得Description之值
            string myPerson = GetDescription(Person.CandyCandy); //糖糖
            Response.Write(myPerson);

            //經由「字串值」取得Description之值
            string myPerson2 = GetDescription(((Person) Enum.Parse(typeof(Person), "HipHopMan"))); //嘻哈俠
            Response.Write(myPerson2);

            //經由「列舉型別的基底型別數值」取得Description之值
            string myPerson3 = GetDescription((Person) Enum.ToObject(typeof(Person), 2)); //台灣女孩
            Response.Write(myPerson3);
        }

        public enum Person : int
        {
            [Description("糖糖")]
            CandyCandy = 0,
            [Description("嘻哈俠")]
            HipHopMan = 1,
            [Description("台灣女孩")]
            TaiwanGirl = 2
        }

        public string GetDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes
                = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}