using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
public partial class Manager_ScenicManage_TicketManage_TicketEdit2 : System.Web.UI.Page
{

    private int ticketId;
    private TicketBase CurrentTicket;
    private bool IsNew = true;
    BLLTicket bllTicket = new BLLTicket();
    BLLDJEnterprise bllEnterprise = new BLLDJEnterprise();
    protected void Page_Load(object sender, EventArgs e)
    {
        //参数判断与处理(考虑用框架处理)
        string paramTicketId = Request["Id"];
        if (!string.IsNullOrEmpty(paramTicketId))
        {
            if (int.TryParse(paramTicketId, out ticketId))
            {
                CurrentTicket = bllTicket.GetTicket(ticketId);
                IsNew = false;
            }
            else
            {
                ErrHandler.Redirect(ErrType.ParamIllegal);
            }

        }

        if (!IsPostBack)
        {
            if (!IsNew)
            {
                LoadForm();
            }
        }
    }

    private void LoadForm()
    {
        tbxBeginDate.Text = CurrentTicket.BeginDate.ToShortDateString();
        tbxEndDate.Text = CurrentTicket.EndDate.ToShortDateString();
        tbxName.Text = CurrentTicket.Name;
        tbxOrder.Text = CurrentTicket.OrderNumber.ToString();
        tbxOwner.Text = CurrentTicket.Scenic.Name;
        rptTicketPrice.DataSource = CurrentTicket.TicketPrice;
        cbxIsMain.Checked = CurrentTicket.IsMain;
        cbxLock.Checked = CurrentTicket.Lock;
        tbxProductCode.Text = CurrentTicket.ProductCode;
        tbxRemark.Text = CurrentTicket.Remark;
        if (CurrentTicket.TourActivity != null)
        {
            hlActivity.Text = CurrentTicket.TourActivity.Name;
            hlActivity.NavigateUrl = "~/Manager/TourActivity/activityDetail.aspx?actId="+CurrentTicket.TourActivity.Id;
        }
        if (CurrentTicket is UnionTicket)
        {
            rptTicket.DataSource = ((UnionTicket)CurrentTicket).TicketList;
        }
        if (CurrentTicket is Ticket)
        {
            Ticket t = (Ticket)CurrentTicket;
            if (t.UnionTicket != null)
            {
                hlUnionTicket.Text = t.UnionTicket.Name;
                hlUnionTicket.NavigateUrl = "TicketEdit2.aspx?id=" + t.Id;
            }
        }
    }

    private void UpdateForm(TicketBase ticket)
    {
        ticket.IsMain = cbxIsMain.Checked;
        ticket.BeginDate = Convert.ToDateTime(tbxBeginDate.Text);
        ticket.EndDate = Convert.ToDateTime(tbxEndDate.Text);
        ticket.Lock = cbxLock.Checked;
        ticket.Name = tbxName.Text;
        ticket.OrderNumber = Convert.ToDecimal(tbxOrder.Text);
        ticket.ProductCode = tbxProductCode.Text;
        ticket.Remark = tbxRemark.Text;
        ticket.Scenic = bllEnterprise.GetEntByName(tbxOwner.Text);
    }
    private void Save()
    {
        if (IsNew)
        {
            if (rblTicketType.SelectedIndex == 0)
            {
                CurrentTicket = new Ticket();
            }
            else
            {
                CurrentTicket = new UnionTicket();
            }
        }
        UpdateForm(CurrentTicket);
        bllTicket.SaveOrUpdateTicket(CurrentTicket);
        string returlUrl = string.Empty;
        if (IsNew)
        {
            returlUrl = "TicketEdit2.aspx?id=" + CurrentTicket.Id;
        }
        CommonLibrary.Notification.Show(this, "", "保存成功", returlUrl);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
    }
}