using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LocalTravelAgent_GroupRoute : System.Web.UI.Page
{
    //public const string GROUPID = "GROUPID";
    private string excelPath = "d:/upload/";
    //private string groupid;

    protected void Page_Load(object sender, EventArgs e)
    {
        //groupid = Request["id"];
        //if (!string.IsNullOrEmpty(groupid))
        //{

        //}
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string fullname = FileUpload1.FileName.ToString();//直接取得文件名
        string url = FileUpload1.PostedFile.FileName.ToString();//取得上传文件路径
        string typ = FileUpload1.PostedFile.ContentType.ToString();//获取文件MIME内容类型
        string typ2 = fullname.Substring(fullname.LastIndexOf(".") + 1);//后缀名, 不带".".
        int size = FileUpload1.PostedFile.ContentLength;

        #region 保存
        //if (File.Exists(url))
        //{
        //    Response.Write("<script>alert('文件已存在 !')</script>");
        //}
        //else
        //{
        if (typ2 == "xlsx" || typ2 == "xls")
        {
            if (size <= 4134904)
            {
                FileUpload1.SaveAs(excelPath + "temp." + typ2);
                Label1.Text = excelPath + "temp." + typ2;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('你的文件超过限制大小!')", true);
                return;
            }
        }
        else
        {
            Label1.Text = "上传文件格式不正确.";
            return;
        }
        //}
        #endregion
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Dijiesheweb/LocalTravelAgent/GroupRoute.aspx");
    }
}