<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecommentEnt.ascx.cs"
    Inherits="LocalTravelAgent_Groups_RecommentEnt" %>
<asp:Repeater runat="server" ID="rptRecomEnt">
    <ItemTemplate>
        <a style="font-weight: 600; font-size: big;" href="#">
            <%#Eval("Name") %></a>
    </ItemTemplate>
</asp:Repeater>
