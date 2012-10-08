using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class Admin_EnterpriseEdit : System.Web.UI.Page
{

    bool IsNew = false;
    DJ_TourEnterprise CurrentEnterprise;
    BLLArea bllArea = new BLLArea();
    BLLDJEnterprise bllEnterprise = new BLLDJEnterprise();
    protected void Page_Load(object sender, EventArgs e)
    {
        string param = Request["entId"];
        int EntId;
        if (!int.TryParse(param, out EntId))
        {
            IsNew = true;
            CurrentEnterprise = new DJ_TourEnterprise();
        }
        else
        {
            CurrentEnterprise = bllEnterprise.GetDJS8id(EntId.ToString())[0];
        }
        if (!IsPostBack)
        {
            if (!IsNew)
            {
                LoadForm();
            }
        }

    }

    private void LoadForm()
    {
        tbxAdress.Text = CurrentEnterprise.Address;
        tbxAreaCode.Text = CurrentEnterprise.Area.Code;
        tbxChargePerson.Text = CurrentEnterprise.ChargePersonName;
        tbxName.Text = CurrentEnterprise.Name;
        tbxOfficePhone.Text = CurrentEnterprise.Phone;
        tbxPhone.Text = CurrentEnterprise.ChargePersonPhone;
        rblType.SelectedValue = CurrentEnterprise.Type.ToString();
    }
    private void UpdateForm()
    {
        CurrentEnterprise.Address = tbxAdress.Text;
        CurrentEnterprise.Area = bllArea.GetAreaByCode(tbxAreaCode.Text.Trim());
        CurrentEnterprise.ChargePersonName = tbxChargePerson.Text;
        CurrentEnterprise.Name = tbxName.Text;
        CurrentEnterprise.Phone = tbxOfficePhone.Text;
        CurrentEnterprise.ChargePersonPhone = tbxPhone.Text;
        CurrentEnterprise.Type = (EnterpriseType)(Convert.ToInt32(rblType.SelectedValue));
    }

    public void Save()
    {
        if (rblType.SelectedValue == "5")
        {
            if (IsNew)
            {
                CurrentEnterprise = new DJ_DijiesheInfo();
            }
        }

        UpdateForm();

        bllEnterprise.Save(CurrentEnterprise);
        if (IsNew)
        {
            Response.Redirect("enterpriseedit.aspx?entid=" + CurrentEnterprise.Id);
        }
        else
        {

        }


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
    }
}