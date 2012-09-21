using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LocalTravelAgent_DjsEdit : System.Web.UI.Page
{

    BLL.BLLDijiesheInfo blldjs = new BLL.BLLDijiesheInfo();
    BLL.BLLArea bllarea = new BLL.BLLArea();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindArea();
            BindType();
        }
    }

    private void BindArea()
    {
        IList<Model.Area> areas = bllarea.GetSubArea("330000");
        ddlArea.DataSource = areas;
        ddlArea.DataTextField = "Name";
        ddlArea.DataValueField = "Code";
        ddlArea.DataBind();
    }

    private void BindType()
    {
        IList<string> types = new List<string>(){
            Model.EnterpriseType.宾馆.ToString(),
            Model.EnterpriseType.饭店.ToString(),
            Model.EnterpriseType.购物点.ToString(),
            Model.EnterpriseType.景点.ToString()
        };
        ddlType.DataSource = types;
        ddlType.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        ResultHelper rh = checkComplete();
        if (!rh.bresult)
        { 
            Page.ClientScript.RegisterStartupScript(this.GetType(),"","alert('"+rh.sresult+"')",true);
            return;
        }
        blldjs.AddDjs("新疆牙买提", "新疆乌鲁木齐", 
            bllarea.GetAreaByCode("330100"), "阿凡提", "15988886666", "010-156489765");
    }

    private ResultHelper checkComplete()
    {
        if (string.IsNullOrEmpty(txtName.Text))
        {
            return new ResultHelper(false, "请检查，名称还未填写！");
        }
        if (string.IsNullOrEmpty(txtAddress.Text))
        {
            return new ResultHelper(false, "请检查，地址还未填写！");
        }
        if (string.IsNullOrEmpty(txtCPN.Text))
        {
            return new ResultHelper(false, "请检查，负责人姓名还未填写！");
        }
        if (string.IsNullOrEmpty(txtCPP.Text))
        {
            return new ResultHelper(false, "请检查，负责人电话还未填写！");
        }
        if (string.IsNullOrEmpty(txtTel.Text))
        {
            return new ResultHelper(false, "请检查，联系电话还未填写！");
        }
        return new ResultHelper(true, "");
    }
}