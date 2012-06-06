using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class ScenicManager_ScenicPicture : System.Web.UI.Page
{
    BLLScenicImg bllscenicimg = new BLLScenicImg();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnok_Click(object sender, EventArgs e)
    {
        ScenicImg si = new ScenicImg();
        si.Description = txtDesc.Text;
        si.ImgType = (ImgType)(ddlpictype.SelectedIndex+1);
        si.Scenic = Master.Scenic;
        si.Title = txtTitle.Text;
        bool flag = false;
        string ss = "";
        string strPath = Server.MapPath("\\ScenicImg");

        if (hfimgurl.Value == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('请上传图片')", true);
            return;
        }
        else
        {
            string strFileExten = System.IO.Path.GetExtension(hfimgurl.Value).ToLower().Trim();
            string[] extFile = { ".jpg", ".gif", ".png", ".bmp" };

            for (int i = 0; i < extFile.Length; i++)
            {
                if (strFileExten == extFile[i])
                    flag = true;
            }
            if (flag)//是图片格式
            {
                string time =Guid.NewGuid() + System.IO.Path.GetExtension(hfimgurl.Value).ToLower().Trim();
                //string[] files = Directory.GetFiles();
                File.Copy(Server.MapPath(string.Format("~/ScenicManager/Upload"))+"\\"+hfimgurl.Value, strPath + "\\" + time);
                ss = time;
                si.Name = ss;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('上传的图片格式不正确')", true);
                return;
            }
        }
        bllscenicimg.SaveOrUpdate(si);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('上传成功')", true);
    }
}