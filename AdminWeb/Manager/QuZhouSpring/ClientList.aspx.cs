using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
/// <summary>
/// 为接入方 分配景区门票.
/// </summary>
public partial class Manager_QuZhouSpring_ClientManger : System.Web.UI.Page
{
    BLLQZSpringPartner bllqz = new BLLQZSpringPartner();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        rpt.DataSource = bllqz.GetListByName(txtName.Text);
        rpt.DataBind();
    }



    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Manager/QuZhouSpring/ClientEditor.aspx");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }
}