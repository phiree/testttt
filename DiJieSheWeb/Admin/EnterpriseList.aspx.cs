using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
/// <summary>
/// 政府部门数据导入
/// </summary>
public partial class Admin_EnterpriseList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
 
protected void  rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
{
    if (e.CommandName.ToLower() == "addadmin")
    {
        Guid entId = Guid.Parse(e.CommandArgument.ToString());


        DJ_User_TourEnterprise dj = new DJ_User_TourEnterprise();
      //  dj.Enterprise=new blldj
    }
}
}