using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.IO;

public partial class ScenicManager_UpdateScenicImg : System.Web.UI.Page
{
    BLLScenicImg bllsenicimg = new BLLScenicImg();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["siid"] != null)
            {
                bind();
            }
        }
    }
    protected void btnok_Click(object sender, EventArgs e)
    {
        ScenicImg si = new ScenicImg();
        if (Request.QueryString["siid"] != null)
            si = bllsenicimg.GetSiBySiid(int.Parse(Request.QueryString["siid"]));
        si.Description = txtDesc.Text;
        si.ImgType = (ImgType)(ddlpictype.SelectedIndex + 1);
        si.Scenic = Master.Scenic;
        si.Title = txtTitle.Text;
        bool flag = false;
        string ss = "";
        string strPath = "";
        if (si.ImgType == ImgType.主图)
        {
            strPath = Server.MapPath("\\ScenicImg\\mainimg");
        }
        else
        {
            strPath = Server.MapPath("\\ScenicImg\\detailimg");
        }
        if (Request.QueryString["siid"] == null)
        {
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
                    string time = Guid.NewGuid() + System.IO.Path.GetExtension(hfimgurl.Value).ToLower().Trim();
                    //string[] files = Directory.GetFiles();
                    File.Copy(Server.MapPath(string.Format("~/ScenicManager/Upload")) + "\\" + hfimgurl.Value, strPath + "\\" + time);
                    ss = time;
                    si.Name = ss;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('上传的图片格式不正确')", true);
                    return;
                }
            }
        }
        else
        {
            if (hfimgurl.Value != "")
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
                    string time = Guid.NewGuid() + System.IO.Path.GetExtension(hfimgurl.Value).ToLower().Trim();
                    //string[] files = Directory.GetFiles();
                    File.Copy(Server.MapPath(string.Format("~/ScenicManager/Upload")) + "\\" + hfimgurl.Value, strPath + "\\" + time);
                    ss = time;
                    si.Name = ss;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('上传的图片格式不正确')", true);
                    return;
                }
            }
        }
        bllsenicimg.SaveOrUpdate(si);
        //bind();
        //绑定景区表中的photo字段
        if (bllsenicimg.GetSiByType(Master.Scenic, 1).Count > 0)
        {
            Scenic sc = Master.Scenic;
            sc.Photo = bllsenicimg.GetSiByType(Master.Scenic, 1)[0].Name;
            new BLLScenic().UpdateScenicInfo(sc);
        }
        Response.Redirect("/scenicmanager/ScenicPictureShow.aspx");
    }

    private void bind()
    {
        int siid = int.Parse(Request.QueryString["siid"]);
        ScenicImg si = bllsenicimg.GetSiBySiid(siid);
        if (si.ImgType == ImgType.主图)
        {
            uploadimg.Src = "/ScenicImg/mainimg/" + si.Name;
        }
        else
        {
            uploadimg.Src = "/ScenicImg/detailimg/" + si.Name;
        }
        ddlpictype.SelectedIndex = (int)si.ImgType - 1;
        txtTitle.Text = si.Title;
        txtDesc.Text = si.Description;
    }
}