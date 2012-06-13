<%@ Page Title="" Language="C#" MasterPageFile="~/detail.master" AutoEventWireup="true" CodeFile="RefundApply.aspx.cs" Inherits="Order_RefundApply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="fhead" Runat="Server">
 订单退款
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="fbody" Runat="Server">
  退款总金额:

  <asp:Button runat="server" ID="btnApply" OnClick="btnApply_Click"  Text="申请退款"/>

</asp:Content>

