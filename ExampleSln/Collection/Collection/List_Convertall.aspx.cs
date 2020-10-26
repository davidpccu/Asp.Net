using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Collection
{
    public partial class List_Convertall : System.Web.UI.Page
    {
        public static string TransToString(int i) 
        {
            return i.ToString();
        }

        public class BmiModel 
        {
            public double weight;
            public double height;
            public double BMI;
        }

        public static BmiModel CalculateBMI (BmiModel model) 
        {
            //體重(公斤) / 身高2
            model.BMI = (model.weight) / (model.height * model.height);
            return model;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // 這個語法可以將Array或者是List<object>來進行轉型

            // List<int> -> List<string>
            List<int> myInt = new List<int>() { 100, 200, 300 };
            List<string> myString = myInt.ConvertAll( new Converter<int, string>(TransToString) );

            // List<object> -> List<object>
            List<BmiModel> BodyDetail = new List<BmiModel>() 
            {
                new BmiModel() { weight = 65, height = 175 },
                new BmiModel() { weight = 100, height = 180 }
            };
            BodyDetail = BodyDetail.ConvertAll(new Converter<BmiModel, BmiModel>(CalculateBMI) );
        }
    }
}