using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Groups_GroupDriver : System.Web.UI.Page
{
    //var
    const string DJSID = "djsid";

    //var
    BLL.BLLDJEnterprise blldjs = new BLL.BLLDJEnterprise();
    string djsid = string.Empty;//djsid

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGuide();
            ddlDJS_TextChanged(null, null);
        }
    }

    private void BindGuide()
    {
        IList<Model.DJ_TourEnterprise> telist = blldjs.GetDjs8all();
        ddlDJS.DataSource = telist;
        ddlDJS.DataTextField = "Name";
        ddlDJS.DataValueField = "Id";
        ddlDJS.DataBind();
    }

    protected void ddlDJS_TextChanged(object sender, EventArgs e)
    {
        IList<Model.DJ_Group_Base> gblist = blldjs.GetGroupmem8epid(ddlDJS.Text);
        IList<Model.DJ_Group_Driver> gdlist = new List<Model.DJ_Group_Driver>();
        foreach (var item in gblist)
        {
            Model.DJ_Group_Driver gd = item as Model.DJ_Group_Driver;
            if (gd != null)
            {
                gdlist.Add(gd);
            }
        }
        rptGuide.DataSource = gdlist;
        rptGuide.DataBind();
    }
}