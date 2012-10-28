using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Collections;

public partial class TourManagerDpt_EnterEdit : System.Web.UI.Page
{
    bool IsNew = false;
    DJ_TourEnterprise CurrentEnterprise;
    BLLArea bllArea = new BLLArea();
    BLLDJEnterprise bllEnterprise = new BLLDJEnterprise();

    protected void Page_Load(object sender, EventArgs e)
    {
        string param = Request["entId"];
        int EntId;
        //新建
        if (!int.TryParse(param, out EntId))
        {
            IsNew = true;
            CurrentEnterprise = new DJ_TourEnterprise();
        }
        //修改
        else
        {
            CurrentEnterprise = bllEnterprise.GetDJS8id(EntId.ToString())[0];
        }
        if (!IsPostBack)
        {
            BindType();
            if (!IsNew)
            {
                LoadForm();
            }
        }
    }

    private void BindType()
    {
        EnterpriseType et = new EnterpriseType();
        ArrayList list = new ArrayList();
        foreach (int i in Enum.GetValues(et.GetType()))
        {
            ListItem listitem = new ListItem(Enum.GetName(et.GetType(), i), i.ToString());
            list.Add(listitem);
        }
        ddltype.DataSource = list;
        ddltype.DataTextField = "text";
        ddltype.DataValueField = "value";
        ddltype.DataBind();
    }

    private void LoadForm()
    {
        tbxAdress.Text = CurrentEnterprise.Address;
        ddlarea.Areacode = CurrentEnterprise.Area.Code;
        tbxChargePerson.Text = CurrentEnterprise.ChargePersonName;
        tbxName.Text = CurrentEnterprise.Name;
        tbxOfficePhone.Text = CurrentEnterprise.Phone;
        tbxPhone.Text = CurrentEnterprise.ChargePersonPhone;
        tbxEnenmail.Text = CurrentEnterprise.Email;
        tbxYyzz.Text = CurrentEnterprise.Buslicense;
        ddltype.SelectedIndex = ddltype.Items.IndexOf(ddltype.Items.FindByText(CurrentEnterprise.Type.ToString()));
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        CurrentEnterprise.Address = tbxAdress.Text;
        CurrentEnterprise.Area = bllArea.GetAreaByCode(ddlarea.Areacode);
        CurrentEnterprise.ChargePersonName = tbxChargePerson.Text;
        CurrentEnterprise.Name = tbxName.Text;
        CurrentEnterprise.Phone = tbxOfficePhone.Text;
        CurrentEnterprise.ChargePersonPhone = tbxPhone.Text;
        CurrentEnterprise.Email = tbxEnenmail.Text;
        CurrentEnterprise.Buslicense = tbxYyzz.Text;
        CurrentEnterprise.Type = (EnterpriseType)(Convert.ToInt32(ddltype.SelectedValue));
        bllEnterprise.Save(CurrentEnterprise);
        if (IsNew)
        {
            Response.Redirect("EnterpriseDetail.aspx?entid=" + CurrentEnterprise.Id);
        }
        else
        {

        }
    }
}