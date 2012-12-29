<%@ Page Title="" Language="C#" MasterPageFile="~/detail.master" AutoEventWireup="true" CodeFile="ResetPwd.aspx.cs" Inherits="Account_ResetPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/theme/default/css/ResetPwd.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("#tr2").css("display", "none");
            $("[id$='BtnSend']").click(function () {
                $.get("ResetPwd.ashx?name=" + escape($("[id$='txtUserName']").val()), function (data) {
                    if (data == "wrong") {
                        alert("无此账号！")
                        $("#tr1").css("display", "");
                        $("#tr2").css("display", "none");
                    }
                    else {
                        $("#tr1").css("display", "none");
                        $("#tr2").css("display", "");
                        $("[id$='BtnSend']").css("display", "none");
                    }
                });
                return false;
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <div id="Resmain">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr id="tr1">
                <td>
                    用户名:
                </td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="tbx tbxconpwd">
                    </asp:TextBox>
                </td>
            </tr>
            <tr id="tr2">
                <td colspan="2">
                    <span class="resettext">重设密码已发送到你的邮箱，请查收!</span>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <div style="border:1px solid #E78834;width:130px;"><asp:Button ID="BtnSend" runat="server" Text="找回密码" CssClass="btn  btnlight regBtn" /></div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

