using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class Manager_ScenicManage_TicketManage_UnionTicketEdit : System.Web.UI.Page
{
    /// <summary>
    /// 创建/编辑套票信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    int ticketId;
    public TicketUnion CurrentTicket;
    BLLTicket bllTicket = new BLLTicket();
    BLLScenic bllScenic = new BLLScenic();
    BLLDJEnterprise bllEnt = new BLLDJEnterprise();
    protected void Page_Load(object sender, EventArgs e)
    {
        string paramTicketId = Request["ticketid"];
        if (!int.TryParse(paramTicketId, out ticketId))
        {
            ErrHandler.Redirect(ErrType.ParamIllegal);
        }
        CurrentTicket =(TicketUnion) bllTicket.GetTicket(ticketId);

        if (!IsPostBack)
        {
            LoadPrice();
            BindTickets();   
        }

    }
    private void LoadPrice()
    { 
        
    }
    protected void btnSavePrice_Click(object sender, EventArgs e)
    { 
        
    }
    private void BindTickets()
    {
        rptTickets.DataSource = CurrentTicket.TicketList;
        rptTickets.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int total;
      IList<DJ_TourEnterprise> scenics=  bllEnt.GetListByNameLike(tbxKeyword.Text.Trim());
      rptSearchScenics.DataSource = scenics;
      rptSearchScenics.DataBind();
    }
    protected void rptScenics_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "deletescenic")
        { 
          //删除对应关系
            int ticketid = Convert.ToInt32(e.CommandArgument);
            Ticket childT = bllTicket.GetTicket(ticketid);
            CurrentTicket.TicketList.Remove(childT);
            bllTicket.SaveOrUpdateTicket(CurrentTicket);
         //   bllScenicTicket.Delete(scenicId, ticketId);
            BindTickets();
        }
    }
    protected void rptSearchScenics_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "addscenic")
        {

            int scenicId = Convert.ToInt32(e.CommandArgument);
            //为联票创建一张门票
            DJ_TourEnterprise ent = bllEnt.GetOne(scenicId);
            //如果该拥有者已经有一张门票属于该套票 则不做任何操作
            if (CurrentTicket.TicketList.Where(x => x.Scenic.Id == scenicId).Count() > 0)
            {
                CommonLibrary.Notification.Show(this, "", "该套票已经包含此景区的门票,不需要创建", "");
            }
            else
            {
                TicketNormal t = new TicketNormal();
                t.BeginDate = DateTime.Today;
                t.EndDate = DateTime.MaxValue;
                t.IsMain = false;
                t.Lock = true;
                t.Name = CurrentTicket.Name + "-" + ent.Name;
                t.Scenic = ent;
                //获得主票的原价信息,赋值给自动创建的门票
                decimal originalPrice = 0;
                if (ent.Tickets.Count > 0)
                {

                    if (ent.Tickets.Where(x => x.IsMain).Count() > 0)
                    {
                        originalPrice = ent.Tickets.Where(x => x.IsMain).ToList()[0].GetPrice(PriceType.Normal);
                    }
                    else
                    {
                        originalPrice = ent.Tickets[0].GetPrice(PriceType.Normal);
                    }
                }
                IList<TicketPrice> tpList = new List<TicketPrice>();
                TicketPrice tp1 = new TicketPrice();
                tp1.Price = 0;
                tp1.PriceType = PriceType.PayOnline;

                TicketPrice tp2 = new TicketPrice();
                tp2.Price = 0;
                tp2.PriceType = PriceType.PreOrder;

                TicketPrice tp3 = new TicketPrice();
                tp3.Price = originalPrice;
                tp3.PriceType = PriceType.Normal;

                tpList.Add(tp1);
                tpList.Add(tp2);
                tpList.Add(tp3);
                t.TicketPrice = tpList;
                t.TicketUnion = CurrentTicket;
                bllTicket.SaveOrUpdateTicket(t);
            }

            
            BindTickets();
        }
    }
}