using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class ScenticManager_StatisInfo : bpScenicManager
{
    BLLOrder bllOrder = new BLLOrder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //bind();
        }
    }

    private void bind()
    {
        CurrentScenic = Master.Scenic;
        bool? paistate=null;
        if (unpay.Checked)
            paistate = false;
        if (paid.Checked)
            paistate = true;
        if (paid.Checked & unpay.Checked)
            paistate = null;
        rptStatis.DataSource = bllOrder.GetMonthOrder(
            CurrentScenic.Id, txtbegin.Text.Trim(), txtend.Text.Trim(), paistate);
        rptStatis.DataBind();
    }

    protected void rptStatis_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "jiesuan")
        {
            string[] data = e.CommandArgument.ToString().Split(';');
            bllOrder.AddMonthBill(data[0], Master.Scenic, data[1], int.Parse(data[2]), decimal.Parse(data[3]), true);
            bind();
        }
    }

    protected void unpay_CheckedChanged(object sender, EventArgs e)
    {
        if (DateTime.Parse(txtbegin.Text) > DateTime.Parse(txtend.Text))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "btnOk", "alert('起始日期必须大于结束日期')", true);
        }
        bind();
    }
}