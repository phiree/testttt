using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class TourManagerDpt_Default : basepageMgrDpt
{
    BLLDJEnterprise BllEnt = new BLLDJEnterprise();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 获取当前用户辖区内的企业.
    /// </summary>
    private void BindList()
    {
        //IList<DJ_TourEnterprise> entList = BllEnt.GetDJS8Muti(CurrentDpt.Area.Id,
    }

    protected void rptItemCommand(object sender, RepeaterCommandEventArgs e)
    { 
    
    }
}