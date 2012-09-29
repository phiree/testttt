using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Groups_GroupDriverDetail : System.Web.UI.Page
{
    //var
    BLL.BLLDJEnterprise blldjs = new BLL.BLLDJEnterprise();
    string driverid = string.Empty;
    Model.DJ_Group_Worker gw;

    protected void Page_Load(object sender, EventArgs e)
    {
        driverid = Request.QueryString["id"];
        if (!IsPostBack)
        {
            BindDriver();
        }
    }

    private void BindDriver()
    {
        IList<Model.DJ_Group_Worker> gwlist = blldjs.GetDriver8id(driverid);
        if (gwlist.Count > 0)
        {
            gw = gwlist[0];
            lblName.Text = gw.Name;
            txtIDcard.Text = gw.IDCard;
            txtPhone.Text = gw.Phone;
            txtCarno.Text = gw.SpecificIdCard;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (gw != null)
        {
            gw.IDCard = txtIDcard.Text;
            gw.Phone = txtPhone.Text;
            gw.SpecificIdCard = txtCarno.Text;
            blldjs.UpdateDriver(gw);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改成功!')", true);
            Response.Redirect("/Groups/GroupDriverList.aspx");
        }
    }
}