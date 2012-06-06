<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DefaultMap.aspx.cs" Inherits="map_DefaultMap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/DefaultMapCss.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.2"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/InlineTip.js" type="text/javascript"></script>
    <script src="/map/map.js" type="text/javascript"></script>
    <%--<link href="/Styles/default.css" rel="stylesheet" type="text/css" />--%>
    <link rel="stylesheet" type="text/css" href="../Styles/page.css" />
    <script src="../Scripts/jquery.myPagination.js" type="text/javascript"></script>
    <script type="text/javascript">
        var winWidth = 0;

        var winHeight = 0;

        function findDimensions() //函数：获取尺寸
        {

            //获取窗口宽度

            if (window.innerWidth)

                winWidth = window.innerWidth;

            else if ((document.body) && (document.body.clientWidth))

                winWidth = document.body.clientWidth;

            //获取窗口高度

            if (window.innerHeight)

                winHeight = window.innerHeight;

            else if ((document.body) && (document.body.clientHeight))

                winHeight = document.body.clientHeight;

            //通过深入Document内部对body进行检测，获取窗口大小

            if (document.documentElement && document.documentElement.clientHeight && document.documentElement.clientWidth) {

                winHeight = document.documentElement.clientHeight;

                winWidth = document.documentElement.clientWidth;

            }

        }

        $(document).ready(
            function () {
                findDimensions();
                if (winWidth < 1260) {
                    $("body").width(1260);
                }
                if (winHeight < 680) {
                    $("body").height(winHeight);
                    $("#left").height(680 - 185);
                    $("#right").height(680 - 185);
                }
                else {
                    $("#left").height(winHeight - 185);
                    $("#right").height(winHeight - 185);
                }
                $("#left").width($("body").width() - 278-1);
                $(".topmid").width($("body").width() - 18 - 265 - 30 - 18);





     
            });
            window.onresize = function () {
                findDimensions();
                if (winWidth < 1260) {
                    $("body").width(1260);
                }
                else {
                    $("body").width(winWidth);
                }
                if (winHeight < 680) {
                    $("body").height(winHeight);
                    $("#left").height(680 - 185);
                    $("#right").height(680 - 185);
                }
                else {
                    $("body").height(winHeight);
                    $("#left").height(winHeight - 185);
                    $("#right").height(winHeight - 185);
                }
                $("#left").width($("body").width() - 278-1);
                $(".topmid").width($("body").width() - 18 - 265 - 30 - 18);
            }

           


           
    </script><script language="javascript" type="text/javascript">
                 $(function () {
                     $(".areaname a").each(function (e) {
                         var that = this;
                         var type = $(that).parent().attr("id");

                         var href = $(that).attr("href");

                         if (getParameterByName(type, window.location.href) == getParameterByName(type, href) || getParameterByName(type, window.location.href) + "areaid=1018" == getParameterByName(type, href)) {
                             $(that).addClass("highlightSelected");
                             $(that).css("color", "White");
                             
                         }
                         else {
                             $(that).removeClass("highlightSelected");
                         }
                     });
                     function getParameterByName(name, query) {
                         query = query.replace("#m", "");
                         var match = RegExp('[?&]' + name + '=([^&]*)')
                    .exec(query);
                         return match && decodeURIComponent(match[1].replace(/\+/g, ' '));
                     }


                     $("#txtSearch").InlineTip({ "tip": "请输入您要搜索的景区" });
                 });


                 function btnarea(obj) {
                     if (obj.innerHTML == "全部") {
                         $.cookie("level", "");
                     }
                     else {
                         $.cookie("level", obj.innerHTML);
                     }
                     $(".sceniclevel a").attr("style", "background-color:#B5B5B5;");
                     $(obj).attr("style", "background-color:#8BB06D");
                     check2();
                 }
                
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="top">
            <div class="toptop">
                <div class="topreturn">
                    <a href="../Default.aspx">返回首页</a>
                </div>
                <div class="toplogin">
                    <asp:LoginView ID="LoginView1" runat="server">
                            <LoggedInTemplate>
                                <asp:LoginName ID="LoginName1" runat="server" CssClass="loginname" />
                                <img id="imgIcon" alt="<%= iconAlt %>" style='display: <%= string.IsNullOrEmpty(iconUrl)?"none":"block" %>'
                                    src="<%= iconUrl %>" />
                            </LoggedInTemplate>
                            <AnonymousTemplate>
                                <a id="hrefreg" href="/account/register.aspx" class="aregister">注册</a>
                            </AnonymousTemplate>
                        </asp:LoginView>
                    <asp:LoginStatus ID="loginStatus"  LoginText="登录" LogoutText="退出" LogoutAction="Redirect" LogoutPageUrl="/account/logout.aspx" CssClass="loginstatus"
                            runat="server" />
                </div>
            </div>
            <div class="topleft"></div>
            <div class="topmid">
                <div class="searchscenic">
                    
                    
                </div>
                <div class="areaname" id="areaid">
                    <asp:Repeater ID="rptarea" runat="server" 
                        onitemdatabound="rptarea_ItemDataBound" >
                        <ItemTemplate>
                            <a runat="server" id="areaname" href='<%# Eval("Id","DefaultMap.aspx?areaid={0}") %>'><%# Eval("Name")  %></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="level">
                    <a class="aareatitle">地区:</a>
                    <div class="sceniclevel">
                        <a style=" background:#8BB06D" onclick="btnarea(this)">全部</a><a onclick="btnarea(this)">5A</a><a onclick="btnarea(this)">4A</a><a onclick="btnarea(this)">3A</a>
                    </div>
                </div>
            </div>
            <div class="topright"></div>
        </div>
        <div class="seper">
        
        </div>
        <div id="left">
            <div id="container">
            </div>
        </div>
        <div id="right">
            <div class="searchdiv">
                <input id="txtSearch" type="text" class="scenicname" />
                <input id="Button1" type="button" class="btnsearch" onclick="check2();" />
            </div>
            <%--<div class="resulttitle">
                搜索到：<span id="searchareaname"></span>共<span id="countscenic" style="margin:0px"></span>个景区
            </div>--%>
            <div id="resultscenic">
            </div>
            <div style=" padding:5px; margin: 20px 0px 10px 0px; height:25px;" id="pager" ></div>
        </div>
        <div id="bottom">
             <div class="about"><a>关于中国旅游在线</a><span>|</span><a>联系我们</a><span>|</span><a>景区登录</a></div>
        </div>
    </form>
</body>
</html>
