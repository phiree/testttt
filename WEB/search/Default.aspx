<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="search_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
    <link href="/theme/default/css/default.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/DiscountTicket.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/pager.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
            <div id="sceniccount">
                共搜索到与<span style="font-weight: 600; color:#E8641B">"<%=q %>"</span>相关景点&nbsp;<asp:Label Font-Bold="true" runat="server" ID="lblTotalRecord" style="color:#E8641B"></asp:Label>个
            </div>
            <div id="searchbody">
                <div style=" display:inline-block; margin-bottom:0px;">
                <asp:Repeater runat="server" ID="rptItems" OnItemDataBound="rptscenic_ItemDataBound">
            <ItemTemplate>
                <div class="scenicdesc">
                    <div class="scenicimgdivbg">
                        <a href='/<%#Eval("Area.SeoName") %>/<%#Eval("SeoName") %>.html'>
                            <asp:Image ID="Image1" CssClass="scenicdescimg" runat="server" ImageUrl='' /></a>
                    </div>
                    <div class="scenicname">
                        <a style="display: block" href='/<%#Eval("Area.SeoName") %>/<%#Eval("SeoName") %>.html'>
                            <!---->
                            <%# Eval("Name")%></a>
                    </div>
                    <div class="dvprice">
                        <div style="float: left">
                            <span class="normalpr"><em>原价
                                <asp:Literal runat="server" ID="liPriceNormal"></asp:Literal>元</em></span> <span
                                    class="onlinepr">在线价<em><asp:Literal runat="server" ID="liPriceOnline"></asp:Literal></em>元</span>
                        </div>
                        <a class="linkorder" href='/<%#Eval("Area.SeoName") %>/<%#Eval("SeoName") %>.html'>
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
</asp:Content>
