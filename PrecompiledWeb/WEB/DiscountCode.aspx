<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="DiscountCode, App_Web_v5zntehw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="DisCode" runat="server" Text=""></asp:TextBox>
    <asp:Button ID="BtnOK" Text="确认" runat="server" OnClick="BtnOK_Click" />
</asp:Content>

