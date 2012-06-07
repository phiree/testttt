<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/uc.master" AutoEventWireup="true"
    CodeFile="Order.aspx.cs" Inherits="UserCenter_MyTickets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../theme/default/css/ucdefault.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ucContent" runat="Server">
    <div id="otop">我的订单</div>
    <div id="odetail">
        <asp:Repeater runat="server" ID="rptOrder" 
            onitemdatabound="rptOrder_ItemDataBound" >
            <HeaderTemplate>
                <div class="otitlename">
                    <span class="ofirst">订票时间</span><span class="osecond">订票内容</span><span class="othird">订票方式</span><span class="ofour">订票状态</span><span class="ofifth">订单详情</span>
                </div>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:HiddenField runat="server" ID="hfodid" Value='<%# Eval("Id") %>' />
                <div class="oinfo">
                    <span class="ofirst"><%#Eval("BuyTime","{0:yyyy-MM-dd}")%></span>
                    <span class="osecond">
                        <asp:Repeater ID="rptod" runat="server">
                            <ItemTemplate>
                                <span class="odname">
                                    <a href='<%# "/"+Eval("TicketPrice.Ticket.Scenic.Area.SeoName")+"/"+Eval("TicketPrice.Ticket.Scenic.SeoName")+".html"%>'><%# Eval("TicketPrice.Ticket.Scenic.Name")%></a>
                                </span>
                            </ItemTemplate>
                        </asp:Repeater>
                    </span>
                    <span class="othird">
                        <%# Eval("OrderDetail[0].TicketPrice.PriceType").ToString() == "PayOnline"?"在线购买":"网上预订"%>
                    </span>
                    <span runat="server" id="paystate" class="ofour"></span>
                    <span class="ofifth" style="margin-left:5px;"><a href='/UserCenter/Orderdetail.aspx?orderid=<%#Eval("Id")%>'><%# Eval("Id") %>使用详情</a></span>
                </div>
            </ItemTemplate>
            <AlternatingItemTemplate>
            <asp:HiddenField runat="server" ID="hfodid" Value='<%# Eval("Id") %>' />
                <div class="oainfo">
                    <span class="ofirst"><%#Eval("BuyTime","{0:yyyy-MM-dd}")%></span>
                    <span class="osecond"><asp:Repeater ID="rptod" runat="server">
                            <ItemTemplate>
                                <span class="odname">
                                <a href='<%# "/"+Eval("TicketPrice.Ticket.Scenic.Area.SeoName")+"/"+Eval("TicketPrice.Ticket.Scenic.SeoName")+".html"%>'><%# Eval("TicketPrice.Ticket.Scenic.Name")%></a>
                                </span>
                            </ItemTemplate>
                        </asp:Repeater></span>
                    <span class="othird">
                        <%# Eval("OrderDetail[0].TicketPrice.PriceType").ToString() == "PayOnline"?"在线购买":"网上预订"%>
                    </span>
                    <span runat="server" id="paystate" class="ofour"></span>
                    <span class="ofifth" style="margin-left:5px;"><a href='/UserCenter/Orderdetail.aspx?orderid=<%#Eval("Id")%>'><%# Eval("Id") %>使用详情</a></a></span>
                    
                </div>
            </AlternatingItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
