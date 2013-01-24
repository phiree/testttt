using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserCenter_MyLinks : basepage
{
    BLL.BLLBackManager bllmanager = new BLL.BLLBackManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindList();
        }
    }

    private void BindList()
    {
        int pageIndex = GetPageIndex();
        long totalRecord;
        IList<Model.PromotionStatic> promList = bllmanager.GetPromList(" where User.Name='"+CurrentUser.UserName+"'", pageIndex, pager.PageSize, out totalRecord);
        pager.RecordCount = (int)totalRecord;
        rptLinks.DataSource = promList;
        rptLinks.DataBind();
    }

    private int GetPageIndex()
    {
        string paramPageIndex = Request[pager.UrlPageIndexName];
        int pageIndex;
        int.TryParse(paramPageIndex, out pageIndex);
        return pageIndex;
    }
}