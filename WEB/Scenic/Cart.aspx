<%@ Page Title="" Language="C#" MasterPageFile="~/detail.master" AutoEventWireup="true"
    CodeFile="Cart.aspx.cs" Inherits="Scenic_Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/theme/default/css/cart.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/json2.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/Cart.js" type="text/javascript"></script>
    <script src="/Scripts/pages/cart.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="fhead" runat="Server">
    <span class="stepcurrent">购物车</span><span>确认订单</span><span>完成订单</span>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="fbody" runat="Server">
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
                                    操作
                                </td>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <input type="hidden" class="hdId" value='<%#Eval("Scenic.Id") %>' />
                            <%#Eval("Scenic.Name") %>
                        </td>
                        <td>
                            <asp:Literal runat="server" ID="liPriceOrder"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal runat="server" ID="liPriceOnline"></asp:Literal>
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
                    <tfoot>
                        <tr>
                            <td colspan="5">
                              <div><span>共<strong id="ticketsSum"></strong>张门票</span> <span>在线支付价:<strong></strong> </span> <span>预订价:<strong></strong> </span> </div>
                            </td>
                        </tr>
                    </tfoot>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div id="payaction">
     <a href="/"><img src="/theme/default/image/btncontinue.png" alt="继续购物" /></a> <a href="checkout.aspx"><img alt="确认订单" src="/theme/default/image/btnorder.png" /></a>
    </div>
</asp:Content>
