<%@ Page Title="" Language="C#" MasterPageFile="~/detail.master" AutoEventWireup="true"
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
    <div id="maindefault">
        <div class="defaultleft">
            <div class="webscenic">
                <div class="webscenicdiv">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <img src="/theme/default/image/newversion/jiantouicon3.png" />
                            </td>
                            <td style="padding-top: 10px;">
                                预订免费
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="/theme/default/image/newversion/jiantouicon3.png" />
                            </td>
                            <td style="padding-top: 10px;">
                                保证低价折扣
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="/theme/default/image/newversion/jiantouicon3.png" />
                            </td>
                            <td style="padding-top: 10px;">
                                门票有效期长
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="/theme/default/image/newversion/jiantouicon3.png" />
                            </td>
                            <td style="padding-top: 10px;">
                                订票后随时游玩,
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td style="padding-top: 10px;">
                                无需提前确认
                            </td>
                        </tr>
                    </table>
                </div>
                <p>
                    订票,尽在旅游在线</p>
            </div>
            <div class="Recscenic">
                <p>
                    推荐景区</p>
                <div class="recscdiv">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 10%">
                                <span style="display: block; width: 15px; height: 15px; background-color: #62BD19;
                                    text-align: center; color: White;">1</span>
                            </td>
                            <td style="width: 65%">
                                仙都
                            </td>
                            <td style="color: #E8641B; width: 25%">
                                15元
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%">
                                <span style="display: block; width: 15px; height: 15px; background-color: #62BD19;
                                    text-align: center; color: White;">1</span>
                            </td>
                            <td style="width: 65%">
                                仙都
                            </td>
                            <td style="color: #E8641B; width: 25%">
                                15元
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%">
                                <span style="display: block; width: 15px; height: 15px; background-color: #62BD19;
                                    text-align: center; color: White;">1</span>
                            </td>
                            <td style="width: 65%">
                                仙都
                            </td>
                            <td style="color: #E8641B; width: 25%">
                                15元
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%">
                                <span style="display: block; width: 15px; height: 15px; background-color: #62BD19;
                                    text-align: center; color: White;">1</span>
                            </td>
                            <td style="width: 65%">
                                仙都
                            </td>
                            <td style="color: #E8641B; width: 25%">
                                15元
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%">
                                <span style="display: block; width: 15px; height: 15px; background-color: #62BD19;
                                    text-align: center; color: White;">1</span>
                            </td>
                            <td style="width: 65%">
                                仙都
                            </td>
                            <td style="color: #E8641B; width: 25%">
                                15元
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%">
                                <span style="display: block; width: 15px; height: 15px; background-color: #62BD19;
                                    text-align: center; color: White;">1</span>
                            </td>
                            <td style="width: 65%">
                                仙都
                            </td>
                            <td style="color: #E8641B; width: 25%">
                                15元
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%">
                                <span style="display: block; width: 15px; height: 15px; background-color: #62BD19;
                                    text-align: center; color: White;">1</span>
                            </td>
                            <td style="width: 65%">
                                仙都
                            </td>
                            <td style="color: #E8641B; width: 25%">
                                15元
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%">
                                <span style="display: block; width: 15px; height: 15px; background-color: #62BD19;
                                    text-align: center; color: White;">1</span>
                            </td>
                            <td style="width: 65%">
                                仙都
                            </td>
                            <td style="color: #E8641B; width: 25%">
                                15元
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%">
                                <span style="display: block; width: 15px; height: 15px; background-color: #62BD19;
                                    text-align: center; color: White;">1</span>
                            </td>
                            <td style="width: 65%">
                                仙都
                            </td>
                            <td style="color: #E8641B; width: 25%">
                                15元
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <a href="" class="postcarddesc"></a>
            <div class="visitedscenic">
                <p>
                    最近浏览过的景区</p>
                <div class="visitedscdiv">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 10%">
                                <img style="margin-left: 5px" src="/theme/default/image/newversion/jiantouicon2.png" />
                            </td>
                            <td style="width: 65%">
                                仙都
                            </td>
                            <td style="color: #E8641B; width: 25%">
                                15元
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%">
                                <img style="margin-left: 5px" src="/theme/default/image/newversion/jiantouicon2.png" />
                            </td>
                            <td style="width: 65%">
                                仙都
                            </td>
                            <td style="color: #E8641B; width: 25%">
                                15元
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%">
                                <img style="margin-left: 5px" src="/theme/default/image/newversion/jiantouicon2.png" />
                            </td>
                            <td style="width: 65%">
                                仙都
                            </td>
                            <td style="color: #E8641B; width: 25%">
                                15元
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%">
                                <img style="margin-left: 5px" src="/theme/default/image/newversion/jiantouicon2.png" />
                            </td>
                            <td style="width: 65%">
                                仙都
                            </td>
                            <td style="color: #E8641B; width: 25%">
                                15元
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="bookprocess">
                <p>
                    订票流程</p>
                <div class="processdiv">
                    <img src="/theme/default/image/newversion/jiantouicon4.png" />&nbsp;选择景区&nbsp;&nbsp;放入购物车<br />
                    <img src="/theme/default/image/newversion/jiantouicon4.png" />&nbsp;填写订单<br />
                    <img src="/theme/default/image/newversion/jiantouicon4.png" />&nbsp;确认订单<br />
                    <img src="/theme/default/image/newversion/jiantouicon4.png" />&nbsp;前往景区<br />
                    <span style="margin-left: 10px;">&nbsp;在线支付的游客</span><br />
                    <span style="margin-left: 10px;">&nbsp;凭身份证领取景区门票</span><br />
                    <span style="margin-left: 10px;">&nbsp;预订的游客</span><br />
                    <span style="margin-left: 10px;">&nbsp;凭身份证&nbsp;购买折扣门票</span><br />
                    <img src="/theme/default/image/newversion/jiantouicon4.png" />&nbsp;入园游玩<br />
                </div>
            </div>
        </div>
        <div class="defaultright">
            <p>
                浙江省景区门票&nbsp;选择列表</p>
            <div id="selectdiv">
                <div class="areadiv">
                    <span class="areadivspan">所在城市:</span>
                    <a runat="server" id="hrefAllArea" t="area" style="margin-right:10px;">全部 </a>
                    <asp:Repeater runat="server" ID="rptAreas" OnItemDataBound="rptArea_ItemDataBound">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <a t="area" runat="server" id="hrefArea" style="margin-right:10px;">
                                <%# Eval("Name").ToString().Substring(3,2) %>
                            </a>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <div class="themediv">
                    <span class="themedivspan">
                        旅游主题
                    </span>
                </div>
                <div class="leveldiv">
                    <span>景区级别:</span> <a runat="server" id="hlLevelAll">全部</a> <a runat="server" t="level"
                        id="hlLevel5">5A</a> <a runat="server" t="level" id="hlLevel4">4A</a> <a runat="server"
                            t="level" id="hlLevel3">3A</a>
                </div>
            </div>
            <p class="selectarea">
                您选择的景区门票:浙江省&nbsp;&nbsp;><a href="" runat="server" id="breadareaurl"><asp:Literal ID="lAreabread" runat="server"></asp:Literal></a>><a href="" runat="server" id="breadlevelurl"><asp:Literal ID="lLevelBread"
                    runat="server"></asp:Literal></a>&nbsp;<a style="text-decoration:none"><asp:Literal ID="lblTotal"
                    runat="server"></asp:Literal></a></p>
            <div id="sceniclist">
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
                                    <span class="normalpr"><em>原价
                                        <asp:Literal runat="server" ID="liPriceNormal"></asp:Literal>元</em></span> <span
                                            class="onlinepr">在线价<em><asp:Literal runat="server" ID="liPriceOnline"></asp:Literal></em>元起</span>
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
                <div id="pager" class="span-19 last">
                    <uc:AspNetPager runat="server" EnableUrlRewriting="true" ID="pagerGot" CssClass="paginator"
                        UrlPaging="true" UrlPageIndexName="pgotindex" UrlRewritePattern="%area%/%level%/page_{0}.html"
                        FirstPageText="首页" LastPageText="尾页" PageSize="12" NextPageText="下一页" CurrentPageButtonClass="cpb"
                        PrevPageText="上一页">
                    </uc:AspNetPager>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
