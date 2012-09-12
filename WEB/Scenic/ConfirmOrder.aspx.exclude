<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConfirmOrder.aspx.cs" Inherits="Scenic_ConfirmOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Styles/Confirm.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <div id="confirmMain">
        <p class="confiminfo">
            您的确认信息
        </p>
        <p class="wenziinfo" id="quereninfo" runat="server">
            您的购买信息已经确认,应付款<span><asp:Literal runat="server" ID="liTotal"></asp:Literal></span>元,请立即付款</p>
            <asp:Button ID="btnGoToPay" runat="server" CssClass="btnpay" Text="去付款" 
            onclick="btnGoToPay_Click" />
    </div>
</asp:Content>

