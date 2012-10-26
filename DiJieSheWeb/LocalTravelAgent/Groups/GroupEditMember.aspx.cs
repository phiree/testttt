using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using Model;
using System.Text;
public partial class LocalTravelAgent_Groups_GroupEditMember : basepageDjsGroupEdit
{
    string[] fieldsName = { "tourertype", "realname", "phone", "idcardno", "othercardno", "memberid" };
    public string MemberJsonList = string.Empty;
    ExcelOplib.ExcelGroupOpr excel = new ExcelOplib.ExcelGroupOpr();

    BLL.BLLDJTourGroup bllGroup = new BLL.BLLDJTourGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();

        }
    }

    private void LoadData()
    {
        BuildJsonData();
        LoadSimpleData();
    }
    private void LoadSimpleData()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        foreach (Model.DJ_TourGroupMember member in CurrentGroup.Members)
        {
            sb.Append(member.MemberType.ToString());
            sb.Append(",");
            sb.Append(member.RealName.ToString());
            sb.Append(",");
            sb.Append(member.PhoneNum.ToString());
            sb.Append(",");

            sb.Append(member.IdCardNo.ToString());
            sb.Append(",");
            sb.Append(member.SpecialCardNo.ToString());
            if (CurrentGroup.Members.IndexOf(member) < CurrentGroup.Members.Count - 1)
            {
                sb.AppendLine(Environment.NewLine);
            }
        }
        tbxSimple.Text = sb.ToString();

    }
    private void BuildJsonData()
    {
        MemberJsonList = BLL.BLLDJTourGroup.BuildJsonForMemberList(CurrentGroup.Members);
        // JavaScriptSerializer serializer = new JavaScriptSerializer();
        //MemberJsonList= serializer.Serialize(CurrentGroup.Members);

    }


    private void UpdateSimple(TextBox tbx)
    {
        ///删除所有成员先--首先要做提醒
        foreach (DJ_TourGroupMember member in CurrentGroup.Members)
        {
            bllGroup.Delete(member);
        }
       //保存新的成员
        string[] arrStrMember = tbx.Text.Split(Environment.NewLine.ToCharArray());

        string errMsg=string.Empty;
       foreach (string s in arrStrMember)
       {
           if (string.IsNullOrEmpty(s)) continue;
           DJ_TourGroupMember member = ParseMember(s, out errMsg);
           if (!string.IsNullOrEmpty(errMsg))
           {
               lblSimpleMsg.ForeColor = System.Drawing.Color.Red;   
               lblSimpleMsg.Text = errMsg;
               break; 
           }
           bllGroup.Save(member);
       }
       if (string.IsNullOrEmpty(errMsg))
       {
           lblSimpleMsg.ForeColor = System.Drawing.Color.Green;
           lblSimpleMsg.Text = "保存成功";
       }


    }
    private Model.DJ_TourGroupMember ParseMember(string strMember, out string errMsg)
    {
        errMsg = "";
        string[] strArrMember = strMember.Split(',');
        if (strArrMember.Length != 5)
        {
            errMsg = "格式有误.源:" + strMember + ".";
            return null;
        }
        Model.DJ_TourGroupMember member = new Model.DJ_TourGroupMember();
        Model.MemberType memberType;
        string strType = strArrMember[0];
        if (!Enum.TryParse<MemberType>(strType, out memberType))
        {
            errMsg = "游客类型有误.请输入六个类型中的一个.源:" + strMember;
            return null;
        }
        member.MemberType = memberType;

        member.RealName = strArrMember[1];

        member.PhoneNum = strArrMember[2];
        member.IdCardNo = strArrMember[3];
        member.SpecialCardNo = strArrMember[4];
        member.DJ_TourGroup = CurrentGroup;

        return member;
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        UpdateSimple(tbxSimple);
        BuildJsonData();
        Response.Redirect("/localtravelagent/Groups/GroupList.aspx");
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string excelPath="d:/";
        string fullname = fuMemberExcel.FileName.ToString();//直接取得文件名
        string url = fuMemberExcel.PostedFile.FileName.ToString();//取得上传文件路径
        string typ = fuMemberExcel.PostedFile.ContentType.ToString();//获取文件MIME内容类型
        string typ2 = fullname.Substring(fullname.LastIndexOf(".") + 1);//后缀名, 不带".".
        int size = fuMemberExcel.PostedFile.ContentLength;
        string message=string.Empty;

        #region 保存
        if (typ2 == "xlsx" || typ2 == "xls" || typ2 == "xlsm")
        {
            if (size <= 4134904)
            {
                fuMemberExcel.SaveAs(excelPath + "temp." + typ2);
                IList<ExcelOplib.Entity.GroupMember> memlist=excel.getMemberlist(excelPath + "temp." + typ2, out message);
                if (string.IsNullOrEmpty(message))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in memlist)
                    {
                        sb.Append(item.Memtype + "," + item.Memname + "," + item.Memphone + "," + item.Memid + ","+item.Cardno+"\n");
                    }
                    tbxExcel.Text = sb.ToString();
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('" + message + "')", true);
                }
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
        #endregion
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        UpdateSimple(tbxExcel);
        BuildJsonData();
        Response.Redirect("/localtravelagent/Groups/GroupList.aspx");
    }
}