<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LTALogin.aspx.cs" Inherits="LTALogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="x-ua-compatible" content="ie=8" />
    <script src="Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="/theme/bp/screen.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link href="/theme/bp/print.css" rel="stylesheet" type="text/css" media="print" />
    <link href="/theme/default/css/Login.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var PicIndex = 1;//图片顺序
        $(function () {
            changeBgPic();
        });
        function changeBgPic() {
            $("#loginbg").fadeOut(3000,changeSrc);
            $("#loginbg").fadeIn(3000);
            
            t = setTimeout("changeBgPic()", 15000);
        }
        function changeSrc() {
            if (PicIndex == 4)
                PicIndex = 1;
            $("#loginbg").attr("src", "/image/LoginBg_" + PicIndex + ".jpg");
            PicIndex++;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="LTA_main">
        <div class="top_border">
        </div>
        <div class="LTA_mainbody">
            <div class="LTA_left">
                <img src="theme/default/image/LTALogin_icon.gif" width="62px" height="52px" />
                <p>
                    地接社管理系统</p>
                <div class="LTA_login">
                    <asp:Login ID="Login1" runat="server" onloggedin="Login1_LoggedIn">
                        <LayoutTemplate>
                            <table cellpadding="0">
                                <tr>
                                    <td style=" text-align:right;padding-right:10px">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" ForeColor="#8E8E8E" Font-Size="13px" >用户名:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server" Width="140px" Height="20px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                            ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style=" text-align:right;padding-right:10px">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" ForeColor="#8E8E8E" Font-Size="13px" >密码:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="140px" Height="20px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                            ErrorMessage="必须填写“密码”。" ToolTip="必须填写“密码”。" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="text-align:left">
                                        <asp:CheckBox ID="RememberMe" runat="server" Text="下次记住我。" ForeColor="#8E8E8E" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color: Red;">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                <td></td>
                                    <td align="right" style="text-align:left">
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" style="margin-top:20px; background-color:#016A6D; color:White;font-weight:bold; text-align:center; width:75px;height:25px; line-height:22px;border:none; cursor:pointer;" Text="登录" ValidationGroup="Login1" />
                                    </td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                    </asp:Login>
                    <hr />
                    <asp:Button ID="BtnRegister" runat="server" CssClass="btn_register" 
                        onclick="BtnRegister_Click" />
                </div>
            </div>
            <div class="LTA_right">
                <img id="loginbg"  src="image/LoginBg_3.jpg" />
            </div>
            <hr class="LTA_Login_Sepert" />
            <div class="LTA_about">
                主办：浙江旅游信息中心&nbsp;&nbsp;12306&nbsp;&nbsp;技术支持：杭州笨牛信息技术有限公司&nbsp;&nbsp;0571-87801108
            </div>
        </div>
    </div>
    </form>
</body>
</html>
