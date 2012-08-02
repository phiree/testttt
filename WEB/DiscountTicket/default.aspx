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
        <img src="/theme/default/image/newversion/icon.gif" />浙江省景区门票&nbsp;选择列表
    </div>
    <div id="selectdiv">
        <div class="areadiv">
            <span class="areadivspan" style="color: #009F3C;">所在城市:</span> <a runat="server"
                id="hrefAllArea" t="area" style="margin-right: 10px;">全部 </a>
            <asp:Repeater runat="server" ID="rptAreas" OnItemDataBound="rptArea_ItemDataBound">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <a t="area" runat="server" id="hrefArea" style="margin-right: 10px;">
                        <%# Eval("Name").ToString().Substring(3,2) %>
                    </a>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="themediv">
            <span class="themedivspan" style="color: #009F3C;">旅游主题 </span>
            <a runat="server" id="hrefTopicAll">全部</a>
            <asp:Repeater ID="rptTopic" runat="server" 
                onitemdatabound="rptTopic_ItemDataBound">
                <ItemTemplate>
                    <a runat="server" id="hltopic"><%# Eval("Name") %></a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="leveldiv">
            <span style="color: #009F3C; float:left; display:block; height:25px; width:55px;" >景区级别:</span> <a runat="server" id="hlLevelAll">全部</a>
            <a runat="server" t="level" id="hlLevel5">5A</a> <a runat="server" t="level" id="hlLevel4">
                4A</a> <a runat="server" t="level" id="hlLevel3">3A</a>
        </div>
    </div>
    <div class="breadNav">
        <p class="selectarea">
            <img src="/theme/default/image/newversion/icon.gif" />
            您选择的景区门票:浙江省&nbsp;&nbsp;><a href="" runat="server" id="breadareaurl"><asp:Literal
                ID="lAreabread" runat="server"></asp:Literal></a>><a href="" runat="server" id="breadlevelurl"><asp:Literal
                    ID="lLevelBread" runat="server"></asp:Literal></a>&nbsp;<a style="text-decoration: none"><asp:Literal
                        ID="lblTotal" runat="server"></asp:Literal></a></p>
    </div>
    <div id="sceniclist">
        <asp:Repeater runat="server" ID="rptItems" OnItemDataBound="rptscenic_ItemDataBound">
            <ItemTemplate>
                <div class="scenicdesc">
                    <div class="scenicimgdivbg">
                        <a href='/<%#Eval("Scenic.Area.SeoName") %>/<%#Eval("Scenic.SeoName") %>.html'>
                            <asp:Image ID="Image1" CssClass="scenicdescimg" runat="server" ImageUrl='<%# Eval("Scenic.Photo","/ScenicImg/{0}") %>' /></a>
                    </div>
                    <div class="scenicname">
                        <a style="display: block" href='/<%#Eval("Scenic.Area.SeoName") %>/<%#Eval("Scenic.SeoName") %>.html'>
                            <!---->
                            <%# Eval("Scenic.Name")%></a>
                    </div>
                    <div class="dvprice">
                        <div style="float: left">
                            <span class="normalpr"><em>原价
                                <asp:Literal runat="server" ID="liPriceNormal"></asp:Literal>元</em></span> <span
                                    class="onlinepr">在线价<em><asp:Literal runat="server" ID="liPriceOnline"></asp:Literal></em>元</span>
                        </div>
                        <a class="linkorder" href='/<%#Eval("Scenic.Area.SeoName") %>/<%#Eval("Scenic.SeoName") %>.html'>
                        </a>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label runat="server" CssClass="success noresult" Visible="false" ID="lblNoResult">没有相应的景区</asp:Label>
            </FooterTemplate>
        </asp:Repeater>
        <div id="pager" class="span-19 last" style="margin-left: 30px;">
            <uc:AspNetPager runat="server" EnableUrlRewriting="true" ID="pagerGot" CssClass="paginator"
                UrlPaging="true" UrlPageIndexName="pgotindex" UrlRewritePattern="%area%/%level%/page_{0}.html"
                FirstPageText="首页" LastPageText="尾页" PageSize="12" NextPageText="下一页" CurrentPageButtonClass="cpb"
                PrevPageText="上一页">
            </uc:AspNetPager>
        </div>
    </div>
</asp:Content>
