<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="EnterpriseList.aspx.cs" Inherits="Admin_EnterpriseList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">

<asp:Repeater runat="server" ID="rpt" OnItemCommand="rpt_ItemCommand" OnItemDataBound="rpt_ItemDataBound">
<HeaderTemplate><table></HeaderTemplate>
<ItemTemplate>
<tr>
<td><%#Eval("Name") %></td><td>指派管理员<asp:TextBox runat="server" ID="tbxUserName"></asp:TextBox>
<asp:Button runat="server" CommandArgument='<%#Eval("Id") %>' Text="确定" ID="btnadmin" CommandName="AddAdmin" />
</td>
</tr>

</ItemTemplate>
<FooterTemplate></table></FooterTemplate>
</asp:Repeater>
</asp:Content>

