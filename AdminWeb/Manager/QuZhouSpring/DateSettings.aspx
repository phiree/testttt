<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="DateSettings.aspx.cs" Inherits="Manager_QuZhouSpring_DateSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <table>
        <tr>
            <td>
                活动开始日期
            </td>
            <td>
                <asp:TextBox runat="server" ID="tbxStart"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                活动结束日期
            </td>
            <td>
                <asp:TextBox runat="server" ID="tbxEnd"></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:Button runat="server" ID="btnSave" Text="保存活动日期" OnClick="btnSave_Click" />

  参与活动的门票列表.格式: 门票ID|门票代码(Productcode,提供给合作单位)<asp:TextBox runat="server" ID="tbxTicketsAsign"></asp:TextBox>

     <asp:Button runat="server" ID="btnSaveTickets" Text="保存参加活动的门票ID" OnClick="btnSaveTickets_Click" />
     <asp:Repeater  runat="server" ID="rptTicketList">
        <ItemTemplate>
        
        </ItemTemplate>
     </asp:Repeater>
</asp:Content>
