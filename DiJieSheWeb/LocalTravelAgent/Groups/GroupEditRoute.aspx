<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="GroupEditRoute.aspx.cs" Inherits="LocalTravelAgent_Groups_GroupEditRoute" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div>
        本区域奖励企业列表:(什么是奖励企业)</div>
    <div>
        <asp:Repeater runat="server" ID="rptRecomEnt">
            <ItemTemplate>
                <a style="font-weight:600; font-size:big;" href="#">
                    <%#Eval("Name") %></a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
