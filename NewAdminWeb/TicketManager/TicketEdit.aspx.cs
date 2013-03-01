using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using BLL;
using Model;
using FineUI;

public partial class TicketManager_TicketEdit : System.Web.UI.Page
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
        //hlUnionTicket.Visible = !isUnionTicket;

        tbxBeginDate.Text = CurrentTicket.BeginDate.ToString("yyyy-MM-dd");
        tbxEndDate.Text = CurrentTicket.EndDate.ToString("yyyy-MM-dd");
        tbxName.Text = CurrentTicket.Name;
        //tbxOrder.Text = CurrentTicket.OrderNumber.ToString();
        tbxOwner.Text = CurrentTicket.Scenic.Name;
        tbxPriceNormal.Text = CurrentTicket.GetPrice(PriceType.Normal).ToString("0");
        tbxPricePayOnline.Text = CurrentTicket.GetPrice(PriceType.PayOnline).ToString("0");
        tbxPricePreOrder.Text = CurrentTicket.GetPrice(PriceType.PreOrder).ToString("0");
        cbxIsMain.Checked = CurrentTicket.IsMain;
        cbxLock.Checked = CurrentTicket.Lock;
        tbxProductCode.Text = CurrentTicket.ProductCode;
        //tbxRemark.Text = CurrentTicket.Remark;
        if (CurrentTicket.TourActivity != null)
        {
            hlActivity.Text = CurrentTicket.TourActivity.Name;
            hlActivity.NavigateUrl = "~/Manager/TourActivity/activityDetail.aspx?actId=" + CurrentTicket.TourActivity.Id;
        }
        if (CurrentTicket is TicketUnion)
        {
            //rptTicket.DataSource = ((TicketUnion)CurrentTicket).TicketList;
            TicketTabStrip.Tabs[1].Visible = true;

        }
        if (CurrentTicket is TicketNormal)
        {
            TicketNormal t = (TicketNormal)CurrentTicket;
            if (t.TicketUnion != null)
            {
                hlUnionTicket.Text = t.TicketUnion.Name;
                hlUnionTicket.NavigateUrl = "TicketEdit2.aspx?id=" + t.Id;
            }
            TicketTabStrip.Tabs[1].Visible = false;
        }
        //绑定联票信息
        if (CurrentTicket.GetType() == typeof(TicketUnion))
        {
            bindTicketUnion();
            bindAllTicket();
        }
    }

    private bool UpdateForm(Ticket ticket)
    {
        ticket.IsMain = cbxIsMain.Checked;
        ticket.BeginDate = Convert.ToDateTime(tbxBeginDate.Text);
        ticket.EndDate = Convert.ToDateTime(tbxEndDate.Text);
        ticket.Lock = cbxLock.Checked;
        ticket.Name = tbxName.Text;
        //ticket.OrderNumber = Convert.ToDecimal(tbxOrder.Text);
        ticket.ProductCode = tbxProductCode.Text;
        //ticket.Remark = tbxRemark.Text;

        DJ_TourEnterprise ent = bllEnterprise.GetEntByName(tbxOwner.Text);
        if (ent == null) return false;
        ticket.Scenic = ent;

        //价格 以后把价格类型改成字典表
        IList<TicketPrice> tpList = ticket.TicketPrice;
        if (tpList == null || tpList.Count == 0)
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
            Alert.ShowInTop("景区名称无效", MessageBoxIcon.Error);
        }
        else
        {
            bllTicket.SaveOrUpdateTicket(CurrentTicket);
            string returlUrl = string.Empty;
            if (IsNew)
            {
                returlUrl = "TicketEdit.aspx?id=" + CurrentTicket.Id;
                Alert.ShowInTop("保存成功", "信息", "window.location='/TicketManager/" + returlUrl + "'");
            }
            else
            {
                Alert.ShowInTop("保存成功", MessageBoxIcon.Information);
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
    }

    protected void gridTicketList_RowCommand(object sender, FineUI.GridCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int ticketid = Convert.ToInt32(gridTicketList.DataKeys[e.RowIndex][0]);
            Ticket childT = bllTicket.GetTicket(ticketid);
            (CurrentTicket as TicketUnion).TicketList.Remove(childT);
            bllTicket.SaveOrUpdateTicket(CurrentTicket);
            bindTicketUnion();
            //   bllScenicTicket.Delete(scenicId, ticketId);
        }
    }

    private void bindTicketUnion()
    {
        gridTicketList.DataSource = (CurrentTicket as TicketUnion).TicketList;
        gridTicketList.DataBind();
    }

    private void bindAllTicket()
    {
        gridAllTicket.DataSource= bllTicket.GetAll<Ticket>().Where(x => x.Name.Contains(tbxKeyword.Text)).ToList();
        gridAllTicket.DataBind();
    }

    protected void gridAllTicket_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        gridAllTicket.PageIndex = e.NewPageIndex;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bindAllTicket();
    }

    protected void gridAllTicket_RowCommand(object sender, FineUI.GridCommandEventArgs e)
    {
        if (e.CommandName == "add")
        {
            int ticketid = Convert.ToInt32(gridAllTicket.DataKeys[e.RowIndex][0]);
            if ((CurrentTicket as TicketUnion).TicketList.Where(x => x.Id == ticketid).Count() > 0)
            {
                Alert.ShowInTop("该套票已经包含此景区的门票,不需要创建", MessageBoxIcon.Information);
            }
            else
            {
                Ticket ticket= bllTicket.GetOne(ticketid);
                ticket.TicketUnion = CurrentTicket as TicketUnion;
                bllTicket.SaveOrUpdate(ticket);
                (CurrentTicket as TicketUnion).TicketList.Add(ticket);
                bindTicketUnion();
            }
        }
    }

    protected void tbxOwner_TriggerClick(object sender, EventArgs e)
    {
        if (Session["OwnerScenic"] == null)
        {
            Session["OwnerScenic"] = "";
        }
        else
        {
            Session["OwnerScenic"] = tbxOwner.Text;
        }
        winScenic.Hidden = false;
        
    }

    protected void winScenic_Close(object sender, EventArgs e)
    {
        tbxOwner.Text = Session["OwnerScenic"].ToString();
    }
}