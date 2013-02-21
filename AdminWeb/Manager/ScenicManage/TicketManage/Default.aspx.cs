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
    string sessionName = "ownerlist";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           BindList(
                
                );
        }

    }
  
    private void BindList()
    {
        rptOwnerList.DataSource = bllEnt.GetDjs8all().Where(x => x.Tickets.Count > 0 && x.Name.Contains(tbxKeyWords.Text));
        rptOwnerList.ItemDataBound += new RepeaterItemEventHandler(rptOwnerList_ItemDataBound);
        rptOwnerList.DataBind();
    }
    protected void rptTicket_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        Ticket t = bllTicket.GetTicket(Convert.ToInt32(e.CommandArgument));
        if (e.CommandName.ToLower() == "disable")
        {
        
          t.Enabled = false;
        }
        if (e.CommandName.ToLower() == "enable")
        {
          
            t.Enabled = true;
        }
        bllTicket.SaveOrUpdateTicket(t);
        
        BindList();

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        
        BindList();
    }
    private void SaveListToSession(IList<DJ_TourEnterprise> ownerList)
    {
      
        if (Session[sessionName] == null)
        {
            Session.Add(sessionName, ownerList);
        }
        else
        {
            Session[sessionName] = ownerList;
        }
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