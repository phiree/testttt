<%@ Page Title="" Language="C#" MasterPageFile="~/detail.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>中国旅游在线_浙江旅游景点门票预订官网</title>
    <script src="/Scripts/slide.js" type="text/javascript"></script>
    <script src="/Scripts/pages/default.js" type="text/javascript"></script>
    <link href="/theme/default/css/default.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/pager.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/Show.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $(".navlistnb a").attr("class", "");
            $(".navlistnb a:eq(0)").attr("class", "navhight");
            $(".navhight").next().attr("class", "");
            $(".navlistnb a").each(function () {
                if ($(this).attr("class") == "navhight") {
                    $(this).next().css("display", "none");
                    $(".chartdiv").css("display", "block");
                }
                else {
                    $(this).next().css("display", "");
                    $(".chartdiv").css("display", "block");
                    $(this).click(function () {
                        $(this).next().css("display", "none");
                        $(".chartdiv").css("display", "block");
                    });
                    $(this).mouseover(function () {
                        $(this).next().css("display", "none");
                        $(".chartdiv").css("display", "block");
                    });
                    $(this).mouseout(function () {
                        $(this).next().css("display", "");
                        $(".chartdiv").css("display", "block");
                    });
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <!--顶部推荐-->
    <div id="toprecomm">
        <div id="imgPlay">
            <ul class="imgs" id="actor">
                <li>
                    <img src="/Img/slide/1.png" />
                </li>
                <li>
                    <img src="/Img/slide/2.png" />
                </li>
                <li><a href="/lishui/yunhetitianjingqu.html">
                    <img src="/Img/slide/3.png" /></a> </li>
            </ul>
            <div class="num">
                <p class="lc">
                </p>
                <p class="mc">
                </p>
                <p class="rc">
                </p>
            </div>
            <div id="numInner" class="num">
            </div>
            <div class="prev">
                上一张</div>
            <div class="next">
                下一张</div>
        </div>
    </div>
    <div class="lpcolum">
        <a href="">
            <img width="100%" height="100%" src="/ScenicImg/套票江郎山.jpg" alt="套票江郎山" />
        </a>
    </div>
     <div class="fcolum">
        <div class="fcolum1">
            <span class="fcol1_scname">
                兰溪六洞山风景区
            </span>
            <span class="fcol1_area">金华</span>
            <a href=""><img src="/ScenicImg/兰溪六风洞景区.jpg" width="100%" height="160px" alt="兰溪六风洞景区" /></a>
            <p>山美、水秀、洞奇、寺幽为特色。涌雪洞的“地下长河”为海内一绝……</p>
            <hr />
            <div class="fcol1_bottom">
                <span>景区门票,买一送一</span></a><a href="" class="btna"></a>
            </div>
        </div>
        <div class="fcolum1">
            <span class="fcol1_scname">
                夹溪十八涡景区
            </span>
            <span class="fcol1_area">金华</span>
            <a href=""><img src="/ScenicImg/夹溪十八涡景区.jpg" width="100%" height="160px" alt="夹溪十八涡景区" /></a>
            <p>近千米长的河床t徒然下跌，水流随势跌落入潭……</p>
            <hr />
            <div class="fcol1_bottom">
                <span>清凉一夏，特价门票</span></a><a href="" class="btna"></a>
            </div>
        </div>
        <div class="fcolum1">
            <span class="fcol1_scname">
                浙西大峡谷
            </span>
            <span class="fcol1_area">宁波</span>
            <a href=""><img src="/ScenicImg/浙西大峡谷.jpg" width="100%" height="160px" alt="浙西大峡谷" /></a>
            <p>景区以峡谷溪流、田野风光为特色景观，集皮筏漂流、竹筏漂流……</p>
            <hr />
            <div class="fcol1_bottom">
                <span>漂的不只是好心情</span></a><a href="" class="btna"></a>
            </div>
        </div>
        <div class="fcolum1">
            <span class="fcol1_scname">
                新昌大佛寺景区
            </span>
            <span class="fcol1_area">嵊州</span>
            <a href=""><img src="/ScenicImg/新昌大佛寺.jpg" width="100%" height="160px" alt="新昌大佛寺景区" /></a>
            <p>巨大的弥勒佛石像正面跌坐于大殿正中。这座巨大的石像，雕凿于悬崖绝壁之中，历时约30年才全部雕成……</p>
            <hr />
            <div class="fcol1_bottom">
                <span>佛地优惠,免费许愿<span><a href="" class="btna"></a>
            </div>
        </div>
    </div>
    <div class="scoloum">
        <div class="sccol1">
            <div class="sccol1row1">
                <a href="/Tickets/lishui/shenlonggu.html">
                    <img alt="遂昌神龙谷瀑布" src="/ScenicImg/“中华第一高瀑”-遂昌神龙谷瀑布.jpg" width="100%" height="100%" />
                    <p>
                    </p>
                    <span>遂昌神龙谷瀑布</span>
                    <div class="mark">
                    </div>
                </a>
            </div>
            <div class="sccol1row2">
                <a href="/Tickets/lishui/suishangjingkuang.html">
                    <img alt="遂昌金矿" src="/ScenicImg/遂昌金矿.jpg" width="100%" height="100%" />
                    <p>
                    </p>
                    <span>遂昌金矿</span>
                    <div class="mark">
                    </div>
                </a>
            </div>
        </div>
        <div class="sccol2">
            <div class="sccol2row1">
                <a href="/Tickets/lishui/nanjianyan.html">
                    <img alt="南尖岩" src="/ScenicImg/南尖岩.jpg" width="100%" height="100%" />
                    <p>
                    </p>
                    <span>南尖岩</span>
                    <div class="mark" style="width: 50%">
                    </div>
                </a><a href="">
                    <img alt="畲乡漂流" src="/ScenicImg/畲乡漂流.jpg" width="100%" height="100%" />
                    <p style="left: 163px;">
                    </p>
                    <span style="left: 163px;">畲乡漂流</span>
                    <div class="mark" style="width: 50%; left: 163px;">
                    </div>
                </a>
            </div>
            <div class="sccol2row2">
                <a href="/Tickets/lishui/xiandufengjingmingshengqu.html">
                    <img alt="仙都" src="/ScenicImg/仙都.jpg" width="100%" height="100%" />
                    <p>
                    </p>
                    <span>仙都</span>
                    <div class="mark">
                    </div>
                </a>
            </div>
            <div class="sccol2row3">
                <a href="/Tickets/lishui/longquanshandujiaqu.html">
                    <img alt="龙泉山" src="/ScenicImg/龙泉山-高山新居.jpg" width="100%" height="100%" />
                    <p>
                    </p>
                    <span>龙泉山</span>
                    <div class="mark" style="width: 50%">
                    </div>
                </a><a href="/Tickets/lishui/xianduhuanglongshanjingqu.html">
                    <img alt="黄龙景区" src="/ScenicImg/黄龙景区.jpg" width="100%" height="100%" />
                    <p style="left: 163px;">
                    </p>
                    <span style="left: 163px;">黄龙景区</span>
                    <div class="mark" style="width: 50%; left: 163px;">
                    </div>
                </a>
            </div>
        </div>
        <div class="sccol3">
            <div class="sccol3row1">
                <a href="/Tickets/lishui/shexiangzhichuang.html">
                    <img alt="畲家少女" src="/ScenicImg/畲家少女.jpg" width="100%" height="100%" />
                    <p>
                    </p>
                    <span>畲家少女</span>
                    <div class="mark">
                    </div>
                </a>
            </div>
            <div class="sccol3row2">
                <a href="/Tickets/lishui/shimendongshenlinggongyuan.html">
                    <img alt="青田石门洞" src="/ScenicImg/青田石门洞.jpg" width="100%" height="100%" />
                    <p>
                    </p>
                    <span>青田石门洞</span>
                    <div class="mark">
                    </div>
                </a>
            </div>
        </div>
        <div class="sccol4">
            <div class="sccol4row1">
                <img alt="地图" src="/ScenicImg/bj.gif" width="220px" height="214px" />
                <div class="sccol4row1bg">
                </div>
                <div class="sccol4row1info">
                    <p class="mapscname">
                        丽水&nbsp;&nbsp;&nbsp;&nbsp;旅游亮点</p>
                    <hr />
                    <p class="mapscnameinfo">
                        <a href="/Tickets/lishui/nanjianyan.html">寻找瑶池――南尖岩</a>
                    </p>
                    <p class="mapscnameinfo">
                        <a href="/Tickets/lishui/baishanzhujingqu.html">穿越――百山祖―黄茅尖</a></p>
                    <hr />
                    <p class="mapscnameinfo">
                        <a href="/Tickets/ruoliaoyuanshilingjingqu.html">松阳县――箬寮原始林旅游</a></p>
                    <p class="mapscnameinfo2">
                        旧志云：“徒其巅可览七邑之胜”</p>
                    <hr />
                    <p class="mapscnameinfo">
                        <a href="/Tickets/lishui/shenlonggu.html">遂昌县――神龙谷旅游</a></p>
                    <p class="mapscnameinfo2">
                        森林瀑布神龙谷，汤公寻梦牡丹亭</p>
                </div>
            </div>
        </div>
    </div>
    <div class="tscoloum">
        <div class="t_fdiv">
            <p style="margin-top:40px; text-align:center;color:White; font-weight:bold; font-size:14px;">千年府城</p>
            <p style="margin-top:5px;text-align:center;color:White; font-weight:bold; font-size:14px;">江南临海</p>
        </div>
        <div class="t_sdiv">
            <div class="t_s_col1">
                <a href="">
                    <img alt="江南大峡谷" src="/ScenicImg/江南大峡谷.gif" width="100%" height="100%" />
                    <span style="margin:280px 0px 0px 0px;" class="t_s_span">江南大峡谷</span>
                    <div class="mark" style="width:100%; height:100%;"></div>
                </a>
                <a href="" style=" position:absolute; display:block; width:200px; height:150px; right:0px; top:0px" class="dj">
                    <span style="margin:127px 0px 0px 115px;" class="t_s_span">江南古长城</span>
                </a>
            </div>
            <div class="t_s_col2">
                <div class="t_s_col2_r1">
                    <a style="width:205px; height:150px; display:block; float:left;margin-left:1px" href="">
                        <img alt="国华珠算博物馆" src="/ScenicImg/国华珠算博物馆.jpg" width="205px" height="150px" />
                        <span style="margin:127px 0px 0px 90px;" class="t_s_span">国华珠算博物馆</span>
                        <div class="mark" style="width:205px; height:150px;"></div>
                    </a>
                    <a style="width:110px; height:150px;display:block; float:left;margin-left:1px" href="">
                        <img alt="九台沟" src="/ScenicImg/九台沟.jpg" width="110px" height="150px" />
                        <span style="margin:127px 0px 0px 262px;" class="t_s_span">九台沟</span>
                        <div class="mark" style="width:110px; height:150px;left:207px"></div>
                    </a>
                    <a style="width:229px; height:150px;display:block; float:left;margin-left:1px" href="">
                        <img alt="紫阳古街" src="/ScenicImg/紫阳古街.jpg" width="227px" height="150px" />
                        <span style="margin:127px 0px 0px 475px;" class="t_s_span">紫阳古街</span>
                        <div class="mark" style="width:229px; height:150px;left:319px"></div>
                    </a>
                    <a style="width:235px; height:155px;display:block; float:left;margin-left:1px;margin-top:1px;" href="">
                        <img alt="临海东湖" src="/ScenicImg/临海东湖.jpg" width="235px" height="155px" />
                        <span style="margin:283px 0px 0px 165px;" class="t_s_span">临海东湖</span>
                        <div class="mark" style="width:235px; height:155px;top:152px"></div>
                    </a>
                    <a style="width:308px; height:155px;display:block; float:left;margin-left:1px;margin-top:1px;" href="">
                        <img alt="桃江十三渚" src="/ScenicImg/桃江十三渚.jpg" width="308px" height="155px" />
                        <span style="margin:283px 0px 0px 461px;" class="t_s_span">桃江十三渚</span>
                        <div class="mark" style="width:308px; height:155px;top:152px;left:237px"></div>
                    </a>
                </div>
            </div>
        </div>
    </div>
    <div class="defaultbottom">
    </div>
</asp:Content>
