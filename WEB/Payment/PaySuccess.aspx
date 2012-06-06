<%@ Page Title="" Language="C#" MasterPageFile="~/detail.master" AutoEventWireup="true"
    CodeFile="PaySuccess.aspx.cs" Inherits="Payment_PaySuccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="fhead" runat="Server">
    支付完成
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="fbody" runat="Server">
    <div id="paysuccess" style=" width:500px; min-height: 300px; margin: 20px auto;">
        <div style="font-size: 18px; font-weight: 600; color: #78A240;">
            支付成功!</div>
        <div  style="margin:20px 0;">
            <a href="/UserCenter/Orderdetail.aspx?orderid=<%=OrderId %>">查看订单详情</a>
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
