using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using CommonLibrary;
public partial class ScenticManager_Default : bpScenicManager
{

    BLLScenic bllscenic = new BLLScenic();
    BLLTicketPrice bllticketprice = new BLLTicketPrice();
    BLLMembership bllMember = new BLLMembership();
    protected void Page_Load(object sender, EventArgs e)
    {
        ScenicAdmin scenicAdmin = bllMember.GetScenicAdmin((Guid)CurrentMember.Id);
        switch ((int)scenicAdmin.AdminType)
        {
            case 1:
                Response.Redirect("/scenicmanager/onlinesell/Pricesetting.aspx");
                break;
            case 2:
                Response.Redirect("/scenicmanager/CheckTicket.aspx");
                break;
            case 4:
                Response.Redirect("/scenicmanager/StatisInfo.aspx");
                break;
            case 3:
                Response.Redirect("/scenicmanager/onlinesell/Pricesetting.aspx");
                break;
            case 5:
                 Response.Redirect("/scenicmanager/CheckTicket.aspx");
                break;
            case 6:
                Response.Redirect("/scenicmanager/CheckTicket.aspx");break;
            case 7:
                Response.Redirect("/scenicmanager/onlinesell/Pricesetting.aspx");
                break;
            default:
                break;
        }
    }
}