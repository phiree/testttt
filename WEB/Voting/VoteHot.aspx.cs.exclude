using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Voting_VoteHot : basepage
{
    BLL.BLLVote bllVote = new BLL.BLLVote();
    public string MemberId
    {
        get
        {
            return CurrentUser.ProviderUserKey == null ? "" : CurrentUser.ProviderUserKey.ToString();
        }
        private set { }
    }
    public string Urlfrom
    {
        get
        {
            return Request.UrlReferrer == null ? "" : Request.UrlReferrer.Host;
        }
        private set { }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
            BindHot10();
            BindHotPhoto();
    }

    private void BindHot10()
    {
        rptHot10.DataSource = bllVote.GetScenicsByVote("33");
        rptHot10.DataBind();
    }
    protected void rptHot10_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "link2detail")
        {
            int scenicid = int.Parse(e.CommandArgument.ToString());
            Response.Redirect("../Scenic/?id=" + scenicid);
            return;
        }
    }
    private void BindHotPhoto()
    {
        rptHotPhoto.DataSource = bllVote.GetScenicsByVote("33");
        rptHotPhoto.DataBind();
    }
}