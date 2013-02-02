using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommonLibrary;
using System.Configuration;
using Model;
using BLL;
using System.Web.Configuration;
using System.Xml;

public partial class Manager_QuZhouSpring_DateSettings : System.Web.UI.Page
{
    BLLQZTicketAsign bllta = new BLLQZTicketAsign();
    BLLTicket bllTicket = new BLLTicket();
    BLLTicketAssign bllTa = new BLLTicketAssign();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        //从配置文件中读取活动的有限期限
        string quzhouDate = ConfigurationManager.AppSettings["quzhouDate"];
        tbxStart.Text = quzhouDate.Split(',')[0].ToString();
        tbxEnd.Text = quzhouDate.Split(',')[1].ToString();
        rptDateList.DataSource = bllta.GetAllDateTime();
        rptDateList.DataBind();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (tbxStart.Text == "" || tbxEnd.Text == "" || DateTime.Parse(tbxStart.Text) > DateTime.Parse(tbxEnd.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('时间选择不正确')", true);
            return;
        }
        //保存活动有限期限到配置文件
        string config = Server.MapPath("/config/app.config");
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load(config);

        XmlNodeList topM = xmldoc.DocumentElement.ChildNodes;
        foreach (XmlElement element in topM)
        {
            if (element.Attributes["key"].Value == "quzhouDate")
            {
                element.Attributes["value"].Value = tbxStart.Text.Trim()+","+tbxEnd.Text.Trim();
            }
        }
        xmldoc.Save(config);

        string[] ticketId = ConfigurationManager.AppSettings["ticketId"].Split(',');
        List<Ticket> listTicket = new List<Ticket>();
        for (int i = 0; i < ticketId.Length; i++)
        {
            listTicket.Add(bllTicket.GetTicket(int.Parse(ticketId[i])));
        }
        bllta.SaveDate(DateTime.Parse(tbxStart.Text), DateTime.Parse(tbxEnd.Text), listTicket);
        BindData();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('保存成功')", true);
    }




    protected void BindTicketList()
    {

    }

    int total1 = 0, total2 = 0, total3 = 0;
    protected void rptDateList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Literal solidAmount = e.Item.FindControl("solidAmount") as Literal;
            Literal Amount = e.Item.FindControl("Amount") as Literal;
            DateTime dt= (DateTime)e.Item.DataItem;
            int solidamount = 0;
            int amount = 0;
            foreach (var item in bllta.GetQzByDate(dt))
	        {
                solidamount += item.SoldAmount;
                amount += item.Amount;
	        }
            solidAmount.Text = solidamount.ToString();
            total2 += solidamount;
            Amount.Text = amount.ToString();
            total1 += amount;
            Literal laCheckedAmount = e.Item.FindControl("laCheckedAmount") as Literal;
            string ticketList = ConfigurationManager.AppSettings["ticketId"];
            List<Ticket> listTicket = new List<Ticket>();
            foreach (var ticketId in ticketList.Split(','))
            {
                Ticket t=bllTicket.GetTicket(int.Parse(ticketId.ToString()));
                listTicket.Add(t);
            }
            int Count=0;
            foreach (var ticket in listTicket)
            {
                Count += bllTa.GetListByTimeAndScenic(dt, dt.AddDays(1), ticket.Scenic).Count;
            }
            if (solidamount != 0)
                laCheckedAmount.Text = Count.ToString() + "(" + (Count * 100.0 / solidamount).ToString("f2") + "%)";
            else
                laCheckedAmount.Text = Count.ToString();
            total3 += Count;

        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            Literal laTotal = e.Item.FindControl("laTotal") as Literal;
            Literal laTotal2 = e.Item.FindControl("laTotal2") as Literal;
            Literal laTotal3 = e.Item.FindControl("laTotal3") as Literal;
            laTotal.Text = total1.ToString();
            laTotal2.Text = total2.ToString();
            if(total2!=0)
                laTotal3.Text = total3.ToString() + "(" + (total3 * 100.0 / total2).ToString("f2") + "%)";
            else
                laTotal3.Text = total3.ToString();
        }
    }
}