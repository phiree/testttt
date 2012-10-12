<%@ Page Title="" Language="C#" MasterPageFile="~/TourManagerDpt/manager.master" AutoEventWireup="true" CodeFile="EnterpriseDetail.aspx.cs" Inherits="TourManagerDpt_EnterpriseDetail" %>
<%@ Register Src="~/UC/EnterpriseDetail.ascx" TagPrefix="UC" TagName="EntDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">
   
   <UC:EntDetail runat="server" id="ucEntDetail"></UC:EntDetail>
</asp:Content>

