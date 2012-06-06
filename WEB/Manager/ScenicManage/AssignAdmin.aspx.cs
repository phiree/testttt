using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
/// <summary>
/// 为景区分配管理员
/// </summary>
public partial class Manager_ScenicManage_AssignAdmin : System.Web.UI.Page
{
    BLLScenic bllScenic = new BLLScenic();
    BLLMembership bllMember = new BLLMembership();
    Scenic Scenic;
    protected void Page_Load(object sender, EventArgs e)
    {
        string paramId = Request["scenicid"];
        int scenicId;
        if (!int.TryParse(paramId, out scenicId))
        {
            Scenic = bllScenic.GetScenicById(scenicId);
        }
    }
}