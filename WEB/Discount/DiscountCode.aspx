<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DiscountCode.aspx.cs" Inherits="DiscountCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #DisMain
        {
            margin: 30px auto;
            width: 500px;
            text-align: center;
        }
        #Navmain
        {
            margin: 10px auto;
            width: 960px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <div id="Navmain">
        <a href="/Default.aspx">首页</a>->注册优惠码</div>
    <div id="DisMain">
        <p>
            请输入您的优惠码,优惠码在您的明信片上</p>
        <asp:TextBox ID="DisCode" runat="server" Text=""></asp:TextBox>
        <asp:Button ID="BtnOK" Text="确认" runat="server" OnClick="BtnOK_Click" />
    </div>
</asp:Content>
