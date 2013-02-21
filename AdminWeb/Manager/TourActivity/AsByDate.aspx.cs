using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class Manager_TourActivity_AsByDate : System.Web.UI.Page
{
    BLLTourActivity bllTa = new BLLTourActivity();
    BLLOrderDetail bllOd = new BLLOrderDetail();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindData();
        }
    }

    private void bindData()
    {
        Guid actId = Guid.Parse(Request.QueryString["actId"]);
        TourActivity ta = bllTa.GetOne(actId);
        rptDt.DataSource = ta.Tickets;
        rptDt.DataBind();

    }
    List<int> countSolidList = new List<int>();
    int temp = 0;
    protected void rptDt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Guid actId = Guid.Parse(Request.QueryString["actId"]);
        TourActivity ta = bllTa.GetOne(actId);
        DateTime dt=DateTime.Parse(Request.QueryString["dt"]);
        if (e.Item.ItemType == ListItemType.Header)
        {
            if (ddlType.SelectedValue == "出售数量")
            {
                Literal laPartnerName = e.Item.FindControl("laPartnerName") as Literal;
                foreach (var partner in ta.Partners)
                {
                    countSolidList.Add(0);
                    string tdpartner = "<td>";
                    tdpartner += partner.Name;
                    tdpartner += "</td>";
                    laPartnerName.Text += tdpartner;
                }
                laPartnerName.Text += "<td>总计</td>";
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    countSolidList.Add(0);
                }
                Literal laPartnerName = e.Item.FindControl("laPartnerName") as Literal;
                laPartnerName.Text = "<td>身份证读卡器</td><td>人工</td><td>手机</td><td>总计</td>";
            }
            
        }
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Literal laCountName = e.Item.FindControl("laCountName") as Literal;
            Ticket t = e.Item.DataItem as Ticket;
            int solidAmount = 0;
            if (ddlType.SelectedValue == "出售数量")
            {
                temp = 0;
                foreach (var partner in ta.Partners)
                {
                    ActivityTicketAssign ata = ta.GetActivityAssignForPartnerTicketDate(partner.PartnerCode, t.ProductCode, dt);
                    if (ata == null)
                        ata = new ActivityTicketAssign();
                    solidAmount += ata.SoldAmount;
                    countSolidList[temp++] += ata.SoldAmount;
                    laCountName.Text += "<td>" + ata.SoldAmount + "</td>";
                }
                laCountName.Text += "<td>" + solidAmount.ToString() + "</td>";
            }
            else
            {
                //List<OrderDetail> listOd = bllOd.GetUsedOrderDetailForIdcardInActivity(ta.ActivityCode).ToList();
                Literal laCheckAmount = e.Item.FindControl("laCountName") as Literal;
                int checkAmount = 0;
                List<TicketAssign> listTa=bllOd.GetTaForIdCardInActivity(ta.ActivityCode,dt).ToList();
                string[] str=new string[3]{"身份证读卡器","人工","手工"};
                temp = 0;
                foreach (var s in str)
	            {
                    checkAmount = listTa.Where(x => x.OrderDetail.TicketPrice.Ticket.Id == t.Id).Where(x => x.checkType == s).Count();
                    laCheckAmount.Text += "<td>" + checkAmount.ToString() + "</td>";
                    countSolidList[temp++]+= checkAmount;
	            }
                laCheckAmount.Text += "<td>" + listTa.Where(x => x.OrderDetail.TicketPrice.Ticket.Id == t.Id).Count().ToString() + "</td>";
                countSolidList[temp++]+=listTa.Where(x => x.OrderDetail.TicketPrice.Ticket.Id == t.Id).Count();
               
                
                //laCheckAmount.Text = checkAmount.ToString();
            }
        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            if (ddlType.SelectedValue == "出售数量")
            {
                Literal laTotal = e.Item.FindControl("laTotal") as Literal;
                int tt = 0;
                foreach (int solid in countSolidList)
                {
                    tt += solid;
                    laTotal.Text += "<td>" + solid.ToString() + "</td>";
                }
                laTotal.Text += "<td>" + tt.ToString() + "</td>";
            }
            else
            {
                Literal laTotal = e.Item.FindControl("laTotal") as Literal;

                foreach (var countSolid in countSolidList)
                {
                    laTotal.Text += "<td>" + countSolid.ToString() + "</td>";
                }
            }
        }
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindData();
    }
}