<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Scenic_Default" %>
<%@ Register TagPrefix="self" Namespace="TourControls" Assembly="TourControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
    <script type="text/javascript"
    src="https://maps.google.com/maps/api/js?sensor=true">
    </script>
    <link href="/theme/default/css/TCCSS.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/global.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/default.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/scenic.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/pages/Brower.js" type="text/javascript"></script>
    <script src="/Scripts/scenic.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.2&amp;services=true"> </script>
    
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <asp:HiddenField ID="hfposition" runat="server" />
    <asp:HiddenField ID="hfscname" runat="server" />
    <p class="navsc">
        您选择的景区门票：浙江省&nbsp;>&nbsp;<a
            runat="server" id="areaname"></a>&nbsp;<a runat="server" id="county"></a>&nbsp;<a runat="server" id="scenicname"></a></p>
    <div id="mainscenic">
        <div class="mainscbg">
            <img runat="server" id="ImgMainScenic" class="mainscenicimg" src="" /></div>
        <div id="maintitle">
            <h2 runat="server" id="maintitlett">
            </h2>
            <div class="themespan">
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
                地址：<%=scaddress%>&nbsp;&nbsp;&nbsp;<a href="#plate1">查看地图</a>
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
            <p class="captitle">
                门票种类和价格</p>
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
                            旅游在线预定价
                        </td>
                        <td>
                            在线支付价
                        </td>
                        <td>
                            旅游卡优惠价
                        </td>
                        <td>
                            操作
                        </td>
                    </tr>
                </tbody>
                    <asp:Repeater ID="rpttp" runat="server">
                        <ItemTemplate>
                            <tr class="pttr" onmouseover="" onmouseout="">
                            <td style="text-align:left;padding-left:60px;">
                            <input type="hidden" value='<%#Eval("Id") %>' />
                                <%# Eval("Name") %>
                            </td>
                            <td>
                                <%# Eval("TicketPrice[0].Price","{0:0}")%>
                            </td>
                            <td>
                                <%# Eval("TicketPrice[1].Price", "{0:0}")%>
                            </td>
                            <td style="color: #EC6B9E; font-weight: bold">
                                <%--<%# Eval("TicketPrice[2].Price", "{0:0}")%>--%>
                                0
                            </td>
                            <td>
                                0
                            </td>
                            <td style="text-align: center;">
                                <input id="btnputcart" type="button" class="btnputcart" value="放入购物车" onclick="AddToCart(this)" />
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
            <%--<div class="otinfo" runat="server" id="dp_info">--%>
                <self:ContentReader runat="server" ID="sc_dp" scFuncType="订票说明" type="景区" CssClass="otinfo"/>
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
                    <self:ContentReader runat="server" ID="plate2" scFuncType="景区详情" type="景区"/>
                    </div>
                <p id="plap">
                    交通指南</p>
                <div id="plate1">
                    <a onclick="gotocenter()" style="float:right;margin-right:15px;cursor:pointer;color:#53C46C">恢复坐标中心</a>
                    <div id="containtermap">
                    </div>
                    <self:ContentReader runat="server" ID="sc_jtzn" scFuncType="交通指南" type="景区" CssClass="rdinfo"/>

                </div>
            </div>
        </div>
    </div>
    
    <img src="/theme/default/image/newversion/backtop.png" width="41px" height="49px"
        class="backtop" />
</asp:Content>
