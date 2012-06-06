<%@ Page Title="" Language="C#" MasterPageFile="~/detail.master" AutoEventWireup="true"
    CodeFile="CheckOut.aspx.cs" Inherits="Scenic_CheckOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  <script src="/Scripts/json2.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/Cart.js" type="text/javascript"></script>
    <script src="/Scripts/pages/cart.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="fhead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="fbody" runat="Server">
    <div id="itemlist">
        <div id="ilh">
            我的订单
        </div>
        <div id="ilBody">
            <asp:Repeater runat="server" ID="rptCart" OnItemDataBound="rptCart_ItemDataBound">
                <HeaderTemplate>
                    <table>
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
                            <span class="qtyCut">-</span><input class="qtyModify" runat="server" id="inputQty"
                                type="text" /><span class="qtyAdd">+</span>
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
                                共<span id="ticketsSum"></span>张门票
                            </td>
                        </tr>
                    </tfoot>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div id="tourinfo">
        <div id="tihead">
            指定游览者
        </div>
        <div id="contacts">
            <div>
                常用联系人</div>
            <asp:Repeater runat="server" ID="rptContacts">
              <ItemTemplate> <span cardid=""></span></ItemTemplate> 
            </asp:Repeater>
        </div>
        <asp:Repeater runat="server" ID="rptAssign">
            <HeaderTemplate>
                <table id="tilist">
                    <tr>
                        <td>
                            景区名称
                        </td>
                        <td>
                            游览者姓名
                        </td>
                        <td>
                            游览者身份证号码
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
    </div>
    <div id="payinfo">
    </div>
    <div id="payaction">
  
    </div>
</asp:Content>
