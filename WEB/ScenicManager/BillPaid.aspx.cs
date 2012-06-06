using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class ScenicManager_BillPaid : bpScenicManager
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
        CurrentScenic = Master.Scenic;
        rptStatis.DataSource = bllOrder.GetListForUser(0, CurrentScenic.Id,true,null,null);
        rptStatis.DataBind();
    }
}