using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class ScenicManager_PrintScenicPrice : basepage
{
    BLLTicketPrice bllticketprice = new BLLTicketPrice();
    protected void Page_Load(object sender, EventArgs e)
    {
        Model.ScenicAdmin user = new BLL.BLLMembership().GetScenicAdmin((Guid)CurrentUser.ProviderUserKey);
        Model.Scenic scenic = user.Scenic;
        lblScenicname.Text = scenic.Name;
        lblyj.Text = bllticketprice.GetTicketPriceByScenicandtypeid(scenic.Id, 1).Price.ToString("0");
        lblydj.Text = bllticketprice.GetTicketPriceByScenicandtypeid(scenic.Id, 2).Price.ToString("0");
        lblyhj.Text = bllticketprice.GetTicketPriceByScenicandtypeid(scenic.Id, 3).Price.ToString("0");
    }
}