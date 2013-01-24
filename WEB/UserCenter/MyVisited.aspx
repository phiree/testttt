<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/uc.master" AutoEventWireup="true"
    CodeFile="MyVisited.aspx.cs" Inherits="UserCenter_MyVisited" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../theme/default/css/ucdefault.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/ucdefault.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ucContent" runat="Server">
    <div id="vdetail">
        <asp:Repeater ID="rptVisited" runat="server" OnItemDataBound="rptVisited_ItemDataBound">
            <HeaderTemplate>
                <div class="vtitlename">
                    <span class="vtfirst">时间</span><span class="vtsecond">景区名称</span><span class="vtthird">购票方式</span><span
                        class="vtfour">价格</span><span class="vtfifth">数量</span><span class="vtsix">游客名称</span>
                </div>
            </HeaderTemplate>
            <ItemTemplate>
                <div class="vinfo" onmouseover="changebg(this)" onmouseout="changebg2(this)">
                    <span class="vtfirst">
                        <%# Eval("UsedTime","{0:yyyy-MM-dd}")%></span><span class="vtsecond"><%# Eval("OrderDetail.TicketPrice.Ticket.Scenic.Name")%></span><span
                            runat="server" id="vpricetype" class="vtthird"><%# Eval("OrderDetail.TicketPrice.PriceType")%></span><span
                                class="vtfour" runat="server" id="vprice"><%# Eval("OrderDetail.TicketPrice.Price","{0:0}")%></span><span
                                    runat="server" id="vcount" class="vtfifth"><%# Eval("UsedTime")%></span><span class="vtsix"><%# Eval("Name")%></span></div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="vtotal">
            <span runat="server" id="vtotalprice"></span><br />
            <span runat="server" id="vtotalexpain"></span>
        </div>
    </div>
</asp:Content>
