<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Scenic_Default" %>

<%@ Register TagPrefix="self" Namespace="TourControls" Assembly="TourControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
    <%--<script type="text/javascript" src="https://maps.google.com/maps/api/js?sensor=true">
    </script>--%> 
     <script src="/Scripts/pages/contentReader.js" type="text/javascript"></script>
    <link href="/Content/global.css" rel="stylesheet" type="text/css" />
    <link href="/Content/page/scenic.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/pages/Brower.js" type="text/javascript"></script>
    <script src="/Scripts/pages/scenic.js" type="text/javascript"></script>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <asp:HiddenField ID="hfposition" runat="server" />
    <asp:HiddenField ID="hfscname" runat="server" />
    <asp:HiddenField ID="hfProductCode" runat="server" />
    <asp:HiddenField ID="hfSyCount" runat="server" />
    <p class="navsc">
        您选择的景区门票：浙江省&nbsp;>&nbsp;<a runat="server" id="areaname"></a>&nbsp;<a runat="server"
            id="county"></a>&nbsp;<a runat="server" id="scenicname"></a></p>
    <div id="mainscenic">
        <%--衢州门票活动剩余票数显示--%>
        <div runat="server" id="qzTicketCount" class="qzTicketCount">
            <%--<span class="tc">余<span class="countSum" style=" font-size:24px; font-weight:bold;">50</span>张</span>--%>
            <%--<span class="noTc" style=" font-size:14px;">已抢完</span>--%>
        </div>
        <div class="mainscbg">
            <img runat="server" id="ImgMainScenic" class="mainscenicimg" src="" /></div>
        <div id="maintitle">
            <h2 runat="server" id="maintitlett">
            </h2>
            <div class="themespan" style="display:none">
                主题标签
                <asp:Repeater ID="rpttopic" runat="server">
                    <ItemTemplate>
                        <span>
                            <%# Eval("Topic.Name") %></span>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="sclv">
                <span>景区级别:</span><%=sclevel%>
            </div>
            <div class="scaddr">
                <span>地址：</span><%=scaddress%>&nbsp;&nbsp;&nbsp;<a href="#plate1">查看地图</a>
            </div>
            <div class="scdesc">
                <%=scshortdesc %><a href="#plate2">景区简介</a>
            </div>
            <div class="ordertype">
                <h3>
                    订票方式</h3>
                <span>网上购买</span><span>预订</span><span>明信片预订</span>
            </div>
            <div class="paytype">
                <h3>
                    付款方式</h3>
                <span>网上支付</span><span>景区现付</span>
            </div>
        </div>
        <div id="priceinfo">
            <div class="captitle">
                门票种类和价格</div>
            <table border="0" cellpadding="0" cellspacing="0">
                <tbody>
                    <tr class="tstr">
                        <td>
                            景区门票
                        </td>
                        <td>
                            门票原价
                        </td>
                        <td>
                           景区现付价
                        </td>
                        <td>
                            在线支付价
                        </td>
                       <%-- <td>
                            旅游卡优惠价
                        </td>--%>
                        <td>
                            操作
                        </td>
                    </tr>
                </tbody>
                <asp:Repeater ID="rpttp" runat="server" onitemdatabound="rpttp_ItemDataBound">
                    <ItemTemplate>
                        <tr class="pttr" onmouseover="" onmouseout="">
                            <td style="text-align: left; padding-left: 60px;">
                                <input type="hidden" value='<%#Eval("Id") %>' />
                                <%# Eval("Name") %>
                            </td>
                            <td>
                                <%# Eval("TicketPrice[0].Price","{0:0}")%>
                            </td>
                            <td>
                                <%# Eval("TicketPrice[1].Price", "{0:0}")%>
                            </td>
                           <%-- <td style="color: #EC6B9E; font-weight: bold">
                                0
                            </td>--%>
                             <td>
                                <%# Eval("TicketPrice[2].Price", "{0:0}")%>
                            </td>
                            <td style="text-align: center;">
                            <!--活动规则判断-->
                                <input runat="server" id="btnputcart" type="button" class="btnputcart" value="立即抢票" onclick='AddToCart(this,<%# Eval("Id") %>)' />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <hr />
        </div>
        <div runat="server" id="introordertk" class="introordertk">
            <p class="captitle">
                订票说明</p>
            <asp:Repeater ID="rptBookNote" runat="server" OnItemDataBound="rptBookNote_ItemDataBound">
                <ItemTemplate>
                     <self:ContentReader runat="server" HasBorder="true" ID="sc_dp" scFuncType="订票说明" scname='<%# Eval("Scenic.Name") %>'
                type="景区" CssClass="otinfo" />
                </ItemTemplate>
            </asp:Repeater>


            <%--<div class="otinfo" runat="server" id="dp_info">--%>
           
            <%--</div>--%>
        </div>
        <div id="allinfo">
            <p class="captitle">
                景区概况</p>
            <div class="selectinfospan">
                <span class="highselected" onclick="btnselect(this)">景区简介</span> <span onclick="btnselect(this)">
                    交通指南</span>
            </div>
            <div id="changeinfo">
                <div id="scdetailplate">
                    <asp:Repeater runat="server" ID="rptscInfo" OnItemDataBound="rptscInfo_ItemDataBound">
                        <ItemTemplate>
                            <self:ContentReader runat="server" ID="plate2" HasBorder="true" scFuncType="景区详情" scname='<%# Eval("Scenic.Name") %>'
                            type="景区" />
                        </ItemTemplate>
                    </asp:Repeater>
                    
                </div>
                <p id="plap">
                    交通指南</p>
                <div id="plate1">
                    <a onclick="gotocenter()" style="float: right; margin-right: 15px; cursor: pointer;
                        color: #53C46C">恢复坐标中心</a>
                    <div id="containtermap">
                    </div>
                    <asp:Repeater runat="server" ID="rptJt" OnItemDataBound="rptJt_ItemDataBound">
                        <ItemTemplate>
                            <self:ContentReader runat="server" ID="sc_jtzn" scFuncType="交通指南" type="景区" CssClass="rdinfo" scname='<%# Eval("Scenic.Name") %>' />
                        </ItemTemplate>
                    </asp:Repeater>
                    
                </div>
            </div>
        </div>
    </div>
    <img src="/theme/default/image/newversion/backtop.png" width="41px" height="49px"
        class="backtop" />
</asp:Content>
