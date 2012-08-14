<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/uc.master" AutoEventWireup="true"
    CodeFile="AccountInfo.aspx.cs" Inherits="UserCenter_AccountInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../theme/default/css/ucdefault.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ucContent" runat="Server">
    <div id="ainfo">
        <table border="0" cellpadding="5" cellspacing="0">
            <tr>
                <td>
                    登陆名称
                </td>
                <td>
                    <asp:TextBox ID="txtBoxLoginname" runat="server" CssClass="atxt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtBoxLoginname"
                        runat="server" ErrorMessage="必填"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    真实名称
                </td>
                <td>
                    <asp:TextBox ID="txtBoxName" runat="server" CssClass="atxt"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    身份证号
                </td>
                <td>
                    <asp:TextBox ID="txtBoxIdcard" runat="server" CssClass="atxt"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtBoxIdcard"
                        ValidationExpression="^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{4}$|^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$"
                        runat="server" ErrorMessage="身份证号码无效"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    联系电话
                </td>
                <td>
                    <asp:TextBox ID="txtBoxPhone" runat="server" CssClass="atxt"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    联系地址
                </td>
                <td>
                    <asp:TextBox ID="txtBoxAddress" runat="server" CssClass="atxt" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnModify" runat="server" OnClick="btnModify_Click" CssClass="achangebtn" Text="保存修改" />
                </td>
            </tr>
        </table>
    </div>
    <div style="display: none">
        <div>
            登陆名称:
            <br />
        </div>
        <div>
            真实名称:
        </div>
        <div>
            身份证号:
        </div>
        <div>
            联系电话:
        </div>
        <div>
            联系地址:
        </div>
        <div>
            <asp:Button ID="btnCancel" runat="server" ValidationGroup="cancel" Text="取消" /></div>
    </div>
</asp:Content>
