<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="GroupEditRoute.aspx.cs" Inherits="LocalTravelAgent_Groups_GroupEditRoute" %>
<%@ Register Src="~/LocalTravelAgent/Groups/RecommentEnt.ascx" TagName="recomment" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div>
        本区域奖励企业列表:(什么是奖励企业)</div>
    <div>
       <uc:recomment  runat="server"  ID="ucrecomment"/>
    </div>
</asp:Content>
