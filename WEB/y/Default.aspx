<%@ Page Title="" Language="C#" MasterPageFile="~/y/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="qumobile_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" runat="Server">
    <script src="/Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/InlineTip.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("[id$='UserName']").InlineTip({ "tip": '用户名' });
            $("[id$='Password']").InlineTip({ "tip": '111111' });
        });
        function changeType() {
            $("[id$='Password']").attr("type", "password");
        }   
        
    </script>
    <script type="text/javascript">
        
    </script>
    <style type="text/css">
       .tbx
       {
           -moz-border-radius:5px; -webkit-border-radius:5px; border-radius:5px;
           
           height:25px;
           width:190px;
           padding-left:10px;
       }
       .login
       {
           margin-left:30px;
       }
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <div class="login">
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        <asp:Login ID="scenicManagerLogin" runat="server" 
            onloggedin="scenicManagerLogin_LoggedIn" >
            <LayoutTemplate>
                <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="10px">
                              
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server" CssClass="tbx"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                            ControlToValidate="UserName" ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。" 
                                            ValidationGroup="scenicManagerLogin">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password"  CssClass="tbx"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                            ControlToValidate="Password" ErrorMessage="必须填写“密码”。" ToolTip="必须填写“密码”。" 
                                            ValidationGroup="scenicManagerLogin">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2">
                                        <asp:Button ID="LoginButton" runat="server" style="margin-left:10px;" CssClass="btn" CommandName="Login" Text="登录" 
                                            ValidationGroup="scenicManagerLogin" />
                                            <asp:CheckBox ID="RememberMe" runat="server" Text="下次记住我。" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color:Red;">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:Login>
    </div>
</asp:Content>
