using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Groups_Grouplist : System.Web.UI.Page
{
    BLL.BLLDJTourGroup blltg = new BLL.BLLDJTourGroup();

    protected void Page_Load(object sender, EventArgs e)
    {
        BindGroups();
    }

    public void BindGroups()
    {
        IList<Model.DJ_TourGroup> tglist = blltg.GetTourGroupByAll();
        rptGroups.DataSource = tglist;
        rptGroups.DataBind();
    }
}