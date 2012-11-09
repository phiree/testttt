using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LocalTravelAgent_DjsEdit : basepageDJS
{

    BLL.BLLDJEnterprise blldjs = new BLL.BLLDJEnterprise();
    BLL.BLLArea bllarea = new BLL.BLLArea();
    Model.DJ_TourEnterprise djs;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindArea();
            BindType();
            BindData();
        }
    }

    private void BindData()
    {

        djs = CurrentDJS;
            txtName.Text = djs.Name;
            txtCPP.Text = djs.ChargePersonPhone;
            txtCPN.Text = djs.ChargePersonName;
            txtTel.Text = djs.Phone;
            txtAddress.Text = djs.Address;
            ddlArea.SelectedIndex = ddlArea.Items.IndexOf(ddlArea.Items.FindByText(djs.Area.Name));
        
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
            //Model.EnterpriseType.宾馆.ToString(),
            //Model.EnterpriseType.饭店.ToString(),
            //Model.EnterpriseType.购物点.ToString(),
            //Model.EnterpriseType.景点.ToString()
            "地接社"
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
        if (djs == null)
        {
            blldjs.AddDjs(txtName.Text.Trim(), txtAddress.Text.Trim(),
                bllarea.GetAreaByCode("330100"), txtCPN.Text.Trim(), txtCPP.Text.Trim(), "010-156489765","","");
        }
        else
        {
            //blldjs.Save(djs);
        }
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