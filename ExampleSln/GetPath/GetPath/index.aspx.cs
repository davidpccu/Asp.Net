using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPath
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //傳回傳遞給方法之虛擬路徑的完整實體路徑
            //傳遞給 MapPath 方法的路徑必須是應用程式的相對路徑，而不是絕對路徑。
            Response.Write("Server.MapPath : " + Server.MapPath("~") + "<br />");

            //抓取 ASP.NET 網頁程式，所在的目錄
            Response.Write("Server.MapPath : " + Server.MapPath(".") + "<br />");

            //取得 asp.net 應用程式在伺服器上虛擬應用程式根路徑
            Response.Write("Request.ApplicationPath : " + Request.ApplicationPath + "<br />");

            //取得目前要求的虛擬路徑
            Response.Write("Request.CurrentExecutionFilePath : " + Request.CurrentExecutionFilePath + "<br />");

            //取得目前要求的虛擬路徑，與 CurrentExecutionFilePath 屬性不同，FilePath 並不會反映伺服器端的傳輸。
            Response.Write("Request.FilePath : " + Request.FilePath + "<br />");

            //取得目前要求的虛擬路徑
            Response.Write("Request.Path : " + Request.Path + "<br />");

            //取得目前執行應用程式之根目錄的實體檔案系統路徑
            Response.Write("Request.PhysicalApplicationPath : " + Request.PhysicalApplicationPath + "<br />");

            //取得與要求的 URL 對應之實體檔案系統路徑
            Response.Write("Request.PhysicalPath : " + Request.PhysicalPath + "<br />");
        }
    }
}