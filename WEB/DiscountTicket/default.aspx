<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="default.aspx.cs" Inherits="DiscountTicket_DiscountTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
    <link href="/theme/default/css/default.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/DiscountTicket.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/pager.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/Disticket.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="ticketsellist">
        <h1>
            <asp:Literal runat="server" ID="liH1">浙江省景区门票</asp:Literal>
        </h1>
    </div>
    <div id="selectdiv">
        <div class="areadiv">
            <span class="areadivspan" style="color: Black; font-weight: normal">所在城市:</span>
            <a runat="server" id="hrefAllArea" t="area" style="margin-right: 10px;">全部</a>
            <asp:Repeater runat="server" ID="rptAreas" OnItemDataBound="rptArea_ItemDataBound">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <a t="area" runat="server" id="hrefArea" style="margin-right: 10px; position:relative">
                        <%# Eval("Name").ToString().Substring(3,2).Trim() %>
                        <span class="topicon">▲</span>
                    </a>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div id="countydiv" runat="server" class="countydiv">
            <span class="themedivspan" style="color: Black; font-weight: normal; visibility:hidden">所在区县:</span>
            <div style="float: left; width: 640px; background-color:#F3F2EE;padding-top:10px;">
                <%--<a runat="server" id="hrefCountyAll" style="margin-right: 10px;" class="hlc">全部</a>--%>
                <asp:Repeater ID="rptCounty" runat="server"  onitemdatabound="rptCounty_ItemDataBound">
                    <ItemTemplate>
                        <a runat="server" id="hlcounty" style="margin-right: 10px;">
                            <%# Eval("Name").ToString().Substring(3).Trim() %>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="themediv">
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
            <span class="themedivspan" style="color: Black; font-weight: normal">景区级别:</span>
            <a runat="server" id="hlLevelAll">全部</a> <a runat="server" t="level" id="hlLevel5">5A</a>
            <a runat="server" t="level" id="hlLevel4">4A</a> <a runat="server" t="level" id="hlLevel3">
                3A</a>
        </div>
    </div>
    <div class="breadNav">
        <p class="selectarea">
            您的位置:<a href="/tickets/">景点门票</a>
            <asp:PlaceHolder ID="phArea" runat="server">> <a href="" runat="server" id="breadareaurl">
            </a></asp:PlaceHolder>
            <asp:PlaceHolder ID="phCounty" runat="server">> <a href="" runat="server" id="breadcountyurl">
            </a></asp:PlaceHolder>
            <asp:PlaceHolder ID="phLevel" runat="server">><a href="" runat="server" id="breadlevelurl">
            </a></asp:PlaceHolder>
            <asp:PlaceHolder ID="phTopic" runat="server">><a href="" runat="server" id="breadtopic">
             </a> </asp:PlaceHolder>
           &nbsp;<a style="text-decoration: none"><asp:Literal ID="lblTotal" runat="server"></asp:Literal></a></p>
    </div>
    <div id="sceniclist">
        <asp:Repeater runat="server" ID="rptItems" OnItemDataBound="rptscenic_ItemDataBound">
            <ItemTemplate>
                <div class="scenicdesc">
                    <div class="scenicimgdivbg">
                        <a href='/Tickets/<%#Eval("Area.SeoName") %>/<%#Eval("SeoName") %>.html'>
                            <asp:Image ID="Image1" CssClass="scenicdescimg" runat="server" ImageUrl='' /></a>
                    </div>
                    <div class="scenicname">
                        <a style="display: block;font-size:14px;" href='/Tickets/<%#Eval("Area.SeoName") %>/<%#Eval("SeoName") %>.html'>
                            <!---->
                            <%# Eval("Name")%></a>
                    </div>
                    <div class="dvprice">
                        <div style="float: left">
                            <span class="normalpr"><em>原价
                                <asp:Literal runat="server" ID="liPriceNormal"></asp:Literal>元</em></span> <span
                                    class="onlinepr">在线价<em><asp:Literal runat="server" ID="liPriceOnline"></asp:Literal></em>元</span>
                        </div>
                        <a class="linkorder" href='/Tickets/<%#Eval("Area.SeoName") %>/<%#Eval("SeoName") %>.html'>
                        </a>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label runat="server" CssClass="success noresult" Visible="false" ID="lblNoResult">没有相应的景区</asp:Label>
            </FooterTemplate>
        </asp:Repeater>
        <div id="pager" class="span-19 last" style="margin-left: 30px; margin-bottom: 40px;">
            <uc:AspNetPager runat="server" EnableUrlRewriting="true" ID="pagerGot" CssClass="paginator"
                UrlPaging="true" UrlPageIndexName="pgotindex" UrlRewritePattern="/Tickets/%area%/%level%/page_{0}.html"
                FirstPageText="首页" LastPageText="尾页" PageSize="12" NextPageText="下一页" CurrentPageButtonClass="cpb"
                PrevPageText="上一页">
            </uc:AspNetPager>
        </div>
    </div>
</asp:Content>
