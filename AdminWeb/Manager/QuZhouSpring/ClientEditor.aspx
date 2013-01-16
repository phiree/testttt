<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="ClientEditor.aspx.cs" Inherits="Manager_QuZhouSpring_ClientEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
<div class="detail_titlebg">
        接入网站编辑
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            编辑详情
        </div>
        <table>
            <tr>
                <td>
                    网站ID
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxFriendlyId"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    网站名称
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxClientName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    网站IP
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxRequestSource"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    是否启用
                </td>
                <td>
                    <asp:CheckBox runat="server" ID="cbxEnable" Checked="true" /></td>
                </td>
            </tr>
        </table>
        <asp:Button runat="server" ID="btnSave" Text="保存" btnSave_Click CssClass="btn"
            Style="margin-left: 350px;" />
    </div>
</asp:Content>

