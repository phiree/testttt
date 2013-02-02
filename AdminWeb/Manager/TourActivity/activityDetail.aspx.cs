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
}