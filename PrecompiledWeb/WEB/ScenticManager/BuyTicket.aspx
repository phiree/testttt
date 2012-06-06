<%@ page title="" language="C#" masterpagefile="~/ScenticManager/sm.master" autoeventwireup="true" inherits="ScenticManager_BuyTicket, App_Web_hlxbshxx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Repeater ID="Repeater2" runat="server">
        <ItemTemplate>
            <p>明信片类型:<%# (bool)Eval("Type") ? "电子明信片" : "实际明信片"%></p>
            <p>身份证号:<%# Eval("IdCard")%></p>
            <p>截止日期:<%# Eval("CloseTime")%></p>
        </ItemTemplate>
    </asp:Repeater>

    <asp:Repeater ID="Repeater1" runat="server" 
        onitemdatabound="Repeater1_ItemDataBound" onitemcommand="Repeater1_ItemCommand" 
        >
        <ItemTemplate>
            <table cellpadding="5">
            <tr style="display:none;">
                <td>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Id") %>'></asp:Label></td>
            </tr>
                <tr>
                    <td>门票类型</td>
                    <td>
                        <asp:Label ID="lblTicketType" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td>门票名称</td>
                    <td><%# Eval("Ticket.Name") %></td>
                </tr>
                <tr>
                    <td>门票价格</td>
                    <td>
                        <asp:Label ID="lblTicketPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td>数量</td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("TotalNum") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td>总价</td>
                    <td><%# Eval("TotalPrice") %></td>
                </tr>
                <tr>
                    <td>是否支付</td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text='<%# (bool)Eval("IsPaid")?"是":"否" %>'></asp:Label></td>
                </tr>
                <tr>
                    <td>已使用的票数</td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("UsedNum") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td>购买时间</td>
                    <td><%# Eval("BuyTime") %></td>
                </tr>
                <tr>
                    <td>身份证号</td>
                    <td><%# Eval("IdCard") %></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnPay" runat="server" Text="付款" CommandArgument='<%# Eval("Id") %>' CommandName="update"  /></td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

