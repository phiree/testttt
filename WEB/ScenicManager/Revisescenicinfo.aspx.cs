using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class ScenicManager_Updatescenicinfo : bpScenicManager
{
    Model.Ticket ticket;
    BLLTicket bllTicket = new BLLTicket();
    BLLScenic bllscenic = new BLLScenic();
    public int module;
    public int scenicid;

    protected void Page_Load(object sender, EventArgs e)
    {

        CurrentScenic = Master.Scenic;
        ticket = bllTicket.GetTicketByscId(CurrentScenic.Id)[0];
        Model.ScenicAdmin user = new BLLMembership().GetScenicAdmin((Guid)CurrentUser.ProviderUserKey);
        Scenic scenic = user.Scenic;
        module = (int)Model.ScenicModule.SellOnLine;
        scenicid = scenic.Id;
        if (!IsPostBack)
        {
        }
    }


    
    protected void btnApply_Click(object sender, EventArgs e)
    {
        ScenicCheckProgress scp = bllscenic.GetCheckProgressByscidandmouid(CurrentScenic.Id, 1);
        BllScenic.Apply(CurrentScenic, CurrentMember, ScenicModule.SellOnLine,scp.Id);
    }
}