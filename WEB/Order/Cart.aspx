<%@ Page Title="" Language="C#" MasterPageFile="~/detail.master" AutoEventWireup="true"
    CodeFile="Cart.aspx.cs" Inherits="Scenic_Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/theme/default/css/global.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/cart.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/json2.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/Cart.js" type="text/javascript"></script>
    <script src="/Scripts/pages/cart.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        $(function () {
            $("#cart").hide();
            var cart = new Cart();
            $("#cticketsSum").text(cart.TotalQty);
            var totalOnlinePrice = 0;
            var totalPreorderPrice = 0;
            $(".orderlist tbody tr").each(function () {
                var that = this;
                var qty = parseInt($(that).find(".qtyModify").val());
                var priceorder = parseFloat($(that).find(".priceorder").text());
                var priceonline = parseFloat($(that).find(".priceonline").text());
                totalOnlinePrice += qty * priceonline;
                totalPreorderPrice += qty * priceorder;
            });
            $("#totalonline").text(totalOnlinePrice);
            $("#totalpreorder").text(totalPreorderPrice);
        });
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="fhead" runat="Server">
    <div id="orderstep">
        <span class="stepcurrent">购物车</span><span>>确认订单</span><span>>完成订单</span></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="fbody" runat="Server">
    <asp:Panel runat="server" ID="pnlCart">
        <div id="itemlist">
            <div id="ilBody">
                <asp:Repeater runat="server" ID="rptCart" OnItemDataBound="rptCart_ItemDataBound">
                    <HeaderTemplate>
                        <table class="orderlist">
                            <thead>
                                <tr>
                                    <td>
                                        景区名称
                                    </td>
                                    <td>
                                        预订价
                                    </td>
                                    <td>
                                        在线价
                                    </td>
                                    <td>
                                        购买数量
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input type="hidden" class="hdId" value='<%#Eval("Id") %>' />
                                <a href='/scenic/?tid=<%#Eval("Id") %>'>
                                    <%#Eval("Scenic.Name") %></a>
                            </td>
                            <td>
                                <span class="priceorder">
                                    <asp:Literal runat="server" ID="liPriceOrder"></asp:Literal></span>
                            </td>
                            <td>
                                <span class="priceonline">
                                    <asp:Literal runat="server" ID="liPriceOnline"></asp:Literal>
                                </span>
                            </td>
                            <td>
                                <span class="qtyCut qtyBtn">-</span><input class="qtyModify" runat="server" id="inputQty"
                                    type="text" /><span class="qtyAdd qtyBtn">+</span>
                            </td>
                            <td>
                                <span class="delete">删除</span>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                        <tfoot>
                            <tr>
                                <td colspan="5">
                                    <div>
                                        <span>共<strong id="cticketsSum"></strong>张门票</span> <span>在线支付价:<strong id="totalonline"></strong>
                                        </span><span>预订价:<strong id="totalpreorder"></strong> </span>
                                    </div>
                                </td>
                            </tr>
                        </tfoot>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div id="payaction">
            <a href="/" class="btn btngray">继续购物</a> <a class="btn btnlight" href="checkout.aspx">
                确认订单</a>
        </div>
    </asp:Panel>
    <asp:Panel CssClass="emptycart" runat="server" ID="pnlEmptyCart">
      <div style="padding:0; margin:20px auto; " > 
       <span>您的购物车内还没有门票,<a href="/" style="color:Blue; font-size:large;">现在去挑选吧!</a></span>
      </div>
    </asp:Panel>
</asp:Content>
