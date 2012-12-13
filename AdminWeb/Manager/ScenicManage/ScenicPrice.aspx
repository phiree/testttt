<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="ScenicPrice.aspx.cs" Inherits="Manager_ScenicManage_ScenicPrice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
    <table>
        <tr>
            <td colspan="2">
                景区价格审核
            </td>
        </tr>
        <tr>
            <td>
                原价
            </td>
            <td>
                <asp:TextBox ID="txtyj" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                预订价
            </td>
            <td>
                <asp:TextBox ID="txtydj" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                优惠价
            </td>
            <td>
                <asp:TextBox ID="txtyhj" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                传真图片
            </td>
            <td>
                <asp:Image ID="imgcontract" runat="server" Height="242px" Width="322px" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button runat="server" ID="btnPass" Text="通过" OnClick="btnPass_Click" />
                <asp:Button runat="server" ID="btnNoPass" Text="拒绝" OnClick="btnNoPass_Click" />
            </td>
        </tr>
    </table>
    <asp:Panel runat="server" ID="pnlPassed">
        已经通过审核
    </asp:Panel>
</asp:Content>
