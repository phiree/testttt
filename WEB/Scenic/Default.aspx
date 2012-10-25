<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Scenic_Default" %>
<%@ Register TagPrefix="self" Namespace="TourControls" Assembly="TourControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
    <link href="/theme/default/css/TCCSS.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/global.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/default.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/scenic.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/pages/Brower.js" type="text/javascript"></script>
    <script src="/Scripts/scenic.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.2&amp;services=true"> </script>
    
    <script type="text/javascript">

        var cart = new Cart();
        function AddToCart(btn) {
            //var qty = $("#txtTicketCount").val();
            cart.AddToCart(GetTicketId(btn), 1);
            window.location.href = "/order/cart.aspx";
        }

       
      

        function GetTicketId(btn) {
            var ticketId = 0;
            ticketId = $($(btn).parent().siblings()[0]).children("input").val()
            
            return ticketId;
        }

        function ShowPriceIntro() {
            $("#priceintrodiv").css("display", "block");
            var mubiao = $(".priceintro");
            $("#priceintrodiv").css({ left: mubiao.position().left + "px", top: mubiao.position().top - 10 + "px" });
        }
        function ClosePriceIntro() {
            $("#priceintrodiv").css("display", "none");
        }
        var map;
        var position;
        var flag = 1;
        function showmap() {
            ////////////////////////////////////////////////复杂覆盖物
            // 复杂的自定义覆盖物1
            function ComplexCustomOverlay1(point, text, id) {
                this._point = point;
                this._text = text;
                this._id = id;
                this._name = text;
            }
            ComplexCustomOverlay1.prototype = new BMap.Overlay();
            ComplexCustomOverlay1.prototype.initialize = function (mapp) {
                this._map = mapp;
                var div = this._div = document.createElement("div");
                div.style.position = "absolute";
                div.style.zIndex = BMap.Overlay.getZIndex(this._point.lat);
                div.className = "divicon";
                div.style.MozUserSelect = "none";
                div.style.fontSize = "12px";
                div.id = this._div;
                div.name = this._name;

                var span = this._span = document.createElement("span");
                //div.appendChild(span);
                span.style.height = "15px";
                div.style.cursor = "pointer";
                span.style.display = "inline-block";
                span.style.color = "Black";
                span.style.margin = "0px 5px 2px 3px";
                span.appendChild(document.createTextNode(this._id));
                var that = this;

                var spanscenic = this._span = document.createElement("span");
                div.appendChild(spanscenic);
                spanscenic.height = "15px";
                spanscenic.style.position = "relative";
                spanscenic.style.top = "-2px \0";
                spanscenic.style.display = "inline-block";
                spanscenic.style.lineHeight = "15px";
                spanscenic.style.color = "White";
                spanscenic.appendChild(document.createTextNode(this._text))


                var arrow = this._arrow = document.createElement("div");
                //                arrow.style.background = "url('/Img/yuansu/largeicon2.gif') no-repeat";
                //                arrow.style.position = "absolute";
                //                arrow.style.width = "14px";
                //                arrow.style.height = "15px";
                //                arrow.style.top = "19px";
                arrow.className = "jiancss";
                arrow.style.left = "10px";
                //                arrow.style.overflow = "hidden";
                div.appendChild(arrow);

                map.getPanes().labelPane.appendChild(div);

                return div;
            }
            ComplexCustomOverlay1.prototype.draw = function () {
                var map = this._map;
                var pixel = map.pointToOverlayPixel(this._point);
                this._div.style.left = pixel.x - parseInt(this._arrow.style.left) + "px";
                this._div.style.top = pixel.y - 30 + "px";
            }
            ////////////////////////////////////////////////

            ////////////////////////////////////////////////复杂覆盖物
            // 复杂的自定义覆盖物2
            // 复杂的自定义覆盖物
            function ComplexCustomOverlay2(point, text, mouseoverText) {
                this._point = point;
                this._text = text;
                this._overText = mouseoverText;
            }
            ComplexCustomOverlay2.prototype = new BMap.Overlay();
            ComplexCustomOverlay2.prototype.initialize = function (map) {
                this._map = map;
                var div = this._div = document.createElement("div");
                div.style.position = "absolute";
                div.style.zIndex = BMap.Overlay.getZIndex(this._point.lat);
                div.style.background = "url('/Img/yuansu/smallicon6.gif') no-repeat";
                //div.style.border = "1px solid #BC3B3A";
                div.style.color = "white";
                div.style.height = "13px";
                div.style._height = "16px";
                div.style.width = "8px";
                div.style.padding = "2px";
                div.style.fontSize = "12px";
                div.style.cursor = "pointer";
                div.style.whiteSpace = "nowrap";
                div.style.MozUserSelect = "none";
                div.name = this._text;

                map.getPanes().labelPane.appendChild(div);

                return div;
            }
            ComplexCustomOverlay2.prototype.draw = function () {
                var map = this._map;
                var pixel = map.pointToOverlayPixel(this._point);
                this._div.style.left = pixel.x - 3 + "px";
                this._div.style.top = pixel.y - 16 + "px";
            }
            ////////////////////////////////////
            map = new BMap.Map("containtermap");            // 创建Map实例
            position= "<%=scpoint %>";

            var point = new BMap.Point(position.split(",")[0], position.split(",")[1]);    // 创建点坐标
            if (flag == 1) {
                map.centerAndZoom(point, 8);
                flag++;
            }
            else
                map.centerAndZoom(point, map.getZoom());                      // 初始化地图,设置中心点坐标和地图级别。

            var txt = "<%=scmapname %>";
            var myCompOverlay1 = new ComplexCustomOverlay1(point, txt, 0);
            map.addOverlay(myCompOverlay1);
            //            if (position != "120.159033,30.28376") {
            //                var marker = new BMap.Marker(new BMap.Point(position.split(",")[0], position.split(",")[1]));  // 创建标注
            //                map.addOverlay(marker);              // 将标注添加到地图中
            //            }
            for (var i = 0; i < parseInt("<%=imgcount %>"); i++) {
                var positions = "<%=bindimglist %>".split(":")[i];
                var point2 = new BMap.Point(positions.split(",")[0], positions.split(",")[1]);
                var myCompOverlay2 = new ComplexCustomOverlay1(point2, positions.split(",")[2], 0);
                map.addOverlay(myCompOverlay2);
            }
            map.addControl(new BMap.NavigationControl());
        }
        
        function gotocenter() {
            var point = new BMap.Point(position.split(",")[0], position.split(",")[1]);    // 创建点坐标
            if (flag == 1) {
                map.centerAndZoom(point, 8);
                flag++;
            }
            else
                map.centerAndZoom(point, map.getZoom());                      // 初始化地图,设置中心点坐标和地图级别。
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            showmap();
        });
       
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
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
