using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
public partial class UC_ScenicSideList : System.Web.UI.UserControl
{
    public IList<Model.Scenic> ScenicList { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ScenicList != null)
        {
            rptvisited.DataSource = ScenicList;
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