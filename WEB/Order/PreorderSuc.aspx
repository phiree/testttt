<%@ Page Title="" Language="C#" MasterPageFile="~/order.master" AutoEventWireup="true" CodeFile="PreorderSuc.aspx.cs" Inherits="Order_PreorderSuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" Runat="Server">
    <link href="/theme/default/css/global.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/cart.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/json2.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/Cart.js" type="text/javascript"></script>
    <script src="/Scripts/pages/cart.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphstate" Runat="Server">
    <div class="cartbread" style="margin-left:40px">完成订单</div>
    <img class="stateimg" src="/theme/default/image/newversion/cart_state3.png"/>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" Runat="Server">
        <div id="paysuccess" style=" width:97%; min-height: 300px; margin: 15px auto; background:url('/theme/default/image/newversion/paysucbg.gif' ); background-position:top; background-repeat:no-repeat; display:inline-block;">
        <div style="font-size: 18px; font-weight: 600; color: #EB7286; margin:50px 0px 30px 130px;">
           预订成功!</div>
        <div  style="margin:20px 0px 0px 130px;">
            您的订单已完成，你可以在<a style="color:#8E569B; font-weight:bold;margin-left:5px;margin-right:5px;" href="/UserCenter/">个人中心</a>查看订票信息，感谢您订购了景区门票
        </div>

        </div>
</asp:Content>

