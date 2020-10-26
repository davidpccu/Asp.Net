using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fullCalendar.js
{
    /// <summary>
    /// handleCalendar 的摘要描述
    /// </summary>
    public class handleCalendar : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            IList<CalendarDTO> tasksList = new List<CalendarDTO>();

            tasksList.Add(new CalendarDTO
            {
                id = 1,
                title = "Google search",
                start = DateTime.Now,
                end = DateTime.Now,
                url = "//www.google.com"
            });
            tasksList.Add(new CalendarDTO
            {
                id = 1,
                title = "Bing search",
                start = DateTime.Now.AddDays(1),
                end = DateTime.Now.AddDays(1),
                url = "//www.bing.com"
            });
            System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
             new System.Web.Script.Serialization.JavaScriptSerializer();
            string sJSON = oSerializer.Serialize(tasksList);
            context.Response.Write(sJSON);
        }

        public class CalendarDTO
        {
            public int id { get; set; }
            public string title { get; set; }
            public DateTime start { get; set; }
            public DateTime end { get; set; }
            public string url { get; set; }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}