<%@ Page Language="C#" MasterPageFile="~/order.master" AutoEventWireup="true"
    CodeFile="CheckOut.aspx.cs" Inherits="Scenic_CheckOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
    <title>订单结算</title>
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-1.9.1.custom.min.js" type="text/javascript"></script>
    <link href="/theme/default/css/global.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/checkout.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/cart.css" rel="stylesheet" type="text/css" />
    <link href="/Scripts/jqueryplugin/jqueryui/css/ui-lightness/jquery-ui-1.9.1.custom.min.css"
        rel="stylesheet" type="text/css" />
    <script src="/Scripts/json2.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/pages/Cart.js" type="text/javascript"></script>
    <script src="/Scripts/VeriIdCard.js" type="text/javascript"></script>
    <link href="/theme/default/css/cart.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/pages/checkout.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/InlineTip.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphstate" runat="Server">
    <div class="cartbread">
        您选择的门票列表</div>
    <div class="stateimg"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <div id="itemlist">
        <div id="ilBody">
            <asp:Repeater runat="server" ID="rptCart" OnItemDataBound="rptCart_ItemDataBound">
                <HeaderTemplate>
                    <table id="orderlist" class="orderlist" style="padding: 0px; margin: 0px; width: 100%">
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
                                    在线支付价
                                </td>
                                <td>
                                    购买数量
                                </td>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <input type="hidden" class="hdId" value='<%#Eval("Id") %>' />
                            <a runat=server id="hrefScenic" href='<%# "/Tickets/"+Eval("Scenic.Area.SeoName")+"/"+Eval("Scenic.SeoName")+".html"%>'>
                                <%#Eval("DisplayNameOfOwner") %></a>
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
                        <td>
                            <span tid='<%#Eval("Id") %>' class="qtyfinal"></span>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                    <tfoot style="background-color: White">
                        <tr>
                            <td colspan="6">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="text-align:right;color:Black;padding-right:50px;">
                                订<strong style="font-size: 20px;margin-left:15px;margin-right:15px; color:#E8360F; vertical-align:text-bottom; font-size:20px; line-height:18px;" id="cticketsSum"></strong>张门票
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="border-top: 1px solid #CDCDCD">
                                <div style="color:Black">
                                    <span style="margin-right:50px;">景区现付价合计:<strong
                                        style="font-size: 20px; margin-left:10px;margin-right:10px;color:#E8360F" id="totalonline"></strong>元&nbsp; </span><span>在线支付合计:<strong
                                            style="font-size: 20px;margin-left:10px;margin-right:10px;color:#E8360F" id="totalpreorder"></strong> </span>元
                                </div>
                            </td>
                        </tr>
                    </tfoot>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div id="tihead" class="tihead">
            填写游客信息<span>景区根据游客信息确认在线支付或者预订的情况，请准确填写。</span></div>
    <div id="tourinfo">
        <div id="contactlist">
            <asp:Repeater runat="server" ID="rptContacts">
                <HeaderTemplate>
                    <div id="contactHead">
                        常用联系人</div>
                    <div id="contactBody">
                </HeaderTemplate>
                <ItemTemplate>
                    <div>
                        <a class="assignitem" href="javascript:void" idcard='<%#Eval("IdCard") %>' cid='<%#Eval("Id") %>'>
                            <%#Eval("Name") %></a>
                        <!--<a href="javascript:void" class="assignitem" style="display:none" all="">全部指派</a>-->
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <asp:Repeater runat="server" ID="rptAssign">
            <HeaderTemplate>
                <table id="tilist">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td style="padding-left: 20px; width: 25%">
                        <%#Eval("DisplayNameOfOwner")%>
                        <span class="veriblock"></span>
                    </td>
                    <td style="width: 35%;">
                        游览者姓名:&nbsp;<input type="text" tid='<%#Eval("Id") %>' class="assignName" style="vertical-align: middle" />
                        <span class="veriname"></span>
                    </td>
                    <td style="width: 50%;">
                        身份证号:&nbsp;<input type="text" tid='<%#Eval("Id")%>' onblur="veriidcard()" class="assignIdcard"
                            style="vertical-align: middle" />
                        <span class="veritext"></span>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
    </div>
    <div runat="server" id="divPaymentChoose">
    <div class="tihead" style="margin-top:20px;margin-bottom:10px;">
            选择付款方式</div>
    <div id="payinfo">
        <div id="payonline" pricetype="3" class="priceselection">
            <span class="price">
                <input type="radio" name="price" />
                网上订购总价:<em id="bpricepreorder">123</em>元</span><span class="pricedesc">通过支付宝支付,享受网上订购优惠价.</span>
            <div class="clear">
            </div>
        </div>
        <div id="preorder" pricetype="2" class="priceselection" style="border-bottom: 2px solid #AAA;">
            <span class="price">
                <input type="radio" name="price" checked="checked" />
                景区现付总价:<em id="bpriceonline">234</em>元</span><span class="pricedesc">预订门票,无需立即支付,鼠标一点,实惠又方便</span>
            <div class="clear">
            </div>
        </div>
        <div id="nhorder" pricetype="2" class="priceselection" style="border-bottom: 2px solid #AAA;">
            <span class="price">
                <input type="radio" name="price"  />
                农行在线支付价:<em style="margin-left: 10px;margin-right: 10px;font-size: 24px;color: #EC6B9E;">50</em>元</span><span class="pricedesc">在线使用农行卡支付,享受农行在线支付价</span>
            <div class="clear">
            </div>
        </div>
        <div id="nhpreorder" pricetype="2" class="priceselection">
            <span class="price">
                <input type="radio" name="price"  />
                农行网上预定价:<em style="margin-left: 10px;margin-right: 10px;font-size: 24px;color: #EC6B9E;">52</em>元</span><span class="pricedesc">预订门票，使用农行卡到景区现付，享受农行网上预定价</span>
            <div class="clear">
            </div>
        </div>
    </div>
    </div>
    <div id="payaction">
        <span class="btntkok" id="btnCheckout">确认订单</span>
    </div>
</asp:Content>
