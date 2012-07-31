<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Manager_AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网站管理员登录</title>
    <link href="/theme/default/css/managerlogin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <div id="mainlogin">
            <div id="title">
                中国旅游在线&nbsp;网站后台管理系统
            </div>
            <div>
                <asp:Login ID="Login1" runat="server" OnLoggingIn="Login1_LoggingIn" cellpadding="20"
                    cellspacing="40" class="tablemain" onloggedin="Login1_LoggedIn">
                    <LayoutTemplate>
                        <%--<table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">--%>
                        <tr>
                            <td align="left" style="padding: 0px margin:0px; width: 80px;">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass="username">登录名:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="UserName" runat="server" CssClass="txtusername"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                    ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" CssClass="username">密码:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="txtusername"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                    ErrorMessage="必须填写“密码”。" ToolTip="必须填写“密码”。" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <%--<tr>
                                            <td colspan="2">
                                                <asp:CheckBox ID="RememberMe" runat="server" Text="下次记住我。" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2" style="color: Red;">
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                            </td>
                                        </tr>--%>
                        <tr>
                            <td>
                            </td>
                            <td align="left" colspan="2">
                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" ValidationGroup="Login1"
                                    CssClass="btnlogin" />
                            </td>
                        </tr>
                        <%--</table>--%>
                    </LayoutTemplate>
                </asp:Login>
            </div>
        </div>
    </div>
    <div id="footer">
        <span>杭州笨牛信息科技有限公司</span>
    </div>
    <div style="display: none">
    </div>
    </form>
</body>
</html>
