<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="Details.aspx.cs" Inherits="Hotels_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
    <script src="/Scripts/contentReader.js" type="text/javascript"></script>
    <link href="/theme/default/css/TCCSS.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/global.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/default.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/scenic.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-1.9.1.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <link href="/Scripts/jqueryplugin/jqueryui/css/ui-lightness/jquery-ui-1.9.1.custom.min.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("#<%=checkInDateApply.ClientID %>").datepicker({ minDate: new Date() });
            $("#<%=checkOutDateApply.ClientID %>").datepicker({ minDate: new Date() });
        });
    </script>
    <style type="text/css">
        .in h2
        {
            background: url(/img/hotel/detailbg.png?t=201301291427) 0 -259px repeat-x;
            color: #131313;
            padding: 6px;
            font-size: 14px;
            font-weight: bold;
        }
        .facilities
        {
            width: 700px;
            border-bottom: 1px solid #E6E6E6;
            font-size: 12px;
            color: #555;
            overflow: auto;
            height: 1%;
            padding: 5px;
        }
        .in
        {
            border: 1px solid #CCC;
            margin-bottom: 10px;
            width: 97%;
        }
        .detail_box
        {
            width: 97%;
            border: 2px solid #FF6800;
            border-top: 0;
            margin-top: 10px;
        }
        .detail_box .dateBox
        {
            width: 700px;
            height: 35px;
            margin: auto;
            margin-top: 15px;
        }
        .rpList
        {
            width: 700px;
            border: 0;
            border-collapse: collapse;
            border-spacing: 0;
            margin: auto;
            margin-bottom: 20px;
            margin-top: 20px;
        }
        .detail_box .dateBox .left .indate
        {
            width: 110px;
            height: 25px;
            background: url(/img/hotel/detailicon.png?t=201301291427) no-repeat -42px -431px;
            border: 0;
            margin: 0 5px;
            vertical-align: middle;
            line-height: 23px;
            padding-left: 5px;
        }
        .rpList
        {
            width: 700px;
            border: 0;
            border-collapse: collapse;
            border-spacing: 0;
            margin: auto;
            margin-bottom: 20px;
            margin-top: 20px;
        }
        .rpList tr tr:hover
        {
            background: #f7f7f7;
        }
        .rpList th
        {
            color: #556c97;
            height: 21px;
            border-top: 1px solid #dde4f0;
            border-bottom: 1px solid #dde4f0;
            background: url(/img/hotel/detailbg.png?t=201301291427) repeat-x 0 -197px;
        }
        .rpList .w1
        {
            width: 210px;
            padding-left: 5px;
        }
        .rpList .w2
        {
            width: 50px;
            text-align: center;
        }
        .rpList .w3
        {
            width: 55px;
            text-align: center;
        }
        .rpList .w4
        {
            width: 205px;
            padding-left: 5px;
        }
        .rpList .w5
        {
            width: 70px;
        }
        .rpList th.w1
        {
            width: 210px;
            border-left: 1px solid #dde4f0;
            padding-left: 5px;
        }
        .rpList th.w2
        {
            width: 50px;
            text-align: center;
        }
        .rpList th.w3
        {
            width: 55px;
        }
        .rpList th.w4
        {
            width: 200px;
            padding-left: 5px;
        }
        .rpList th.w5
        {
            width: 75px;
            border-right: 1px solid #dde4f0;
        }
        .rpList td
        {
            height: 35px;
            border-bottom: 1px solid #f2f2f2;
        }
        .rpList td .gift
        {
            width: 16px;
            height: 16px;
            background: url(/img/hotel/icons.png?t=201301291427) 0 -930px no-repeat;
            display: inline-block;
            margin-left: 5px;
            vertical-align: middle;
        }
        .rpNtable td
        {
            border: 0;
        }
        .rpNtable td.w4
        {
            font-size: 20px !important;
            font-family: Tahoma;
            color: #ff7200;
        }
        .rpNtable td.w3
        {
            font-size: 14px;
            font-family: Tahoma;
        }
        .rpNtable td.w3 span.f12, .rpNtable td.w4 span.f12
        {
            font-size: 12px;
            font-family: Arial;
        }
        .rpNtable td.w4 span.f12
        {
            vertical-align: 5px;
        }
        .rpNtable td.w4 span.bor
        {
            border-bottom: 1px dotted #f60;
            cursor: pointer;
            _display: inline-block;
        }
        .rpNtable td.w4 span.f16
        {
            font-size: 16px;
            line-height: 17px;
            margin-left: 5px;
            width: 50px;
            height: 15px;
            background: url(/img/hotel/detailicon.png?t=201301291427) no-repeat 36px -384px;
            _background: url(/img/hotel/detailicon.png?t=201301291427) no-repeat 36px -383px;
            display: inline-block;
            cursor: pointer;
        }
        .rpNtable td.w4 span.f16:hover
        {
            background: url(/img/hotel/detailicon.png?t=201301291427) no-repeat 36px -399px;
        }
        .rpNtable td.w3, .rpNtable td.w3 span.f12
        {
            color: #b7b7b7;
            text-decoration: line-through;
            text-align: center;
        }
        .rpNtable td.pd25
        {
            width: 190px;
            padding-left: 25px;
        }
        table
        {
            border-collapse: collapse;
            border-spacing: 0;
        }
        a.book, a.full
        {
            float: right;
            margin-right: 5px;
            width: 56px;
            height: 27px;
            background: url(/img/hotel/detailicon.png?t=201301291427) -96px 0 no-repeat;
            display: inline-block;
            overflow: hidden;
            text-indent: -2000px;
        }
        a.book:hover
        {
            background-position: -96px -27px;
        }
        a.full
        {
            background-position: -96px -54px;
            cursor: not-allowed;
        }
        a.full:hover
        {
            background-position: -96px -54px;
            cursor: not-allowed;
        }
        .hotFxz
        {
            background: #f8f7f7;
            border-top: 1px solid #e4e1e3;
            padding: 10px;
            position: relative;
        }
        .hotFxz .fxzimg
        {
            margin-bottom: 5px;
        }
        .hotFxz p
        {
            word-wrap: break-word;
            word-break: break-all;
            margin: 0;
            padding: 0;
            color: #999;
        }
        .hotFxz .tr
        {
            width: 30px;
            height: 25px;
            float: right;
            _width: auto;
            _float: inherit;
            text-align: right;
            display: inline-block;
            margin-top: -20px;
        }
        .fanIcon
        {
            display: inline-block;
            width: 32px;
            padding-left: 16px;
            height: 15px;
            overflow: hidden;
            background: url(/img/hotel/hotels2012.png?t=201301291427) no-repeat -10px -521px;
            font-size: 11px;
            font-family: Arial;
            color: #ee9219;
            text-align: center;
            line-height: 15px;
            margin-left: 5px;
            cursor: help;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <p class="navsc">
        您选择的酒店：浙江省&nbsp;>&nbsp;<a runat="server" id="areaname">丽水市</a>&nbsp;>&nbsp;<a runat="server"
            id="county">遂昌县</a></p>
    <div class="mainscbg">
        <asp:Image ID="imgMain" CssClass="mainscenicimg" ImageUrl="" runat="server" />
    </div>
    <div id="maintitle">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblhotelname" Text="text" runat="server" Style="font-size: 18px; font-family: 微软雅黑;" />
                </td>
            </tr>
            <tr>
                <td style="width: 60px;">
                    星级：
                </td>
                <td>
                    <asp:Label Text="text" runat="server" ID="lbllevel" />
                </td>
            </tr>
            <tr>
                <td style="width: 60px;">
                    地址：
                </td>
                <td>
                    <asp:Label ID="lbladdress" Text="text" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 60px;">
                    酒店简介：
                </td>
                <td>
                    <asp:Label Text="text" runat="server" ID="lblhoteldesc" />
                </td>
            </tr>
            <tr>
                <td style="width: 60px;">
                    支付方式：
                </td>
                <td>
                    <asp:Repeater runat="server" ID="rptPayways">
                        <ItemTemplate>
                            <span>网上购买</span>
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
    </div>
    <div class="detail_box">
        <div class="dateBox">
            <div class="left">
                入住日期<input id="checkInDateApply" type="text"
                    class="indate" runat="server"/>离店日期<input type="text" class="indate" id="checkOutDateApply"
                        runat="server"/><input name="" type="button" class="inbut"
                            id="Revise" method="submit" value="修改"/>
            </div>
            <div class="right" id="promotionHtml">
            </div>
        </div>
        <div id="divRoomLoading" class="tc p15" style="display: none;">
            <span class="com_loading"></span>正在加载房型列表，请稍等…
        </div>
        <div id="divRoomList">
            <table class="rpList" id="commonRoomTable">
                <tbody>
                    <tr>
                        <th class="w1">
                            房型
                        </th>
                        <th class="w2">
                            床型
                        </th>
                        <th class="w2">
                            早餐
                        </th>
                        <th class="w2">
                            宽带
                        </th>
                        <th class="w3">
                            &nbsp;
                        </th>
                        <th class="w4">
                            日均价
                        </th>
                        <th class="w5">
                            &nbsp;
                        </th>
                    </tr>
                    <asp:Repeater runat="server" ID="rptrooms2">
                        <ItemTemplate>
                            <tr isshow="1" class="">
                                <td colspan="7">
                                    <table class="rpNtable">
                                        <tbody>
                                            <tr roomid="0001" isshadow="false" rpid="115707" sid="22165">
                                                <td class="w1" style="position: relative;">
                                                    <a href="javascript:void(0);">
                                                        <%#Eval("roomName")%></a>
                                                </td>
                                                <td class="w2">
                                                    <%#Eval("bedType").ToString().Split('床')[0]%>床
                                                </td>
                                                <td class="w2">
                                                    <%#Eval("ratePlanName")%>
                                                </td>
                                                <td class="w2">
                                                    <%#Eval("hasInternet")%>
                                                </td>
                                                <td class="w3">
                                                </td>
                                                <td class="w4">
                                                    <span class="bor" method="AvgPrice" style="font-size: 20px;"><span class="f12">¥</span><%#Eval("averageRate")%></span><span
                                                        class="fanIcon" method="coupon" islongcui="0">10元</span>
                                                </td>
                                                <td class="w5">
                                                    <a method="Order" title="" href='/Hotels/Order.aspx?hotelid=<%=Request["hotelid"].ToString() %>&typeid=<%#Eval("RoomTypeId") %>&rpid=<%#Eval("ratePlanId") %>&cin=<%=checkInDateApply.Value %>&cout=<%=checkOutDateApply.Value %>' class="book">预订</a>
                                                </td>
                                            </tr>
                                            <tr class="" mark="d" roomid="0001" style="display:none">
                                                <td colspan="7">
                                                    <div class="hotFxz">
                                                        <span class="jt"></span>
                                                        <div class="fxzimg">
                                                            <img src='<%#Eval("url_1") %>'
                                                                width="70" height="70" class="mr5" bigimageurl="http://www.elongstatic.com/imageapp/hotels/hotelimages/1272/21272002/1_6d0bc6a1-5ff0-4e69-96f4-945311b83a5e.jpg?v=20120727141238"
                                                                ispanorama="false" alt='<%#Eval("roomName") %>' method="ShowImage">
                                                        </div>
                                                        <p class="mb10">
                                                            <span class="mr20">床型：<%#Eval("bedType")%></span><span class="mr20">房间面积：<%#Eval("area")%>平方米</span><span
                                                                class="mr20">楼层：<%#Eval("roomFloor")%>层 </span>上网方式：宽带[<%#Eval("hasInternet")%>]</p>
                                                        <p>
                                                            其它：可加床：RMB 100;可安排无烟楼层</p>
                                                        <div class="tr">
                                                            <a href="javascript:void(0);" method="HideRoomDetail">隐藏</a></div>
                                                    </div>
                                                    <div class="clear">
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <div class="p5 ml15 mb10">
            </div>
        </div>
    </div>
    <div class="in faci">
        <h2>
            设施服务</h2>
        <div class="bgy">
            <dl class="facilities">
                <dt>酒店电话</dt>
                <dd>
                    <asp:Label Text="text" runat="server" ID="lblhoteltel" /></dd>
            </dl>
            <dl class="facilities">
                <dt>开业时间</dt>
                <dd>
                    <asp:Label Text="text" runat="server" ID="lblopentime" />
                </dd>
            </dl>
            <dl class="facilities" id="netAndwifi">
                <dt>提供服务</dt>
                <dd>
                    <asp:Label Text="text" runat="server" ID="lblnet" /></dd>
            </dl>
            <dl class="facilities">
                <dt class="lin">可接受的信用卡</dt>
                <dd class="credit">
                    <asp:Repeater runat="server">
                        <ItemTemplate>
                            <span class="unionpay" title="国内发行银联卡">国内发行银联卡</span>
                        </ItemTemplate>
                    </asp:Repeater>
                </dd>
            </dl>
            <div class="clear">
            </div>
        </div>
        <div class="downy">
        </div>
    </div>
    <div class="in faci">
        <h2>
            酒店简介</h2>
        <div class="bgy">
            <div class="p10 gray" id="Introduce">
                <asp:Label Text="text" runat="server" ID="lblhotelintro" />
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="downy">
        </div>
    </div>
</asp:Content>
