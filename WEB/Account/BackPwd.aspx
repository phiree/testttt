<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BackPwd.aspx.cs" Inherits="Account_BackPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/theme/default/css/ResetPwd.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <div id="Resmain">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    重置密码:
                </td>
                <td>
                    <asp:TextBox ID="txtPwd" runat="server" CssClass="tbx tbxconpwd" TextMode="Password" style="vertical-align:middle">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="必填" ControlToValidate="txtPwd" ForeColor="Red" style=" margin-bottom:10px;"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    确认密码:
                </td>
                <td>
                    <asp:TextBox ID="txtPwd2" runat="server" CssClass="tbx tbxconpwd" TextMode="Password" style="vertical-align:middle">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtPwd2" ErrorMessage="必填" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="txtPwd2" ControlToValidate="txtPwd" ErrorMessage="两次密码必须相同" 
                        ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <div style="border:1px solid #E78834;width:130px;"><asp:Button ID="BtnReset" 
                            runat="server" Text="重置密码" CssClass="btn  btnlight regBtn" 
                            onclick="BtnReset_Click" /></div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

