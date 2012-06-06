using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.IO;
public partial class ScenticManager_OnlineSell_UploadContract : basepage
{
    BLLScenic bllScenic = new BLLScenic();

    protected void Page_Load(object sender, EventArgs e)
    {
        string paramModule = Request["module"];
        string paramScenicId = Request["scenicid"];
        int moduleId, scenicId;
        if (!(int.TryParse(paramModule, out moduleId) || int.TryParse(paramScenicId, out scenicId)))
        {
            ErrHandler.Redirect(ErrType.ParamIllegal);
        }
        ContractImg temp=bllScenic.GetContractImg((new BLLMembership().GetScenicAdmin((Guid)CurrentUser.ProviderUserKey)).Scenic.Id);
        if (temp == null) return;
        ScenicImg.ImageUrl = "/ScenicImg/" + temp.Imgloc;
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string strPath = Server.MapPath("\\ScenicImg");

        string fileExt = System.IO.Path.GetExtension(hfimgurl.Value);
        if (fileExt == ".jpg" || fileExt == ".gif" || fileExt == ".png")
        {
            try
            {
                var filename = DateTime.Now.ToString("MMddhhmmss")+DateTime.Now.Millisecond.ToString() +fileExt;
                string[] files = Directory.GetFiles(Server.MapPath(string.Format("/ScenicManager/Upload")));
                File.Copy(files[0], strPath + "\\" + filename);
                new BLLScenic().UploadContractImg(new ContractImg()
                {
                    Imgloc = filename,
                    Scenic = new BLLMembership().GetScenicAdmin((Guid)CurrentUser.ProviderUserKey).Scenic,
                    ScenicModule = ScenicModule.SellOnLine
                });
            }
            catch (Exception ex)
            {
                Label1.Text = "发生错误：" + ex.Message.ToString();
            }
        }
        else
        {
            Label1.Text = "只允许上传jpg、gif文件！";
        }
    }
}