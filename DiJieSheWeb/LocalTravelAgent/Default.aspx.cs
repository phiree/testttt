using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LocalTravelAgent_Default : System.Web.UI.Page
{
    BLL.BLLArea bllarea = new BLL.BLLArea();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindArea();
            BindType();
        }
    }

    private void BindArea()
    {
        IList<Model.Area> areas = bllarea.GetSubArea("330000");
        ddlArea.DataSource = areas;
        ddlArea.DataTextField = "Name";
        ddlArea.DataValueField = "Code";
        ddlArea.DataBind();
    }

    private void BindType()
    {
        IList<string> types = new List<string>(){
            Model.EnterpriseType.宾馆.ToString(),
            Model.EnterpriseType.饭店.ToString(),
            Model.EnterpriseType.购物点.ToString(),
            Model.EnterpriseType.景点.ToString()
        };
        ddlType.DataSource = types;
        ddlType.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }
}