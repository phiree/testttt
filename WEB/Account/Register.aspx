<%@ Page Title="注册" Language="C#" MasterPageFile="~/detail.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head">
    <link href="/theme/default/css/register.css" rel="stylesheet" type="text/css" />
    <script language="javascript">
        $(function () {
            $("#cbxAgree").change(function () {
                var checked = $(this).attr("checked");
                if (checked) {
                    $(".btnReg").removeClass("btndisabled");
                    $(".btnReg").attr("disabled", "");
                }
                else {
                    $(".btnReg").addClass("btndisabled");
                    $(".btnReg").attr("disabled", "disabled");
                }
            });
            $("#topbar").empty();

            $(".tbxusername").focus();
            $(".tbxconpwd").keypress(function (e) {
                if (e.charCode == 13) {
                    $(".regBtn").click();
                }
            });
        });
    </script>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="fhead">
    欢迎注册
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="fbody">
    <div class="block" id="regcontainer">
        <div>
            <%--&nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />--%>
        </div>
        <table>
            <tr>
                <td>
                    用户名:
                </td>
                <td>
                    <asp:TextBox ID="txtBoxLoginname" TabIndex=1  CssClass="tbx tbxusername" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtBoxLoginname"
                        runat="server" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                        密码:
                </td>
                <td>
                    <asp:TextBox ID="txtBoxPwd"  TabIndex=2 CssClass="tbx" runat="server" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBoxPwd" ErrorMessage="必填"
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    确认密码:
                </td>
                <td>
                    <asp:TextBox ID="tbxPwdConfirm"  TabIndex=3 runat="server" CssClass="tbx tbxconpwd" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBoxPwd" ErrorMessage="必填"
                        Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtBoxPwd"
                        ControlToValidate="tbxPwdConfirm" Display="Dynamic" ErrorMessage="两次输入不一致" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="lp ar" colspan="2">
                    <input type="checkbox" checked="checked" id="cbxAgree" /><label for="cbxAgree">我同意<a
                        href="#">用户服务条款</a></label>
                </td>
            </tr>
            <tr>
                <td class="lp" colspan="2">
                    <asp:Button  TabIndex=4  class="btn  btnlight regBtn" ID="btnReg" runat="server" Text="注册" OnClick="btnRegist_Click" />
                </td>
                
            </tr>
           
        </table>
       
    </div>
</asp:Content>
