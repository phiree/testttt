using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Scenic_QuickSuc : System.Web.UI.Page
{
    public string phone;
    public string psw;

    protected void Page_Load(object sender, EventArgs e)
    {
        phone = Request["phone"];
        psw = Request["psw"];
    }
}