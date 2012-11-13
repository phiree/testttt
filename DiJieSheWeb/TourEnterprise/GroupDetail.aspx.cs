using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TourEnterprise_GroupDetail : System.Web.UI.Page
{
    BLL.BLLDJTourGroup blltg = new BLL.BLLDJTourGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        string guid = Request.QueryString[0];
        BindData(guid);
    }

    private void BindData(string guid)
    {
        Model.DJ_TourGroup tg = blltg.GetOne(Guid.Parse(guid));
    
        lblName.Text = tg.Name;
        lblDate.Text = tg.BeginDate.ToShortDateString() + "-" + tg.EndDate.ToShortDateString();
        lblDays.Text = tg.DaysAmount.ToString();
        lblPnum.Text = (tg.AdultsAmount + tg.ChildrenAmount).ToString();
        lblPadult.Text = tg.AdultsAmount.ToString();
        lblPchild.Text = tg.ChildrenAmount.ToString();
        lblForeigners.Text = tg.ForeignersAmount.ToString();
        lblGangaotais.Text = tg.GangaotaisAmount.ToString();

        rptMem.DataSource = tg.Members;
        rptMem.DataBind();

        rptWorkers.DataSource = tg.Workers;
        rptWorkers.DataBind();
    }
}