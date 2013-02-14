using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class Manager_BillCheck : basepage
{
    BLL.BLLArea bllArea = new BLLArea();
    BLLOrder bllOrder = new BLLOrder();
    BLLScenic bllScenic = new BLLScenic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindProvince();
        }
    }

    private void bindBills(int scenicID)
    {
        var temp = bllOrder.GetListForUser(0, scenicID,true,null,null);
        if (null == temp) return;
        rptStatis.DataSource = temp;
        rptStatis.DataBind();
    }
    protected void ddlProvince_TextChanged(object sender, EventArgs e)
    {
        IList<Model.Area> areaList = bllArea.GetSubArea(ddlProvince.SelectedValue);
        BindCity(areaList);
    }

    protected void ddlCity_TextChanged(object sender, EventArgs e)
    {
        BindScenicList(ddlCity.SelectedValue);
    }

    protected void ddlScenics_TextChanged(object sender, EventArgs e)
    {
        bindBills(int.Parse(ddlScenics.SelectedValue));
    }

    private void BindProvince()
    {
        IList<Model.Area> areaList = bllArea.GetAreaProvince();
        ddlProvince.DataSource = areaList;
        ddlProvince.DataTextField = "Name";
        ddlProvince.DataValueField = "Code";
        ddlProvince.DataBind();
        ddlProvince_TextChanged(null, null);
    }

    private void BindCity(IList<Model.Area> areaList)
    {
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
    }
}