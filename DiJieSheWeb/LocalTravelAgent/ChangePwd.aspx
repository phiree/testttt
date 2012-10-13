<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true" CodeFile="ChangePwd.aspx.cs" Inherits="LocalTravelAgent_ChangePwd" %>

<%@ Register TagPrefix="ucPwd" TagName="changePwd" Src="/UC/ChangePwd.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <ucPwd:changePwd runat="server" ID="ChangePwd" />
</asp:Content>

