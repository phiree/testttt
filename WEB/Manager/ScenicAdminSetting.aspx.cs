using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_ScenicAdminSetting : System.Web.UI.Page
{
    BLL.BLLMembership bllMem = new BLL.BLLMembership();
    protected void Page_Load(object sender, EventArgs e)
    {
        BindUsers();
    }

    private void BindUsers()
    {
        int pageIndex = GetPageIndex();
        long totalRecord=0;
        var users = bllMem.GetScenicAdmin(0);
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
}