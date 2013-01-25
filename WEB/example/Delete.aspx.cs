using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class example_Default2 : System.Web.UI.Page
{
    BLLTicketAssign bllTa = new BLLTicketAssign();
    BLLOrder bllOrder = new BLLOrder();
    BLLQZTicketAsign bllQzTa = new BLLQZTicketAsign();
    BLLQZPartnerTicketAsign bllQzPta = new BLLQZPartnerTicketAsign();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }




    private void DeleteMethod()
    {

        //先根据idcard找出ticketAssign
        List<TicketAssign> listTa = bllTa.GetAll<TicketAssign>().ToList();
        //然后找出相应的OrderDetail
        List<OrderDetail> listOrderDetail = new List<OrderDetail>();
        foreach (var ta in listTa)
        {
            listOrderDetail.Add(ta.OrderDetail);
        }
        List<OrderDetail> newListOrderDetail = new List<OrderDetail>();
        //把相同门票的order相应删除
        foreach (var od in listOrderDetail)
        {
            //找出身份证号相同的
            List<OrderDetail> odSameIdCard = newListOrderDetail.Where(x => x.TicketAssignList[0].IdCard == od.TicketAssignList[0].IdCard).ToList();
            //然后再在这个基础上判断门票号是否相同
            if (odSameIdCard.Where(x => x.TicketPrice.Ticket.Id == od.TicketPrice.Ticket.Id).Count() > 0)
            {
                bllOrder.Delete(od.Order);
                ////再把soldAmount加回去
                //QZTicketAsign qzTa= bllQzTa.GetQzByDateAndTicket(DateTime.Parse("2013-01-25"), od.TicketPrice.Ticket.Id)[0];
                //QZPartnerTicketAsign qzPta= qzTa.PartnerTicketAsign.Where(x => x.Partner.FriendlyId == "9c815efa-402a-40ce-860b-c0fa37f707eb").ToList()[0];
                //qzPta.SoldAmount = qzPta.SoldAmount - 1;
                //bllQzPta.SaveOrUpdate(qzPta);
            }
            else
            {
                newListOrderDetail.Add(od);
            }
        }
    }

    protected void btnDelete_OnClick(object sender, EventArgs e)
    {
        DeleteMethod();
    }
}