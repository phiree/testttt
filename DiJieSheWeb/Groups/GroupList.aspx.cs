using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LocalTravelAgent_GroupList : System.Web.UI.Page
{
    BLL.BLLDJEnterprise blldjs = new BLL.BLLDJEnterprise();

    protected void Page_Load(object sender, EventArgs e)
    {
        BindGroup();
    }

    private void BindGroup()
    {
        rptGrouplist.DataSource =blldjs.GetGroup8all() ;
        rptGrouplist.DataBind();
    }
}