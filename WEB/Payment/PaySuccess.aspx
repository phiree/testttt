<%@ Page Title="" Language="C#" MasterPageFile="~/detail.master" AutoEventWireup="true"
    CodeFile="PaySuccess.aspx.cs" Inherits="Payment_PaySuccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    支付完成
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <div id="paysuccess" style=" width:500px; min-height: 300px; margin: 20px auto;">
        <div style="font-size: 18px; font-weight: 600; color: #78A240;">
            支付成功!</div>
        <div  style="margin:20px 0; font-weight:600;">
            <a href="/UserCenter/Orderdetail.aspx?orderid=<%=OrderId %>">查看订单详情</a>
        </div>
        
    </div>
</asp:Content>
