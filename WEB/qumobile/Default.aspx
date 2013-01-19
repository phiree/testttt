<%@ Page Title="" Language="C#" MasterPageFile="~/qumobile/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="qumobile_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" runat="Server">
    <style type="text/css">
        .login
        {
            margin: 0px auto;
            width:250px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <div class="login">
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        <asp:Login ID="scenicManagerLogin" runat="server" 
            onloggedin="scenicManagerLogin_LoggedIn" >
        </asp:Login>
    </div>
</asp:Content>
