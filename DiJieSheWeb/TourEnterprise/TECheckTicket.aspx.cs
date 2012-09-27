using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

public partial class TourEnterprise_TECheckTicket : System.Web.UI.Page
{
    BLLDJTourGroup blldjtourgroup = new BLLDJTourGroup();
    BLLDJConsumRecord blldjcr = new BLLDJConsumRecord();
    BLLDJRoute blldjroute = new BLLDJRoute();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            init();
        }
    }

    private void init()
    {
        detailinfo.Visible = false;
        rptGroupList.DataSource = blldjtourgroup.GetTourGroupByTEId(Master.CurrentTE.Id);
        rptGroupList.DataBind();
    }


    private void bind()
    {
        if (txtTE_info.Text.Trim() != "")
        {
            string[] strinfos = txtTE_info.Text.Trim().Split('/');
            string idcard = strinfos[0];
            ViewState["idcard"] = idcard;
            BindRptByIdcard(idcard);
        }
        else
        {
            ScriptManager.RegisterStartupScript(txtTE_info, txtTE_info.GetType(), "s", "alert('无此导游身份证信息')", true);
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
            laChildrenAmount.Text = dj_tourgroup.ChildrenAmount.ToString();
            Repeater rptRoute = e.Item.FindControl("rptRoute") as Repeater;
            rptRoute.ItemDataBound += new RepeaterItemEventHandler(rptRoute_ItemDataBound);
            rptRoute.DataSource = dj_tourgroup.DJ_Product.Routes;
            rptRoute.DataBind();
        }
    }

    protected void txtTE_info_Click(object sender, EventArgs e)
    {
        bind();
    }

    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem rptitem in rptTourGroupInfo.Items)
        {
            HtmlInputRadioButton hirb = rptitem.FindControl("rdoSelect") as HtmlInputRadioButton;
            if (hirb.Checked)
            {
                HiddenField hfGroupId = rptitem.FindControl("hfGroupId") as HiddenField;
                DJ_TourGroup group = blldjtourgroup.GetTourGroupById(Guid.Parse(hfGroupId.Value));
                TextBox tbAdultAmount = rptitem.FindControl("txtAdultsAmount") as TextBox;
                TextBox tbChildAmount = rptitem.FindControl("txtChildrenAmount") as TextBox;
                Repeater rptRoute = rptitem.FindControl("rptRoute") as Repeater;
                tbAdultAmount.Text = Regex.Replace(tbAdultAmount.Text, "[^0-9]", "");
                tbChildAmount.Text = Regex.Replace(tbChildAmount.Text, "[^0-9]", "");
                int IsHaveSelect = 0;
                foreach (RepeaterItem routeitem in rptRoute.Items)
                {
                    CheckBox cbSelect = routeitem.FindControl("ChSelect") as CheckBox;
                    if (cbSelect.Enabled && cbSelect.Checked)
                    {
                        if (Verify(tbAdultAmount.Text, tbChildAmount.Text))
                        {
                            HiddenField hfRouteId = routeitem.FindControl("hfRouteId") as HiddenField;
                            DJ_Route route = blldjroute.GetById(Guid.Parse(hfRouteId.Value));
                            blldjcr.Save(Master.CurrentTE, route, DateTime.Now, int.Parse(tbAdultAmount.Text), int.Parse(tbChildAmount.Text));
                            ScriptManager.RegisterStartupScript(btnCheckOut, btnCheckOut.GetType(), "s", "alert('验证成功!')", true);
                            BindRptByIdcard(ViewState["idcard"].ToString());
                            return;
                        }
                    }
                    if (cbSelect.Enabled && !cbSelect.Checked)
                    {
                        IsHaveSelect = 1;
                    }
                }
                if (IsHaveSelect == 0)
                {
                    ScriptManager.RegisterStartupScript(btnCheckOut, btnCheckOut.GetType(), "s", "alert('都已验证成功，没有需要验证的行程!')", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnCheckOut, btnCheckOut.GetType(), "s", "alert('请选择一个行程!')", true);
                    return;
                }
            }

        }
    }

    private bool Verify(string adultamout, string childrenamout)
    {
        if (adultamout == "" || childrenamout == "")
        {
            ScriptManager.RegisterStartupScript(btnCheckOut, btnCheckOut.GetType(), "s", "alert('成人或者儿童数量不能为空，请重新填写')", true);
            return false;
        }
        return true;
    }

    /// <summary>
    /// 根据省份证号绑定数据
    /// </summary>
    /// <param name="idcard"></param>
    private void BindRptByIdcard(string idcard)
    {
        rptTourGroupInfo.DataSource = blldjtourgroup.GetTourGroupByGuideIdcard(idcard);
        rptTourGroupInfo.DataBind();
        if (rptTourGroupInfo.Items.Count > 0)
        {
            HtmlInputRadioButton hirb = rptTourGroupInfo.Items[0].FindControl("rdoSelect") as HtmlInputRadioButton;
            hirb.Checked = true;
            detailinfo.Visible = true;
        }
        else
        {
            detailinfo.Visible = false;
            ScriptManager.RegisterStartupScript(txtTE_info, txtTE_info.GetType(), "s", "alert('无此导游身份证信息')", true);
        }
    }

    protected void btnBind_Click(object sender, EventArgs e)
    {
        string idcard = hfidcard.Value;
        ViewState["idcard"] = idcard;
        if (!string.IsNullOrEmpty(idcard))
        {
            BindRptByIdcard(idcard);
        }
        else
        {
            ScriptManager.RegisterStartupScript(txtTE_info, txtTE_info.GetType(), "s", "alert('无此导游身份证信息')", true);
        }
    }

    protected void rptRoute_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DJ_Route route = e.Item.DataItem as DJ_Route;
            CheckBox cbSelect = e.Item.FindControl("ChSelect") as CheckBox;
            Literal LaIsCheck = e.Item.FindControl("LaIsCheck") as Literal;
            DJ_GroupConsumRecord gcr = blldjcr.GetGroupConsumRecordByRouteId(route.Id);
            if (gcr != null)
            {
                cbSelect.Checked = true;
                cbSelect.Enabled = false;
                LaIsCheck.Text = "已验证";
            }
            else
            {
                LaIsCheck.Text = "未验证";
            }
        }
    }
}