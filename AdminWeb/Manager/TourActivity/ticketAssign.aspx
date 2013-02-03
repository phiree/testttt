<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="ticketAssign.aspx.cs" Inherits="Manager_TourActivity_ticketAssign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
门票分配<br />
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Selected="True" Text="按时间维度" Value="按时间维度"></asp:ListItem>
        <asp:ListItem  Text="按供应商维度" Value="按供应商维度"></asp:ListItem>
        <asp:ListItem Text="按门票维度" Value="按门票维度"></asp:ListItem>
    </asp:RadioButtonList>

</asp:Content>

