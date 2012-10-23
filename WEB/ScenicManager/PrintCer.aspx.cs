using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class TourEnterprise_PrintCer : System.Web.UI.Page
{
    BLLDJConsumRecord blldjcr = new BLLDJConsumRecord();
    protected void Page_Load(object sender, EventArgs e)
    {
        bind();
    }

    private void bind()
    {
        string[] routeids = Request.QueryString["routeids"].Split(',');
        List<DJ_GroupConsumRecord> Listgcr = new List<DJ_GroupConsumRecord>();
        foreach (string routeid in routeids)
        {
            if(routeid!="")
                Listgcr.Add(blldjcr.GetGroupConsumRecordByRouteId(Guid.Parse(routeid)));
        }
        title.InnerHtml = Listgcr[0].Enterprise.Name+"验证凭证";
        rptPrint.DataSource = Listgcr;
        rptPrint.DataBind();
    }
    protected void rptPrint_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Literal laGuiderName = e.Item.FindControl("laGuiderName") as Literal;
            DJ_GroupConsumRecord gcr = e.Item.DataItem as DJ_GroupConsumRecord;
            foreach (DJ_Group_Worker work in gcr.Route.DJ_TourGroup.Workers.Where(x=>x.WorkerType==DJ_GroupWorkerType.导游))
	        {
                laGuiderName.Text += work.Name + " ";
	        }
            
        }
    }
}