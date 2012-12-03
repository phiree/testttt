using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_ScenicAdminDetail : System.Web.UI.Page
{
    DAL.DALArea dalarea = new DAL.DALArea();
    IDAL.IScenic dalscenic = new DAL.DALScenic();
    BLL.BLLMembership bllMembership = new BLL.BLLMembership();
    public Model.TourMembership User;

    Guid userId;
    protected void Page_Load(object sender, EventArgs e)
    {
        string paramUserId = Request["userid"];
        if (!Guid.TryParse(paramUserId, out userId))
        {
            BLL.ErrHandler.Redirect(BLL.ErrType.ParamIllegal);
        }
        User = bllMembership.GetMemberById(userId);
        if (User == null)
        {
            BLL.ErrHandler.Redirect(BLL.ErrType.ParamIllegal);
        }
        if (!IsPostBack)
        {
            BindProvince();
        }
        BindScenic();

    }

    private void BindScenic()
    {
        Model.ScenicAdmin sa = bllMembership.GetScenicAdmin(userId);
        lblScenic.Text = sa == null ? "无" : sa.Scenic.Name;
        btnDelete.Visible = sa != null;
    }

    private void BindProvince()
    {
        IList<Model.Area> areaList = dalarea.GetAreaProvince();
        ddlProvince.DataSource = areaList;
        ddlProvince.DataTextField = "Name";
        ddlProvince.DataValueField = "Code";
        ddlProvince.DataBind();
    }
    protected void ddlProvince_TextChanged(object sender, EventArgs e)
    {
        IList<Model.Area> areaList = dalarea.GetSubArea(ddlProvince.SelectedValue);
        BindCity(areaList);

        ddlCity_TextChanged(null, null);
    }

    protected void btnDelte_Click(object sender, EventArgs e)
    {
        bllMembership.DeleteScenicAdmin(userId); BindScenic();
    }

    private void BindCity(IList<Model.Area> areaList)
    {
        ddlCity.DataSource = areaList;
        ddlCity.DataTextField = "Name";
        ddlCity.DataValueField = "Code";
        ddlCity.DataBind();
    }

    protected void ddlCity_TextChanged(object sender, EventArgs e)
    {

        BindScenicList(ddlCity.SelectedValue);
    }
    private void BindScenicList(string cityAreaCode)
    {
        IList<Model.Scenic> scenicList = dalscenic.GetScenicByAreacode(cityAreaCode);
        cblSceniclist.DataSource = scenicList;
        cblSceniclist.DataTextField = "Name";
        cblSceniclist.DataValueField = "Id";
        cblSceniclist.DataBind();
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        foreach (ListItem item in cblSceniclist.Items)
        {
            if (item.Selected == true)
            {
                bllMembership.CreateUpdateScenicAdmin(new Guid(Request["userid"]), int.Parse(item.Value));
            }
        }
        BindScenic();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "btnOk", "alert('设置成功')", true);
    }
}