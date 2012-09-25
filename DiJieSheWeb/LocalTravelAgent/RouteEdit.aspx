<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true"
    CodeFile="RouteEdit.aspx.cs" Inherits="LocalTravelAgent_RouteEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <table>
        <tr>
            <td>
            </td>
            <td>
                第<asp:TextBox runat="server" ID="tbxDayNo"></asp:TextBox>天
             
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="必填"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                时间
            </td>
            <td>
                <asp:TextBox runat="server" ID="tbxBeginTime"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="必填"></asp:RequiredFieldValidator>
                至
                <asp:TextBox runat="server" ID="tbxEndTime"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="必填"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                地点
            </td>
            <td>
                <asp:TextBox runat="server" ID="tbxEnterprise"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ErrorMessage="必填"></asp:RequiredFieldValidator>
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
    <asp:Button runat="server" ID="btnSave" Text="保存" />
</asp:Content>
