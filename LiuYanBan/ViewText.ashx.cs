using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LiuYanBan
{
    /// <summary>
    /// ViewText 的摘要说明
    /// </summary>
    public class ViewText : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            DataTable table = SqlHelper.ExecuteDataSet("Select * from T_LiuYanBan");
            var data = new { Titel="查看所有留言",Msg=table.Rows};
           string html = CommonHelper.RenderHtml("ViewText.html", data);
           context.Response.Write(html);
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