using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
public partial class Manager_BillAll : System.Web.UI.Page
{
    BLL.BLLArea bllArea = new BLLArea();
    BLLOrder bllOrder = new BLLOrder();
    BLLScenic bllScenic = new BLLScenic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCity();
        }
    }

    private void bindBills(int scenicID)
    {
        var temp = bllOrder.GetListForUser(0, scenicID,null,null,null);
        if (null == temp) return;
        rptStatis.DataSource = temp;
        rptStatis.DataBind();
    }

    protected void ddlCity_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(ddlCity.SelectedValue))
            BindScenicList(ddlCity.SelectedValue);
    }

    protected void ddlScenics_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(ddlCity.SelectedValue))
            bindBills(int.Parse(ddlScenics.SelectedValue));
    }

    private void BindCity()
    {
        IList<Model.Area> areaList = bllArea.GetSubArea("330000");
        ddlCity.DataSource = areaList;
        ddlCity.DataTextField = "Name";
        ddlCity.DataValueField = "Code";
        ddlCity.DataBind();
        ddlCity_TextChanged(null, null);
    }
    private void BindScenicList(string cityAreaCode)
    {
        IList<Model.Scenic> scenicList = bllScenic.GetScenicByAreacode(cityAreaCode);
        ddlScenics.DataSource = scenicList;
        ddlScenics.DataTextField = "Name";
        ddlScenics.DataValueField = "Id";
        ddlScenics.DataBind();
        ddlScenics_TextChanged(null, null);
    }
}