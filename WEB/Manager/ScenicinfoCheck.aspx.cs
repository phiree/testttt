using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Manager_ScenicinfoCheckaspx : System.Web.UI.Page
{
    BLL.BLLBackManager bllmanager = new BLL.BLLBackManager();
    BLL.BLLScenic bllScenic = new BLL.BLLScenic();
    public IList<Model.Scenic> datasource;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindList(); //showData();
        }
     
    }
    private void BindList()
    {

        int pageIndex = GetPageIndex();
        long totalRecord;
        IList<Model.Scenic> scenicList = bllmanager.GetScenicList("", pageIndex-1, pager.PageSize, out totalRecord);
        pager.RecordCount = (int)totalRecord;
        rpt.DataSource = scenicList;
        rpt.DataBind();
    }
    private int GetPageIndex()
    {
        string paramPageIndex = Request[pager.UrlPageIndexName];
        int pageIndex;
        int.TryParse(paramPageIndex, out pageIndex);
        return pageIndex;

    }


    
    protected void rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
       
        if (e.CommandName.ToLower() == "validate")
        {
            //验证按钮的事件
            int scenicId = int.Parse(e.CommandArgument.ToString());
            Model.Scenic scenic = bllScenic.GetScenicById(scenicId);
         
            bllScenic.UpdateScenicInfo(scenic);
            BindList();
        }
    }
    protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            //如果已经验证通过，则隐藏按钮
            Button btnValidate = e.Item.FindControl("btnValidate") as Button;
           
        }
    }
}