<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;

public class Handler : IHttpHandler
{

    BLL.BLLMembership bllMembership = new BLL.BLLMembership();
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        if (context.Request.QueryString["openid"] != null)
        {
            string memberName = string.Empty;
            var openid = context.Request.QueryString["openid"];
            Model.TourMembership tm = bllMembership.GetMemberByOpenid(openid, Model.Opentype.TencentWeibo);
            //第1次登录

            if (tm == null)
            //将用户信息加入数据库
            {
                BLL.BLLMembership bllMember = new BLL.BLLMembership();
                BLL.BLLProm bllProm = new BLL.BLLProm();
                try
                {
                    string username = context.Request.QueryString["nickname"];
                    bllMember.CreateUser(username, openid, Model.Opentype.TencentWeibo);
                    memberName = username;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                memberName = tm.Name;
            }
            System.Web.Security.FormsAuthentication.SetAuthCookie(memberName, false);
            context.Response.Redirect("/");
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