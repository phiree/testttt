<%@ WebHandler Language="C#" Class="RegistHandler" %>

using System;
using System.Web;

public class RegistHandler : IHttpHandler
{

    BLL.BLLMembership bllMember = new BLL.BLLMembership();

    public void ProcessRequest(HttpContext context)
    {

        string username = context.Request["phone"];
        string idcard=context.Request["idcard"];
        
        //根据后两位的平方生成的密码
        int temp=Guid.NewGuid().GetHashCode();
        string password = temp.ToString().Substring(temp.ToString().Length - 6, 6);
        string email = "";
        Model.TourMembership isexist = bllMember.GetMember(username);
        if (isexist != null)
        {
            //已经注册的用户  且身份证号码相同(用于排除输错号码的可能)
            if (isexist.IdCard == idcard)
            {
                context.Response.Write(password);
                return;
            }
            else
            {
                context.Response.Write("false");
                return;
            }
        }
        else
        {
            bllMember.CreateUser(username, string.Empty, string.Empty,
            idcard, username, password, email);
            context.Response.Write(password);
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