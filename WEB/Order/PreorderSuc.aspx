<%@ Page Title="" Language="C#" MasterPageFile="~/detail.master" AutoEventWireup="true" CodeFile="PreorderSuc.aspx.cs" Inherits="Order_PreorderSuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="fhead" Runat="Server">
预定成功
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="fbody" Runat="Server">
 <div id="paysuccess" style=" width:500px; min-height: 300px; margin: 20px auto;">
        <div style="font-size: 18px; font-weight: 600; color: #78A240;">
            预定成功!</div>
        <div  style="margin:20px 0;">
            <a href="/UserCenter/Orderdetail.aspx?orderid">进入 我的订单</a>
        </div>
        <div style="padding-top:10px; min-height:60px;
            background:url(/theme/default/image/greenflag.png) top left no-repeat;
             padding-left:40px;
             border:1px solid #ddd;
             "> <p>
             
             </p>
            
        </div>
    </div>
</asp:Content>

