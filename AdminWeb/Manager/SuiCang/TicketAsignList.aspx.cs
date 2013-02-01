using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// 将给定
/// </summary>
public partial class Manager_QuZhouSpring_TicketAsignList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void txtTime_TextChanged(object sender, EventArgs e)
    {
        if (DateTime.Parse(txtTime.Text) < DateTime.Now)
        {
            btnSave.Visible = false;
            txtAmount.Enabled = false;
        }
        else
        {
            btnSave.Visible = true;
            txtAmount.Enabled = true;
        }
    }
}