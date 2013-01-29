<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="TicketStatistics3.aspx.cs" Inherits="Manager_QuZhouSpring_TicketStatistics3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <asp:Repeater runat="server" ID="rptStatic">
        <HeaderTemplate>
            <table>
            <tr>
                <td>
                    日期
                </td>
                <td>
                    景区
                </td>
                <td>
                    派送总量
                </td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# ((object[])Container.DataItem)[0].ToString() %>
                </td>
                <td>
                    <a href='/manager/quzhouspring/TicketStatistics4.aspx?scenicname=<%# ((object[])Container.DataItem)[1].ToString() %>'>
                        <%# ((object[])Container.DataItem)[1].ToString() %></a>
                </td>
                <td>
                    <%# ((object[])Container.DataItem)[3].ToString() %>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table></FooterTemplate>
    </asp:Repeater>
</asp:Content>
