using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class ScenicManager_OnlineSell_Uploadscenicprice : basepage
{
    BLLContractScenicPrice bllcsp = new BLLContractScenicPrice();
    BLLScenic bllscenic = new BLLScenic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.UrlReferrer.AbsolutePath == "/ScenicManager/OnlineSell/PrintScenicPrice.aspx")
        {
            ScenicCheckProgress scp = bllscenic.GetCheckProgressByscidandmouid(Master.Scenic.Id, 1);
            scp.CheckStatus = CheckStatus.Applied_2;
            bllscenic.UpdateCheckState(scp);
        }
    }
    protected void btnok_Click(object sender, EventArgs e)
    {
        string strPath = Server.MapPath("\\ScenicImg");
        string savefilename = "";
        if (fuwj.HasFile)
        {
            string fileExt = System.IO.Path.GetExtension(fuwj.FileName);
            if (fileExt == ".jpg" || fileExt == ".gif" || fileExt == ".png")
            {
                try
                {
                    var filename = DateTime.Now.ToString("MMddhhmmss") + DateTime.Now.Millisecond.ToString() + fileExt;
                    savefilename = filename;
                    fuwj.SaveAs(strPath + "\\" + filename);
                }
                catch
                {

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('只允许上传jpg,gif,png格式的文件');", true);
                return;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('请选择上传的文件');", true);
            return;
        }

        Model.ScenicAdmin user = new BLL.BLLMembership().GetScenicAdmin((Guid)CurrentUser.ProviderUserKey);
        Model.Scenic scenic = user.Scenic;
        ContractImg ci = new ContractImg();
        ci.Imgloc = savefilename;
        ci.Scenic = scenic;
        if (bllscenic.GetContractImg(scenic.Id) != null)
        {
            ci.Id = bllscenic.GetContractImg(scenic.Id).Id;
        }
        ci.ScenicModule = ScenicModule.SellOnLine;
        bllscenic.UploadContractImg(ci);
        
    }
    protected void btnchange_Click(object sender, EventArgs e)
    {
        ScenicCheckProgress scp = bllscenic.GetCheckProgressByscidandmouid(Master.Scenic.Id, 1);
        scp.CheckStatus = CheckStatus.Applied_3;
        bllscenic.UpdateCheckState(scp);
        Response.Redirect("/ScenicManager/OnlineSell/Pricesetting.aspx");
    }
}