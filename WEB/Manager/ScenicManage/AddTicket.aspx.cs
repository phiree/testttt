using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class Manager_ScenicManage_AddTicket : System.Web.UI.Page
{
    int scenicId;
    int ticketId;
    bool isNew;
    public string scenicName = string.Empty;
    BLLScenic bllScenic = new BLLScenic();
    BLLTicket bllTicket = new BLLTicket();
    public Scenic Scenic;
    Ticket CurrentTicket;

    protected void Page_Load(object sender, EventArgs e)
    {
        string paramScenicId = Request["ScenicId"];
        string paramTicketId = Request["ticketId"];

        if (!int.TryParse(paramScenicId, out scenicId))
        {
            BLL.ErrHandler.Redirect(BLL.ErrType.ParamIllegal);
        }

        Scenic = bllScenic.GetScenicById(scenicId);
      
        int.TryParse(paramTicketId, out ticketId);
        isNew = ticketId <= 0;

        if (isNew)
        {
            CurrentTicket = new Ticket();
        }
        else
        {
            CurrentTicket = bllTicket.GetTicket(ticketId);
          
        }
        if (!IsPostBack)
        {
            BindTickets();
            LoadForm();
        }


    }
    /// <summary>
    /// 绑定现有景区
    /// </summary>
    private void BindTickets()
    {

        rptTickets.DataSource = Scenic.Tickets;
        rptTickets.DataBind();
    }
    private void LoadForm()
    {
        tbxName.Text = CurrentTicket.Name;
        tbxOriginal.Text = CurrentTicket.GetPrice(PriceType.Normal).ToString("0");
        tbxPayOffline.Text = CurrentTicket.GetPrice(PriceType.PreOrder).ToString("0");
        tbxPayOnline.Text = CurrentTicket.GetPrice(PriceType.PayOnline).ToString("0");
    }
    private void UpdateForm()
    {
        IList<TicketPrice> prices = new List<TicketPrice>();
        TicketPrice priceOriginal = new TicketPrice
        { PriceType= Model.PriceType.Normal, Ticket=CurrentTicket, Price= Convert.ToDecimal(tbxOriginal.Text) };
        TicketPrice pricePreOrder = new TicketPrice 
        { PriceType = Model.PriceType.PreOrder, Ticket = CurrentTicket, Price = Convert.ToDecimal(tbxPayOffline.Text) };
        TicketPrice pricePayonline = new TicketPrice 
        { PriceType = Model.PriceType.PayOnline, Ticket = CurrentTicket, Price = Convert.ToDecimal(tbxPayOnline.Text) };
        prices.Add(priceOriginal);
        prices.Add(pricePreOrder);
        prices.Add(pricePayonline);
        CurrentTicket.IsMain = cbxIsMainPrice.Checked;
        CurrentTicket.Name = tbxName.Text;
        CurrentTicket.Scenic = Scenic;
        CurrentTicket.TicketPrice = prices;
    }

    private void Save()
    {
        UpdateForm();
        bllTicket.SaveOrUpdateTicket(CurrentTicket);
        if (isNew)
        {
            Response.Redirect("addticket.aspx?scenicid=" + scenicId + "&ticketid=" + CurrentTicket.Id);

        }
        else
        {
            ScriptManager.RegisterStartupScript(this,this.GetType(),"savesuccess","alert('修改成功')",true);
        }
        BindTickets();
    }
    protected void btnSave_Click(object s, EventArgs e)
    {
        Save();
    }

}