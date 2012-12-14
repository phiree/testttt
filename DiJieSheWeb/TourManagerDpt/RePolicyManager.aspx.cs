using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class TourManagerDpt_RePolicyManager : basepageMgrDpt
{
    BLLDJ_Recommand bllRec = new BLLDJ_Recommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindPolicy();
        }
    }

    private void BindPolicy()
    {
        DJ_Recommand recommand= bllRec.GetByGovId(CurrentDpt);
        if(recommand!=null)
            txtPolicy.Text = recommand.RewardPolicy;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DJ_Recommand recommand = bllRec.GetByGovId(CurrentDpt);
        if (recommand == null)
        {
            recommand = new DJ_Recommand();
        }
        recommand.DJ_GovManageDepartment = CurrentDpt;
        recommand.RewardPolicy = txtPolicy.Text;
        if (fuFile.HasFile)
        {
            string strFileExten = System.IO.Path.GetExtension(fuFile.FileName).ToLower().Trim();
            string filename = Guid.NewGuid()  + strFileExten;
            recommand.UploadFile = filename;
            fuFile.SaveAs(Server.MapPath("/PolicyFile/" + filename));
        }
        bllRec.SaveOrUpdate(recommand);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('保存成功')", true);
    }
}