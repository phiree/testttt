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
            Amount.Text = amount.ToString();
        }
    }
}