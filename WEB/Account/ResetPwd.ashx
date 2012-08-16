<%@ WebHandler Language="C#" Class="ResetPwd" %>

using System;
using System.Web;
using BLL;
using Model;
using System.Net.Mail;
using System.Text;
using System.Net;

public class ResetPwd : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string name= context.Request.QueryString["name"];
        BLLMembership bllmember = new BLLMembership();
        TourMembership user = bllmember.GetMember(name);
        if (user == null)
            context.Response.Write("wrong");
        else
        {
            string backurl = "http://www.tourol.cn/Account/BackPwd.aspx?id=" + user.Id + "&pwdcode=" + user.Password;
            TourMembership u = bllmember.GetUserByUserId(user.Id);
            //发送邮件
            string content = "<table><tr><td></td><td style='font-size:14px;'>" + user.Name + "，你好！</td></tr>"
                        + "<tr><td></td><td height='20'>&nbsp;</td>"
                        + "</tr><tr><td></td><td style='font-size:14px;'>点击以下链接并根据页面提示完成密码重设：</td>"
                        + "</tr><tr><td></td><td><a href='" + backurl + "'>" + backurl + "</a></td>"
                        + "</tr><tr><td></td><td style='font-size:14px;color:#999999'>如无法点击，请将链接拷贝到浏览器地址栏中直接访问。</td></tr></table>";
            SendEmail(u.Email, "找回旅游在线密码", content);
            context.Response.Write("true");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }



    /// <summary>
    /// 邮件发送方法
    /// </summary>
    /// <param name="email">email地址</param>
    /// <param name="subject">邮件标题</param>
    /// <param name="content">邮件内容</param>
    /// <returns></returns>
    public static bool SendEmail(string email, string subject, string content)
    {
        string fromSMTP = System.Configuration.ConfigurationManager.AppSettings["FromSMTP"];        //邮件服务器
        string fromEmail = System.Configuration.ConfigurationManager.AppSettings["FromEmail"];      //发送方邮件地址
        string fromEmailPwd = System.Configuration.ConfigurationManager.AppSettings["FromEmailPwd"];//发送方邮件地址密码
        string fromEmailName = System.Configuration.ConfigurationManager.AppSettings["FromName"];   //发送方称呼
        //新建一个MailMessage对象
        MailMessage aMessage = new MailMessage(fromEmail, email, subject, content);
        aMessage.BodyEncoding = Encoding.GetEncoding("gb2312");
        aMessage.IsBodyHtml = true;
        aMessage.Priority = MailPriority.High;
        aMessage.From = new MailAddress(fromEmail, fromEmailName);
        //aMessage.ReplyTo = new MailAddress(fromEmail, fromEmailName); //邮件回复地址
        SmtpClient smtp = new SmtpClient();
        smtp.Host = fromSMTP;
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtp.EnableSsl = false;
        smtp.Credentials = new NetworkCredential(fromEmail, fromEmailPwd); //发邮件的EMIAL和密码
        smtp.Port = 25;
        try
        {
            smtp.Send(aMessage);
            return true;
        }
        catch (Exception ex)
        {
            //return false;
            throw ex;
        }
    }
}
