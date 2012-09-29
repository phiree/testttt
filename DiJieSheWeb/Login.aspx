<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="x-ua-compatible" content="ie=8" />
    <script src="/Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="/theme/bp/screen.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link href="/theme/bp/print.css" rel="stylesheet" type="text/css" media="print" />
    <link href="/theme/default/css/Login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <img src="theme/default/image/login_01.gif" />
            </td>
            <td>
                <img src="theme/default/image/login_02.gif" />
            </td>
            <td>
                <img src="theme/default/image/login_03.gif" />
            </td>
        </tr>
        <tr>
            <td>
                <img src="theme/default/image/login_04.gif" />
            </td>
            <td>
                <div id="login">
                    <asp:Login runat="server" ID="lg" OnLoggedIn="lg_LoggedIn">
                        <LayoutTemplate>
                            <table cellspacing="0" cellpadding="0" class="tblogin">
                                <tr >
                                    <td align="center" colspan="2" style="height:80px;">
                                        <p class="LoginTilte">
                                            浙江旅游&nbsp;&nbsp;单位管理平台</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;height:45px;">
                                        <asp:Label ID="LalUserName" runat="server" CssClass="LalUserName" AssociatedControlID="UserName">用户名:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server" Width="151px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                            ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。" ValidationGroup="lg">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;height:45px">
                                        <asp:Label ID="LalPwd" runat="server" AssociatedControlID="Password" CssClass="LalUserName">密码:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="151px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                            ErrorMessage="必须填写“密码”。" ToolTip="必须填写“密码”。" ValidationGroup="lg">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height:40px; text-align:center;">
                                        <asp:CheckBox ID="RememberMe" runat="server" Text="记住密码" style="margin-right:35px;color:#2C84AC; vertical-align:middle;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color: Red;height:20px;">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False" 
                                            ViewStateMode="Enabled"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="height:75px; text-align:center;">
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="登录" ValidationGroup="lg" CssClass="btn_login" style="margin-right:20px;" />
                                        <asp:Button ID="Register" runat="server" Text="申请加入" CssClass="btn_login" />
                                    </td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                    </asp:Login>
                </div>
            </td>
            <td>
                <img src="theme/default/image/login_06.gif" />
            </td>
        </tr>
        <tr>
            <td>
                <img src="theme/default/image/login_15.gif" />
            </td>
            <td>
                <img src="theme/default/image/login_16.gif" />
            </td>
            <td>
                <img src="theme/default/image/login_17.gif" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <p class="login_bottom">
                    &nbsp;&nbsp;&nbsp;&nbsp;平台开发:杭州笨牛信息&nbsp;&nbsp;&nbsp;&nbsp;0571-87801108
                </p>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
