<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="ClientList.aspx.cs" Inherits="Manager_QuZhouSpring_ClientManger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
<asp:Repeater runat="server">
<ItemTemplate>
<%#Eval("Name") %>
</ItemTemplate>
</asp:Repeater>
<div>
 
</div>
</asp:Content>

