<%@ Page Title="登录"   Language="C#" MasterPageFile="~/detail.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head">
    <link href="/theme/default/css/login.css" rel="stylesheet" type="text/css" />
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
<asp:Content runat="server" ContentPlaceHolderID="fhead">
  用户登录
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="fbody">
    <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false"
        OnLoggedIn="LoginUser_LoggedIn">
        <LayoutTemplate>
            <div id="loginbox">
              <div id="error">
                    <span class="failureNotification">
                        <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                    </span>
                    <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
                        ValidationGroup="LoginUserValidationGroup" />
                </div>
                <table>
                    <tr>
                        <td>
                            用户名:
                        </td>
                        <td>
                            <asp:TextBox TabIndex=1 ID="UserName" runat="server" CssClass="textEntry tbx"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                CssClass="failureNotification" ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。"
                                ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <div id="regtop">
                                <a href="/Account/Register.aspx">没有用户名?现在注册</a></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
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
                            <a href="ResetPwd.aspx" style="color:#838383; margin-left:40px;">忘记密码</a>
                        </td>
                        <td>
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td colspan="2">
                            <asp:Button ID="LoginButton"  TabIndex=3  CssClass="btn loginbtn  btnlight" runat="server" CommandName="Login"
                                Text="登录" ValidationGroup="LoginUserValidationGroup" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td colspan="2">
                            <span>其他登陆方式:</span>
                            <div id="lg3rd">  
                            <a  href="/Account/QQweiboSDKHandle.ashx">
                                <img alt="腾讯微博登录" style="d" src="/Img/tengxunweibo-logo.png" /></a>
                                </div>  
                        </td>
                    </tr>
                </table>
              
            </div>
        </LayoutTemplate>
    </asp:Login>
</asp:Content>
