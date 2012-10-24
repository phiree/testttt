<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Map.aspx.cs" Inherits="map_Map" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <%--<link href="../Styles/DefaultMapCss.css" rel="stylesheet" type="text/css" />--%>
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.2"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/InlineTip.js" type="text/javascript"></script>
    <script src="/map/map.js" type="text/javascript"></script>
    <%--<link href="/Styles/default.css" rel="stylesheet" type="text/css" />--%>
    <link rel="stylesheet" type="text/css" href="../Styles/page.css" />
    <script src="../Scripts/jquery.myPagination.js" type="text/javascript"></script>
    <link href="/theme/default/css/map.css" rel="stylesheet" type="text/css" />
    <script src="mapcommon.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <div id="left">
        <div class="selbg"></div>
        <div class="sellevel">
            <span>景区级别</span><img src="/Img/yuansu/jiantouicon1.png" width="14px" height="9px"  style="margin-left:5px"/>
        </div>
        <div class="sellevelinfo">
            <a style=" border:1px solid #F9CD8A;background-color:#FDF0CA;color:#E8641B" onclick="btnarea(this)">全部</a><a  onclick="btnarea(this)">5A</a><a onclick="btnarea(this)">4A</a><a onclick="btnarea(this)">3A</a>
        </div>
        <div class="selarea">
            <span>选择城市</span><img src="/Img/yuansu/jiantouicon1.png" width="14px" height="9px"  style="margin-left:5px"/>
        </div>
        <div class="selareainfo">
            <asp:Repeater ID="rptarea" runat="server" 
                        onitemdatabound="rptarea_ItemDataBound" >
                        <ItemTemplate>
                            <a runat="server" id="areaname" onclick="qdpostion();" href='<%# Eval("Id","Map.aspx?areaid={0}") %>'><%# Eval("Name")  %></a>
                        </ItemTemplate>
                    </asp:Repeater>
        </div>
        <div class="seltheme">
            <span>旅游主题</span><img src="/Img/yuansu/jiantouicon1.png" width="14px" height="9px"  style="margin-left:5px" />
        </div>
        <div class="selthemeinfo">
            <a style=" border:1px solid #F9CD8A;background-color:#FDF0CA;color:#E8641B"  onclick="qdtopic(this);">全部</a>
            <asp:Repeater ID="rpttheme" runat="server">
                        <ItemTemplate>
                            <a  onclick="qdtopic(this);"><%# Eval("Name")  %></a>
                        </ItemTemplate>
                    </asp:Repeater>
        </div>
        <input id="txtSearch" type="text" class="selkeyword" />
        <input id="Button1" type="button" class="btnsearch" onclick="check2();" value="地图查找" />
        <div id="container">
        </div>
        </div>
    <div id="right">
            <%--<div class="searchdiv">
                <input id="txtSearch" type="text" class="scenicname" />
                <input id="Button1" type="button" class="btnsearch" onclick="check2();" />
            </div>--%>
            <div class="resulttitle">
                搜索到：<span id="searchareaname"></span>共<span id="countscenic" style="margin:0px"></span>个景区
            </div>
            <div id="resultscenic" style="min-height:460px; ">
            </div>
            <div style=" padding:5px; margin: 20px 0px 10px 0px; height:25px;" id="pager" ></div>
        </div>
</asp:Content>

