using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using CommonLibrary;

public partial class ScenicManager_WorderAdd : bpScenicManager
{
    BLL.BLLScenic bllScenic = new BLL.BLLScenic();
    BLL.BLLScenicAdmin bllscenicadmin = new BLL.BLLScenicAdmin();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }

    protected void Bind()
    {
        cblAdminType.DataSource = Enum.GetNames(typeof(Model.ScenicAdminType));
        cblAdminType.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Model.ScenicAdminType sat = 0;
        foreach (ListItem item in cblAdminType.Items)
        {
            if (item.Selected)
            {
                Model.ScenicAdminType admintype = (Model.ScenicAdminType)Enum.Parse(typeof(Model.ScenicAdminType), item.Text);
                sat = sat | admintype;
            }
        }
        int scid = Master.Scenic.Id;
        ScenicAdmin sa = new ScenicAdmin();
        sa.AdminType = ScenicAdminType.景区资料员;
        sa.Scenic = bllScenic.GetScenicById(scid);
        sa.AdminType = sat;
        new BLL.BLLMembership().CreateUser("", "", "", "",txtname.Text , txtpsw.Text,"");
        TourMembership tour = new BLL.BLLMembership().GetMember(txtname.Text);
        sa.Membership = tour;
        sa.IsDisabled = false;
        bllscenicadmin.SaveOrUpdate(sa);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "btnOk", "alert('添加成功')", true);
        Response.Redirect("/ScenicManager/WorkerList.aspx");
    }
}