<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_12301_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Content/page/12301.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <div id="top">
            <h3>12301协助订票平台</h3>
        </div>
        <div id="login">
            <h3 style="text-align:center">12301用户登录</h3>
            <table border="0" cellpadding="5" cellspacing="0">
                <tr>
                    <td>
                        账号：
                    </td>
                    <td>
                        <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        密码:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="BtnOk" runat="server" Text="登录" onclick="BtnOk_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
