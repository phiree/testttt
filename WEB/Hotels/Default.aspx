<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Hotels_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
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
    <div id="sceniclist">
        <asp:Repeater runat="server" ID="rpthotel" OnItemDataBound="rpthotel_ItemDataBound">
            <ItemTemplate>
                <div class="scenicdesc">
                    <div class="scenicimgdivbg">
                        <a href='/Hotels/Details.aspx?hotelid=<%#Eval("hotelId") %>'>
                            <img class="scenicdescimg" src='<%#Eval("url_3") %>' /></a>
                    </div>
                    <div class="scenicname">
                        <a runat="server" id="schref2" title='<%# Eval("HotelName") %>' style="display: block;font-size:14px;" >
                            <%# Eval("HotelName").ToString().Length > 14 ? Eval("HotelName").ToString().Substring(0,14)+"..." : Eval("HotelName")%></a>
                    </div>
                    <div class="dvprice">
                        <div style="float: left">
                            <span class="normalpr"><em>原价
                                <asp:Literal runat="server" ID="liPriceNormal"></asp:Literal>元</em></span> <span
                                    class="onlinepr">新春派送价<em><asp:Literal runat="server" ID="liPriceOnline"></asp:Literal></em>元</span>
                        </div>
                        <aclass="linkorder"  href='/Hotels/Details.aspx?hotelid=<%#Eval("hotelId") %>'>
                            抢票
                        </a>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
