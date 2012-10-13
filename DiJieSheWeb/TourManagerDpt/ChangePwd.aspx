<%@ Page Title="" Language="C#" MasterPageFile="~/TourManagerDpt/manager.master" AutoEventWireup="true" CodeFile="ChangePwd.aspx.cs" Inherits="TourManagerDpt_ChangePwd" %>


<%@ Register TagPrefix="ucPwd" TagName="changePwd" Src="~/UC/ChangePwd.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">
    <ucPwd:changePwd runat="server" ID="ChangePwd" />
</asp:Content>

