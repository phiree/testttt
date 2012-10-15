<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true" CodeFile="ChangePwd.aspx.cs" Inherits="Groups_ChangePwd" %>


<%@ Register TagPrefix="ucPwd" TagName="changepwd" Src="/UC/ChangePwd.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<ucPwd:changepwd runat="server" ID="changePwd" />
</asp:Content>

