using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class LTARegister : System.Web.UI.Page
{
    BLLDJEnterprise bllEnt = new BLLDJEnterprise();
    BLLArea bllArea = new BLLArea();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }

    private void Bind()
    {
        bindArea(3);
        ddlProvince.SelectedValue = "330000";
        ddlProvince_SelectedIndexChanged(null, null);
    }
    protected void BtnRegister_Click(object sender, EventArgs e)
    {
        if (ckSelect.Checked)
        {
            if (!Verify())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('请上传营业执照')", true);
            }
            else
            {
                DJ_DijiesheInfo DJS = new DJ_DijiesheInfo();
                Area area = bllArea.GetAreaByCode(ddlCountry.SelectedValue);
                string filename;
                try
                {
                    string fileExt = System.IO.Path.GetExtension(fuLicence.FileName);
                    filename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString()
               + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + fileExt;
                    fuLicence.SaveAs(Server.MapPath("~/Data/License") + "\\" + filename);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                bllEnt.AddDjs(txtDJSName.Text.Trim(), txtDJSAddress.Text.Trim(), area, txtLinkName.Text.Trim(), txtTel.Text.Trim(), txtTel.Text.Trim(), filename, txtEmail.Text, null);
                Response.Redirect("/RegisterSuccess.aspx");
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('未同意单位管理平台协议')", true);
        }
    }


    private bool Verify()
    {
        if (!fuLicence.HasFile)
        {
            return false;
        }
        return true;
    }
    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindArea(2);
        foreach (ListItem item in ddlCity.Items)
        {
            item.Text = item.Text.Substring(3);
        }
        foreach (ListItem item in ddlCountry.Items)
        {
            item.Text = item.Text.Substring(3);
        }
    }
    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindArea(1);
        foreach (ListItem item in ddlCountry.Items)
        {
            item.Text = item.Text.Substring(3);
        }
    }

    private void bindArea(int AreaLevel)
    {
        if (AreaLevel >= 3)
        {
            ddlProvince.DataTextField = "Name";
            ddlProvince.DataValueField = "Code";
            ddlProvince.DataSource = bllArea.GetAreaProvince();
            ddlProvince.DataBind();
        }
        if (AreaLevel >= 2)
        {
            ddlCity.DataTextField = "Name";
            ddlCity.DataValueField = "Code";
            ddlCity.DataSource = bllArea.GetSubArea(ddlProvince.SelectedValue);
            ddlCity.DataBind();
        }
        if (AreaLevel >= 1)
        {
            ddlCountry.DataTextField = "Name";
            ddlCountry.DataValueField = "Code";
            ddlCountry.DataSource = bllArea.GetSubArea(ddlCity.SelectedValue);
            ddlCountry.DataBind();
        }
    }
}