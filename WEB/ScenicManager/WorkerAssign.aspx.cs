using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScenicManager_WorkerAssign : System.Web.UI.Page
{
    BLL.BLLScenicAdmin bllScenicadmin = new BLL.BLLScenicAdmin();
    BLL.BLLMembership bllMembership = new BLL.BLLMembership();
    public Model.TourMembership User;

    Guid userId;
    protected void Page_Load(object sender, EventArgs e)
    {
        string paramUserId = Request["userid"];
        if (!Guid.TryParse(paramUserId, out userId))
        {
            BLL.ErrHandler.Redirect(BLL.ErrType.ParamIllegal);
        }
        User = bllMembership.GetMemberById(userId);
        if (User == null)
        {
            BLL.ErrHandler.Redirect(BLL.ErrType.ParamIllegal);
        }
        if (!IsPostBack)
        {
            BindScenic();
        }
    }

    private void BindScenic()
    {
        cblAdminType.DataSource = Enum.GetNames(typeof(Model.ScenicAdminType));
        cblAdminType.DataBind();
        Model.ScenicAdmin sa = bllMembership.GetScenicAdmin(userId);
        if (sa != null)
        {
            int admintype = (int)sa.AdminType;
            switch (admintype)
            {
                case 1:
                    cblAdminType.Items[0].Selected = true;
                    lblAdminType.Text = cblAdminType.Items[0].Text;
                    break;
                case 2:
                    cblAdminType.Items[1].Selected = true;
                    lblAdminType.Text = cblAdminType.Items[1].Text;
                    break;
                case 4:
                    cblAdminType.Items[2].Selected = true;
                    lblAdminType.Text = cblAdminType.Items[2].Text;
                    break;
                case 3:
                    cblAdminType.Items[0].Selected = true;
                    cblAdminType.Items[1].Selected = true;
                    lblAdminType.Text = cblAdminType.Items[0].Text + ";" + cblAdminType.Items[1].Text;
                    break;
                case 5:
                    cblAdminType.Items[0].Selected = true;
                    cblAdminType.Items[2].Selected = true;
                    lblAdminType.Text = cblAdminType.Items[0].Text + ";" + cblAdminType.Items[2].Text;
                    break;
                case 6:
                    cblAdminType.Items[1].Selected = true;
                    cblAdminType.Items[2].Selected = true;
                    lblAdminType.Text = cblAdminType.Items[1].Text + ";" + cblAdminType.Items[2].Text;
                    break;
                case 7:
                    cblAdminType.Items[0].Selected = true;
                    cblAdminType.Items[1].Selected = true;
                    cblAdminType.Items[2].Selected = true;
                    lblAdminType.Text = cblAdminType.Items[0].Text + ";" + cblAdminType.Items[1].Text + ";" + cblAdminType.Items[2].Text;
                    break;
                default:
                    lblAdminType.Text = "无";
                    break;
            }
        }
    }
    protected void btnModify_Click(object sender, EventArgs e)
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
        Model.ScenicAdmin sa = bllMembership.GetScenicAdmin(userId);
        sa.AdminType = sat;
        bllScenicadmin.SaveOrUpdate(sa);
        Response.Redirect("WorkerList.aspx");
    }
}