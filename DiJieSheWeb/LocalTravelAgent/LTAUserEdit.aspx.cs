using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class LocalTravelAgent_LTAUserEdit : System.Web.UI.Page
{
    BLLDJ_User blldj_user = new BLLDJ_User();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void bind()
    {
        if (Request.QueryString["userid"] != null)
        {
            Guid userid;
            Guid.TryParse(Request.QueryString["userid"], out userid);
            DJ_User_TourEnterprise user = blldj_user.get
            txtName.Text = user.Name;
            switch ((int)user.PermissionMask)
            {
                case 1: cbList.Items[0].Selected = true; break;
                case 2: cbList.Items[1].Selected = true; break;
                case 3: cbList.Items[0].Selected = true; cbList.Items[1].Selected = true; break;
            }
        }
    }
}