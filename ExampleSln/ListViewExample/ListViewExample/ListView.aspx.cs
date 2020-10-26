using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//額外
using System.Data;

namespace ListViewExample
{
    public partial class ListView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet cvDS = new DataSet();
            DataTable a = new DataTable();
            a.Columns.Add("International_City_Code", typeof(String));
            a.Columns.Add("DM_URL", typeof(String));
            a.Columns.Add("Input_User", typeof(Int32));
            a.Columns.Add("Input_Name", typeof(String));
            a.Columns.Add("Input_Time", typeof(DateTime));

            a.Rows.Add(
                "HKG",
                "123",
                1,
                "許",
                DateTime.Now
            );

            a.Rows.Add(
                "MFM",
                "456",
                2,
                "陳",
                DateTime.Now
            );

            cvDS.Tables.Add(a);

            ListView1.DataSource = cvDS;
            ListView1.DataBind();
        }

        [System.Web.Services.WebMethod(enableSession: true)]
        public static string PostData(string International_City_Code, string DM_URL, string Input_Name)
        {
            //do something

            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                International_City_Code = International_City_Code,
                DM_URL = DM_URL,
                Input_Name = Input_Name
            });
        }

        protected void DataPager1_PreRender(object sender, EventArgs e)
        {
            // 此分頁功能，不適合用在這範例
            // 此範例全用靜態在前端做處理，連POST資料到DB都是用ajax 傳送到後端
            // 所以不會有刷新頁面的狀況，這時候分頁顯示的東西無法立即做更新
            
            // 但如果傳統的postback新增寫法的話
            // 只需要重新繫結ListView 就好了，已經做好設定了
        }

        #region 請忽略，你要進來也無所謂
        /** 忘記當初要做什用的，但我覺得應該是很白癡的事情
         * 
         * ========== 可能性1. ==========
         * 可能是我想用前端 ajax 後端產生新的資料結構 (但是這個用前端就可以做了)
         * 
         * ========== 可能性2. ==========
         * 要用前端 ajax 取得資料庫資料，再轉成json格式
         * 拋到前端後再做View的處理，但是因為刻 html 我覺得太麻煩了
         * 所以用了ListView 去呈現我要的資料
         */

        [System.Web.Services.WebMethod(enableSession: true)]
        public static Dictionary<string, object> GetData()
        {
            DataTable dt = new DataTable();
            dt.TableName = "mydt";
            dt.Columns.Add("International_City_Code", typeof(string));
            dt.Columns.Add("DM_URL", typeof(int));
            dt.Columns.Add("Input_User", typeof(string));
            dt.Columns.Add("Input_Name", typeof(string));
            dt.Columns.Add("Input_Time", typeof(string));

            for ( int i = 0; i < 2; i++ )
            {
                DataRow dr = dt.NewRow();
                dr["International_City_Code"] = "HKG";
                dr["DM_URL"] = i;
                dr["Input_User"] = "";
                dr["Input_Name"] = "";
                dr["Input_Time"] = DateTime.Now.ToString("yyyy/MM/dd");
                dt.Rows.Add(dr);
            }
            return ToJson(dt);
        }

        private static Dictionary<string, object> ToJson(DataTable table)
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add(table.TableName, RowsToDictionary(table));
            return d;
        }

        private static List<Dictionary<string, object>> RowsToDictionary(DataTable table)
        {
            List<Dictionary<string, object>> objs = new List<Dictionary<string, object>>();
            foreach ( DataRow dr in table.Rows )
            {
                Dictionary<string, object> drow = new Dictionary<string, object>();
                for ( int i = 0; i < table.Columns.Count; i++ )
                {
                    drow.Add(table.Columns[i].ColumnName, dr[i]);
                }
                objs.Add(drow);
            }
            return objs;
        }

        #endregion
    }
}