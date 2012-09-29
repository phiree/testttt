using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Groups_GroupGuideDetail : System.Web.UI.Page
{
    //var
    BLL.BLLDJEnterprise blldjs = new BLL.BLLDJEnterprise();
    string guideid = string.Empty;
    Model.DJ_Group_Worker gw;

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
        IList<Model.DJ_Group_Worker> gwlist = blldjs.GetGuide8id(guideid);
        if (gwlist.Count > 0)
        {
            gw = gwlist[0];
            lblName.Text = gw.Name;
            txtIDcard.Text = gw.IDCard;
            txtPhone.Text = gw.Phone;
            txtGuideno.Text = gw.SpecificIdCard;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        gw = blldjs.GetGuide8id(guideid)[0];
        if (gw != null)
        {
            gw.IDCard = txtIDcard.Text;
            gw.Phone = txtPhone.Text;
            gw.SpecificIdCard = txtGuideno.Text;
            blldjs.UpdateGuide(gw);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改成功!')", true);
            Response.Redirect("/Groups/GroupGuideList.aspx");
        }
    }
}