using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class ScenicManager_canelTa : bpScenicManager
{
    BLLTicketAssign bllTa = new BLLTicketAssign();
    BLLOrder bllOrder = new BLLOrder();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    private void bind()
    {
        IList<TicketAssign> listTa = bllTa.GetTaByIdcardandscenic(txtIdCard.Text.Trim(),CurrentScenic);
        rptTa.DataSource = listTa;
        rptTa.DataBind();

    }

    protected void rptTa_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "cancel")
        {
            Guid id = Guid.Parse(e.CommandArgument.ToString());
            TicketAssign ta = bllTa.GetOne(id);
            ta.IsUsed = false;
            bllTa.SaveOrUpdate(ta);
            if (ta.OrderDetail.TicketPrice.PriceType == PriceType.PreOrder)
            {
                Order o = ta.OrderDetail.Order;
                o.IsPaid = false;
                bllOrder.SaveOrUpdate(o);
            }
            bind();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bind();
    }
    protected void rptTa_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            TicketAssign ta = e.Item.DataItem as TicketAssign;
            Button btnCancel = e.Item.FindControl("btnCancel") as Button;
            if (!ta.IsUsed)
            {
                btnCancel.Visible = false;
            }
            else
            {
                btnCancel.Visible = true;
            }
        }
    }
}