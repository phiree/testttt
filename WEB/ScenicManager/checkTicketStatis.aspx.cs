using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class ScenicManager_checkTicketStatis : bpScenicManager
{
    BLLTicketAssign bllTicketAssign = new BLLTicketAssign();
    public int index = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bind();
    }

    private void bind()
    {
        DateTime beginDate, endDate;
        DateTime? beginDate2, endDate2;
        if (DateTime.TryParse(txtbegin.Text.Trim(), out beginDate))
        {
            beginDate2 = beginDate;
        }
        else
        {
            beginDate2 = null;
        }
        if (DateTime.TryParse(txtend.Text.Trim(), out endDate))
        {
            endDate2 = endDate;
        }
        else
        {
            endDate2 = null;
        }
        rptCheckTicketStatis.DataSource= bllTicketAssign.GetListByTimeAndScenic(beginDate2, endDate2, CurrentScenic);
        rptCheckTicketStatis.DataBind();

    }
}