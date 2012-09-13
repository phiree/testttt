<%@ WebHandler Language="C#" Class="RegistHandler" %>

using System;
using System.Web;

public class RegistHandler : IHttpHandler {

    BLL.BLLMembership bllMember = new BLL.BLLMembership();
    
    public void ProcessRequest (HttpContext context) {

        string username = context.Request["phone"];
        //根据后两位的平方生成的密码
        string password = Math.Pow(double.Parse(username.Substring(username.Length - 2, 2)), 2).ToString("D5");
        string email = "";
        Model.TourMembership isexist = bllMember.GetMember(username);
        if (isexist != null)
        {
            context.Response.Write("该用户名已注册，请直接登录。");
            return;
        }
        bllMember.CreateUser(username, string.Empty, string.Empty,
        string.Empty, username, password, email);
        context.Response.Write("该用户名已注册，请直接登录。");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}