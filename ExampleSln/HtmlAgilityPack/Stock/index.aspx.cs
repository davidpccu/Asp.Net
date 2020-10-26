using System;
using System.IO;
using System.Net;
using HtmlAgilityPack;
using System.Text;

namespace Stock
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* 
             * =========================================================================
             * 套件名稱 ：Html Agility Pack
             * Nuget下載：https://www.nuget.org/packages/HtmlAgilityPack/ 
             * 相關介紹網址：https://dotblogs.com.tw/jackbgova/2014/06/10/145471
             * =========================================================================
             * 
             * html-agility-pack 這套件在VS2012 無法順利由nuget下載下來，他需要Nuget最低版本是2.12
             * VS2012只支援到2.8.1
             * 參考：https://stackoverflow.com/questions/27384885/how-to-upgrade-nuget-with-visual-studio-express-2012
             * 
             * 參考使用的教學範例
             * http://html-agility-pack.net/ (官方文件)
             * https://msdn.microsoft.com/zh-tw/ee787055.aspx (網友使用範例)
             * 
             */


            //指定來源網頁
            WebClient url = new WebClient();
            //將網頁來源資料暫存到記憶體內
            MemoryStream ms = new MemoryStream(url.DownloadData("http://tw.stock.yahoo.com/q/q?s=1101"));
            //以奇摩股市為例http://tw.stock.yahoo.com
            //1101 表示為股票代碼

            // 使用預設編碼讀入 HTML 
            HtmlDocument doc = new HtmlDocument();
            doc.Load(ms, Encoding.Default);

            // 裝載第一層查詢結果 
            HtmlDocument hdc = new HtmlDocument();

            //XPath 來解讀它 /html[1]/body[1]/center[1]/table[2]/tr[1]/td[1]/table[1] 
            hdc.LoadHtml(doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/center[1]/table[2]/tr[1]/td[1]/table[1]").InnerHtml);

            // 取得個股標頭 
            HtmlNodeCollection htnode = hdc.DocumentNode.SelectNodes("./tr[1]/th");
            // 取得個股數值 
            string[] txt = hdc.DocumentNode.SelectSingleNode("./tr[2]").InnerText.Trim().Split('\n');
            int i = 0;

            // 輸出資料 
            foreach ( HtmlNode nodeHeader in htnode )
            {
                //將 "加到投資組合" 這個字串過濾掉
                Response.Write(nodeHeader.InnerText + ":" + txt[i].Trim().Replace("加到投資組合", "") + "<br/>");
                i++;
            }

            //清除資料
            doc = null;
            hdc = null;
            url = null;
            ms.Close();
        }
    }
}