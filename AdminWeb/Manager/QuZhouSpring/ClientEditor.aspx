<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="ClientEditor.aspx.cs" Inherits="Manager_QuZhouSpring_ClientEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
<table>
<tr><td>接入商名称</td><td><asp:TextBox runat="server" ID="tbxClientName"></asp:TextBox></td></tr>
<tr><td>接入商接入ID</td><td><asp:TextBox runat="server" ID="tbxFriendlyId"></asp:TextBox></td></tr>
<tr><td>请求IP或域名</td><td><asp:TextBox runat="server" ID="tbxRequestSource"></asp:TextBox></td></tr>
<tr><td>启用</td><td><asp:CheckBox runat="server" ID="cbxEnable" Checked="true" /></td></tr>

</table>
<asp:Button runat="server" ID="btnSave" OnClick="btnSave_Click" Text="保存" />
</asp:Content>

