using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//有額外引用的
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CsharpToJson
{
    public partial class index2 : System.Web.UI.Page
    {
        static string jsonSrc = @"{ 
            ""d"": ""2015-01-01T00:00:00Z"", 
            ""n"": 32767, 
            ""s"": ""darkthread"",
            ""a"": [ 1,2,3,4,5 ]
        }";

        public class foo
        {
            public DateTime d { get; set; }
            public int n { get; set; }
            public string s { get; set; }
            public int[] a { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<h1>反序列化</h1>");
            Func_1();
            Response.Write("<hr/>");
            Func_2();
            Response.Write("<hr/>");
            Func_3();
            Response.Write("<br>");

            Response.Write("<h1>序列化</h1>");
            Func_4();
            Response.Write("<br>");
            Func_5();
            Response.Write("<br>");
            Func_6();
        }

        //反序列化 方法1 定義強型別物件接收資料
        private void Func_1()
        {
            foo f = JsonConvert.DeserializeObject<foo>(jsonSrc);
            Response.Write(string.Format("d:{0}, n:{1}, s:{2}, a:{3}", f.d, f.n, f.s,
                string.Join("/", f.a)));
        }

        //反序列化 方法2 使用JObject、JProperty、JArray、JToken物件
        private void Func_2()
        {
            JObject jo = JObject.Parse(jsonSrc);
            DateTime d = jo.Property("d").Value.Value<DateTime>();
            int n = jo["n"].Value<int>();
            string s = jo["s"].Value<string>();
            int[] ary = jo["a"].Value<JArray>()
                               .Select(o => o.Value<int>()).ToArray();

            Response.Write(string.Format("d:{0}, n:{1}, s:{2}, a:{3}", d, n, s,
                string.Join("/", ary)));
        }

        //反序列化 方法3 使用dynamic
        private void Func_3()
        {
            JObject jo = JObject.Parse(jsonSrc);
            dynamic dyna = jo as dynamic;
            var ary = ((JArray)jo["a"]).Cast<dynamic>().ToArray();
            Response.Write(string.Format("d:{0}, n:{1}, s:{2}, a:{3}", dyna.d, dyna.n, dyna.s,
                string.Join("/", ary)));
        }

        //序列化 方法1 使用強型別
        private void Func_4()
        {
            foo f = new foo()
            {
                d = new DateTime(2015, 1, 1),
                n = 32767,
                s = "darkthread",
                a = new int[] { 1, 2, 3, 4, 5 }
            };
            Response.Write(string.Format("JSON:{0}", JsonConvert.SerializeObject(f)));
        }
 
        //序列化 方法2 使用JObject、JPorperty、JArray
        private void Func_5()
        {
            JObject jo = new JObject();
            jo.Add(new JProperty("d", new DateTime(2015, 1, 1)));
            jo.Add(new JProperty("n", 32767));
            jo.Add(new JProperty("s", "darkthread"));
            jo.Add(new JProperty("a", new JArray(1, 2, 3, 4, 5)));
            Response.Write(string.Format("JSON:{0}", jo.ToString(Formatting.None)));
        }
        //序列化 方法3 使用dynamic
        private void Func_6()
        {
            dynamic dyna = new JObject();
            dyna.d = new DateTime(2015, 1, 1);
            dyna.n = 32767;
            dyna.s = "darkthread";
            dyna.a = new JArray(1, 2, 3, 4, 5);
            Response.Write(string.Format("JSON:{0}", dyna.ToString(Formatting.None)));
        }

    }
}