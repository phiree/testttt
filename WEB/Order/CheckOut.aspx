<%@ Page Title="" Language="C#" MasterPageFile="~/detail.master" AutoEventWireup="true"
    CodeFile="CheckOut.aspx.cs" Inherits="Scenic_CheckOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>订单结算</title>
    <link href="/theme/default/css/global.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/checkout.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/cart.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/json2.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/Cart.js" type="text/javascript"></script>
    <script src="/Scripts/VeriIdCard.js" type="text/javascript"></script>
    <script src="/Scripts/pages/checkout.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(function () {
           
        });
     

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="fhead" runat="Server">
 <div id="orderstep"><span >购物车</span><span class="stepcurrent">>确认订单</span><span>>完成订单</span></div> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="fbody" runat="Server">
    <div id="itemlist">
        <div  class="tihead">
            门票清单</div>
        <div id="ilBody">
            <asp:Repeater runat="server" ID="rptCart" OnItemDataBound="rptCart_ItemDataBound">
                <HeaderTemplate>
                    <table id="sceniclist"  class="orderlist">
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
                                 <span tid='<%#Eval("Id") %>' class="qtyfinal"></span>
                            </td>
                           
                        </tr>
                   
                </ItemTemplate>
                <FooterTemplate>
                </tbody>
                    <tfoot>
                        <tr>
                            <td colspan="4">
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
    <div id="tourinfo">
        <div id="tihead" class="tihead">
            填写游客信息</div>
        <div id="contactlist">
            <asp:Repeater runat="server" ID="rptContacts">
            <HeaderTemplate>
            <div id="contactHead">常用联系人</div>
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
                    <td>
                        <%#Eval("Scenic.Name") %>
                    </td>
                    <td>
                        游览者姓名:<input type="text" tid='<%#Eval("Id") %>' class="assignName" />
                    </td>
                    <td>
                        身份证号:<input type="text"  tid='<%#Eval("Id")%>' class="assignIdcard" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
    </div>
    <div id="payinfo">
        <div id="payonline" pricetype="3" class="priceselection">
            <span class="price">
                <input type="radio"  name="price" />
                在线支付:<em id="bpriceonline">123</em>元</span><span class="pricedesc">通过支付宝支付,享受最优惠价格.</span>
            <div class="clear">
            </div>
        </div>
        <div id="preorder" pricetype="2" class="priceselection">
            <span class="price">
                <input type="radio" name="price" />
                预订总价:<em id="bpricepreorder">234</em>元</span><span class="pricedesc">预订门票,无需立即支付,鼠标一点,实惠又方便</span>
            <div class="clear">
            </div>
        </div>
    </div>
    <div id="payaction">
        <span class="btnlight btn" id="btnCheckout">确认订单</span>
    </div>
</asp:Content>
