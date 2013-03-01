using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using BLL;
using Model;

public partial class ActivityManager_ActivityEdit : System.Web.UI.Page
{
    BLLTourActivity bllTourActivity = new BLLTourActivity();
    BLLActivityPartner bllAp = new BLLActivityPartner();
    BLLActivityTicketAssign BLLAta = new BLLActivityTicketAssign();
    TourActivity ta;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Request.QueryString["actId"] != null)
        {
            Guid actId = Guid.Parse(Request.QueryString["actId"]);
            ta = bllTourActivity.GetOne(actId);
        }
        else
        {
            ta = new TourActivity();
        }
        if (!IsPostBack)
        {
            bindDate();
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        ta.ActivityCode = txtCode.Text;
        ta.AmountPerIdcardInActivity = int.Parse(txtAmountPerIdcardInActivity.Text);
        ta.AmountPerIdcardTicket = int.Parse(txtAmountPerIdcardTicket.Text);
        //ta.AreasBlackList = txtBlack.Text;
        //ta.AreasUseBlackList = ckUseBlackList.Checked;
        //ta.AreasWhiteList = txtWhite.Text;
        ta.BeginDate = DateTime.Parse(txtBeginDate.Text);
        ta.BeginHour = int.Parse(txtBeginHour.Text);
        ta.EndDate = DateTime.Parse(txtEndDate.Text);
        ta.EndHour = int.Parse(txtEndHour.Text);
        ta.Name = txtName.Text;
        //ta.NeedCheckArea = cbxNeedCheckArea.Checked;
        bllTourActivity.SaveOrUpdate(ta);
        string returnUrl="/ActivityManager/ActivityEdit.aspx?actId="+ta.Id;
        Alert.ShowInTop("编辑成功", "信息", "window.location='" + returnUrl + "'");
    }

    private void bindDate()
    {
        if (Request.QueryString["actId"] != null)
        {
            Guid actId = Guid.Parse(Request.QueryString["actId"]);
            TourActivity ta = bllTourActivity.GetOne(actId);
            txtAmountPerIdcardInActivity.Text = ta.AmountPerIdcardInActivity.ToString();
            txtAmountPerIdcardTicket.Text = ta.AmountPerIdcardTicket.ToString();
            txtBeginDate.Text = ta.BeginDate.ToString("yyyy-MM-dd");
            txtBeginHour.Text = ta.BeginHour.ToString();
            //txtBlack.Text = ta.AreasBlackList.ToString();
            //txtWhite.Text = ta.AreasWhiteList.ToString();
            txtCode.Text = ta.ActivityCode.ToString();
            txtEndDate.Text = ta.EndDate.ToString("yyyy-MM-dd");
            txtEndHour.Text = ta.EndHour.ToString();
            txtName.Text = ta.Name;
            //ckUseBlackList.Checked = ta.AreasUseBlackList;
            //cbxNeedCheckArea.Checked = ta.NeedCheckArea;
            bindPartnerList();

        }
        btnAddPartner.OnClientClick = winPartner.GetShowReference("/ActivityManager/Partner_iframe_window.aspx?actId=" + Request.QueryString["actId"], "新增");
        winPartner.OnClientCloseButtonClick = winPartner.GetHidePostBackReference();
    }

    private void bindPartnerList()
    {
        gridPartner.DataSource=ta.Partners;
        gridPartner.DataBind();
    }

    protected void winPartner_Close(object sender, EventArgs e)
    {
        bindPartnerList();
    }

    protected void gridPartner_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        gridPartner.PageIndex = e.NewPageIndex;
    }

    protected void gridPartner_RowCommand(object sender, FineUI.GridCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            Guid paId = Guid.Parse(gridPartner.DataKeys[e.RowIndex][0].ToString());
            List<ActivityTicketAssign> listAta= ta.ActivityTicketAssign.Where(x => x.Partner.Id == paId).ToList();
            foreach (var item in listAta)
            {
                BLLAta.Delete(item);
            }
            bllAp.Delete(bllAp.GetOne(paId));
            bindPartnerList();
        }
    }

    protected void txtTicketId_TriggerClick(object sender, EventArgs e)
    {

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {

    }
}