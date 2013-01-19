<%@ Page Title="" Language="C#" MasterPageFile="~/detail.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="self" Namespace="TourControls" Assembly="TourControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>中国旅游在线_浙江旅游景点门票预订官网</title>
    <script src="/Scripts/slide.js" type="text/javascript"></script>
    <script src="/Scripts/pages/default.js" type="text/javascript"></script>
      <script src="/Scripts/contentReader.js" type="text/javascript"></script>
    <link href="/theme/default/css/default.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/pager.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/Show.css" rel="stylesheet" type="text/css" /> 
    <script type="text/javascript">
        $(function () {
            //startscrolltime();
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
//            $("#quzhouticket").animate({ bottom: "0px" }, 1500);
//            $("#closeWin").click(function () {
//                $("#quzhouticket").animate({ bottom: "-201px" }, 1500);
//            });
        });
        function startscrolltime() {
            scrollimg();
            t = setTimeout("startscrolltime()", 50);
        }

        function scrollimg() {
            var imgtop = $(".adcolum img").css("top");
            imgtop=imgtop.replace("px", "");
            if (imgtop >= 0) {
                $(".adcolum img").css("top", "-160px");
            }
            else {
                imgtop = parseInt(imgtop) + parseInt(1);
                $(".adcolum img").css("top", imgtop+"px");
            }
        }
        


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <%--<self:ContentReader runat="server" ID="default" CanEdit="true" type="首页" CssClass="editdiv"/>--%>
       <!--顶部推荐-->
    <%--<div id="toprecomm">
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
    </div>--%>
    <div id="qz">
        <img src="/theme/default/image/20130116/quzhouBg.png" alt="衢州新春大派送" />
        <a href="/Tickets/quzhou"></a>
    </div>

    <div class="adcolum">
        <img src="/Img/农行.jpg" alt="农行优惠" />
    </div>
    <div class="lpcolum">
        <a href="/topic/jiangshanlianpiao.aspx">
            <img src="/Img/jiangshanlianpiao_home.jpg" alt="套票江郎山" />
        </a>
    </div>
     <div class="fcolum">
        <div class="fcolum1">
            <span class="fcol1_scname">
                江郎山风景名胜区
            </span>
            <span class="fcol1_area">衢州</span>
            <a href="/Tickets/quzhou_jiangshanshi/jianglangshan.html"><img src="/ScenicImg/江郎山风景名胜区.jpg" width="100%" height="160px" alt="江郎山风景名胜区" /></a>
            <p>世界自然遗产、国家级风景名胜区、国家AAAA级旅游区江郎山……</p>
            <hr />
            <div class="fcol1_bottom">
                <span class="yj">原价&nbsp;&nbsp;60元</span><span class="xcmp">春节门票大派送</span><a href="/Tickets/quzhou_jiangshanshi/jianglangshan.html" class="btna"></a>
            </div>
        </div>
        <div class="fcolum1">
            <span class="fcol1_scname">
                廿八都
            </span>
            <span class="fcol1_area">衢州</span>
            <a href="/Tickets/quzhou_jiangshanshi/nianbadu.html"><img src="/ScenicImg/廿八都.jpg" width="100%" height="160px" alt="廿八都" /></a>
            <p>提起“江南古镇”不由使人想到“户藏烟浦，家具画船”的水乡景色……</p>
            <hr />
            <div class="fcol1_bottom">
                <span class="yj">原价&nbsp;&nbsp;120元</span><span class="xcmp">春节门票大派送</span><a href="/Tickets/quzhou_jiangshanshi/nianbadu.html" class="btna"></a>
            </div>
        </div>
        <div class="fcolum1">
            <span class="fcol1_scname">
                清漾
            </span>
            <span class="fcol1_area">衢州</span>
            <a href="/Tickets/quzhou_jiangshanshi/qingyangcun.html"><img src="/ScenicImg/清漾.jpg" width="100%" height="160px" alt="清漾" /></a>
            <p>清漾毛氏文化村，距市区约20公里，位于江郎山麓.....</p>
            <hr />
            <div class="fcol1_bottom">
               <span class="yj">原价&nbsp;&nbsp;50元</span><span class="xcmp">春节门票大派送</span><a href="/Tickets/quzhou_jiangshanshi/qingyangcun.html" class="btna"></a>
            </div>
        </div>
        <div class="fcolum1">
            <span class="fcol1_scname">
                桃花源农家乐
            </span>
            <span class="fcol1_area">衢州</span>
            <a href="/Tickets/quzhou_changshanxian/taohuayuannongjia.html"><img src="/ScenicImg/桃花源农家乐.jpg" width="100%" height="160px" alt="桃花源农家乐" /></a>
            <p>位于常山第一高峰白菊花尖西坡，山高林密，水清空气好……</p>
            <hr />
            <div class="fcol1_bottom">
                <span class="yj">原价&nbsp;&nbsp;50元</span><span class="xcmp">春节门票大派送</span><a href="/Tickets/quzhou_changshanxian/taohuayuannongjia.html" class="btna"></a>
            </div>
        </div>
    </div>



    

    <div class="scoloum">
        <div class="sccol1">
            <div class="sccol1row1">
                <a href="/Tickets/quzhou_changshanxian/sanqushilin.html">
                    <img alt="三衢石林" src="/ScenicImg/“三衢石林.jpg" width="100%" height="100%" />
                    <p>
                    </p>
                    <span>遂昌神龙谷瀑布</span>
                    <div class="mark">
                    </div>
                </a>
            </div>
            <div class="sccol1row2">
                <a href="/Tickets/quzhou_kaihuaxian/fengloukeng.html">
                    <img alt="钱江源枫楼坑景区" src="/ScenicImg/钱江源枫楼坑景区.jpg" width="100%" height="100%" />
                    <p>
                    </p>
                    <span>钱江源枫楼坑景区</span>
                    <div class="mark">
                    </div>
                </a>
            </div>
        </div>
        <div class="sccol2">
            <div class="sccol2row1">
                <a href="/Tickets/quzhou_longyouxian/longyoushiku.html">
                    <img alt="龙游石窟" src="/ScenicImg/龙游石窟.jpg" width="100%" height="100%" />
                    <p>
                    </p>
                    <span>龙游石窟</span>
                    <div class="mark" style="width: 50%">
                    </div>
                </a><a href="/Tickets/quzhou_longyouxian/longyouminjuyuan.html">
                    <img alt="龙游民居苑" src="/ScenicImg/龙游民居苑.jpg" width="100%" height="100%" />
                    <p style="left: 163px;">
                    </p>
                    <span style="left: 163px;">龙游民居苑</span>
                    <div class="mark" style="width: 50%; left: 163px;">
                    </div>
                </a>
            </div>
            <div class="sccol2row2">
                <a href="/Tickets/quzhou_quzhou/jiulonghu.html">
                    <img alt="九龙湖" src="/ScenicImg/九龙湖.jpg" width="100%" height="100%" />
                    <p>
                    </p>
                    <span>九龙湖</span>
                    <div class="mark">
                    </div>
                </a>
            </div>
            <div class="sccol2row3">
                <a href="/Tickets/quzhou_changshanxian/jindingzi.html">
                    <img alt="金钉子景区" src="/ScenicImg/金钉子景区.jpg" width="100%" height="100%" />
                    <p>
                    </p>
                    <span>金钉子景区</span>
                    <div class="mark" style="width: 50%">
                    </div>
                </a><a href="/Tickets/quzhou_changshanxian/huanggangshanwanshousi.html">
                    <img alt="黄冈山万寿寺" src="/ScenicImg/黄冈山万寿寺.jpg" width="100%" height="100%" />
                    <p style="left: 163px;">
                    </p>
                    <span style="left: 163px;">黄冈山万寿寺</span>
                    <div class="mark" style="width: 50%; left: 163px;">
                    </div>
                </a>
            </div>
        </div>
        <div class="sccol3">
            <div class="sccol3row1">
                <a href="/Tickets/quzhou_kaihuaxian/gutianshan.html">
                    <img alt="古田山国家级自然保护区" src="/ScenicImg/古田山国家级自然保护区.jpg" width="100%" height="100%" />
                    <p>
                    </p>
                    <span>古田山国家级自然保护区</span>
                    <div class="mark">
                    </div>
                </a>
            </div>
            <div class="sccol3row2">
                <a href="/Tickets/quzhou_jiangshanshi/fugaishan.html">
                    <img alt="浮盖山" src="/ScenicImg/浮盖山.jpg" width="100%" height="100%" />
                    <p>
                    </p>
                    <span>浮盖山</span>
                    <div class="mark">
                    </div>
                </a>
            </div>
        </div>
        <div class="sccol4">
            <div class="sccol4row1">
                <img src="/theme/default/image/20130116/scenicAdBg2.png" />
                <div class="sclist">
                <a href="/Tickets/quzhou_kaihuaxian/geyimeishubolanyuan.html">中国根艺美术博览园</a>
                <a href="/Tickets/quzhou_changshanxian/sanqushilin.html">三衢石林</a>
                <a href="/Tickets/quzhou_jiangshanshi/jianglangshan.html">世界自然遗产--江郎山</a>
                <a href="/Tickets/quzhou_jiangshanshi/qingyangcun.html">毛泽东祖居地--清漾毛氏文化村</a>
                <a href="/Tickets/quzhou_jiangshanshi/nianbadu.html">江南古寨廿八都--寻梦之都</a>
                <a href="/Tickets/quzhou_quzhou/jiulonghu.html">九龙湖景区</a>
                </div>
            </div>
        </div>
    </div>


    <%--<div id="quzhouticket">
        <a href="/Tickets/quzhou" style=" display:block; width:100%;height:100%; position:absolute; z-index:9990">
        </a>
        <a id="closeWin" style="width:20px; height:20px; display:block; position:absolute;top:0px; right:0px; z-index:9991;cursor:pointer">
        </a>
    </div>--%>
</asp:Content>
