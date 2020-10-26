using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace UsejQuerySubmitJson
{
    /// <summary>
    /// HandleIndex 的摘要描述
    /// </summary>
    public class HandleIndex : IHttpHandler
    {
        public class User
        {
            public string UserName { get; set; }
            public List<string> Skill { get; set; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string array = context.Request.QueryString["array"] ?? string.Empty;
            List<User> _User = JsonConvert.DeserializeObject<List<User>>(array);
            
            // 接下來可做寫入DB的動作....

            /* ajax的dataType為text時，回傳字串型別的資料，不然會失敗 */
            //context.Response.Write("Save!!");

            // 當dataType 是json的話，回傳一個object的資料
            string returnValue = JsonConvert.SerializeObject(_User);
            context.Response.Write(returnValue);
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