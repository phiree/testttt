using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class UC_CityCode : System.Web.UI.UserControl
{
    BLLArea bllArea = new BLLArea();
    private string areacode = "0";
    public string Areacode
    {
        get
        {
            return ddlAreaCity.SelectedValue;
        }
        set
        {
            areacode = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindArea();
            BindSubArea();
        }
    }
    private void BindArea()
    {
        ddlAreaProvince.DataSource = bllArea.GetSubArea("330000");
        ddlAreaProvince.DataTextField = "Name";
        ddlAreaProvince.DataValueField = "Code";
        ddlAreaProvince.DataBind();
        if (areacode != "0")
        {
            ddlAreaProvince.SelectedIndex = ddlAreaProvince.Items.IndexOf(
                ddlAreaProvince.Items.FindByText(
                bllArea.GetAreaByCode(areacode.Substring(0, 4) + "00").Name));
        }
    }
    private void BindSubArea()
    {
        ddlAreaCity.DataSource = bllArea.GetSubArea(ddlAreaProvince.SelectedValue,true);
        ddlAreaCity.DataTextField = "Name";
        ddlAreaCity.DataValueField = "Code";
        ddlAreaCity.DataBind();
        if (areacode != "0")
        {
            ddlAreaCity.SelectedIndex = ddlAreaCity.Items.IndexOf(
                ddlAreaCity.Items.FindByText(
                bllArea.GetAreaByCode(areacode).Name));
        }
    }
    protected void ddlAreaProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubArea();
    }
}