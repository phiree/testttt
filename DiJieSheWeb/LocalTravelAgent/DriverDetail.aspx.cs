using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LocalTravelAgent_DriverDetail : System.Web.UI.Page
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
            var source = bllworker.GetWorkers8Multi(id, null, null, null, null, Model.DJ_GroupWorkerType.司机, null);
            if (source.Count > 0)
            {
                tbxName.Text = source[0].Name;
                txtPhone.Text = source[0].Phone;
                txtidcard.Text = source[0].IDCard;
                txtdriverid.Text = source[0].SpecificIdCard;
                tbxBelong.Text = source[0].DJ_Dijiesheinfo.Name;
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        var workers = bllworker.GetWorkers8Multi(id, null, null, null, null, Model.DJ_GroupWorkerType.司机, null);
        if (workers.Count >0)
        {
            var worker = workers[0];
            worker.Name = tbxName.Text;
            worker.CompanyBelong = tbxBelong.Text;
            worker.Phone = txtPhone.Text;
            worker.IDCard = txtidcard.Text;
            worker.SpecificIdCard = txtdriverid.Text;
            bllworker.UpdateWorkers(worker);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改成功, 返回列表页!')", true);
            Response.Redirect("/LocalTravelAgent/DriverList.aspx");
        }
    }

}