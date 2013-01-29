<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="TicketStatistics2.aspx.cs" Inherits="Manager_QuZhouSpring_TicketStatistics2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <asp:Repeater runat="server" ID="rptdate">
    <HeaderTemplate>
        <table>
            
    </HeaderTemplate>
        <ItemTemplate>
        <tr>
            <td>
                <%# ((object[])Container.DataItem)[0].ToString() %>
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

