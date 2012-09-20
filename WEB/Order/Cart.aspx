<%@ Page Title="" Language="C#" MasterPageFile="~/order.master" AutoEventWireup="true"
    CodeFile="Cart.aspx.cs" Inherits="Scenic_Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
    <link href="/theme/default/css/global.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/cart.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/json2.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/Cart.js" type="text/javascript"></script>
    <script src="/Scripts/pages/cart.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        $(function () {
            $("#cart").hide();
            init();
        });
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphstate" runat="Server">
    <div class="cartbread">购物车</div>
    <img class="stateimg" src="/theme/default/image/newversion/cart_state1.png"/>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <asp:Panel runat="server" ID="pnlCart">
        <div id="itemlist">
            <div id="ilBody">
                <asp:Repeater runat="server" ID="rptCart" OnItemDataBound="rptCart_ItemDataBound">
                    <HeaderTemplate>
                        <table class="orderlist" cellpadding=0 cellspacing=0>
                            <thead>
                                <tr>
                                    <td>
                                        景区名称
                                    </td>
                                    <td>
                                        门票种类
                                    </td>
                                    <td>
                                        原价
                                    </td>
                                    <td>
                                        景区现付价
                                    </td>
                                    <td>
                                        网上订购价
                                    </td>
                                    <td>
                                        购买数量
                                    </td>
                                    <td>
                                        操作
                                    </td>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr onmousemove="carttdon(this)" onmouseout="carttdout(this)">
                            <td>
                                <input type="hidden" class="hdId" value='<%#Eval("Id") %>' />
                                <a runat="server" id="ahref" href='/Tickets/<%#Eval("Scenic.Area.SeoName") %>/<%#Eval("Scenic.SeoName") %>.html'>
                                    <%#Eval("Scenic.Name") %></a>
                            </td>
                            <td>
                                <%# Eval("Name") %>
                            </td>
                            <td>
                                <%# Eval("TicketPrice[0].Price","{0:0}")%>
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
                            <td style="width:200px">
                                <span class="qtyCut qtyBtn" style="margin-left:20px;_margin-left:10px; margin-top:2px; background:url('/Img/btnjian2.jpg'); background-repeat:no-repeat;border:0px;"></span><input class="qtyModify" runat="server" id="inputQty"
                                    type="text" /><span class="qtyAdd qtyBtn" style="background:url('/Img/btnjian2.jpg'); background-repeat:no-repeat;border:0px; margin-top:2px;">+</span>
                            </td>
                            <td>
                                <span class="delete">删除</span>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <%--<FooterTemplate>
                        
                        <tfoot>
                            <tr>
                                <td colspan="7">
                                    <div>
                                        <span>共<strong style=" font-size:20px" id="cticketsSum"></strong>张门票</span> <span>网上订购价:<strong style=" font-size:20px" id="totalonline"></strong>
                                        </span>元&nbsp;<span>景区现付价:<strong style=" font-size:20px" id="totalpreorder"></strong> </span>元
                                    </div>
                                </td>
                            </tr>
                        </tfoot>
                        
                    </FooterTemplate>--%>
                </asp:Repeater>
                </tbody>
                </table>
            </div>
        </div>
        <div class="tkcount">
            订<strong id="cticketsSum">3</strong>张门票
        </div>
        <div class="tksum">
            <div class="tksuminfo">景区现付价合计：<strong id="totalpreorder"></strong>元</div>
            <div class="tksuminfo2">在线支付合计：<strong id="totalonline"></strong>元</div>
        </div>
        <div id="payaction">
            <a class="cartbtnok" href="checkout.aspx">确认订单</a><a href="/" class="cartbtngoon">继续购物</a> 
        </div>
    </asp:Panel>
    <asp:Panel CssClass="emptycart" runat="server" ID="pnlEmptyCart">
      <div style=" text-align :center; margin:20px auto; " > 
       <span>您的购物车内还没有门票,<a href="/" style="color:Blue; font-size:large;">现在去挑选吧!</a></span>
      </div>
    </asp:Panel>
</asp:Content>
