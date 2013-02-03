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

    public int ticketId;
    private Ticket CurrentTicket;
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
        bool isUnionTicket = CurrentTicket.GetType() == typeof(TicketUnion);
        rblTicketType.SelectedIndex = isUnionTicket ? 1 : 0;
        tblNormal.Visible = !isUnionTicket;
        tblUnion.Visible = isUnionTicket;
        tbxBeginDate.Text = CurrentTicket.BeginDate.ToShortDateString();
        tbxEndDate.Text = CurrentTicket.EndDate.ToShortDateString();
        tbxName.Text = CurrentTicket.Name;
        tbxOrder.Text = CurrentTicket.OrderNumber.ToString();
        tbxOwner.Text = CurrentTicket.Scenic.Name;
        tbxPriceNormal.Text = CurrentTicket.GetPrice(PriceType.Normal).ToString("0");
        tbxPricePayOnline.Text = CurrentTicket.GetPrice(PriceType.PayOnline).ToString("0");
        tbxPricePreOrder.Text = CurrentTicket.GetPrice(PriceType.PreOrder).ToString("0");
        cbxIsMain.Checked = CurrentTicket.IsMain;
        cbxLock.Checked = CurrentTicket.Lock;
        tbxProductCode.Text = CurrentTicket.ProductCode;
        tbxRemark.Text = CurrentTicket.Remark;
        if (CurrentTicket.TourActivity != null)
        {
            hlActivity.Text = CurrentTicket.TourActivity.Name;
            hlActivity.NavigateUrl = "~/Manager/TourActivity/activityDetail.aspx?actId="+CurrentTicket.TourActivity.Id;
        }
        if (CurrentTicket is TicketUnion)
        {
            rptTicket.DataSource = ((TicketUnion)CurrentTicket).TicketList;
        }
        if (CurrentTicket is TicketNormal)
        {
            TicketNormal t = (TicketNormal)CurrentTicket;
            if (t.TicketUnion != null)
            {
                hlUnionTicket.Text = t.TicketUnion.Name;
                hlUnionTicket.NavigateUrl = "TicketEdit2.aspx?id=" + t.Id;
            }
        }
    }

    private bool UpdateForm(Ticket ticket)
    {
        ticket.IsMain = cbxIsMain.Checked;
        ticket.BeginDate = Convert.ToDateTime(tbxBeginDate.Text);
        ticket.EndDate = Convert.ToDateTime(tbxEndDate.Text);
        ticket.Lock = cbxLock.Checked;
        ticket.Name = tbxName.Text;
        ticket.OrderNumber = Convert.ToDecimal(tbxOrder.Text);
        ticket.ProductCode = tbxProductCode.Text;
        ticket.Remark = tbxRemark.Text;

        DJ_TourEnterprise ent = bllEnterprise.GetEntByName(tbxOwner.Text);
        if (ent == null) return false;
        ticket.Scenic = ent;

        //价格 以后把价格类型改成字典表
          IList<TicketPrice> tpList=ticket.TicketPrice;
          if (tpList.Count==0)
          {
              tpList = new List<TicketPrice>();
              TicketPrice tp1 = new TicketPrice();
              tp1.PriceType = PriceType.Normal;
              tp1.Price = Convert.ToDecimal(tbxPriceNormal.Text);
              tp1.Ticket = ticket;
              tpList.Add(tp1);

              TicketPrice tp2 = new TicketPrice();
              tp2.PriceType = PriceType.PayOnline;
              tp2.Price = Convert.ToDecimal(tbxPricePayOnline.Text);
              tp2.Ticket = ticket;
              tpList.Add(tp2);

              TicketPrice tp3 = new TicketPrice();
              tp3.PriceType = PriceType.PreOrder;
              tp3.Price = Convert.ToDecimal(tbxPricePreOrder.Text);
              tp3.Ticket = ticket;
              tpList.Add(tp3);
              ticket.TicketPrice = tpList;
          }
          else
          {
              tpList[0].Price = Convert.ToDecimal(tbxPriceNormal.Text);
              tpList[1].Price = Convert.ToDecimal(tbxPricePayOnline.Text);
              tpList[2].Price = Convert.ToDecimal(tbxPricePreOrder.Text);
          }
        
       

       
        return true;
    }
    private void Save()
    {
        if (IsNew)
        {
            if (rblTicketType.SelectedIndex == 0)
            {
                CurrentTicket = new TicketNormal();
            }
            else
            {
                CurrentTicket = new TicketUnion();
            }
        }
        if (!UpdateForm(CurrentTicket))
        {
            CommonLibrary.Notification.Show(this, "", "景区名称无效", "");
        }
        else
        {
            bllTicket.SaveOrUpdateTicket(CurrentTicket);
            string returlUrl = string.Empty;
            if (IsNew)
            {
                returlUrl = "TicketEdit2.aspx?id=" + CurrentTicket.Id;
            }
            CommonLibrary.Notification.Show(this, "", "保存成功", returlUrl);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
    }
}