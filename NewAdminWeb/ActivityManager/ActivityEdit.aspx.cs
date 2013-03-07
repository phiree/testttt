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
    BLLTicket bllTicket = new BLLTicket();
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
            bindData();
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

    private void bindData()
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
            bindTicket();
            bindTaDate();
            btnAddPartner.OnClientClick = winPartner.GetShowReference("/ActivityManager/Partner_iframe_window.aspx?actId=" + Request.QueryString["actId"], "新增");
            winPartner.OnClientCloseButtonClick = winPartner.GetHidePostBackReference();
            winTicket.OnClientCloseButtonClick = winTicket.GetHidePostBackReference();
            winTicketEdit.OnClientCloseButtonClick = winTicketEdit.GetHidePostBackReference();
            ActivityTabStrip.Tabs[1].Visible = true;
            ActivityTabStrip.Tabs[2].Visible = true;
            ActivityTabStrip.Tabs[3].Visible = true;
            toolFoot.Hidden=false;
        }
        else
        {
            ActivityTabStrip.Tabs[1].Visible = false;
            ActivityTabStrip.Tabs[2].Visible = false;
            ActivityTabStrip.Tabs[3].Visible = false;
            toolFoot.Hidden=true;
        }
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
            if (DateTime.Now >= ta.BeginDate)
            {
                Alert.ShowInTop("活动已经开始，不能删除该供应商");
                return;
            }
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
        //if (Session["OwnerTicket"]==null)
        Session["OwnerTicket"] = "";
        winTicket.Hidden = false;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtTicketId.Text == "" || Session["OwnerTicket"] == "" || Session["OwnerTicket"] == null)
        {
            Alert.ShowInTop("请选择一个门票");
        }
        else
        {
            int ticketId = int.Parse(Session["OwnerTicket"].ToString().Split(',')[0]);
            if (ta.Tickets.Where(x => x.Id == ticketId).Count() > 0)
            {
                Alert.ShowInTop("该门票已经在该活动之内！", MessageBoxIcon.Information);
            }
            else
            {
                Ticket t = bllTicket.GetTicket(ticketId);
                t.TourActivity = ta;
                bllTicket.SaveOrUpdateTicket(t);
                ta.Tickets.Add(t);
                bindTicket(); 
            }
        }
    }

    private void bindTicket()
    {
        gridTicket.DataSource = ta.Tickets;
        gridTicket.DataBind();
    }
    private void bindTaDate()
    {
        DateTime beginDate = ta.BeginDate;
        DateTime endDate = ta.EndDate;
        List<DateTime> listDate = new List<DateTime>();
        for (int i = 0; beginDate.AddDays(i) <= endDate; i++)
        {
            listDate.Add(beginDate.AddDays(i));
        }
        SaveTicket(beginDate);
        gridDate.DataSource = listDate;
        gridDate.DataBind();
        gridAssign.DataSource = ta.Tickets;
        gridAssign.DataBind();
        
    }
    protected void gridDate_RowClick(object sender, FineUI.GridRowClickEventArgs e)
    {
        DateTime beginDate = ta.BeginDate;
        DateTime endDate = ta.EndDate;
        List<DateTime> listDate = new List<DateTime>();
        for (int i = 0; beginDate.AddDays(i) <= endDate; i++)
        {
            listDate.Add(beginDate.AddDays(i));
        }
        DateTime dt = listDate[e.RowIndex];
        Region2.Title = dt.ToString("yyyy-MM-dd") + "分配情况";
        SaveTicket(dt);
        gridAssign.DataSource = ta.Tickets;
        gridAssign.DataBind();

    }

    private void SaveTicket(DateTime dt)
    {
        foreach (var ticket in ta.Tickets)
        {
            foreach (var pa in ta.Partners)
            {
                if (ta.GetActivityAssignForPartnerTicketDate(pa.PartnerCode, ticket.ProductCode, dt) == null)
                {
                    ActivityTicketAssign ata = new ActivityTicketAssign();
                    ata.DateAssign = dt;
                    ata.Partner = pa;
                    ata.Ticket = ticket;
                    ata.TourActivity = ta;
                    BLLAta.Save(ata);
                    ta.ActivityTicketAssign.Add(ata);
                }
            }
        }
    }
    protected void winTicket_Close(object sender, EventArgs e)
    {
        if (Session["OwnerTicket"]!="")
            txtTicketId.Text = Session["OwnerTicket"].ToString().Split(',')[2] + "-" + Session["OwnerTicket"].ToString().Split(',')[1];
    }
    protected void winTicketEdit_Close(object sender, EventArgs e)
    {
        bindTicket();
    }

    protected void gridTicket_RowCommand(object sender, FineUI.GridCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            if (DateTime.Now >= ta.BeginDate)
            {
                Alert.ShowInTop("活动已经开始，不能删除该门票");
                return;
            }
            int tickedId = int.Parse(gridTicket.DataKeys[e.RowIndex][0].ToString());
            List<ActivityTicketAssign> listAta = ta.ActivityTicketAssign.Where(x => x.Ticket.Id == tickedId).ToList();
            foreach (var item in listAta)
            {
                BLLAta.Delete(item);
            }
            Ticket t=bllTicket.GetOne(tickedId);
            t.TourActivity = null;
            bllTicket.SaveOrUpdate(t);
            bindTicket();
        }
    }

    protected void gridAssign_RowDataBound(object sender, FineUI.GridRowEventArgs e)
    {
        Ticket t = e.DataItem as Ticket;
        if (t != null)
        {
            Repeater rptAssign = gridAssign.Rows[e.RowIndex].FindControl("rptAssign") as Repeater;
            DateTime dt;
            if (gridDate.SelectedRowIndex < 0)
            {
                dt = DateTime.Parse(gridDate.Rows[0].DataItem.ToString());
                Region2.Title = dt.ToString("yyyy-MM-dd") + "分配情况";
            }
            else
                dt = ta.BeginDate.AddDays(gridDate.SelectedRowIndex);
            rptAssign.DataSource = ta.GetActivityAssignForTicketDate(t.ProductCode, dt);
            rptAssign.DataBind();
        }
    }

    protected void btnReturnList_Click(object sender,EventArgs e)
    {
        Response.Redirect("/ActivityManager/ActivityList.aspx");
    }
}