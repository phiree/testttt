<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true" CodeFile="RecDetailEnt.aspx.cs" Inherits="LocalTravelAgent_RecDetailEnt" %>
<%@ Register Src="~/LocalTravelAgent/Groups/RecEntList.ascx" TagName="rec"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="/theme/default/css/public.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<uc:rec runat="server"  />
</asp:Content>

