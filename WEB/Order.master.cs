using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Model;
using BLL;

public partial class OrderMaster: System.Web.UI.MasterPage
{
    BLLScenic bllscenic = new BLLScenic();
    BLLArea bllArea = new BLLArea();
    protected void Page_Load(object sender, EventArgs e)
    {
        BindVisited();
    }

    //绑定最近浏览过的景区
    private void BindVisited()
    {
        List<Scenic> listsc = new List<Scenic>();
        if (Request.Cookies["visitedscenic"] != null)
        {
            string[] allkeys = Request.Cookies["visitedscenic"].Value.Split(',');
            foreach (string item in allkeys)
            {
                Scenic sss = bllscenic.GetScenicById(int.Parse(item));
                listsc.Add(sss);
            }
            rptvisited.DataSource = listsc;
            rptvisited.DataBind();
        }
    }
    protected void rptvisited_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Model.Scenic t = e.Item.DataItem as Model.Scenic;
            HtmlAnchor ha = e.Item.FindControl("ahref") as HtmlAnchor;
            ha.HRef = "/Tickets/" + bllArea.GetAreaByCode(t.Area.Code.Substring(0, 4) + "00").SeoName + "_" + t.Area.SeoName + "/" + t.SeoName + ".html";
        }
    }
}
