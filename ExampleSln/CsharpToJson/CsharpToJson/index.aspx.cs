//預設
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//有額外引用的
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
using System.IO;

namespace CsharpToJson
{
    public partial class index : System.Web.UI.Page
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public enum Options
        {
            Option1, Option2
        }

        public class Entity
        {
            public Options A1 { get; set; }

            public Options A2 { get; set; }

            [JsonConverter(typeof(StringEnumConverter))]
            public Options B1 { get; set; }

            [JsonConverter(typeof(StringEnumConverter))]
            public Options B2 { get; set; }

            public string P1 { get; set; }

            [JsonIgnore]
            public string P2 { get; set; }
        }

        [DataContract]
        public class Computer
        {
            // included in JSON
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public decimal SalePrice { get; set; }

            // ignored
            public string Manufacture { get; set; }
            public int StockCount { get; set; }
            public decimal WholeSalePrice { get; set; }
            public DateTime NextShipmentDate { get; set; }
        }

        public class Item 
        {
            public List<string> KeyWords { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //給值
            Person myPerson = new Person();
            myPerson.Name = "Stoenr";
            myPerson.Age = 18;

            //序列化 - using Newtonsoft.Json;
            string output = JsonConvert.SerializeObject(myPerson, Formatting.Indented);
            Response.Write(output);

            //反序列化 - using Newtonsoft.Json;
            Person book2 = JsonConvert.DeserializeObject<Person>(output);
            string output2 = string.Format("<br/>Name：{0}，Age：{1}", book2.Name, book2.Age);
            Response.Write(output2);

            //Json 查詢 - using Newtonsoft.Json.Linq
            JObject myQuery = JsonConvert.DeserializeObject<JObject>(output);
            string output3 = string.Format("<br/>Query：{0}", myQuery.GetValue("Name")); //myQuery["Name"]
            Response.Write(output3);

            //忽略
            Entity myEntity = new Entity()
            {
                A1 = Options.Option1,
                A2 = Options.Option2,
                B1 = Options.Option1,
                B2 = Options.Option2,
                P1 = "P1",
                P2 = "P2"
            };
            string output4 = JsonConvert.SerializeObject(myEntity, Formatting.Indented);
            Response.Write("<br/>" + output4);

            Response.Write("<hr>");
            string str = Server.MapPath(".");
            List<Item> items;
            using ( StreamReader r = new StreamReader(Server.MapPath(".") + "/test.json",System.Text.Encoding.Default) )
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Item>>(json);
            }
            foreach ( Item item in items )
            {
                foreach ( string item2 in item.KeyWords )
                {
                    Response.Write(item2.ToString() + ",");
                }
                    
            }
            Response.Write("<hr>");


            int? x = null;
            // Set y to the value of x if x is NOT null; otherwise,
            // if x = null, set y to -1.
            int y = x ?? -1;
            Response.Write(y.ToString());
        }
    }
}