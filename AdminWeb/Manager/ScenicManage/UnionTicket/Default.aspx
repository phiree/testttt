<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Manager_ScenicManage_UnionTicket_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <div>
        套票列表</div>
    <asp:Repeater runat="server" ID="rptUnioTickets">
        <HeaderTemplate>
            <table>
                <tr>
                    <td>
                        名称
                    </td>
                    <td>
                        景区列表
                    </td>
                    <td>
                        价格
                    </td>
                    <td>
                        操作
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table></FooterTemplate>
    </asp:Repeater>
</asp:Content>
