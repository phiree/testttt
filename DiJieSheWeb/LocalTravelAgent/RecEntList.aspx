<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true" CodeFile="RecEntList.aspx.cs" Inherits="LocalTravelAgent_RecEntList" %>
<%@ Register Src="~/LocalTravelAgent/Groups/RecommentEnt.ascx" TagName="recomment"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="/theme/default/css/public.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<uc:recomment runat="server" AreaCode="330000" redirtRecEntList="/LocalTravelAgent/RecDetailEnt.aspx" />
</asp:Content>

