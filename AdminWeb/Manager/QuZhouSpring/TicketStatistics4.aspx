<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="TicketStatistics4.aspx.cs" Inherits="Manager_QuZhouSpring_TicketStatistics4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <asp:Repeater runat="server" ID="rptStatic"
        onitemdatabound="rptStatic_ItemDataBound">
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
                    <a href='/manager/quzhouspring/TicketStatistics3.aspx?date=<%# ((object[])Container.DataItem)[0].ToString() %>'>
                        <%# ((object[])Container.DataItem)[0].ToString() %></a>
                </td>   
                <td>
                    <%# ((object[])Container.DataItem)[1].ToString() %>
                </td>
                <td>
                    <asp:Label ID="lblnum" text='<%# ((object[])Container.DataItem)[3].ToString() %>' runat="server" />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <tr>
                <td>
                    总计
                </td>
                <td></td>
                <td>
                    <asp:Label ID="lbltotal" Text="总计数量" runat="server" />
                </td>
            </tr>
            </table></FooterTemplate>
    </asp:Repeater>
</asp:Content>
