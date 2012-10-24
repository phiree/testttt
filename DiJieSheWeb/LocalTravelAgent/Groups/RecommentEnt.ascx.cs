using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
public partial class LocalTravelAgent_Groups_RecommentEnt : System.Web.UI.UserControl
{
    public string AreaCode { get; set; }
    BLLDJ_GovManageDepartment BllGov = new BLLDJ_GovManageDepartment();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindRecommendEnt();
        }
    }
    private void BindRecommendEnt()
    {
        List<Model.DJ_GovManageDepartment> ListGov = BllGov.GetGovDptByName("").ToList();
        if (ddlArea.SelectedValue == "市级")
        {
            ListGov = ListGov.Where(x => x.Area.Level == AreaLevel.市).ToList();
        }
        if (ddlArea.SelectedValue == "区县")
        {
            ListGov = ListGov.Where(x => x.Area.Level == AreaLevel.区县).ToList();
        }
        rptRecomEnt.DataSource = ListGov;
        rptRecomEnt.DataBind();
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        BindRecommendEnt();
    }
}