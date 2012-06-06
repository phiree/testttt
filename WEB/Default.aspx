<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="/Scripts/slide.js" type="text/javascript"></script>
    <script src="/Scripts/pages/default.js" type="text/javascript"></script>
    <link href="/theme/default/css/default.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/pager.css" rel="stylesheet" type="text/css" />
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
                    <img src="/Img/slide/3.png" />
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
    <div id="nav" class="span-5 last">
        <div id="navtop">
            <span>在线门票</span>
        </div>
        <div id="navlevel">
            <span>级别:</span> <a runat="server" id="hlLevelAll">全部</a>| <a runat="server" t="level"
                id="hlLevel5">5A</a>| <a runat="server" t="level" id="hlLevel4">4A</a>| <a runat="server"
                    t="level" id="hlLevel3">3A</a>
        </div>
        <div id="navarea">
            <div>
                <span style="display: block" class="areaname"><span id="ptAreaAll">地区:</span> <a
                    runat="server"  id="hrefAllArea" t="area">全部 </a></span>
            </div>
            <asp:Repeater runat="server" ID="rptAreas" OnItemDataBound="rptArea_ItemDataBound">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <div>
                        <span class="areaname"><a t="area"  runat="server" id="hrefArea">
                            <%# Eval("Name").ToString().Substring(3) %>
                        </a></span>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div class="span-19 last" id="items">
        <div id="itemstop">
            <div id="itemstopcontainer">
                <a name="m">
                    <asp:Label runat="server" ID="lAreabread">全部景区</asp:Label></a>
                <asp:Label runat="server" ID="lArrow">>></asp:Label>
                <asp:Label runat="server" ID="lLevelBread">全部级别</asp:Label>
                <asp:Label runat="server" ID="lblTotal"></asp:Label>
            </div>
        </div>
        <div id="itemsbody">
            <asp:Repeater runat="server" ID="rptItems" OnItemDataBound="rptscenic_ItemDataBound">
                <ItemTemplate>
                    <div class="scenicdesc">
                        <a href='/<%#Eval("Scenic.Area.SeoName") %>/<%#Eval("Scenic.SeoName") %>.html'>
                            <asp:Image ID="Image1" CssClass="scenicdescimg" runat="server" ImageUrl='<%# Eval("Scenic.Photo","/ScenicImg/{0}") %>' /></a>
                        <div class="scenicname transparentBar">
                            <a style="display: block" href='/<%#Eval("Scenic.Area.SeoName") %>/<%#Eval("Scenic.SeoName") %>.html'>
                                <!---->
                                <%# Eval("Scenic.Name")%></a>
                        </div>
                        <div class="dvprice">
                            <div style="float: left">
                                <span class="normalpr">门票<em>
                                    <asp:Literal runat="server" ID="liPriceNormal"></asp:Literal></em></span> <span class="onlinepr">
                                        在线价<em><asp:Literal runat="server" ID="liPriceOnline"></asp:Literal></em>起</span>
                            </div>
                            <a class="linkorder" href='/<%#Eval("Scenic.Area.SeoName") %>/<%#Eval("Scenic.SeoName") %>.html'>
                                <img src="/theme/default/image/orderbtn.png" /></a>
                        </div>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label runat="server" CssClass="success noresult" Visible="false" ID="lblNoResult">没有相应的景区</asp:Label>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div id="pager" class="span-19 last">
            <uc:AspNetPager runat="server" EnableUrlRewriting="true" ID="pagerGot" CssClass="paginator" UrlPaging="true"
                UrlPageIndexName="pgotindex"  UrlRewritePattern="%area%/%level%/page_{0}.html" FirstPageText="首页" LastPageText="尾页"
                PageSize="12" NextPageText="下一页" CurrentPageButtonClass="cpb" PrevPageText="上一页">
            </uc:AspNetPager>
        </div>
    </div>
</asp:Content>
