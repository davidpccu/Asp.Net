using System;
using System.IO;
using System.Net;
using HtmlAgilityPack;
using System.Text;

namespace Stock
{
    public partial class index2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
             * 此範例過期，該網頁結構有所變化，有心的人在幫忙修改此份Code範例
             * 資料來源：http://rate.bot.com.tw/Pages/Static/UIP003.zh-TW.htm
             * 範例網址：https://dotblogs.com.tw/jackbgova/2014/06/11/145488
             * 另外一個：https://dotblogs.com.tw/jackbgova/2014/12/08/147553
             * 
             */

            //指定來源網頁
            WebClient url = new WebClient();
            //將網頁來源資料暫存到記憶體內
            MemoryStream ms = new MemoryStream(url.DownloadData("http://rate.bot.com.tw/Pages/Static/UIP003.zh-TW.htm"));
            //以台灣銀行為範例

            // 使用預設編碼讀入 HTML 
            HtmlDocument doc = new HtmlDocument();
            doc.Load(ms, Encoding.Default);

            //取得現在的日期
            Response.Write("現在時間：" + DateTime.Now + "<br />");
            // 在Html內表示換行

            // 取得匯率 
            for (int x = 3; x <= 21; x++)
            {
                string txt1 = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/ul[1]/li[2]/center[1]/div[1]/div[2]/table[2]/tr[" + x + "]/td[1]").InnerText;
                string txt2 = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/ul[1]/li[2]/center[1]/div[1]/div[2]/table[2]/tr[" + x + "]/td[2]").InnerText;
                string txt3 = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/ul[1]/li[2]/center[1]/div[1]/div[2]/table[2]/tr[" + x + "]/td[3]").InnerText;
                string txt4 = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/ul[1]/li[2]/center[1]/div[1]/div[2]/table[2]/tr[" + x + "]/td[4]").InnerText;
                string txt5 = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/ul[1]/li[2]/center[1]/div[1]/div[2]/table[2]/tr[" + x + "]/td[5]").InnerText;
                string totle = string.Format("幣別：{0} ，買入現金匯率：{1} ，賣出即期匯率：{2} ，買入遠期匯率：{3} ，賣出歷史匯率：{4}", txt1, txt2, txt3, txt4, txt5);
                Response.Write(totle + "<br />");
            }

            //清除資料
            doc = null;
            url = null;
            ms.Close();
        }
    }
}