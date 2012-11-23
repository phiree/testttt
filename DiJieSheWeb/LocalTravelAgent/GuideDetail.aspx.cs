using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LocalTravelAgent_GuideDetail : System.Web.UI.Page
{
    string id = string.Empty;
    BLL.BLLDJGroup_Worker bllgroupworker = new BLL.BLLDJGroup_Worker();
    BLL.BLLWorker bllworker = new BLL.BLLWorker();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
            id = Request.QueryString[0];
        if (!IsPostBack)
        {
            BindDetail();
        }
    }

    private void BindDetail()
    {
        if (!string.IsNullOrEmpty(id))
        {
            var source = bllworker.GetWorkers8Multi(id, null, null, null, null, Model.DJ_GroupWorkerType.导游, null);
            if (source.Count > 0)
            {
                lblname.Text = source[0].Name;
                txtPhone.Text = source[0].Phone;
                txtidcard.Text = source[0].IDCard;
                txtGuideid.Text = source[0].SpecificIdCard;
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        var workers = bllgroupworker.Get8Multi(id, null, null, null, null, Model.DJ_GroupWorkerType.导游, null, null);
        if (workers.Count > 0)
        {
            var worker = workers[0];
            worker.DJ_Workers.Phone = txtPhone.Text;
            worker.DJ_Workers.IDCard = txtidcard.Text;
            worker.DJ_Workers.SpecificIdCard = txtGuideid.Text;
            worker.DJ_Workers.CompanyBelong = tbxBelong.Text;
            bllgroupworker.UpdateData(worker);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改成功, 返回列表页!')", true);
            Response.Redirect("/LocalTravelAgent/GuideList.aspx");
        }
    }
}