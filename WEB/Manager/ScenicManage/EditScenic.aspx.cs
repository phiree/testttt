using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class Manager_ScenicManage_EditScenic : System.Web.UI.Page
{

    BLLScenic bllScenic = new BLLScenic();
    BLLArea bllArea = new BLLArea();
    bool IsNew = false;
    int scenicId;
    Scenic scenic;
    protected void Page_Load(object sender, EventArgs e)
    {


        string strParamId = Request["Id"];
        if (string.IsNullOrEmpty(strParamId))
        {
            IsNew = true;
            scenic = new Scenic();

        }
        else if (!int.TryParse(strParamId, out scenicId))
        {
            BLL.ErrHandler.Redirect(BLL.ErrType.ParamIllegal);
        }
        else
        {
            IsNew = false;
            scenic = bllScenic.GetScenicById(scenicId);
            if (scenic == null)
            {
                ErrHandler.Redirect(ErrType.ObjectIsNull);
            }

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
        tbxAddress.Text = scenic.Address;
        tbxArea.Text = scenic.Area.Id.ToString();
        tbxBookNote.Text = scenic.BookNote;
        tbxDesc.Text = scenic.Desec;
        tbxDetail.Text = scenic.ScenicDetail;
        tbxName.Text = scenic.Name;
        tbxOrder.Text = scenic.ScenicOrder.ToString();
        tbxSeoName.Text = scenic.SeoName;
        tbxTransfer.Text = scenic.Trafficintro;
        rblLevel.SelectedValue = scenic.Level;
    }
    public void UpdateForm()
    {
        scenic.Address = tbxAddress.Text;
        scenic.Area =bllArea.GetAreaByAreaid(Convert.ToInt32( tbxArea.Text));
        scenic.BookNote = tbxBookNote.Text;
        scenic.Desec = tbxDesc.Text;
        scenic.ScenicDetail = tbxDetail.Text;
        scenic.Name = tbxName.Text;
        scenic.ScenicOrder = int.Parse(tbxOrder.Text);
        scenic.SeoName = tbxSeoName.Text;
        scenic.Trafficintro = tbxTransfer.Text;
        scenic.Level = rblLevel.SelectedValue;
    }
    public void Save()
    {
        UpdateForm();
        bllScenic.UpdateScenicInfo(scenic);

        if (IsNew)
        {
            Response.Redirect("EditScenic.aspx?id=" + scenic.Id);
        }
        else {
            ScriptManager.RegisterStartupScript(this,this.GetType(),"updatealert","alert('更新成功')",true);
        }
       

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        Save();
    }
}