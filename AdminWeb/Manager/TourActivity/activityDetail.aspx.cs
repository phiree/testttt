using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class Manager_TourActivity_activityDetail : System.Web.UI.Page
{
    BLLTourActivity bllTourActivity = new BLLTourActivity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindDate();
        }
    }

    private void bindDate()
    {
        if (Request.QueryString["actId"] != null)
        {
            string actId = Request.QueryString["actId"];
            TourActivity ta= bllTourActivity.GetOne(actId);
            txtAmountPerIdcardInActivity.Text = ta.AmountPerIdcardInActivity.ToString();
            txtAmountPerIdcardTicket.Text = ta.AmountPerIdcardTicket.ToString();
            txtBeginDate.Text = ta.BeginDate.ToString("yyyy-MM-dd");
            txtBeginHour.Text = ta.BeginHour.ToString();
            txtBlack.Text = ta.AreasBlackList.ToString();
            txtWhite.Text = ta.AreasWhiteList.ToString();
            txtCode.Text = ta.ActivityCode.ToString();
            txtEndDate.Text = ta.EndDate.ToString("yyyy-MM-dd");
            txtEndHour.Text = ta.EndHour.ToString();
            txtName.Text = ta.Name;
            ckIsBuy.Checked = ta.AreasUseBlack;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        TourActivity ta;
        if (Request.QueryString["actId"] != null)
        {
            string actId = Request.QueryString["actId"];
            ta = bllTourActivity.GetOne(actId);
        }
        else
        {
            ta = new TourActivity();
        }
        ta.ActivityCode = txtCode.Text;
        ta.AmountPerIdcardInActivity = int.Parse(txtAmountPerIdcardInActivity.Text);
        ta.AmountPerIdcardTicket = int.Parse(txtAmountPerIdcardTicket.Text);
        ta.AreasBlackList = txtBlack.Text;
        ta.AreasUseBlack = ckIsBuy.Checked;
        ta.AreasWhiteList = txtWhite.Text;
        ta.BeginDate = DateTime.Parse(txtBeginDate.Text);
        ta.BeginHour = int.Parse(txtBeginHour.Text);
        ta.EndDate = DateTime.Parse(txtEndDate.Text);
        ta.EndHour = int.Parse(txtEndHour.Text);
        ta.Name = txtName.Text;
        bllTourActivity.SaveOrUpdate(ta);
    }
}