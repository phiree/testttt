using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Groups_GroupGuideDetail : System.Web.UI.Page
{
    //var
    BLL.BLLDijiesheInfo blldjs = new BLL.BLLDijiesheInfo();
    string guideid = string.Empty;
    Model.DJ_Group_Guide gg;

    protected void Page_Load(object sender, EventArgs e)
    {
        guideid = Request.QueryString["id"];
        if (!IsPostBack)
        {
            BindGuide();
        }
    }

    private void BindGuide()
    {
        IList<Model.DJ_Group_Guide> gglist=blldjs.GetGuide8id(guideid);
        if (gglist.Count > 0)
        {
            gg = gglist[0];
            lblName.Text = gg.Name;
            txtIDcard.Text = gg.Idcard;
            txtPhone.Text = gg.Phone;
            txtGuideno.Text = gg.GuideNo;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        gg = blldjs.GetGuide8id(guideid)[0];
        if (gg != null)
        {
            gg.Idcard = txtIDcard.Text;
            gg.Phone = txtPhone.Text;
            gg.GuideNo = txtGuideno.Text;
            blldjs.UpdateGuide(gg);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改成功!')", true);
            Response.Redirect("/Groups/GroupGuideList.aspx");
        }
    }
}