<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="UnionTicketList.aspx.cs" Inherits="Manager_ScenicManage_UnionTicket_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <div>
        <a href="UnionTicketEdit.aspx">增加联票</a></div>
    <asp:Repeater runat="server" ID="rptList">
        <HeaderTemplate>
        </HeaderTemplate>
        <FooterTemplate>
        </FooterTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    所属景区
                </td>
                <td>
                    联票名称
                </td>
                <td>
                    包含景区
                </td>
                <td>
                    价格
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
