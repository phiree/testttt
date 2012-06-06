<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Payment_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <div class="page">
        <table id="Trans" cellpadding="5px">
            <tr><td>订单名称</td><td>数量</td><td>单价</td><td>订单价格</td></tr>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Ticket.Name")%></td>
                        <td><%# Eval("TotalNum") %></td>
                        <td><%# Eval("Price") %></td>
                        <td><%# Eval("TotalPrice") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater> 
            <tr>
                <td colspan="4" style=" text-align:center;">
                    <asp:Button ID="Button1" runat="server" Text="支付宝支付" /><asp:Button ID="Button2"
                        runat="server" Text="网银支付" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
