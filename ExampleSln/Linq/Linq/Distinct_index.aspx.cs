using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Linq
{
    public partial class Distinct_index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //塞資料
            var datas = new List<Person>();
            int idx = 0;
            for ( idx = 0; idx < 5; ++idx )
            {
                datas.Add(new Person() { ID = idx.ToString(), Name = "SLM" });
            }
            datas.Add(new Person() { ID = idx.ToString(), Name = "FuckSLM" });

            //然後直接用內建的Distinct過濾，發現根本沒用
            var distinctDatas = datas.Distinct();
            ShowDatas(distinctDatas);

            Response.Write("<hr/>");
            var a = datas.Distinct(person => person.Name);
            ShowDatas(a);
        }

        //Person類別
        public struct Person
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return Name;
            }
        }

        //response
        public static void ShowDatas<T>(IEnumerable<T> datas)
        {
            foreach ( var data in datas )
            {
                HttpContext.Current.Response.Write(data.ToString() + "<br>");
            }
        }
    }

    public static class EnumerableExtender
    {
        public static IEnumerable<TSource> Distinct<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach ( TSource element in source )
            {
                var elementValue = keySelector(element);
                if ( seenKeys.Add(elementValue) )
                {
                    yield return element;
                }
            }
        }
    }
}