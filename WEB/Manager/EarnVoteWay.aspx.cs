using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
/// <summary>
/// 管理每种获取选票方式对应的数量
/// </summary>
public partial class Manager_EarnVoteWay : System.Web.UI.Page
{
    BLL.BLLEarnWayAmount bll = new BLL.BLLEarnWayAmount();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindWays();
            LoadList();
        }
    }
    private void LoadList()
    {
        IList<EarnWayAmount> list = bll.GetList();
        rpt.DataSource = list;
        rpt.DataBind();
    }

    private void BindWays()
    {
        ddlWays.DataSource = Enum.GetNames(typeof(EarnWay));
        ddlWays.DataTextField = "";
        ddlWays.DataBind();
        foreach (string name in Enum.GetNames(typeof(EarnWay)))
        { 
        
        }
    }
}