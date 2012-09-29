using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Groups_GroupGuide : System.Web.UI.Page
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
        }
    }

    private void BindGuide()
    {
        IList<Model.DJ_TourEnterprise> telist=blldjs.GetDjs8all();
        ddlDJS.DataSource = telist;
        ddlDJS.DataTextField = "Name";
        ddlDJS.DataValueField = "Id";
        ddlDJS.DataBind();
    }

    protected void ddlDJS_TextChanged(object sender, EventArgs e)
    {
        IList<Model.DJ_Group_Worker> gblist = blldjs.GetGroupmem8epid(ddlDJS.Text);
        //IList<Model.DJ_Group_Worker> gwlist = new List<Model.DJ_Group_Worker>();
        //foreach (var item in gblist)
        //{
        //    Model.DJ_Group_Worker gw = item as Model.DJ_Group_Worker;
        //    if (gw != null)
        //    {
        //        gwlist.Add(gw);
        //    }
        //}
        rptGuide.DataSource = gblist;
        rptGuide.DataBind();
    }
}