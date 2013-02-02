using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class Manager_ScenicManage_TicketManage_Default : System.Web.UI.Page
{

    BLLTicket bllTicket = new BLLTicket();
    BLLDJEnterprise bllEnt = new BLLDJEnterprise();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindList(
                 bllEnt.GetDjs8all().Where(x=>x.Tickets.Count>0).ToList()
                );
        }

    }
    private void BindList(IList<DJ_TourEnterprise> ownerList)
    {
        rptOwnerList.DataSource = ownerList;
        rptOwnerList.ItemDataBound += new RepeaterItemEventHandler(rptOwnerList_ItemDataBound);
        rptOwnerList.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        var ownerList = bllEnt.GetListByNameLike(tbxKeyWords.Text.Trim());
        BindList(ownerList);
    }

    void rptOwnerList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rptTicket = e.Item.FindControl("rptTicket") as Repeater;
            var ticketList = ((DJ_TourEnterprise)e.Item.DataItem).Tickets;
            rptTicket.DataSource = ticketList;
            rptTicket.DataBind();
        }
    }
}