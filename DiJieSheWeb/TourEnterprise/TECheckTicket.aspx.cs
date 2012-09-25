using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Web.UI.HtmlControls;

public partial class TourEnterprise_TECheckTicket : System.Web.UI.Page
{
    public BLLDJTourGroup blldjtourgroup = new BLLDJTourGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    private void bind()
    {
        string[] strinfos= txtTE_info.Text.Trim().Split('/');
        string idcard = strinfos[0];
        rptTourGroupInfo.DataSource = blldjtourgroup.GetTourGroupByGuideIdcard(idcard);
        rptTourGroupInfo.DataBind();
        if (rptTourGroupInfo.Items.Count > 0)
        {
            HtmlInputRadioButton hirb = rptTourGroupInfo.Items[0].FindControl("rdoSelect") as HtmlInputRadioButton;
            hirb.Checked = true;
        }
    }


    protected void rptTourGroupInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DJ_TourGroup dj_tourgroup = e.Item.DataItem as DJ_TourGroup;
            Literal laGuideName = e.Item.FindControl("laGuideName") as Literal;
            laGuideName.Text = dj_tourgroup.GuideName;
            Literal laEnterpriceName = e.Item.FindControl("laEnterpriceName") as Literal;
            laEnterpriceName.Text = dj_tourgroup.DJ_DijiesheInfo.Name;
            Literal laGroupName = e.Item.FindControl("laGroupName") as Literal;
            laGroupName.Text = dj_tourgroup.Name;
            Literal laAdultAmount = e.Item.FindControl("laAdultAmount") as Literal;
            laAdultAmount.Text = dj_tourgroup.AdultsAmount.ToString();
            Literal laChildrenAmount = e.Item.FindControl("laChildrenAmount") as Literal;
        }
    }
}