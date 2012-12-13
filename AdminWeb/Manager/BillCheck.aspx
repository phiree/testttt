<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="BillCheck.aspx.cs" Inherits="Manager_BillCheck" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
    <asp:DropDownList ID="ddlProvince" runat="server" OnTextChanged="ddlProvince_TextChanged"
        AutoPostBack="True">
    </asp:DropDownList>
    <asp:DropDownList ID="ddlCity" runat="server" OnTextChanged="ddlCity_TextChanged"
        AutoPostBack="True">
    </asp:DropDownList>
    <asp:DropDownList ID="ddlScenics" runat="server" AutoPostBack="True" OnTextChanged="ddlScenics_TextChanged">
    </asp:DropDownList>
    <asp:Repeater ID="rptStatis" runat="server">
        <HeaderTemplate>
            <table>
                <tr>
                    <td>
                        订单号
                    </td>
                    <td>
                        名称
                    </td>
                    <td>
                        类型
                    </td>
                    <td>
                        票数
                    </td>
                    <td>
                        单价
                    </td>
                    <td>
                        总价
                    </td>
                    <td>
                        订单时间
                    </td>
                    <td>
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
