using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using FineUI;

public partial class ActivityManager_Partner_iframe_window : System.Web.UI.Page
{
    BLLActivityPartner bllAp = new BLLActivityPartner();
    BLLTourActivity bllTa = new BLLTourActivity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindData();
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        ActivityPartner ap;
        if (Request.QueryString["paId"] != null)
        {
            Guid id = Guid.Parse(Request.QueryString["paId"]);
            ap = bllAp.GetOne(id);
        }
        else
        {
            ap = new ActivityPartner();
        }
        //ap.NeedCheckTime = cbxNeedCheckTime.Checked;
        ap.Name = txtName.Text;
        ap.PartnerCode = txtPartnerCode.Text;
        //ap.OnlyControlTotalAmount = ckOnlyControlTotalAmount.Checked;
        //ap.Enabled = ckEnabled.Checked;
        Guid taId = Guid.Parse(Request.QueryString["actId"]);
        ap.TourActivity = bllTa.GetOne(taId);
        bllAp.SaveOrUpdate(ap);
        string returnUrl="/ActivityManager/Partner_iframe_window.aspx?actId="+taId.ToString()+"&paId="+ap.Id.ToString();
        Alert.ShowInTop("编辑成功", "信息", "window.location='" + returnUrl + "'");
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('保存成功');window.location='/manager/touractivity/partnerList.aspx?actId=" + Request.QueryString["actId"] + "'", true);
    }

    private void bindData()
    {
        if (Request.QueryString["paId"] != null)
        {
            Guid id = Guid.Parse(Request.QueryString["paId"]);
            ActivityPartner ap = bllAp.GetOne(id);
            txtName.Text = ap.Name;
            txtPartnerCode.Text = ap.PartnerCode;
            //ckEnabled.Checked = ap.Enabled;
            //cbxNeedCheckTime.Checked = ap.NeedCheckTime;
            //ckOnlyControlTotalAmount.Checked = ap.OnlyControlTotalAmount;
        }
    }
}