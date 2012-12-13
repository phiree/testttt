<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <% if(false) 
{ %>
      <script src="/Scripts/jquery-1.6.4-vsdoc.js" type="text/javascript"></script>
<% } %>
  
    <meta http-equiv="x-ua-compatible" content="ie=8" />
    <script src="/Scripts/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.9.2.min.js" type="text/javascript"></script>
    <link href="/theme/bp/screen.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link href="/theme/bp/print.css" rel="stylesheet" type="text/css" media="print" />
    <link href="/theme/default/css/Login.css" rel="stylesheet" type="text/css" />
    <link href="/Content/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script language="javascript">
        function PopMsg(msg, type, redirecturl,autoClose) {

            var ele = "<div id='popMsg'></div>";
            $("form").append(ele);
            $("#popMsg").html(msg);
            var sec = 0;
            var outSec = 4;
            var interval = null;

            $("#popMsg").dialog({
                modal: true,

                open: function (event, ui) {
                    sec = 0;
                    if (autoClose) {
                        interval = setInterval(closeTimer, 1000);
                    }
                    $('.ui-widget-overlay').bind('click', function () { $("#popMsg").dialog('close'); });
                }
                ,
                close: function (event, ui) {
                    if (redirecturl != null && redirecturl + "" != "undefined") {
                        window.location.href = redirecturl;
                    }
                }

            });

            function closeTimer() {
                if (sec >= outSec) {
                    $('#popMsg').dialog('close');
                    interval = null;
                }
                else {
                  $('#popMsg').dialog({ title: outSec-sec });
                    sec++;
                }
            }
        }
    </script>
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
                    <asp:Login runat="server" ID="lg">
                        <LayoutTemplate>
                            <table cellspacing="0" cellpadding="0" class="tblogin">
                                <tr >
                                    <td align="center" colspan="2" style="height:80px;">
                                        <p class="LoginTilte">
                                            旅游在线后台管理</p>
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
                                         <asp:Button ID="Button1" OnClick="democlick" runat="server" Text="Button" />
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
                
            </td>
        </tr>

    </table>
    
    </form>
</body>
</html>
