using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CacheNET
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //(ASP.NET)Cache讓多個網頁和使用者共用資源

            // Create new DataTable and DataSource objects.
            DataTable dt = new DataTable();

            // Declare DataColumn and DataRow variables.
            DataColumn column;
            DataRow row;

            // Create new DataColumn, set DataType, ColumnName and add to DataTable.    
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "id";
            dt.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "item";
            dt.Columns.Add(column);

            // Create new DataRow objects and add to DataTable.    
            for ( int i = 0; i < 10; i++ )
            {
                row = dt.NewRow();
                row["id"] = i;
                row["item"] = "item " + i.ToString();
                dt.Rows.Add(row);
            }

            if ( Cache["Mydt"] == null )
            {
                // 1個小時候會到期
                Cache.Insert("Mydt", dt, null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
                Response.Write("Hello" + DateTime.Now.ToString());

                // 下面的話是用會變動的過期時間來算，就是每當有人存取，過期時間就會從最
                // 後存取的時間開始往後算1小時，如果1小時都不再有人存取這個Cache["Mydt"]的話
                // 就會清掉啦，但是1小時內如果有人存取，就重新開始計算時間
                // Cache.Insert("Mydt", dt, null,System.Web.Caching.Cache.NoAbsoluteExpiration,TimeSpan.FromHours(1))

            }
            else
            {
                // 這邊else是Cache還存在的情況
                Response.Write("World" + DateTime.Now.ToString());
            }


        }
    }
}