using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
public partial class LocalTravelAgent_Groups_RecommentEnt : System.Web.UI.UserControl
{
    public string AreaCode { get; set; }
    BLLDJEnterprise bllEnt = new BLLDJEnterprise();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindRecommendEnt();
        }
    }
    private void BindRecommendEnt()
    {
        IList<Model.DJ_TourEnterprise> ents = bllEnt.GetRecEnt(AreaCode);
        rptRecomEnt.DataSource = ents;
        rptRecomEnt.DataBind();
    }
}