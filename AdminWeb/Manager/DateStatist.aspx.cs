using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Configuration;

public partial class Manager_DateStatist : System.Web.UI.Page
{
    BLLTicket bllTicket = new BLLTicket();
    BLLTicketAssign bllTa = new BLLTicketAssign();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindData();
        }
    }

    private void bindData()
    {
        string quzhouDate = ConfigurationManager.AppSettings["quzhouDate"];
        string ticket = ConfigurationManager.AppSettings["ticketId"];
        List<Ticket> listTicket = new List<Ticket>();
        foreach (string id in ticket.Split(','))
        {
            listTicket.Add(bllTicket.GetTicket(int.Parse(id)));
        }
        DateTime beginDate = DateTime.Parse(quzhouDate.Split(',')[0]);
        DateTime endDate = DateTime.Parse(quzhouDate.Split(',')[1]);
        List<table> listTable = new List<table>();
        for (int i = 0; beginDate.AddDays(i)<=endDate; i++)
        {
            foreach (Ticket tt in listTicket)
            {
                table tab = new table();
                tab.date = beginDate.AddDays(i);
                tab.ticket = tt;
                //为这次活动特殊判断，以后不能用
                tab.Amount = bllTa.GetListByTimeAndScenic(beginDate.AddDays(i), beginDate.AddDays(i+1), tt.Scenic).Count;
                listTable.Add(tab);
            }
        }
        rptStatis.DataSource = listTable;
        rptStatis.DataBind();

    }
    protected void rptStatis_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            table t = e.Item.DataItem as table;
            if (t.Amount == 0)
            {
                e.Item.Visible = false;
            }
        }
    }
}

public class table
{
    public DateTime date { get; set; }
    public Ticket ticket { get; set; }
    public int Amount { get; set; }
}