<%@ Page Title="" Language="C#" MasterPageFile="~/order.master" AutoEventWireup="true" CodeFile="QuZhouorderFail.aspx.cs" Inherits="QZOrder_Fail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" Runat="Server">
    <script src="/Scripts/json2.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/pages/Cart.js" type="text/javascript"></script>
    <script src="/Scripts/pages/cartpage.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphstate" Runat="Server">
    <div class="cartbread" style="margin-left:40px"></div>
    <div class="stateimg2" ></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" Runat="Server">
        <div id="paysuccess" style=" width:97%; min-height: 300px; margin: 15px auto; background:url('/theme/default/image/newversion/paysucbg.gif' ); background-position:top; background-repeat:no-repeat; display:inline-block;">
        <div style="font-size: 18px; font-weight: 600; color: #EB7286; margin:50px 0px 30px 130px;">
           抢票失败!</div>
        <div  style="margin:20px 0px 0px 130px;">
        <asp:Literal runat="server" ID="lblMsg"></asp:Literal>
          
        </div>

        </div>
</asp:Content>

