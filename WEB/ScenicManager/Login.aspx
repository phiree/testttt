<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="AdminDefault" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>景区管理员登录</title>
    <link href="/theme/default/css/smlogin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <div id="mainlogin">
            <div id="title">
                景区后台管理系统
            </div>
            <div>
                <asp:Login ID="Login1" runat="server" OnLoggedIn="Login1_LoggedIn" cellpadding="0" cellspacing="20" class="tablemain" >
                    <LayoutTemplate>
                        <%--<table cellpadding="0" cellspacing="0" >--%>
                            <tr>
                                <td align="left" style="width:100px;">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass="username">操作员：</asp:Label>
                                </td>
                                <td align="center">
                                    <div class="txtusername">
                                        <asp:TextBox ID="UserName" runat="server" CssClass="txtusername2"></asp:TextBox>
                                    </div>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" CssClass="username">密码:</asp:Label>
                                </td>
                                <td>
                                    <div class="txtpwd">
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="txtpwd2"></asp:TextBox>
                                    </div>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        ErrorMessage="必须填写“密码”。" ToolTip="必须填写“密码”。" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <%--<tr>
                                <td>
                                </td>
                                <td>
                                    <asp:CheckBox ID="RememberMe" runat="server" Text="下次记住我。" />
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="center" colspan="2" style="color: Red;">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" 
                                        ValidationGroup="Login1" CssClass="btnlogin"  />
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
    <div style="margin: auto; text-align: center; margin-top: 200px; display: none;">
    </div>
    </form>
</body>
</html>
