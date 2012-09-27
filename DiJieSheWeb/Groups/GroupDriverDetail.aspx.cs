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
    Model.DJ_Group_Driver gd;

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
        IList<Model.DJ_Group_Driver> gglist = blldjs.GetDriver8id(driverid);
        if (gglist.Count > 0)
        {
            gd = gglist[0];
            lblName.Text = gd.Name;
            txtIDcard.Text = gd.Idcard;
            txtPhone.Text = gd.Phone;
            txtCarno.Text = gd.Carno;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (gd != null)
        {
            gd.Idcard = txtIDcard.Text;
            gd.Phone = txtPhone.Text;
            gd.Carno = txtCarno.Text;
            blldjs.UpdateDriver(gd);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改成功!')", true);
            Response.Redirect("/Groups/GroupDriverList.aspx");
        }
    }
}