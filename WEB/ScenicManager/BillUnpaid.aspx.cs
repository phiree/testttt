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
            ddlCondition_SelectedIndexChanged(null, null);
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
        if (txtbegin.Text == "" || txtend.Text == "")
        {
            txtbegin.Text = DateTime.Now.Year + "年" + "01月";
            txtend.Text = DateTime.Now.Year + "年" + "12月";
        }
        DateTime begintime, endtime;
        if (DateTime.TryParse(txtbegin.Text, out begintime) && DateTime.TryParse(txtend.Text, out endtime))
        {
            if (begintime > endtime)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('起始时间不得大于终止时间')", true);
                return;
            }
        }
        else
        {
            txtbegin.Text = DateTime.Now.Year + "年" + "01月";
            txtend.Text = DateTime.Now.Year + "年" + "12月";
        }
        bind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ddlCondition_SelectedIndexChanged(null, null);
    }
}