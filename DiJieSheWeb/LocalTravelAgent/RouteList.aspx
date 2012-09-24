<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true" CodeFile="RouteList.aspx.cs" Inherits="LocalTravelAgent_RouteList" %>

<%@ Register src="RouteListControl.ascx" tagname="RouteListControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" Runat="Server">
         <uc1:RouteListControl ID="RouteListControl1" runat="server" />
            
</asp:Content>

