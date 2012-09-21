<<<<<<< HEAD
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true"
    CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <asp:Login ID="Login1" runat="server" OnLoggedIn="Login1_LoggedIn">
    </asp:Login>
</asp:Content>
=======
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" Runat="Server">
    请选择入口
<a href="">旅游管理部门</a>
<a href="">地接社</a>
<a href="">景点,酒店,宾馆,购物点</a>

    <asp:Login ID="Login1" runat="server" onauthenticate="Login1_Authenticate" 
        onloggedin="Login1_LoggedIn">
    </asp:Login>
</asp:Content>

>>>>>>> 9b1f1a0db62ffe8ca93501f8a573df5a01ef0479
