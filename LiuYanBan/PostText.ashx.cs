using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiuYanBan
{
    /// <summary>
    /// PostText 的摘要说明
    /// </summary>
    public class PostText : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string sava = context.Request["Sava"];
            if (string.IsNullOrEmpty(sava))
            {
                //展示
                var titel = new{ titel = "发表留言" };
                string html = CommonHelper.RenderHtml("PostText.html", titel);
                context.Response.Write(html);
            }
            else
            {
                //提交表单
                string nickName = context.Request["NickName"];
                string title = context.Request["Title"];
                string msg = context.Request["Msg"];
                bool isAnonymous = context.Request["IsAnonymous"] == "on";
                string ipAddress = context.Request.UserHostAddress;
              

                SqlHelper.ExecuteNonQuery("Insert into T_LiuYanBan(Titel,Msg,NickName,IsAnonymous,IPAddress,PostDate) values(@Title,@Msg,@NickName,@IsAnonymous,@IPAddress,GetDate())", new SqlParameter("@Title", title), new SqlParameter("@Msg", msg), new SqlParameter("@NickName", nickName), new SqlParameter("@IsAnonymous", isAnonymous), new SqlParameter("@IPAddress", ipAddress));
                context.Response.Redirect("ViewText.ashx");
            }
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