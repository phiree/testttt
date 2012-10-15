<%@ Page Title="" Language="C#" MasterPageFile="~/TourEnterprise/TE.master" AutoEventWireup="true" CodeFile="TEChangePwd.aspx.cs" Inherits="TourEnterprise_TEChangePwd" %>

<%@ Register TagPrefix="ucPwd" TagName="changepwd" Src="~/UC/ChangePwd.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <ucPwd:changepwd runat="server" ID="ChangePwd" />
</asp:Content>

