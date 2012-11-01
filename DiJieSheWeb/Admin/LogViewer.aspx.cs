using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_LogViewer : System.Web.UI.Page
{
    BLL.BLLOperationLog bllOp = new BLL.BLLOperationLog();
    protected void Page_Load(object sender, EventArgs e)
    {
        gv.DataSource = bllOp.GetAll();
        gv.DataBind();
    }
}