﻿using System;
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
    BLLDJ_User bllDjUser = new BLLDJ_User();
    private void LoadForm()
    {
        tbxAdress.Text = CurrentEnterprise.Address;
        ddlarea.Areacode = CurrentEnterprise.Area.Code;
        tbxChargePerson.Text = CurrentEnterprise.ChargePersonName;
        tbxName.Text = CurrentEnterprise.Name;
        tbxOfficePhone.Text = CurrentEnterprise.Phone;
        tbxPhone.Text = CurrentEnterprise.ChargePersonPhone;
        rblType.SelectedValue = CurrentEnterprise.Type.ToString();
        //DJ_User_TourEnterprise djuserEnt = bllDjUser.GetUser_TEbyId(CurrentEnterprise.Id);
        //if (djuserEnt != null)
        //{ tbxAccount.Text = djuserEnt.Name; }
        tbxSeoName.Text = CurrentEnterprise.SeoName;
    }
    private void UpdateForm()
    {
        CurrentEnterprise.Address = tbxAdress.Text;
        CurrentEnterprise.Area = bllArea.GetAreaByCode(ddlarea.Areacode);
        CurrentEnterprise.ChargePersonName = tbxChargePerson.Text;
        CurrentEnterprise.Name = tbxName.Text;
        CurrentEnterprise.Phone = tbxOfficePhone.Text;
        CurrentEnterprise.ChargePersonPhone = tbxPhone.Text;
        CurrentEnterprise.Type = (EnterpriseType)(Convert.ToInt32(rblType.SelectedValue));
        //DJ_User_TourEnterprise djuserEnt = bllDjUser.GetUser_TEbyId(CurrentEnterprise.Id);
        //if (djuserEnt == null)
        //{ 
        //    //创建新用户
        //}
        CurrentEnterprise.SeoName = tbxSeoName.Text;
    }

    public void Save()
    {
        if (rblType.SelectedValue == ((int)EnterpriseType.旅行社).ToString())
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