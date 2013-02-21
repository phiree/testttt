<%@ Page Title="登录"   Language="C#" MasterPageFile="~/detail.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head">
    <link href="/Content/page/login.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        $(function () {
            $("#topbar").empty();
            $(".textEntry").focus();
            $(".passwordEntry").keypress(function (e) {
                if (e.charCode == 13) {
                    $(".loginbtn").click();
                }
            });
        }); 
           
    </script>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="cphmain">
    <div id="loginmain">
        <div class="loginmainleft">
            <div class="lmbg">
                <span>没有用户名？</span>
                <a href="/Account/Register.aspx">免费注册</a>
            </div>
        </div>
        <div class="loginmainright">
            <div class="logindiv">
                <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false"
        OnLoggedIn="LoginUser_LoggedIn">
        <LayoutTemplate>
                <table>
                    <tr>
                        <td colspan="3" style="background-color:#DFEDD5; height:30px; padding-left:20px; font-weight:bold; font-size:14px;">
                           用户登录
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left:20px;">
                            用户名:
                        </td>
                        <td >
                            <asp:TextBox TabIndex=1 ID="UserName" runat="server" CssClass="textEntry tbx"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                CssClass="failureNotification" ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。"
                                ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left:20px;">
                            密码:
                        </td>
                        <td>
                            <asp:TextBox  ID="Password"  TabIndex=2 runat="server" CssClass="passwordEntry tbx" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:CheckBox ID="RememberMe" Text="下次自动登录" CssClass="cbremember" runat="server" />
                        </td>
                        <td>
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td colspan="2"  style="padding-bottom:10px">
                            <div style="border:1px solid #55A930;width:100px; float:left;"><asp:Button ID="LoginButton"  TabIndex=3  CssClass=" loginbtn  " runat="server" CommandName="Login" style="border:0px none solid" 
                                Text="登录" ValidationGroup="LoginUserValidationGroup" /></div><a href="ResetPwd.aspx" style="color:#838383; margin-left:20px; color:#55A930; float:left; margin-top:5px;">忘记密码？</a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="border-top:1px solid #DFEDD5; padding-left:20px; padding-top:10px;">
                            <span>使用合作方式登录:</span>
                            <div id="lg3rd">  
                            <a  href="/Account/QQweiboSDKHandle.ashx">
                                <img alt="腾讯微博登录" style="d" src="/Img/tengxunweibo-logo.png" /></a>
                                </div>  
                        </td>
                    </tr>
                </table>
             <div id="error">
                    <span class="failureNotification">
                        <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                    </span>
                    <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
                        ValidationGroup="LoginUserValidationGroup" />
                </div>
        </LayoutTemplate>
    </asp:Login>
            </div>
        </div>
    </div>
    <div style="display:none">
  
    </div>
</asp:Content>

