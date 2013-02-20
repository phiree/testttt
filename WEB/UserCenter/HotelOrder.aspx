<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/uc.master" AutoEventWireup="true"
    CodeFile="HotelOrder.aspx.cs" Inherits="UserCenter_HotelOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../theme/default/css/ucdefault.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ucContent" runat="Server">
    <div class="odetail">
        <div style="border: 1px solid #B7B7B7; background: #FFFCD4; padding: 5px 25px 5px 10px;
            margin-bottom: 3px;">
            系统自动保留您6个月的订单，如需查询更久的历史订单，请致电客服中心。
        </div>
        <asp:Repeater ID="rptHotel" runat="server" OnItemDataBound="rptHotel_ItemDataBound">
            <HeaderTemplate>
                <div class="otitlename">
                    <span class="hotel13">订单号</span>|<span class="hotel10">预定日期</span>|<span class="hotel25">酒店名称</span>|<span
                        class="hotel10">入住时间</span>|<span class="hotel10">总金额</span>|<span class="hotel10">订单状态</span>|<span
                            class="hotel10">操作</span>
                </div>
            </HeaderTemplate>
            <ItemTemplate>
                <div class="oinfo">
                    <a class="hotel13a" target="_self" href='/Hotels/OrderDetail.aspx?orderid=<%#Eval("orderid") %>'>
                        <%#Eval("orderid")%></a>|<span class="hotel10">
                            <%#((DateTime)Eval("bookDate")).ToString("yyyy-MM-dd")%></span>|<a class="hotel25a"
                                target="_blank" href='/Hotels/Details.aspx?hotelid=<%#Eval("hotelid")%>'><%#Eval("Hotel.hotelname")%></a>|<span
                                    class="hotel10"><%#((DateTime)Eval("checkindate")).ToString("yyyy-MM-dd")%></span>|<span
                                        class="hotel10"><%#((decimal)Eval("totalprice")).ToString("F2")%></span>|<span class="hotel10">
                                            <%#Eval("statuscode")%></span>|<a class="hotel5a" href='/Hotels/OrderDetail.aspx?orderid=<%#Eval("orderid") %>'>修改</a>|<a
                                                class="hotel5a" href="#">取消</a>
                </div>
                <hr class="osper" />
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
