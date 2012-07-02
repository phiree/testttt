using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScenicManager_WorkerList : bpScenicManager
{
    BLL.BLLMembership bllMem = new BLL.BLLMembership();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindUsers();
        }
    }

    private void BindUsers()
    {
        int pageIndex = GetPageIndex();
        long totalRecord = 0;
        var users = bllMem.GetScenicAdmin(Master.Scenic.Id);
        pager.RecordCount = (int)totalRecord;
        rptScenicAdmin.DataSource = users;
        rptScenicAdmin.DataBind();
    }

    private int GetPageIndex()
    {
        string paramPageIndex = Request[pager.UrlPageIndexName];
        int pageIndex;
        int.TryParse(paramPageIndex, out pageIndex);
        return pageIndex;
    }
    protected void rptScenicAdmin_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Model.ScenicAdmin sadmin = (Model.ScenicAdmin)e.Item.DataItem;
            int admintype = (int)sadmin.AdminType;
            //(e.Item.FindControl("ckbselect") as CheckBox).ID = sadmin.Membership.Id.ToString();
            switch (admintype)
            {
                case 1:
                    (e.Item.FindControl("lblAdminType") as Label).Text =
                        ((Model.ScenicAdminType)Enum.ToObject(typeof(Model.ScenicAdminType), 1)).ToString();
                    break;
                case 2:
                    (e.Item.FindControl("lblAdminType") as Label).Text =
                       ((Model.ScenicAdminType)Enum.ToObject(typeof(Model.ScenicAdminType), 2)).ToString();
                    break;
                case 4:
                    (e.Item.FindControl("lblAdminType") as Label).Text =
                       ((Model.ScenicAdminType)Enum.ToObject(typeof(Model.ScenicAdminType), 4)).ToString();
                    break;
                case 3:
                    (e.Item.FindControl("lblAdminType") as Label).Text =
                        ((Model.ScenicAdminType)Enum.ToObject(typeof(Model.ScenicAdminType), 1)).ToString()+";"+
                        ((Model.ScenicAdminType)Enum.ToObject(typeof(Model.ScenicAdminType), 2)).ToString();
                    break;
                case 5:
                    (e.Item.FindControl("lblAdminType") as Label).Text =
                        ((Model.ScenicAdminType)Enum.ToObject(typeof(Model.ScenicAdminType), 1)).ToString() + ";" +
                        ((Model.ScenicAdminType)Enum.ToObject(typeof(Model.ScenicAdminType), 4)).ToString();
                    break;
                case 6:
                    (e.Item.FindControl("lblAdminType") as Label).Text =
                        ((Model.ScenicAdminType)Enum.ToObject(typeof(Model.ScenicAdminType), 2)).ToString() + ";" +
                        ((Model.ScenicAdminType)Enum.ToObject(typeof(Model.ScenicAdminType), 4)).ToString();
                    break;
                case 7:
                    (e.Item.FindControl("lblAdminType") as Label).Text =
                        ((Model.ScenicAdminType)Enum.ToObject(typeof(Model.ScenicAdminType), 1)).ToString() + ";" +
                        ((Model.ScenicAdminType)Enum.ToObject(typeof(Model.ScenicAdminType), 2)).ToString() + ";" +
                        ((Model.ScenicAdminType)Enum.ToObject(typeof(Model.ScenicAdminType), 4)).ToString();
                    break;
                default:
                    (e.Item.FindControl("lblAdminType") as Label).Text = "无";
                    break;
            }
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        //checkbox中保存了membershipId, 用于将来可能的假删除操作
        foreach (RepeaterItem item in rptScenicAdmin.Items)
        {
            if (item.FindControl("ckbselect") != null)
            {
                CheckBox cb = item.FindControl("ckbselect") as CheckBox;
                if (cb.Checked == true)
                {
                    HiddenField hf = item.FindControl("hfid") as HiddenField;
                    Model.ScenicAdmin sa = new BLL.BLLMembership().GetScenicAdmin((Guid.Parse(hf.Value.ToString())));
                    sa.IsDisabled = true;
                    new BLL.BLLScenicAdmin().SaveOrUpdate(sa);
                }
            }
        }
        BindUsers();
    }
}