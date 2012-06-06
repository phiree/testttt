<%@ page title="" language="C#" masterpagefile="~/ScenticManager/sm.master" autoeventwireup="true" inherits="ScenticManager_UpdateTicketPrice, App_Web_hlxbshxx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="adminright">
        <table>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    原价
                </td>
                <td>
                    <asp:TextBox ID="txtPrice1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    预订价
                </td>
                <td>
                    <asp:TextBox ID="txtPrice2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    优惠价
                </td>
                <td>
                    <asp:TextBox ID="txtPrice3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    如果参加活动评选的请填写以下价格
                </td>
            </tr>
            <tr>
                <td>电子明信片价格</td>
                <td>
                    <asp:TextBox ID="txtPrice4" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>实际明信片的价格</td>
                <td>
                    <asp:TextBox ID="txtPrice5" runat="server"></asp:TextBox></td>
            </tr>
            <tr><td colspan="2">
                <asp:Button ID="Button1" runat="server" Text="确定" onclick="Button1_Click" /></td></tr>
        </table>
    </div>
</asp:Content>

