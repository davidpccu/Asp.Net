using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HttpReqRes
{
    public partial class HttpReqRes : System.Web.UI.Page
    {
        HttpWebRequest _req;
        HttpWebResponse _rep;

        protected void Page_Load(object sender, EventArgs e)
        {
            //string url = "http://www.google.com.tw";
            //string url = "http://www.yahoo.com.tw";
            //string url = "https://sofree.cc/css-table/";
            //string url ="https://tw.stock.yahoo.com/q/q?s=2330";
            string url ="https://www.colatour.com.tw/C10P_Package/C10P001_Projects.aspx?Para=*,HKG,2018/02/23,1,0,%E9%A6%99%E6%B8%AF";
            TextBox1.Text = url;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            _req = (HttpWebRequest)HttpWebRequest.Create(TextBox1.Text.Trim());
            _req.Method = WebRequestMethods.Http.Get;
            //_req.Method = "GET";
            ListBox1.Items.Add("用戶實際回應要求的URI:" + _req.Address.ToString());
            ListBox1.Items.Add("是否允許重新導向回應:" + _req.AllowAutoRedirect.ToString());
            ListBox1.Items.Add("是否允許緩衝傳送資料:" + _req.AllowWriteStreamBuffering.ToString());
            ListBox1.Items.Add("用戶端安全性憑證:" + _req.ClientCertificates.ToString());
            if ( _req.Connection != null )
            {
                ListBox1.Items.Add("與伺服端保持持續性的連結至下達close參數為止:" + _req.Connection.ToString());
            }
            if ( _req.ConnectionGroupName != null )
            {
                ListBox1.Items.Add("連結群組名稱:" + _req.ConnectionGroupName.ToString());
            }
            if ( _req.ContentLength != -1 )
            {
                ListBox1.Items.Add("傳送資料內容的大小:" + _req.ContentLength.ToString());
            }
            if ( _req.ContentType != null )
            {
                ListBox1.Items.Add("傳送資料內容的MIME格式:" + _req.ContentType.ToString());
            }
            ListBox1.Items.Add("是否已接收HTTP伺服端的回應:" + _req.HaveResponse.ToString());
            ListBox1.Items.Add("是否已接收HTTP在HTTP請求完成之後，是否關閉與HTTP伺服端之連結:" + _req.KeepAlive.ToString());
            ListBox1.Items.Add("媒體類型:" + _req.MaximumAutomaticRedirections.ToString());
            if ( _req.MediaType != null )
            {
                ListBox1.Items.Add("媒體類型:" + _req.MediaType.ToString());
            }
            ListBox1.Items.Add("通訊協定方法:" + _req.Method.ToString());
            ListBox1.Items.Add("是否要求預先驗證:" + _req.PreAuthenticate.ToString());
            ListBox1.Items.Add("HTTP通訊協定的版本:" + _req.ProtocolVersion.ToString());
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            _req = (HttpWebRequest)HttpWebRequest.Create(TextBox1.Text.Trim());

            ListBox2.Items.Clear();

            _rep = (HttpWebResponse)this._req.GetResponse();
            HttpStatusCode code = _rep.StatusCode;
            int idNumber = (int)code;
            ListBox2.Items.Add("回應的字元編碼格式:" + _rep.CharacterSet.ToString());
            ListBox2.Items.Add("回應的壓縮及編碼格式:" + _rep.CharacterSet.ToString());
            ListBox2.Items.Add("回應資料內容的大小:" + _rep.ContentLength.ToString());
            ListBox2.Items.Add("回應資料內容的MIME格式:" + _rep.ContentType.ToString());
            ListBox2.Items.Add("最近修改回應內容的日期時間:" + this._rep.LastModified.ToString());
            ListBox2.Items.Add("回應通訊協定的版本:" + _rep.ProtocolVersion.ToString());
            ListBox2.Items.Add("伺服端所回應的URI:" + _rep.ResponseUri.ToString());
            ListBox2.Items.Add("傳送回應的伺服器名稱:" + _rep.Server.ToString());
            ListBox2.Items.Add("回應訊息狀態的編碼編號:" + idNumber.ToString());
            ListBox2.Items.Add("回應訊息狀態的編碼狀態:" + _rep.StatusCode.ToString());
            ListBox2.Items.Add("回應訊息狀態的描述:" + _rep.StatusDescription.ToString());
            _rep.Close();
        }

        //取網頁資料
        protected void Button3_Click(object sender, EventArgs e)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(TextBox1.Text.Trim());
            myRequest.Method = "GET";
            HttpWebResponse myResponse = null;
            Stream stream = null;
            StreamReader streamReader = null;

            myResponse = (HttpWebResponse)myRequest.GetResponse();
            if ( myResponse.StatusCode == HttpStatusCode.OK )
            {
                stream = myResponse.GetResponseStream();
                streamReader = new StreamReader(stream, Encoding.GetEncoding("UTF-8"));
                char[] buffer = new char[256];
                int data = 0;
                string result = string.Empty;
                while ( true )
                {
                    data = streamReader.Read(buffer, 0, buffer.Length);
                    string msg = new string(buffer, 0, data);
                    result = result + msg;
                    if ( data == 0 )
                        break;
                }
                TextBox2.Text = result;
            }
        }

        //取網頁資料2
        protected void Button4_Click(object sender, EventArgs e)
        {
            HttpWebRequest myrequest = HttpWebRequest.Create("https://tw.stock.yahoo.com/q/q?s=2330") as HttpWebRequest;
            HttpWebResponse myresponse = myrequest.GetResponse() as HttpWebResponse;
            StreamReader sr = new StreamReader(myresponse.GetResponseStream(), System.Text.Encoding.Default);
            string strContent = sr.ReadToEnd();

            TextBox2.Text = RemoveHTMLTag(strContent);
            sr.Close();
            myrequest = null;
            myresponse = null;
        }

        //移除html tag
        public static string RemoveHTMLTag(string htmlSource) 
        {

            //移除 style code
            htmlSource = Regex.Replace(htmlSource, @"<style[\d\D]*?>[\d\D]*?</style>", string.Empty, RegexOptions.Singleline);

            //移除 javascript code
            htmlSource = Regex.Replace(htmlSource, @"<script[\d\D]*?>[\d\D]*?</script>", string.Empty);

            //移除html tag
            htmlSource = Regex.Replace(htmlSource, @"<[^>]*>", string.Empty);
            return htmlSource;
        }

        //Error
        protected void Button5_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://tw.stock.yahoo.com/q/q?s=2330");
            request.Method = WebRequestMethods.Http.Get;
            request.BeginGetResponse(new AsyncCallback(responseCallback), request);
        }
        //Error
        public void responseCallback(IAsyncResult Result)
        {
            HttpWebRequest request = Result.AsyncState as HttpWebRequest;
            HttpWebResponse response = request.EndGetResponse(Result) as HttpWebResponse;//取得串流資料
            if ( response.StatusCode == HttpStatusCode.OK )
            {
                Stream stream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream);
                char[] buffer = new char[256];
                int data = 0;
                string result = "";
                //分批讀
                while ( true )
                {
                    data = streamReader.Read(buffer, 0, buffer.Length);
                    string msg = new string(buffer, 0, data);
                    result = result + msg;
                    if ( data == 0 )
                        break;
                }
            }
        }


    }
}