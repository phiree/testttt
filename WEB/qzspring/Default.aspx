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
            imgtop = imgtop.replace("px", "");
            if (imgtop >= 0) {
                $(".adcolum img").css("top", "-160px");
            }
            else {
                imgtop = parseInt(imgtop) + parseInt(1);
                $(".adcolum img").css("top", imgtop + "px");
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
  <!--  <div id="qz" style="margin-top:10px">
        <a href="/Tickets/quzhou"></a>
        <div id="hdgz">
            <ul>
                <li>1、<span>活动时间:</span>2013年1月25日-2013年2月6日。 </li>
                <li>2、<span>开抢时间:</span>每天10:00开抢，每日上新，抢完即止。 </li>
                <li>3、<span>兑换方式:</span>抢票成功的用户刷而带身份证即可进入相应景区；门票不 </li>
                <li><span style=" visibility:hidden;">3、兑换方式:</span>可转让，刷完作废；团队谢绝使用。 </li>
                <li>4、<span>免费身份证门票有效期:</span>2013年2月1日－2013年2月28日。 </li>
                <li>5、<span>特别提醒:</span>一个用户帐号限抢5个景区门票。 </li>
                <li>6、<span>详询热线:</span>12301或0571-12301。 </li>
                <li>7、本次活动最终解释权归浙江省旅游信息中心</li>
            </ul>
        </div>
        <div id="qplc">
            <ul>
                <li>
                    <span class="step"><span style="color:#FEE979;margin-right:25px;">第一步</span>选择喜欢景区，点击“立刻抢票”</span>
                </li>
                <li>
                    <span class="step"><span style="color:#FEE979;margin-right:25px;">第二步</span>注册本站用户</span>
                </li>
                <li>
                    <span class="step"><span style="color:#FEE979;margin-right:25px;">第三步</span>输入游览者姓名和身份证号码（用于景区验票）</span>
                </li>
                <li>
                    <span class="step"><span style="color:#FEE979;margin-right:25px;">第四步</span>在“个人中心”中查看抢到的门票 </span>
                </li>
            </ul>
        </div>


    </div>-->
   <a href="/tickets/quzhou/"><img src="/img/quzhouspringjieshu.jpg" alt='衢州春节门票大派送活动结束' /></a>
 
   <%-- <div class="adcolum">
        <img src="/Img/农行.jpg" alt="农行优惠" />
    </div>--%>
    <%--<div class="lpcolum">
        <a href="/topic/jiangshanlianpiao.aspx">
            <img src="/Img/jiangshanlianpiao_home.jpg" alt="套票江郎山" />
        </a>
    </div>--%>
       <div class="fcolum">
        <div class="fcolum1">
            <span class="fcol1_scname">
                江郎山风景名胜区
            </span>
            <span class="fcol1_area">衢州</span>
            <a href="/Tickets/quzhou_jiangshanshi/jianglangshan.html"><img src="/Img/homepage/江郎山风景名胜区.jpg" width="100%" height="160px" alt="江郎山风景名胜区" /></a>
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
            <a href="/Tickets/quzhou_jiangshanshi/nianbadu.html"><img src="/Img/homepage/廿八都.jpg" width="100%" height="160px" alt="廿八都" /></a>
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
            <a href="/Tickets/quzhou_jiangshanshi/qingyangcun.html"><img src="/Img/homepage/清漾.jpg" width="100%" height="160px" alt="清漾" /></a>
            <p>清漾毛氏文化村，距市区约20公里，位于江郎山麓.....</p>
            <hr />
            <div class="fcol1_bottom">
               <span class="yj">原价&nbsp;&nbsp;50元</span><span class="xcmp">春节门票大派送</span><a href="/Tickets/quzhou_jiangshanshi/qingyangcun.html" class="btna"></a>
            </div>
        </div>
        <div class="fcolum1">
            <span class="fcol1_scname">
                龙游石窟
            </span>
            <span class="fcol1_area">衢州</span>
            <a href="/Tickets/quzhou_longyouxian/longyoushiku.html"><img src="/Img/homepage/龙游石窟.jpg" width="100%" height="160px" alt="龙游石窟" /></a>
            <p>古代最高水平的地下人工建筑群之一</p>
            <hr />
            <div class="fcol1_bottom">
                <span class="yj">原价&nbsp;&nbsp;50元</span><span class="xcmp">春节门票大派送</span><a href="/Tickets/quzhou_changshanxian/taohuayuannongjia.html" class="btna"></a>
            </div>
        </div>
    </div>



    

    <div class="scoloum">
        <div class="sccol1">
            <div class="sccol1row1">
                <a href="/Tickets/quzhou_kaihuaxian/geyimeishubolanyuan.html">
                    <img alt="开化根雕博览园" src="/ScenicImg/small/1e02db61-256b-4671-bfc5-a01c6ebdd422_s.jpg" width="100%" height="100%" />
                    <p>

                    </p>
                   <span>开化根雕博览园</span>
                    <div class="mark">
                    </div>
                </a>
            </div>
            <div class="sccol1row2">
                <a href="/Tickets/quzhou_kaihuaxian/fengloukeng.html">
                    <img alt="钱江源枫楼坑景区" src="/Img/homepage/钱江源枫楼坑景区.jpg" width="100%" height="100%" />
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
                    <img alt="龙游石窟" src="/Img/homepage/龙游石窟.jpg" width="100%" height="100%" />
                    <p>
                    </p>
                    <span>龙游石窟</span>
                    <div class="mark" style="width: 50%">
                    </div>
                </a><a href="/Tickets/quzhou_longyouxian/longyouminjuyuan.html">
                    <img alt="龙游民居苑" src="/Img/homepage/龙游民居苑.jpg" width="100%" height="100%" />
                    <p style="left: 163px;">
                    </p>
                    <span style="left: 163px;">龙游民居苑</span>
                    <div class="mark" style="width: 50%; left: 163px;">
                    </div>
                </a>
            </div>
            <div class="sccol2row2">
                <a href="/Tickets/quzhou_quzhou/jiulonghu.html">
                    <img alt="九龙湖" src="/Img/homepage/九龙湖.jpg" width="100%" height="100%" />
                    <p>
                    </p>
                    <span>九龙湖</span>
                    <div class="mark">
                    </div>
                </a>
            </div>
            <div class="sccol2row3">
                <a href="/Tickets/quzhou_changshanxian/qzwlsz.html">
                    <img alt="卧龙山庄" src="/ScenicImg/small/b26611fa-f534-4118-a183-7b29b9cfeb31_s.jpg" width="100%" height="100%" />
                    <p>
                    </p>
                    <span>卧龙山庄</span>
                    <div class="mark" style="width: 50%">
                    </div>
                </a><a href="/Tickets/quzhou_jiangshanshi/xianxiaguan.html">
                    <img alt="戴笠故居（含仙霞关）" src="/ScenicImg/small/6a5be321-4198-41b4-bbbf-1bd0beb7c015_s.jpg" width="100%" height="100%" />
                    <p style="left: 163px;">
                    </p>
                    <span style="left: 163px;">戴笠故居（含仙霞关）</span>
                    <div class="mark" style="width: 50%; left: 163px;">
                    </div>
                </a>
            </div>
        </div>
        <div class="sccol3">
            <div class="sccol3row1">
                <a href="/Tickets/quzhou_kaihuaxian/gutianshan.html">
                    <img alt="古田山国家级自然保护区" src="/Img/homepage/古田山国家级自然保护区.jpg" width="100%" height="100%" />
                    <p>
                    </p>
                    <span>古田山国家级自然保护区</span>
                    <div class="mark">
                    </div>
                </a>
            </div>
            <div class="sccol3row2">
                <a href="/Tickets/quzhou_jiangshanshi/fugaishan.html">
                    <img alt="浮盖山" src="/Img/homepage/浮盖山.jpg" width="100%" height="100%" />
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
