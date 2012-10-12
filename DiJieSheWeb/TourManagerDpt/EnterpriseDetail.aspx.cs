using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TourManagerDpt_EnterpriseDetail : System.Web.UI.Page
{

    BLL.BLLDJEnterprise BllEnt = new BLL.BLLDJEnterprise();
    protected void Page_Load(object sender, EventArgs e)
    {
        int entId;
        if (int.TryParse(Request["entId"], out entId))
        {
            Model.DJ_TourEnterprise ent = BllEnt.GetDJS8id(entId.ToString())[0];
            ucEntDetail.Ent = ent;
        }
    }
}