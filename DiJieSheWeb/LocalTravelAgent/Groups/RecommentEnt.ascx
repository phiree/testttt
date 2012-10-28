<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecommentEnt.ascx.cs"
    Inherits="LocalTravelAgent_Groups_RecommentEnt" %>
    <ul>
<asp:Repeater runat="server" ID="rptRecomEnt">
    <ItemTemplate>
    <li>
        <a style="font-weight: 600; font-size: big;" href="#">
            <%#Eval("Name") %></a>
            </li>
    </ItemTemplate>
</asp:Repeater></ul>
