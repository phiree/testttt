<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="AsByDate.aspx.cs" Inherits="Manager_TourActivity_AsByDate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
<%= Request.QueryString["dt"] %>详细情况
    <asp:Repeater ID="rptDt" runat="server" onitemdatabound="rptDt_ItemDataBound">
        <HeaderTemplate>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        景区名
                    </td>
                    <td>
                        票名
                    </td>
                    <asp:Literal ID="laPartnerName" runat="server"></asp:Literal>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# Eval("DisplayNameOfOwner")%>
                </td>
                <td>
                    <%# Eval("Name") %>
                </td>
                <asp:Literal ID="laCountName" runat="server"></asp:Literal>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

