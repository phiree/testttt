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
    public int i = 0;
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
        rptPrint.DataSource = Listgcr;
        rptPrint.DataBind();
    }
    protected void rptPrint_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DJ_GroupConsumRecord record = e.Item.DataItem as DJ_GroupConsumRecord;
            Literal laAppendBed = e.Item.FindControl("laAppendBed") as Literal;
            if (record.AppendBed > 0)
            {
                laAppendBed.Text = "加床数" + record.AppendBed;
            }
            else
            {
                laAppendBed.Visible = false;
            }
        }
    }
    protected void BtnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.UrlReferrer.AbsoluteUri);
    }
}