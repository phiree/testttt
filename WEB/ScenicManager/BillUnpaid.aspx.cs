using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class ScenicManager_BillUnpaid : bpScenicManager
{
    BLLOrder bllOrder = new BLLOrder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    private void bind()
    {
        bool? billState=null;
        if (ddlCondition.Text == "已结单") billState = true;
        if (ddlCondition.Text == "未结单") billState = false;
        CurrentScenic = Master.Scenic;
        rptStatis.DataSource = bllOrder.GetListForUser(0, CurrentScenic.Id, billState,txtbegin.Text.Trim(),txtend.Text.Trim());
        rptStatis.DataBind();
    }

    protected void ddlCondition_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind();
    }
}