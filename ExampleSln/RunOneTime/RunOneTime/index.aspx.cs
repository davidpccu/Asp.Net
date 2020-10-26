using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RunOneTime
{
    public partial class index : System.Web.UI.Page
    {
        /*
         * 防止頁面重覆刷新執行的方法
         */

        protected void Page_Load(object sender, EventArgs e)
        {
            if ( !IsPostBack )
            {
                if ( IsRefresh )
                {
                    string data = Session["actionStamp"].ToString();
                    Response.Write(string.Format("F5 重新整理：{0}<br>", data));
                }
                else
                {
                    string data = Session["actionStamp"].ToString();
                    Response.Write(string.Format("first：{0}<br>", data));
                }
            }
        }

        /// <summary>
        /// 設置戳記
        /// </summary>
        private void SetActionStamp()
        {
            Session["actionStamp"] = Server.UrlEncode(DateTime.Now.ToString());
        }

        /// <summary>
        /// 取得值，指出網頁是否經由重新整理動作回傳 (PostBack)
        /// </summary>
        protected bool IsRefresh
        {
            get
            {
                if ( HttpContext.Current.Request["actionStamp"] as string == Session["actionStamp"] as string )
                {
                    SetActionStamp();
                    return false;
                }

                return true;
            }
        }
    }
}