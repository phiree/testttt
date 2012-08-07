using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_SeoInit : System.Web.UI.Page
{
    BLL.BLLScenic bllscenic = new BLL.BLLScenic();
    BLL.BLLArea bllarea = new BLL.BLLArea();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            InitCity();
    }

    private void InitCity()
    {
        ddlCity.DataSource = bllarea.GetSubArea("330000");
        ddlCity.DataTextField = "Name";
        ddlCity.DataValueField = "Code";
        ddlCity.DataBind();
    }
    private void BindList()
    {
        IList<Model.Scenic> scenicList = bllscenic.GetScenicByAreacode(ddlCity.SelectedValue);
        rptScenic.DataSource = scenicList;
        rptScenic.DataBind();
    }

    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindList();
    }

    protected void rptScenic_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string KeyID = e.CommandArgument.ToString();
        Model.Scenic s = bllscenic.GetScenicById(int.Parse(KeyID));
        s.SeoName = (e.Item.FindControl("txtSeoname") as TextBox).Text;
        if (bllscenic.GetScenicBySeoName(s.SeoName) == null)
        {
            bllscenic.UpdateScenicInfo(s);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "btnOk", "alert('修改成功')", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "btnOk", "alert('已存在相同seo名称')", true);
        }
    }
}