using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_ScenicimgInit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        new ExcelOplib.ExcelOpr().Run();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "btnOk", "alert('添加成功')", true);
    }
}