<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/uc.master" AutoEventWireup="true"
    CodeFile="Order.aspx.cs" Inherits="UserCenter_MyTickets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../theme/default/css/ucdefault.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/ucdefault.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ucContent" runat="Server">
    <div id="odetail">
        <asp:Repeater runat="server" ID="rptOrder" 
            onitemdatabound="rptOrder_ItemDataBound" >
            <HeaderTemplate>
                <div class="otitlename">
                    <span class="ofirst">订单号</span>|<span class="osecond">订票内容</span>|<span class="othird">订票方式</span>|<span class="ofour">订票状态</span>|<span class="ofifth">订单详情</span>
                </div>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:HiddenField runat="server" ID="hfodid" Value='<%# Eval("Id") %>' />
                <div class="oinfo" onmouseover="changebg(this)" onmouseout="changebg2(this)">
                    <span class="ofirst"><%# Eval("Id") %></span><span class="tttt">|</span>
                    <span class="osecond" style="margin-left:13px;">
                        <asp:Repeater ID="rptod" runat="server">
                            <ItemTemplate>
                                <span class="odname">
                                    <a style="color:#807940;" href='<%# "/Tickets/"+Eval("TicketPrice.Ticket.Scenic.Area.SeoName")+"/"+Eval("TicketPrice.Ticket.Scenic.SeoName")+".html"%>'><%# Eval("TicketPrice.Ticket.Scenic.Name")%></a>
                                    <span><%# Eval("TicketPrice.Ticket.Name")%><%# Eval("Quantity")%>张</span>
                                </span>
                            </ItemTemplate>
                        </asp:Repeater>
                    </span><span class="tttt">|</span>
                    <span class="othird" style="margin-left:5px;">
                        <%# Eval("OrderDetail[0].TicketPrice.PriceType").ToString() == "PayOnline"?"在线购买":"网上预订"%>
                    </span><span class="tttt">|</span>
                    <span runat="server" id="paystate" class="ofour"></span><span class="tttt">|</span>
                    <span class="ofifth" style="margin-left:5px;"><a style="color:#807940" href='/UserCenter/Orderdetail.aspx?orderid=<%#Eval("Id")%>'>使用详情</a></span>
                </div>
                <hr class="osper" />
            </ItemTemplate>
            
        </asp:Repeater>
    </div>
</asp:Content>
