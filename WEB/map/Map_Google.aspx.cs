using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class map_Map_Google : System.Web.UI.Page
{
    BLLMembership bllMember = new BLLMembership();
    public string iconUrl = "";
    public string iconAlt = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.IsAuthenticated)
        {
            TourMembership member = bllMember.GetMember(Page.User.Identity.Name);

            switch (member.Opentype)
            {
                case Opentype.TencentWeibo:
                    iconAlt = "腾讯微博登录";
                    iconUrl = "/img/weiboicon16.png";
                    break;
                case Opentype.Sina: break;
            }

        }
        if (!IsPostBack)
        {
            bind();
        }
    }

    private void bind()
    {
        rptarea.DataSource = new BLLArea().GetArea(33);
        rptarea.DataBind();
        rpttheme.DataSource = new BLLTopic().GetAllTopics();
        rpttheme.DataBind();
    }
    protected void rptarea_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.FindControl("areaname") != null)
        {
            string str = ((System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("areaname"))).InnerHtml;
            str = str.Substring(3);
            if (str.Length > 0)
                str = str.Substring(0, str.Length - 1);
            else
            {
                str = "全部";
            }
            ((System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("areaname"))).InnerHtml = str;
        }
    }
}