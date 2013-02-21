<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="ticketAssign.aspx.cs" Inherits="Manager_TourActivity_ticketAssign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    门票分配<br />
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Selected="True" Text="按时间维度" Value="按时间维度"></asp:ListItem>
        <asp:ListItem  Text="按供应商维度" Value="按供应商维度"></asp:ListItem>
        <asp:ListItem Text="按门票维度" Value="按门票维度"></asp:ListItem>
    </asp:RadioButtonList>
    <asp:Repeater ID="rptTime" runat="server" 
    onitemcommand="rptTime_ItemCommand">
        <HeaderTemplate>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        时间
                    </td>
                    <td>
                        分配
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
                <tr>
                    <td>
                        <%# DateTime.Parse((Container.DataItem).ToString()).ToString("yyyy-MM-dd") %>
                    </td>
                    <td>
                        <asp:Button ID="btnFpTicket" runat="server" Text="分配门票" CommandName="fp" CommandArgument='<%# DateTime.Parse((Container.DataItem).ToString())%>' />
                        <%--<a href='/Manager/QuZhouSpring/DateTicketAsign.aspx?date=<%# DateTime.Parse((Container.DataItem).ToString()).ToString("yyyy-MM-dd") %>'>分配门票</a>--%>
                    </td>
                </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

