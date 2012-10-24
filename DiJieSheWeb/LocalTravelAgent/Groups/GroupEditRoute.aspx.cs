using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
public partial class LocalTravelAgent_Groups_GroupEditRoute :basepageDjsGroupEdit
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRecommendEnt();
        }
    }

    BLLDJEnterprise bllEnt = new BLLDJEnterprise();
    private void BindRecommendEnt()
    {
     IList<Model.DJ_TourEnterprise> ents=   bllEnt.GetRecEnt(CurrentDJS.Area.Code);
     rptRecomEnt.DataSource = ents;
     rptRecomEnt.DataBind();
    }
}