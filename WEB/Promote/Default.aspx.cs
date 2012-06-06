using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Security;
/// <summary>
/// 处理推广链接.
/// </summary>
public partial class Promote_Default : basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count < 2) return;
        string target = Request.QueryString["target"].ToString();
        
      //  Request.UrlReferrer.AbsoluteUri
        string uid = Request.QueryString["uid"].ToString();
        string urlfrom = GetUrlFrom();
        Session["uid"] = uid;
        Session["urlfrom"] = urlfrom;
        Response.Redirect("../" + target + ".aspx");
    }

    #region method

    private string GetUrlFrom()
    {
        return "tencent";
    }

    /// <summary>
    /// 判断是否已存在用户
    /// </summary>
    /// <returns></returns>
    private bool ValidateCookie()
    {
        bool result = false;
        if (string.IsNullOrWhiteSpace(CurrentUser.UserName))
            result = true;
        return result;
    }

    /// <summary>
    /// 验证url是否可用
    /// </summary>
    /// <returns></returns>
    private bool ValidateUrl()
    {
        bool result = false;
        result = true;
        return result;
    }
    #endregion
}