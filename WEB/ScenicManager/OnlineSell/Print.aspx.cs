using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScenticManager_OnlineSell_Print : basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Model.ScenicAdmin user = new BLL.BLLMembership().GetScenicAdmin((Guid)CurrentUser.ProviderUserKey);
        Model.Scenic scenic = user.Scenic;
        lblAddress.Text = scenic.Address;
        lblArea.Text = scenic.Area.Name;
        lblDesc.Text = scenic.Desec;
        lblLevel.Text = scenic.Level;
        lblLocation.Text = scenic.Position;
        lblScenicname.Text = scenic.Name;
    }
}