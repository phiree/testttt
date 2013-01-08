using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class TourManagerDpt_LTAList : basepageMgrDpt
{
    BLLDJEnterprise bllEnt = new BLLDJEnterprise();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindData();
        }
    }

    private void bindData()
    {
        List<DJ_TourEnterprise> ListDJS = bllEnt.GetRewardEntList(tbxName.Text,CurrentDpt, EnterpriseType.旅行社, 0).OrderByDescending(x => x.LastUpdateTime).ToList();
        rptEntList.DataSource = ListDJS;
        rptEntList.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bindData();
    }
}