<%@ Page Title="" Language="C#" MasterPageFile="~/qumobile/MasterPage.master" AutoEventWireup="true" CodeFile="CheckTicket.aspx.cs" Inherits="qumobile_CheckTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
    <style type="text/css"> 
        #checkticket
        {
            width:320px;
            margin:0px auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <div id="checkticket">
    <asp:TextBox ID="txtinfo" runat="server" Width="250px"></asp:TextBox><asp:Button
        ID="btnSearch" runat="server" Text="查询" />
    </div>
</asp:Content>

