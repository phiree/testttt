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
            BindLevel();
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

    private void BindLevel()
    {
        ArrayList list = new ArrayList();
        string type = ddltype.SelectedItem.Text;
        switch (type)
        {
            case "景点":
                list.Add(new ListItem("5A", "5A"));
                list.Add(new ListItem("4A", "4A"));
                list.Add(new ListItem("3A", "3A"));
                list.Add(new ListItem("无", "无"));
                break;
            case "饭店":
                list.Add(new ListItem("7星", "7星"));
                list.Add(new ListItem("6星", "6星"));
                list.Add(new ListItem("5星", "5星"));
                list.Add(new ListItem("4星", "4星"));
                list.Add(new ListItem("3星", "3星"));
                list.Add(new ListItem("无", "无"));
                break;
            case "宾馆":
                list.Add(new ListItem("7星", "7星"));
                list.Add(new ListItem("6星", "6星"));
                list.Add(new ListItem("5星", "5星"));
                list.Add(new ListItem("4星", "4星"));
                list.Add(new ListItem("3星", "3星"));
                list.Add(new ListItem("无", "无"));
                break;
            case "购物点":
                list.Add(new ListItem("5星", "5星"));
                list.Add(new ListItem("4星", "4星"));
                list.Add(new ListItem("3星", "3星"));
                list.Add(new ListItem("无", "无"));
                break;
            case "旅行社":
                list.Add(new ListItem("5星", "5星"));
                list.Add(new ListItem("4星", "4星"));
                list.Add(new ListItem("3星", "3星"));
                list.Add(new ListItem("无", "无"));
                break;
        }
        ddlLevel.DataSource = list;
        ddlLevel.DataTextField = "text";
        ddlLevel.DataValueField = "value";
        ddlLevel.DataBind();
    }

    protected void ddltype_TextChanged(object sender, EventArgs e)
    {
        BindLevel();
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
        ddlLevel.SelectedIndex = ddlLevel.Items.IndexOf(ddlLevel.Items.FindByText(CurrentEnterprise.Level));
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        CurrentEnterprise.Address = tbxAdress.Text;
        CurrentEnterprise.Area = bllArea.GetAreaByCode(ddlarea.Areacode);
        CurrentEnterprise.Level = ddlLevel.SelectedItem.Text;
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