<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="ImportTravelagency.aspx.cs" Inherits="Manager_ImportTravelagency" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
<asp:TextBox runat="server" ID="tbxAddress"  Text="d:\\TravelInfo.xml"></asp:TextBox>
<asp:Button runat="server" ID="btnImport" Text="导入"  OnClick="btnImport_Click"/>
<asp:Label runat="server" ID="lblDesc"></asp:Label>
</asp:Content>

