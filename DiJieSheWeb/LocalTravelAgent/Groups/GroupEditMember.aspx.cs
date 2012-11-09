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
using System.Collections;
public partial class LocalTravelAgent_Groups_GroupEditMember : basepageDjsGroupEdit
{
    string[] fieldsName = { "tourertype", "realname", "phone", "idcardno", "othercardno", "memberid" };
    public string MemberJsonList = string.Empty;
    ExcelOplib.ExcelGroupOpr excel = new ExcelOplib.ExcelGroupOpr();

    BLL.BLLDJTourGroup bllGroup = new BLL.BLLDJTourGroup();
    BLL.BLLTourGroupMember bllGroupMember = new BLL.BLLTourGroupMember();

    DJ_TourGroupMember currentGroupMember;

    protected void Page_Load(object sender, EventArgs e)
    {

       
        if (!IsPostBack)
        {
            LoadData();
           
        }
    }

    private void LoadData()
    {
        a_link_1.HRef = "/LocalTravelAgent/Groups/GroupEditBasicInfo.aspx?groupid=" + Request["groupid"];
        a_link_2.HRef = "/LocalTravelAgent/Groups/GroupEditMember.aspx?groupid=" + Request["groupid"];
        a_link_3.HRef = "/LocalTravelAgent/Groups/GroupEditRoute.aspx?groupid=" + Request["groupid"];
      
        LoadSimpleData();
        LoadMemberList();
    }
    private void LoadMemberList()
    {
        rptMembers.DataSource = CurrentGroup.Members;
        rptMembers.DataBind();
    }

    protected void rptMembers_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.ToLower() == "edit")
        {

            currentGroupMember = bllGroupMember.GetOne(new Guid(e.CommandArgument.ToString()));
            Session["currentMember"] = currentGroupMember;
            pnlMemberEdit.Visible = true;
            LoadMemberForm();
        }
    }
    private void LoadMemberForm()
    {
        tbxIdCardNo.Text = currentGroupMember.IdCardNo;
        tbxName.Text = currentGroupMember.RealName;
        tbxSpecialCardNo.Text = currentGroupMember.SpecialCardNo;
        tbxPhone.Text = currentGroupMember.PhoneNum;
        try { rblMemberType.SelectedValue = ((int)currentGroupMember.MemberType).ToString(); }
        catch {
            rblMemberType.SelectedIndex = 0;
        }
    }
    private void UpdateMemberForm()
    {
        currentGroupMember.IdCardNo = tbxIdCardNo.Text.Trim();
        currentGroupMember.SpecialCardNo = tbxSpecialCardNo.Text.Trim();
        currentGroupMember.RealName = tbxName.Text.Trim();
        currentGroupMember.PhoneNum = tbxPhone.Text.Trim();

        MemberType mt;
        if (!Enum.TryParse<MemberType>(rblMemberType.SelectedValue, out mt))
        {
            mt = MemberType.成人游客;
        }
        currentGroupMember.MemberType = mt;

        currentGroupMember.DJ_TourGroup = CurrentGroup;

    }
    protected void btnSaveMember_Click(object s, EventArgs e)
    {
        currentGroupMember = (DJ_TourGroupMember)Session["currentMember"];
        if (currentGroupMember == null)
        {
            currentGroupMember = new DJ_TourGroupMember();
        }

        UpdateMemberForm();
        bllGroupMember.SaveOrUpdate(currentGroupMember);
        LoadMemberList();
        Session["currentMember"] = null;
        pnlMemberEdit.Visible = false;
        btnAddMember.Visible = true;
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "savesuc", "alert('保存成功')", true);

    }
    protected void btnAddMember_Click(object sender, EventArgs e)
    {
        ((Button)sender).Visible = false;
        pnlMemberEdit.Visible = true;
        tbxIdCardNo.Text = string.Empty;
        tbxName.Text = string.Empty;
        tbxPhone.Text = string.Empty;
        tbxSpecialCardNo.Text = string.Empty;
        rblMemberType.SelectedValue = "1";

    }

    /// <summary>
    /// 直接录入的加载
    /// </summary>
    private void LoadList()
    {
        rptMembers.DataSource = CurrentGroup.Members;
        rptMembers.DataBind();
    }

    private void LoadSimpleData()
    {

        tbxSimple.Text = bllGroupMember.GenerateSimpleStrings(CurrentGroup.Members);
    }

    private void UpdateSimple(TextBox tbx)
    {
        ///删除所有成员先--首先要做提醒
        string errMsg = string.Empty;
        bllGroup.UpdateMembersFromFormatedString(CurrentGroup, tbx.Text, out errMsg);
        if (!string.IsNullOrEmpty(errMsg))
        {
            lblSimpleMsg.ForeColor = System.Drawing.Color.Red;
            lblSimpleMsg.Text = errMsg;
            return;
        }
        lblSimpleMsg.ForeColor = System.Drawing.Color.Green;
        lblSimpleMsg.Text = "保存成功";
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        UpdateSimple(tbxSimple);
      
        // Response.Redirect("/localtravelagent/Groups/GroupList.aspx");
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string excelPath = "d:/";
        string fullname = fuMemberExcel.FileName.ToString();//直接取得文件名
        string url = fuMemberExcel.PostedFile.FileName.ToString();//取得上传文件路径
        string typ = fuMemberExcel.PostedFile.ContentType.ToString();//获取文件MIME内容类型
        string typ2 = fullname.Substring(fullname.LastIndexOf(".") + 1);//后缀名, 不带".".
        int size = fuMemberExcel.PostedFile.ContentLength;
        string message = string.Empty;

        #region 保存
        if (typ2 == "xlsx" || typ2 == "xls" || typ2 == "xlsm")
        {
            if (size <= 4134904)
            {
                fuMemberExcel.SaveAs(excelPath + "temp." + typ2);
                IList<ExcelOplib.Entity.GroupMember> memlist = excel.getMemberlist(excelPath + "temp." + typ2, out message);
                if (string.IsNullOrEmpty(message))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in memlist)
                    {
                        sb.Append(item.Memtype + "," + item.Memname + "," + item.Memphone + "," + item.Memid + "," + item.Cardno + "\n");
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
     
       // Response.Redirect("/localtravelagent/Groups/GroupList.aspx");
    }
}