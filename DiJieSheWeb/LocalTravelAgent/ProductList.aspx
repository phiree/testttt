<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true"
    CodeFile="ProductList.aspx.cs" Inherits="LocalTravelAgent_ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <!--团队游路线产品-->
    <asp:Repeater runat="server" ID="rptProduct">
        <ItemTemplate>
           <a href='ProductEdit.aspx?productid=<%#Eval("Id") %>'><%#Eval("Name") %></a>
        </ItemTemplate>
    </asp:Repeater>
    <a href="ProductEdit.aspx">新建路线</a>
</asp:Content>
