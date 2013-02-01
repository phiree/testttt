<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Manager_TourActivity_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
活动管理
<table>
<tr>
<td>活动名称</td><td><asp:TextBox runat="server" ID="tbxActivityName"></asp:TextBox></td>
</tr>
<tr>
<td>开始日期(门票销售的起止时间)</td><td><asp:TextBox runat="server" ID="TextBox1"></asp:TextBox></td>

</tr>
<tr>
<td>开始日期(门票销售的起止时间)</td><td><asp:TextBox runat="server" ID="TextBox2"></asp:TextBox></td>

</tr>
</table>
</asp:Content>

