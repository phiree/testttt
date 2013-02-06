<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Hotels_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
    <style type="text/css">
        .product_twocol li
        {
            float: left;
            width: 218px;
            padding: 5px;
            margin-bottom: 15px;
            border: 1px solid #e5e5e5;
        }
        .product_twocol li:hover, .product_twocol li.on
        {
            padding: 2px;
            border: 4px solid #ffe64f;
            box-shadow: 0 0 5px rgba(255,230,79,0.5);
        }
        .product_twocol li .pic
        {
            width: 218px;
            height: 165px;
            overflow: hidden;
            text-align: center;
            margin-bottom: 10px;
        }
        .product_twocol li .pic img
        {
            max-width: 218px;
            _width: 218px;
        }
        .product_twocol li .hinfo .name
        {
            height: 38px;
            margin-bottom: 10px;
            overflow: hidden;
        }
        .product_twocol li .hinfo .name a
        {
            color: #666;
        }
        .product_twocol li .hinfo .name a:hover
        {
            color: #f60;
            text-decoration: none;
        }
        .product_twocol li .hinfo .name .flash_hotel, .product_twocol li .hinfo .name .flash_room
        {
            display: inline-block;
            width: 250px;
            overflow: hidden;
            white-space: nowrap;
            text-overflow: ellipsis;
        }
        .product_twocol li .hinfo .name .flash_hotel
        {
            width: 180px;
            font-size: 14px;
            font-weight: 700;
            color: #333;
            vertical-align: middle;
        }
        .product_twocol li .hinfo .name .flash_hotel:hover, .product_twocol li .hinfo .name a:hover .flash_hotel
        {
            color: #f60;
        }
        .product_twocol li .hinfo .price
        {
            font: 700 34px Arial;
            color: #f60;
        }
        .product_twocol li .hinfo .price .pfh
        {
            font-size: 14px;
            color: #666;
        }
        .product_twocol li .hinfo .ori_price
        {
            color: #666;
            margin-left: 5px;
        }
        .product_twocol li .hinfo .ori_price em
        {
            text-decoration: line-through;
            font-family: arial;
        }
        .product_twocol li .hinfo .btn_view, .product_twocol li .hinfo .btn_view_fs
        {
            display: none;
            width: 70px;
            height: 30px;
            margin-top: 4px;
            background: url(/img/hotel/hotel_index_2013.png?t=201301291427) no-repeat -400px -200px;
            text-indent: -9999em;
        }
        .product_twocol li .hinfo .btn_view:hover
        {
            background-position: -400px -240px;
        }
        .product_twocol li .hinfo .btn_view_fs
        {
            background-position: -400px -280px;
        }
        .product_twocol li .hinfo .btn_view_fs:hover
        {
            background-position: -400px -32z0px;
        }
        .product_twocol li:hover .hinfo .btn_view, .product_twocol li:hover .hinfo .btn_view_fs, .product_twocol li.on .hinfo .btn_view, .product_twocol li.on .hinfo .btn_view_fs
        {
            display: block;
        }
        .product_twocol li .hinfo .fanIcon_old
        {
            vertical-align: 4px;
        }
        .product_twocol li .bt1
        {
            border-top: 1px dotted #ccc;
        }
        .product_twocol li .bb1
        {
            border-bottom: 1px dotted #ccc;
            padding-bottom: 10px;
        }
        .getmore
        {
            text-align: center;
            padding: 20px 0;
        }
        .getmore .btn
        {
            display: block;
            width: 200px;
            height: 30px;
            margin: 0 auto;
            background: url(/img/hotel/hotel_index_2013.png?t=201301291427) no-repeat -120px -460px;
            color: #fff;
            text-decoration: none;
            font: 400 14px/28px Microsoft Yahei,\5b8b\4f53;
            overflow: hidden;
        }
        .getmore .btn:hover
        {
            background-position: -120px -490px;
            color: #fff;
            text-decoration: none;
        }
        .mr10
        {
            margin-right: 10px;
        }
        .mr5
        {
            margin-right: 5px;
        }
        .p5
        {
            padding: 5px;
        }
        a
        {
            color: #36c;
            text-decoration: none;
            outline: 0;
        }
        a:hover
        {
            color: #36c;
            cursor: pointer;
            text-decoration: underline;
        }
        a:active
        {
            color: #c33;
        }
        .clx:after
        {
            clear: both;
            content: ".";
            display: block;
            height: 0;
            visibility: hidden;
            color: #131313;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="ticketsellist">
        <h1>
            <asp:Literal runat="server" ID="liH1">浙江省酒店</asp:Literal>
        </h1>
    </div>
    <%--<div id="selectdiv">
        <div class="areadiv">
            <span class="areadivspan" style="color: Black; font-weight: normal">所在城市:</span>
            <a runat="server" id="hrefAllArea" t="area" style="margin-right: 10px;">全部</a>
            <asp:Repeater runat="server" ID="rptAreas" OnItemDataBound="rptArea_ItemDataBound">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <a t="area" runat="server" id="hrefArea" style="margin-right: 10px; position: relative">
                        <%# Eval("Name").ToString().Substring(3,2).Trim() %>
                        <span class="topicon">▲</span> </a>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div id="countydiv" runat="server" class="countydiv">
            <span class="themedivspan" style="color: Black; font-weight: normal; visibility: hidden">
                所在区县:</span>
            <div style="float: left; width: 640px; background-color: #F3F2EE; padding-top: 10px;">--%>
    <%--<a runat="server" id="hrefCountyAll" style="margin-right: 10px;" class="hlc">全部</a>
                <asp:Repeater ID="rptCounty" runat="server" OnItemDataBound="rptCounty_ItemDataBound">
                    <ItemTemplate>
                        <a runat="server" id="hlcounty" style="margin-right: 10px;">
                            <%# Eval("Name").ToString().Substring(3).Trim() %>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="themediv" style="display: none">
            <span class="themedivspan" style="color: Black; font-weight: normal">旅游主题:</span>
            <div style="float: left; width: 640px;">
                <a runat="server" id="hrefTopicAll" style="margin-right: 10px;">全部</a>
                <asp:Repeater ID="rptTopic" runat="server" OnItemDataBound="rptTopic_ItemDataBound">
                    <ItemTemplate>
                        <a runat="server" id="hltopic" style="margin-right: 10px;">
                            <%# Eval("Name") %></a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="leveldiv">
            <span class="themedivspan" style="color: Black; font-weight: normal">景区等级:</span>
            <a runat="server" id="hlLevelAll">全部</a> <a runat="server" t="level" id="hlLevel5">5A</a>
            <a runat="server" t="level" id="hlLevel4">4A</a> <a runat="server" t="level" id="hlLevel3">
                3A</a> <a runat="server" t="level" id="hlLevel2">2A</a> <a runat="server" t="level"
                    id="hlLevel1">A</a>
        </div>
    </div>--%>
    <div class="breadNav">
        <p class="selectarea">
            您的位置:<a href="/hotels/">酒店</a>
            <%--<asp:PlaceHolder ID="phArea" runat="server">> <a href="" runat="server" id="breadareaurl">
            </a></asp:PlaceHolder>
            <asp:PlaceHolder ID="phCounty" runat="server">> <a href="" runat="server" id="breadcountyurl">
            </a></asp:PlaceHolder>
            <asp:PlaceHolder ID="phLevel" runat="server">><a href="" runat="server" id="breadlevelurl">
            </a></asp:PlaceHolder>
            <asp:PlaceHolder ID="phTopic" runat="server">><a href="" runat="server" id="breadtopic">
            </a></asp:PlaceHolder>
            &nbsp;<a style="text-decoration: none"><asp:Literal ID="lblTotal" runat="server"></asp:Literal></a></p>--%>
    </div>
    <ul id="FlashSaleList" class="product_twocol clx">
        <asp:Repeater runat="server" ID="rpthotel" OnItemDataBound="rpthotel_ItemDataBound">
            <ItemTemplate>
                <li class="mr5">
                    <div class="pic">
                        <a href='/Hotels/Details.aspx?hotelid=<%#Eval("hotelId") %>' target="_blank" title='<%# Eval("HotelName") %>'>
                            <img src='<%#Eval("url_1") %>'
                                onerror="this.src='http://www.elongstatic.com/hotels/pic/nopic_index.png'">
                        </a>
                    </div>
                    <div class="hinfo p5 clx">
                        <div class="name">
                            <a href='/Hotels/Details.aspx?hotelid=<%#Eval("hotelId") %>' target="_blank" title='<%# Eval("HotelName") %>'>
                                <span class="flash_hotel"><%# Eval("HotelName") %></span> <span style="display: ;" class="dx dx4"
                                    title=''></span>
                                <br>
                                <span class="flash_room"><%# Eval("address").ToString().Length > 14 ? Eval("address").ToString().Substring(0, 14) + "..." : Eval("address")%></span> </a>
                        </div>
                        <div class="left">
                            <strong class="price"><span class="pfh">¥</span>188</strong> <%--<span class="ori_price">
                                原价：<em>¥638</em></span>--%>
                        </div>
                        <div class="right">
                            <a href='/Hotels/Details.aspx?hotelid=<%#Eval("hotelId") %>' title="查看" class="btn_view" >查看</a></div>
                    </div>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </ul>
    <%--<div id="sceniclist">
        <asp:Repeater runat="server" ID="rpthotel" OnItemDataBound="rpthotel_ItemDataBound">
            <ItemTemplate>
                <div class="scenicdesc">
                    <div class="scenicimgdivbg">
                        <a href='/Hotels/Details.aspx?hotelid=<%#Eval("hotelId") %>'>
                            <img class="scenicdescimg" src='<%#Eval("url_3") %>' /></a>
                    </div>
                    <div class="scenicname">
                        <a runat="server" id="schref2" title='<%# Eval("HotelName") %>' style="display: block;
                            font-size: 14px;">
                            <%# Eval("HotelName").ToString().Length > 14 ? Eval("HotelName").ToString().Substring(0,14)+"..." : Eval("HotelName")%></a>
                    </div>
                    <div>
                        <div style="float: left;">
                            <strong style="font: 700 34px Arial; color: #F60;"><span style="font-size: 14px;
                                color: #666;">¥</span><%#(decimal.Parse(Eval("lowestPrice").ToString())).ToString("F0")%></strong>
                        </div>
                        <div style="float: right;">
                            <a style="width: 70px; height: 30px; margin-top: 4px; background: url(/img/hotel/hotel_index_2013.png?t=201301291427) no-repeat -400px -200px;
                                text-indent: -9999em;" title="查看" href='/Hotels/Details.aspx?hotelid=<%#Eval("hotelId") %>'>
                                查看</a>
                        </div>
                        </a>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>--%>
</asp:Content>
