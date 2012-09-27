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
    BLL.BLLDijiesheInfo blldjs = new BLL.BLLDijiesheInfo();
    string djsid = string.Empty;//djsid

    protected void Page_Load(object sender, EventArgs e)
    {
        djsid = Request.QueryString[DJSID];
        if (!string.IsNullOrEmpty(djsid))
        {
            BindGuide();
            ddlDJS_SelectedIndexChanged(null, null);
        }
    }

    private void BindGuide()
    {
        IList<Model.DJ_TourEnterprise> telist=blldjs.GetDJS8id(djsid);
        ddlDJS.DataSource = telist;
        ddlDJS.DataTextField = "Name";
        ddlDJS.DataValueField = "Id";
        ddlDJS.DataBind();
    }

    protected void ddlDJS_SelectedIndexChanged(object sender, EventArgs e)
    {
        IList<Model.DJ_Group_Base> gblist = blldjs.GetGroupmem(djsid);
        IList<Model.DJ_Group_Guide> gglist = new List<Model.DJ_Group_Guide>();
        foreach (var item in gblist)
        {
            Model.DJ_Group_Guide gg = item as Model.DJ_Group_Guide;
            if (gg != null)
            {
                gglist.Add(gg);
            }
        }
        rptGuide.DataSource = gglist;
        rptGuide.DataBind();
    }
}