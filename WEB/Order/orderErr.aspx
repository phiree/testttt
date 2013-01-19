<%@ Page Title="" Language="C#" MasterPageFile="~/detail.master" AutoEventWireup="true" CodeFile="orderErr.aspx.cs" Inherits="Order_orderErr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphmain" Runat="Server">
 <div id="paysuccess" style=" width:500px; min-height: 300px; margin: 20px auto;">
        <div class="error" style="font-size: 18px; font-weight: 600; color: #78A240;">
            订单出错!</div>
        <div  style="margin:20px 0;">
           很抱歉,网站未能正确处理您的订单, 错误已经记录在案,我们将尽快解决,您也可以致电我们,询问详情.
        </div>
        
    </div>
</asp:Content>

