<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RouteEditControl.ascx.cs" Inherits="LocalTravelAgent_RouteEditControl" %>
<table>
        <tr>
            <td>
            </td>
            <td>
                第<asp:TextBox runat="server" ID="tbxDayNo"></asp:TextBox>天
             
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ControlToValidate="tbxDayNo"
                    ErrorMessage="必填" ValidationGroup="ucrouteedit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                时间
            </td>
            <td>
                <asp:TextBox runat="server" ID="tbxBeginTime"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="tbxBeginTime" runat="server" 
                    ErrorMessage="必填" ValidationGroup="ucrouteedit"></asp:RequiredFieldValidator>
                至
                <asp:TextBox runat="server" ID="tbxEndTime"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="必填" ValidationGroup="ucrouteedit" ControlToValidate="tbxEndTime"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                地点
            </td>
            <td>
                <asp:TextBox runat="server" ID="tbxEnterprise"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  ControlToValidate="tbxEnterprise"
                    ErrorMessage="必填" ValidationGroup="ucrouteedit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                安排
            </td>
            <td>
                <asp:RadioButtonList runat="server" ID="rblBehavior">
                    <asp:ListItem Value="游玩" Selected="True">游玩</asp:ListItem>
                    <asp:ListItem Value="用餐">用餐</asp:ListItem>
                    <asp:ListItem Value="住宿">住宿</asp:ListItem>
                    <asp:ListItem Value="集合">集合</asp:ListItem>
                    <asp:ListItem Value="自由活动">自由活动</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
    <asp:Button runat="server" ID="btnSave"  ValidationGroup="ucrouteedit" OnClick="btnSave_Click" Text="保存" />