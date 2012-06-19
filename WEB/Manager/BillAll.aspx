<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="BillAll.aspx.cs" Inherits="Manager_BillAll" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <link href="/theme/default/css/Managerdefault.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
    <div id="selectdiv">
        <span>筛选:&nbsp;&nbsp;</span>
        <asp:DropDownList ID="ddlCity" runat="server" OnTextChanged="ddlCity_TextChanged"
        AutoPostBack="True">
    </asp:DropDownList>
    <asp:DropDownList ID="ddlScenics" runat="server" AutoPostBack="True" OnTextChanged="ddlScenics_TextChanged">
    </asp:DropDownList>
    </div>
    
    <asp:Repeater ID="rptStatis" runat="server">
        <HeaderTemplate>
            <table class="tblist" cellpadding="0" cellspacing="0" border="0">
                <tr class="thead">
                    <td style="width:200px">
                        订单号
                    </td>
                    <td style="width:200px">
                        名称
                    </td>
                    <td style="width:200px">
                        类型
                    </td>
                    <td style="width:200px">
                        票数
                    </td>
                    <td style="width:200px">
                        单价
                    </td>
                    <td style="width:200px">
                        总价
                    </td>
                    <td style="width:200px">
                        订单时间
                    </td>
                    <td style="width:200px">
                        是否结算
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# Eval("Order.Id")%>
                </td>
                <td>
                    <%# Eval("TicketPrice.Ticket.Name")%>
                </td>
                <td>
                    <%# Eval("TicketPrice.PriceType")%>
                </td>
                <td>
                    <%# Eval("Quantity")%>
                </td>
                <td>
                    <%# ((Model.Ticket)Eval("TicketPrice.Ticket")).GetPrice((Model.PriceType)Eval("TicketPrice.PriceType"))%>
                </td>
                <td>
                    <%# ((int)Eval("Quantity")) * ((Model.Ticket)Eval("TicketPrice.Ticket")).GetPrice((Model.PriceType)Eval("TicketPrice.PriceType"))%>
                </td>
                <td>
                    <%#Eval("Order.BuyTime")%>
                </td>
                <td>
                    <%#(bool)Eval("Order.IsPaid")?"已付款":"未付款"%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
