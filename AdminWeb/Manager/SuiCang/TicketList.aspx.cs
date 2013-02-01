using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Model;
using BLL;

public partial class Manager_QuZhouSpring_TicketList : System.Web.UI.Page
{
    BLLTicket bllTicket = new BLLTicket();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        string[] ticketId = ConfigurationManager.AppSettings["ticketId"].Split(',');
        List<Ticket> listTicket = new List<Ticket>();
        for (int i = 0; i < ticketId.Length; i++)
        {
            listTicket.Add(bllTicket.GetTicket(int.Parse(ticketId[i])));
        }
        rptTicketList.DataSource = listTicket;
        rptTicketList.DataBind();
    }

    protected void btnSaveTicket_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in rptTicketList.Items)
        {
            string ticketid = (item.FindControl("hfId") as HiddenField).Value;
            Ticket t = bllTicket.GetTicket(int.Parse(ticketid));
            TextBox tbxProductCode = item.FindControl("tbxProductCode") as TextBox;
            TextBox txtbeginDate = item.FindControl("txtbeginDate") as TextBox;
            TextBox txtendDate = item.FindControl("txtendDate") as TextBox;
            t.ProductCode = tbxProductCode.Text;
            t.BeginDate = DateTime.Parse(txtbeginDate.Text);
            t.EndDate = DateTime.Parse(txtendDate.Text);
            bllTicket.SaveOrUpdateTicket(t);
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('保存成功')", true);
    }
}