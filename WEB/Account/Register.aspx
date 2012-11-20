<%@ Page Title="注册" Language="C#" MasterPageFile="../detail.master" AutoEventWireup="true"
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
<asp:Content runat="server" ContentPlaceHolderID="cphmain">
    <div style="border: 1px solid #72B854">
        <div id="regcontainer">
            <p class="regtitle">
                注册新用户</p>
            <table>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtBoxLoginname"
                            runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        用户名:
                    </td>
                    <td>
                        <asp:TextBox ID="txtBoxLoginname" TabIndex="1" CssClass="tbx tbxusername" runat="server"></asp:TextBox>
                    </td>
                    <td style="color: #8D8D8D">
                        &nbsp;支持使用中文、字母、数字
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBoxPwd"
                            ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        密码:
                    </td>
                    <td>
                        <asp:TextBox ID="txtBoxPwd" TabIndex="2" CssClass="tbx" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ErrorMessage="密码必须六位以上" ControlToValidate="txtBoxPwd" Display="Dynamic" 
                            ForeColor="Red" ValidationExpression=".{6}.*"></asp:RegularExpressionValidator>
                    </td>
                    <td style="color: #8D8D8D">
                        &nbsp;6个以上字符，支持使用字母、数字
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBoxPwd"
                            ErrorMessage="*" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        确认密码:
                    </td>
                    <td>
                        <asp:TextBox ID="tbxPwdConfirm" TabIndex="3" runat="server" CssClass="tbx tbxconpwd"
                            TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtBoxPwd"
                            ControlToValidate="tbxPwdConfirm" Display="Dynamic" ErrorMessage="两次输入不一致" ForeColor="Red"></asp:CompareValidator>
                    </td>
                    <td style="color: #8D8D8D">
                        &nbsp;请再次输入密码
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                            ControlToValidate="txtPost" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        联系邮箱:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPost" TabIndex="4" runat="server" CssClass="tbx tbxconpwd"></asp:TextBox>
                    </td>
                    <td style="color: #8D8D8D">
                        &nbsp;请输入常用邮箱，方便找回密码
                    </td>
                </tr>
                <tr>
                    <td class="lp" colspan="2" style="text-align: right">
                        <div style="border: 1px solid #55A930; width: 130px; float: right;">
                            <asp:Button TabIndex="4" class="btn regBtn" ID="btnReg" runat="server" Text="同意以下并提交"
                                OnClick="btnRegist_Click" /></div>
                    </td>
                </tr>
            </table>
            <div class="agreement">
                <p>
                    旅游在线网站服务条款</p>
                <div class="agreeinfo">
                    1.服务条款的确认<br />
                    &nbsp;&nbsp;&nbsp;旅游在线网站的所有权与运作权归杭州笨牛技术有限公司(以下简称"旅游在线")所有。本服务条款具<br />
                    &nbsp;&nbsp;&nbsp;有法律约束力。<br />
                    &nbsp;&nbsp;&nbsp;一旦您点选"注册"并通过注册程序，即表示您自愿接受本协议之所有条款，并已成为在线网的注册用户。<br />
                    &nbsp;&nbsp;&nbsp;用户在享用旅游在线服务的同时，同意接受同程网络会员服务提供的各类信息服务。<br />
                    <br />
                    2.服务内容<br />
                    &nbsp;&nbsp;&nbsp;旅游在线服务的具体内容由旅游在线根据实际情况提供，旅游在线对其所提供之服务拥有最终解释权。
                </div>
            </div>
        </div>
        <div id="regcontainer" style="display: none;">
            <div>
                <%--&nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />--%>
            </div>
        </div>
    </div>
</asp:Content>
