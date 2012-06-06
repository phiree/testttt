<%@ page title="" language="C#" masterpagefile="~/ScenticManager/sm.master" autoeventwireup="true" inherits="ScenticManager_StatisInfo, App_Web_hlxbshxx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Repeater ID="rptStatis" runat="server">
        <HeaderTemplate>
            <table><tr><td>价格方式</td><td>价格</td><td>所售票数</td></tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr><td><%# Eval("PriceType")%></td><td><%# Eval("Price")%></td><td><%# Eval("NumTicket")%></td></tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

