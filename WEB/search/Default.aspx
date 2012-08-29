<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="search_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
    <link href="/theme/default/css/default.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/DiscountTicket.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/pager.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
            <div id="sceniccount" runat="server" class="sceniccount">
                共搜索到与<span style="font-weight: 600; color:#EC6B9E">"<%=q %>"</span>相关景点&nbsp;<asp:Label Font-Bold="true" runat="server" ID="lblTotalRecord" style="color:#EC6B9E"></asp:Label>个
            </div>
            <div id="nosceniccount" runat="server" class="nosceniccount">
                没有搜索到相关景点的门票信息
            </div>
            <div id="searchbody" runat="server" class="searchbody">
                <div style=" display:inline-block; margin-bottom:0px;">
                <asp:Repeater runat="server" ID="rptItems" OnItemDataBound="rptscenic_ItemDataBound">
            <ItemTemplate>
                <div class="scenicdesc">
                    <div class="scenicimgdivbg">
                        <a href='/Tickets/<%#Eval("Area.SeoName") %>/<%#Eval("SeoName") %>.html'>
                            <asp:Image ID="Image1" CssClass="scenicdescimg" runat="server" ImageUrl='' /></a>
                    </div>
                    <div class="scenicname">
                        <a style="display: block;font-size:14px" href='/Tickets/<%#Eval("Area.SeoName") %>/<%#Eval("SeoName") %>.html'>
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
                </div>
                <div id="pager" class="block" style="margin-left:10px; margin-bottom:30px;">
                    <uc:AspNetPager runat="server" ID="pagerGot" CssClass="paginator" UrlPaging="true"
                        UrlPageIndexName="pgotindex" FirstPageText="首页" LastPageText="尾页" PageSize="12"
                        NextPageText="下一页" CurrentPageButtonClass="cpb" PrevPageText="上一页">
                    </uc:AspNetPager>
                </div>
            </div>
            <div id="nosearch" runat="server" class="nosearch">
                <p class="nstitle">
                    很抱歉:无法搜索到您想要的景区，我们为您推荐了您可能感兴趣的其他景区
                </p>
                <div class="nsinfo">
                    <p>热门景区推荐</p>
                    <asp:Repeater ID="rptrmsc" runat="server" 
                        onitemdatabound="rptrmsc_ItemDataBound">
                        <ItemTemplate>
                            <div class="nsinfosc">
                                <img src="/theme/default/image/newversion/jt2.gif" style="margin-right:20px;margin-top:5px;" />
                                <span style="width:120px;"><%# Eval("Name") %></span>
                                <span class="nsinfosc_price"><strong runat="server" id="nsinfosc_price"></strong>元</span>
                                <a href='/Tickets/<%#Eval("Area.SeoName") %>/<%#Eval("SeoName") %>.html'>看看</a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
</asp:Content>
