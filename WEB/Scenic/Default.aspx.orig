<%@ Page Title="" Language="C#" MasterPageFile="/Layout.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Scenic_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
    <link href="/theme/default/css/global.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/default.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/scenic.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/pages/Brower.js" type="text/javascript"></script>
    <script src="/Scripts/scenic.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.2&amp;services=true"> </script>
    <script type="text/javascript">

        var cart = new Cart();
        function AddToCart() {
            var qty = $("#txtTicketCount").val();
            cart.AddToCart(GetTicketId(), qty);
            window.location.href = "/order/cart.aspx";
        }

        function clickmodify(m) {

            var qty = $("#txtTicketCount").val();
            var targetqty = EnsureCartQty(parseInt(qty) + parseInt(m));
            $("#txtTicketCount").val(targetqty);
            cart.ModifyQty(GetTicketId(), targetqty);


        }

        function change() {
            var qty = $("#txtTicketCount").val();
            var targetqty = EnsureCartQty(parseInt(qty));
            $("#txtTicketCount").val(targetqty);
            cart.ModifyQty(GetTicketId(), targetqty);
        }

        function GetTicketId() {
            return "<%=TicketId %>";
        }

        function ShowPriceIntro() {
            $("#priceintrodiv").css("display", "block");
            var mubiao = $(".priceintro");
            $("#priceintrodiv").css({ left: mubiao.position().left + "px", top: mubiao.position().top - 10 + "px" });
        }
        function ClosePriceIntro() {
            $("#priceintrodiv").css("display", "none");
        }

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


            var map = new BMap.Map("containtermap");            // 创建Map实例
            var position = "<%=scpoint %>";
            var point = new BMap.Point(position.split(",")[0], position.split(",")[1]);    // 创建点坐标
            map.centerAndZoom(point, 8);                     // 初始化地图,设置中心点坐标和地图级别。
            var txt = "<%=scbindname %>";
            var myCompOverlay1 = new ComplexCustomOverlay1(point, txt, 0);
            map.addOverlay(myCompOverlay1);
            //            if (position != "120.159033,30.28376") {
            //                var marker = new BMap.Marker(new BMap.Point(position.split(",")[0], position.split(",")[1]));  // 创建标注
            //                map.addOverlay(marker);              // 将标注添加到地图中
            //            }
            for (var i = 0; i < parseInt("<%=imgcount %>"); i++) {
                var positions = "<%=bindimglist %>".split(":")[i];
                var point2 = new BMap.Point(positions.split(",")[0], positions.split(",")[1]);
                var myCompOverlay2 = new ComplexCustomOverlay2(point2, "", 0);
                map.addOverlay(myCompOverlay2);
            }
            map.addControl(new BMap.NavigationControl());
            map.enableScrollWheelZoom(true);
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
                <img src="/theme/default/image/newversion/icon.gif" />您选择的景区门票：浙江省&nbsp;>&nbsp;<a runat="server" id="areaname"></a>&nbsp;>&nbsp;<a runat="server"
                    id="scenicname"></a></p>
            <div id="mainscenic">
                <div class="mainscbg"><img runat="server" id="ImgMainScenic" class="mainscenicimg" src="" /></div>
                <div id="maintitle">
                    <h2 runat="server" id="maintitlett">
                    </h2>
                    <div class="themespan">
                        主题标签<span>峰岩奇绝</span><span>山水神秀</span><span>仙人荟萃之都</span>
                    </div>
                    <div class="sclv">
                        <span>景区级别:</span>4A
                    </div>
                    <div class="scaddr">
                        地址：浙江省丽水市缙云县境内&nbsp;&nbsp;&nbsp;<a href="#plate1">查看地图</a>
                    </div>
                    <div class="scdesc">
                        有奇峰一百六、异洞二十七，有“桂林之秀、黄山之气、华山之险”的美誉。...<a href="#plate2">景区简介</a>
                    </div>
                    <div class="ordertype">
                        <h3>订票方式</h3><span>网上购买</span><span>预订</span><span>明信片预订</span>
                    </div>
                    <div class="paytype">
                        <h3>付款方式</h3><span>网上支付</span><span>景区现付</span>
                    </div>
                </div>
                <div id="priceinfo">
                    <p class="captitle"><img src="/theme/default/image/newversion/icon.gif" />门票种类和价格</p>
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
                                    明信片优惠价
                                </td>
                                <td>
                                    景区现付价
                                </td>
                                <td>
                                    在线支付价
                                </td>
                                <td>
                                    操作
                                </td>
                            </tr>
                        </tbody>
                        <tr class="pttr" onmouseover="" onmouseout="">
                            <td>
                                套票
                            </td>
                            <td>
                                130
                            </td>
                            <td>
                                104
                            </td>
                            <td>
                                104
                            </td>
                            <td style="color: #E8641B; font-weight: bold">
                                90
                            </td>
                            <td style="text-align: center;">
                                <input id="btnputcart" type="button" class="btnputcart" value="放入购物车" />
                            </td>
                        </tr>
                        <tr class="pttr2">
                            <td>
                                鼎湖峰
                            </td>
                            <td>
                                60
                            </td>
                            <td>
                                48
                            </td>
                            <td>
                                48
                            </td>
                            <td style="color: #E8641B; font-weight: bold">
                                40
                            </td>
                            <td style="text-align:center;">
                                <input id="Button2" type="button" class="btnputcart" value="放入购物车" />
                            </td>
                        </tr>
                    </table>
                </div>

                <div id="introordertk">
                    <p class="captitle"><img src="/theme/default/image/newversion/icon.gif" />订票说明</p>
                    <div class="otinfo">
                            1&nbsp;取票：请到鼎湖峰景点，在线支付的游客凭身份证领取景区门票，预定的游客凭身份证购买折扣门票<br />
                            2&nbsp;特殊人群：<br />
                            A.免费政策：儿童身高1.2米以下免费，军官证凭证免费<br />
                            B.优惠政策：<span>儿童身高1.2-1.4米半价。学生票凭证半价，老年人60-70周岁半价，70岁以上浙江省内免费省外半票<br />
                                <span style="margin-left: 70px;"></span>其他优惠以景区公布为准</span> 4&nbsp;发票说明：预订景区门票，网站不提供发票<br />
                            5&nbsp;温馨提示：套票包含仙都里面的六个景点门票<br />
                            &nbsp;&nbsp;网站预订的景区门票有效期一年，未使用的门票可以在期限内更改游客信息。
                     </div>
                </div>


                <div id="allinfo">
                    <p class="captitle"><img src="/theme/default/image/newversion/icon.gif" />景区概况</p>
                    <div class="selectinfospan">
                        <span class="highselected" onclick="btnselect(this)">景区简介</span> <span onclick="btnselect(this)">
                            交通指南</span>
                    </div>
                    <div id="changeinfo">
                        <div id="plate2">
                            仙都，位于浙江省丽水市缙云县境内，是一处以峰岩奇绝、山水神秀为景观特色，融田园风光与人文史迹为一体，以观光、避暑休闲<br />
                            和开展科学、文化活动为一体的国家级重点风景名胜区；亦是一个山明水秀、景物优美、气候宜人的游览胜地。境内九曲练溪，十里<br />
                            画廊，山水飘逸，云雾缭绕。<br />
                            仙都，是一处以峰岩奇绝、山水神秀为特色、融田园风光与人文史迹为一体，以观光、休闲、度假和科普为主的国家级重点风景<br />
                            名胜区、国家首批AAAA级旅游区。境内九曲练溪、十里画廊；山水飘逸、云雾缭绕。有奇峰一百六、异洞二十七，有“桂林之秀、<br />
                            黄山之奇、华山之险”的美誉。仙都风景名胜区由仙都、黄龙、岩门、大洋四大景区组成<br />
                            <asp:Repeater runat="server" ID="rptft">
                                <ItemTemplate>
                                    <div class="sconeft">
                                        <img class="imgft" alt='<%# Eval("Description") %>' src='<%# Eval("Name","/ScenicImg/{0}") %>' />
                                        <p runat="server" id="fttitle1">
                                            <%# Eval("Title")%>
                                        </p>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                            <p id="plap">交通指南</p>
                        <div id="plate1">
                            <div id="containtermap">
                            </div>
                            <div class="rdinfo">
                                从上海到浙江仙都可坐火车到缙云火车站。出站走进二百米到山叉路口，向右转是去县城，一直往下是往鼎湖峰。再次地可乘过路车
                                到鼎湖峰，不用到县城。出站后也可直接雇面包车（20元）到鼎湖峰。&nbsp;&nbsp;&nbsp;到鼎湖峰方向的车很多，几十分钟就有一辆，也可乘到
                                壶镇的车，但在鼎湖峰前面的岔路口就要下车，往里还要走一段路。所以最好乘到铁城（芙蓉峡）的中巴，先到铁城或先到鼎湖峰下车均可。到铁城是三块板，
                                到鼎湖峰二块。在景区可花40元左右（淡季价）包一辆残疾车一天，然后就可以随心所欲地玩了。晚上可乘火车离开，下午5：:3,7:30,9:30都有火车。地的治安也不错。
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    <div id="mainbody" style="display: none">
        <div>
            <div class="leftimg">
            </div>
            <div id="rightprice">
                <%--                <div id="mxprice">
                    <img class="mxpicon" src="../Img/mxpicon.jpg" />
                    <p id="sjmxp" runat="server">
                        明信片优惠价&nbsp;<span runat="server" id="mxphtprice">80</span>元</p>
                    <p id="dzmxp" runat="server">
                        电子明信片优惠价&nbsp;90元</p>
                </div>--%>
                <div>
                </div>
                <div class="yyprice">
                    原价:<span id="yjhtprice" runat="server">100</span>元</div>
                <div class="zxprice">
                    网上订购价:&nbsp;<span id="zfhtprice" runat="server">70</span><font style="color: #D05037">元</font>
                </div>
                <div class="priceintro" onmouseover="ShowPriceIntro()" onmouseout="ClosePriceIntro()">
                </div>
                <div class="ydprice">
                    景区现付价：<span id="ydhtprice" runat="server">95</span>元</div>
                <div class="paytype">
                    付款方式:&nbsp;网银支付&nbsp;&nbsp;支付宝</div>
                <div class="paycount">
                    我要买
                    <input id="btnjian2" type="button" class="btnjian2" style="cursor: pointer" onclick="clickmodify(-1)" />
                    <input name="txtTicketCount" type="text" value="1" onchange="change()" id="txtTicketCount"
                        class="ticketcount" />
                    <input id="Button1" type="button" class="btnadd2" style="cursor: pointer" onclick="clickmodify(1)" />张
                </div>
                <div class="btnpay">
                    <span class="btnlight btn" onclick="AddToCart()">放入购物车</span>
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
        <div id="scdescinfo">
            <div id="scdescription" runat="server" class="scdescription">
            </div>
            <div class="scftshow">
                <%--<div class="sconeft">
                    <asp:Image ID="Imgft1" runat="server" CssClass="imgft" />
                    <p runat="server" id="fttitle1">
                        </p>
                </div>
                <div class="sconeft">
                    <asp:Image ID="Imgft2" runat="server" CssClass="imgft" />
                    <p runat="server" id="fttitle2">
                        </p>
                </div>
                <div class="sconeft">
                    <asp:Image ID="Imgft3" runat="server" CssClass="imgft" />
                    <p runat="server" id="fttitle3">
                        </p>
                </div>
                <div class="sconeft">
                    <asp:Image ID="Imgft4" runat="server" CssClass="imgft" />
                    <p runat="server" id="fttitle4">
                        </p>
                </div>
                <div class="sconeft">
                    <asp:Image ID="Imgft5" runat="server" CssClass="imgft" />
                    <p runat="server" id="fttitle5">
                        </p>
                </div>
                <div class="sconeft">
                    <asp:Image ID="Imgft6" runat="server" CssClass="imgft" />
                    <p runat="server" id="fttitle6">
                        </p>
                </div>--%>
            </div>
        </div>
        <div id="zbscdiv">
            <div class="zbsctitle">
                周边景点
            </div>
            <div class="zbscinfo">
                <div class="zbscpic">
                    <asp:Repeater runat="server" ID="rptzbsc">
                        <ItemTemplate>
                            <div class="zbscone">
                                <a runat="server" id="aImgzb1" href='<%# ResolveUrl(string.Format("/{0}/{1}.html", Eval("Scenic.Area.SeoName"),Eval("Scenic.SeoName"))) %>'>
                                    <img alt="<%# Eval("Description") %>" class="imgzb" src='<%# Eval("Name","/ScenicImg/{0}") %>' />
                                </a>
                                <p runat="server" id="zbname1">
                                    <%# Eval("Scenic.Name") %>
                                </p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <%--<div class="zbscone">
                        <a runat="server" id="aImgzb1"><asp:Image ID="Imgzb1" runat="server" CssClass="imgzb" /></a>
                        <p runat="server" id="zbname1">
                            </p>
                    </div>
                    <div class="zbscone">
                        <a runat="server" id="aImgzb2"><asp:Image ID="Imgzb2" runat="server" CssClass="imgzb" /></a>
                        <p runat="server" id="zbname2">
                            </p>
                    </div>
                    <div class="zbscone">
                        <a runat="server" id="aImgzb3"><asp:Image ID="Imgzb3" runat="server" CssClass="imgzb" /></a>
                        <p runat="server" id="zbname3">
                            </p>
                    </div>
                    <div class="zbscone">
                         <a runat="server" id="aImgzb4"><asp:Image ID="Imgzb4" runat="server" CssClass="imgzb" /></a>
                        <p runat="server" id="zbname4">
                            </p>
                    </div>
                    <div class="zbscone">
                        <a runat="server" id="aImgzb5"><asp:Image ID="Imgzb5" runat="server" CssClass="imgzb" /></a>
                        <p runat="server" id="zbname5">
                            </p>
                    </div>
                    <div class="zbscone">
                        <a runat="server" id="aImgzb6"><asp:Image ID="Imgzb6" runat="server" CssClass="imgzb" /></a>
                        <p runat="server" id="zbname6">
                            </p>
                    </div>--%>
                </div>
                <div class="scmappos">
                    <p>
                        地图&nbsp;&nbsp;&nbsp;&nbsp;<a runat="server" id="searchbigmap" style="font-weight: normal;"
                            href="/map/Default.aspx">[查看大图]</a></p>
                    
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
        <div id="visitedsc">
            <p>
                最近浏览过的景区</p>
            <hr />
            <div class="visitedinfo">
                <asp:Repeater ID="rptvisited" runat="server">
                    <ItemTemplate>
                        <div class="visiteddiv">
                            <a href='<%# ResolveUrl(string.Format("/{0}/{1}.html", Eval("Scenic.Area.SeoName"),Eval("Scenic.SeoName"))) %>'>
                                <img src='<%# Eval("Name","/ScenicImg/{0}") %>' alt='<%# Eval("Description") %>' />
                            </a>
                            <p>
                                <%# Eval("Scenic.Name") %></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div style="display: none">
            <div id="zbscenic">
                <div>
                    周边景区</div>
            </div>
            <div class="clear">
            </div>
            <div id="zbscenicimg">
                <div class="firstimg">
                    <img id="fimg" runat="server" src="" style="height: 200px; width: 328px;" />
                    <div class="fwenzi">
                        <font style="font-size: 25px;">1</font><a id="fiwenzi" runat="server" style="margin-left: 10px;
                            padding-top: -2px; margin-top: 0px; line-height: 12px;"></a></div>
                </div>
                <div class="rightscenicimg">
                    <div>
                        <div class="secdiv" style="border: 10px none Black">
                            <img runat="server" id="secimg" src="" style="height: 90px; border: 0px none White;
                                width: 160px;" />
                            <div class="swenzi">
                                <font style="font-size: 22px;">2</font><a id="secwenzi" runat="server" style="margin-left: 10px;
                                    padding-top: -5px; margin-top: 0px; line-height: 10px;"></a></div>
                        </div>
                        <div class="thdiv">
                            <img id="thimg" runat="server" src="" style="height: 90px; width: 160px;" />
                            <div class="swenzi">
                                <font style="font-size: 22px;">3</font><a id="thwenzi" runat="server" style="margin-left: 10px;
                                    padding-top: -5px; margin-top: 0px; line-height: 10px;"></a></div>
                        </div>
                    </div>
                    <div style="clear: both; padding: 0px; margin: 0px;">
                        <div class="ttdiv">
                            <img id="ttimg" runat="server" src="" style="height: 90px; width: 160px;" />
                            <div class="swenzi">
                                <font style="font-size: 22px;">4</font><a id="ttwenzi" runat="server" style="margin-left: 10px;
                                    padding-top: -5px; margin-top: 0px; line-height: 10px;"></a></div>
                        </div>
                        <div class="fidiv">
                            <img id="ffimg" runat="server" src="" style="height: 90px; width: 160px;" />
                            <div class="swenzi">
                                <font style="font-size: 22px;">5</font><a id="ffwenzi" runat="server" style="margin-left: 10px;
                                    padding-top: -5px; margin-top: 0px; line-height: 10px;"></a></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
    <img src="/theme/default/image/newversion/backtop.png" width="41px" height="49px" class="backtop" />
</asp:Content>
