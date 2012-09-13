<%@ Page Title="" Language="C#" MasterPageFile="~/mobile.master" AutoEventWireup="true" CodeFile="jiangshanlianpiao_mobile.aspx.cs" Inherits="topic_jiangshanlianpiao_mobile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>江郎山-廿八都-清漾联票-中国旅游在线</title>
 
    <script type="text/javascript">

        var cart = new Cart();
        function AddToCart(btn) {
            
            cart.AddToCart(55, 1);
            window.location.href = "/order/cart.aspx";
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
<img style="border:0;margin:0;padding:0;" usemap="#linkOrder" src="../Img/jiangshanlianpiao2.jpg" alt="江山联票" />
<a href="../Scenic/QuickBook.aspx">现在订票</a>

<map id="orderMap" name="linkOrder">

<!--用<map>标记设定图像地图的作用区域，并用name属性爲图像起一个名字-->

<area shape=rect coords=230,38,310,60 href="/scenic/quickbook.aspx">
</map>
</asp:Content>

