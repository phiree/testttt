using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShowMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int type = int.Parse(Request.QueryString["type"]);
            if (type == 1)
            {
                messtitle.Text = "您还没有登录,请先登录后再注册优惠码,5秒后会自动跳转到登录页面，如果没有跳转请手动点击该地址<a style='color:Blue;' href='Account/Login.aspx'>登录</a>";
            }
            if (type == 2)
            { 
                messtitle.Text = "该优惠码无效,请核对您的优惠码,5秒后会自动跳转到注册优惠码界面，如果没有跳转请手动点击该地址<a style='color:Blue;' href='DiscountCode.aspx'>注册优惠码</a>";
            }
            if (type == 3)
            {
                messtitle.Text = "该优惠码以被注册,5秒后会自动跳转到注册优惠码界面，如果没有跳转请手动点击该地址<a style='color:Blue;' href='DiscountCode.aspx'>注册优惠码</a>";
            }
            if (type == 4)
            {
                messtitle.Text = "该优惠码注册成功，如果没有跳转请手动点击该地址<a style='color:Blue;' href='Default.aspx'>首页</a>";
            }
        }
    }
}