using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

namespace ListViewExample
{
    public partial class ListView2 : System.Web.UI.Page
    {
        public class cvFile
        {
            public string Hotel_Remark { get; set; }
            public string Input_Name { get; set; }
            public DateTime Input_Time { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ( !IsPostBack )
            { 
                Init_Process();
            }
        }

        private void Init_Process()
        {
            List<cvFile> FileList = new List<cvFile>();

            //塞兩筆假資料
            for ( int i = 0; i < 20; i++ )
            {
                FileList.Add(new cvFile() {
                    Hotel_Remark = i.ToString(),
                    Input_Name = "許X哲",
                    Input_Time = DateTime.Now
                });
            }
            Session["temp"] = FileList;

            ListView1.DataSource = FileList;
            ListView1.DataBind();
        }

        protected void DataPager1_PreRender(object sender, EventArgs e)
        {
            List<cvFile> FileList = (List<cvFile>)Session["temp"];

            ListView1.DataSource = FileList;
            ListView1.DataBind();
        }

        protected string Set_InputTime(DateTime A)
        {
            return A.ToString();
        }

        protected string Set_HotelRemark(string A)
        {
            return A;
        }

        protected string Set_InputName(string A)
        {
            return A;
        }


    }
}