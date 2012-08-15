<%@ Page Title="" Language="C#" MasterPageFile="~/detail.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="/Scripts/slide.js" type="text/javascript"></script>
    <script src="/Scripts/pages/default.js" type="text/javascript"></script>
    <link href="/theme/default/css/default.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/pager.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/Show.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $(".navlistnb a").attr("class", "");
            $(".navlistnb a:eq(0)").attr("class", "navhight");
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
                <li>
                    <a href="/lishui/yunhetitianjingqu.html"><img src="/Img/slide/3.png" /></a>
                </li>
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
                <span>景区门票<strong>4</strong>折</span><a class="wa" href="">看看</a><a href="" class="btna"></a>
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
                <span>景区门票<strong>4</strong>折</span><a class="wa" href="">看看</a><a href="" class="btna"></a>
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
                <span>景区门票<strong>4</strong>折</span><a class="wa" href="">看看</a><a href="" class="btna"></a>
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
                <span>景区门票<strong>4</strong>折</span><a class="wa" href="">看看</a><a href="" class="btna"></a>
            </div>
        </div>
    </div>
    <div class="scoloum">   
        <div class="sccol1">
            <div class="sccol1row1">
                <a href="">
                    <img alt="遂昌神龙谷瀑布" src="/ScenicImg/“中华第一高瀑”-遂昌神龙谷瀑布.jpg" width="100%" height="100%" />
                    <p></p>
                    <span>遂昌神龙谷瀑布</span>
                    <div class="mark"></div>
                </a>
            </div>
            <div class="sccol1row2">
                <a href="">
                    <img alt="遂昌金矿" src="/ScenicImg/遂昌金矿.jpg" width="100%" height="100%" />
                    <p></p>
                    <span>遂昌金矿</span>
                    <div class="mark"></div>
                </a>
            </div>
        </div>
        <div class="sccol2">   
            <div class="sccol2row1">
                <a href="">
                    <img alt="南尖岩" src="/ScenicImg/南尖岩.jpg" width="100%" height="100%" />
                    <p></p>
                    <span>南尖岩</span>
                    <div class="mark" style="width:50%"></div>
                </a>
                <a href="">
                    <img alt="畲乡漂流" src="/ScenicImg/畲乡漂流.jpg" width="100%" height="100%" />
                    <p style="left:163px;"></p>
                    <span style="left:163px;">畲乡漂流</span>
                    <div class="mark" style="width:50%;left:163px;"></div>
                </a>
            </div>
            <div class="sccol2row2">
                <a href="">
                    <img alt="仙都" src="/ScenicImg/仙都.jpg" width="100%" height="100%" />
                    <p></p>
                    <span>仙都</span>
                    <div class="mark"></div>
                </a>
            </div>
            <div class="sccol2row3">
                <a href="">
                    <img alt="龙泉山" src="/ScenicImg/龙泉山-高山新居.jpg" width="100%" height="100%" />
                    <p></p>
                    <span>龙泉山</span>
                    <div class="mark" style="width:50%"></div>
                </a>
                <a href="">
                    <img alt="黄龙景区" src="/ScenicImg/黄龙景区.jpg" width="100%" height="100%" />
                    <p style="left:163px;"></p>
                    <span style="left:163px;">黄龙景区</span>
                    <div class="mark" style="width:50%;left:163px;"></div>
                </a>
            </div>
        </div>
        <div class="sccol3">   
            <div class="sccol3row1">
                <a href="">
                    <img alt="畲家少女" src="/ScenicImg/畲家少女.jpg" width="100%" height="100%" />
                    <p></p>
                    <span>畲家少女</span>
                    <div class="mark"></div>
                </a>
            </div>
            <div class="sccol3row2">
                <a href="">
                    <img alt="青田石门洞" src="/ScenicImg/青田石门洞.jpg" width="100%" height="100%" />
                    <p></p>
                    <span>青田石门洞</span>
                    <div class="mark"></div>
                </a>
            </div>
        </div>
        <div class="sccol4">
            <div class="sccol4row1">
                <img alt="地图" src="/ScenicImg/bj.gif" width="220px" height="214px" />
                <div class="sccol4row1bg"></div>
                <div class="sccol4row1info">
                    <p class="mapscname">丽水&nbsp;&nbsp;&nbsp;&nbsp;旅游亮点</p>
                    <hr/>
                    <p class="mapscnameinfo">寻找瑶池――南尖岩</p>
                    <p class="mapscnameinfo">穿越――百山祖―黄茅尖</p>
                    <hr />
                    <p class="mapscnameinfo">松阳县――这察原始林旅游</p>
                    <p class="mapscnameinfo2">旧志云：“徒其巅可览七邑之胜”</p>
                    <hr />
                    <p class="mapscnameinfo">遂昌县――神龙谷旅游</p>
                    <p class="mapscnameinfo2">森林瀑布神龙谷，汤公寻梦牡丹亭</p>
                </div>
            </div>
        </div> 
    </div>
    <div class="defaultbottom">
        
    </div>
</asp:Content>
