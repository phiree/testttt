<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="TicketStatistics2.aspx.cs" Inherits="Manager_QuZhouSpring_TicketStatistics2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <asp:Repeater runat="server" ID="rptdate">
        <HeaderTemplate>
            <table>
            <tr>
                <td>
                    日期
                </td>
                <td>
                    派送总量
                </td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <a href='/manager/quzhouspring/TicketStatistics3.aspx?date=<%# ((object[])Container.DataItem)[0].ToString() %>'>
                        <%# ((object[])Container.DataItem)[0].ToString() %></a>
                </td>
                <td>
                    <%# ((object[])Container.DataItem)[1].ToString() %>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
