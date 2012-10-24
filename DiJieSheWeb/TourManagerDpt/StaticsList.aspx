<%@ Page Title="" Language="C#" MasterPageFile="~/TourManagerDpt/manager.master"
    AutoEventWireup="true" CodeFile="StaticsList.aspx.cs" Inherits="TourManagerDpt_StaticsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="Server">
    <asp:Repeater ID="rptOrigin" runat="server">
        <HeaderTemplate>
            <table border="1" cellpadding="1" cellspacing="1">
                <thead>
                    <tr>
                        <td>
                        序号
                        </td>
                        <td>
                        地接社名称
                        </td>
                        <td>
                        成人数
                        </td>
                        <td>
                        儿童数
                        </td>
                        <td>
                        住宿天数
                        </td>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%=xuhao_orig++%>
                </td>
                <td>
                    <%#Eval("Route.DJ_TourGroup.DJ_DijiesheInfo.Name")%>
                </td>
                <td>
                    <%#Eval("AdultsAmount")%>
                </td>
                <td>
                    <%#Eval("ChildrenAmount")%>
                </td>
                <td>
                    <%#Eval("LiveDay")%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody> </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Repeater ID="rptGov1" runat="server">
        <HeaderTemplate>
            <table border="1" cellpadding="1" cellspacing="1">
                <thead>
                    <tr>
                        <td>
                        序号
                        </td>
                        <td>
                        地接社名称
                        </td>
                        <td>
                        成人数
                        </td>
                        <td>
                        儿童数
                        </td>
                        <td>
                        住宿天数
                        </td>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%=xuhao++ %>
                </td>
                <td>
                    <a href='/TourManagerDpt/StaticsDetail.aspx?=<%#Eval("Name")%>'><%#Eval("Name")%></a>
                    
                </td>
                <td>
                    <%#Eval("AdultsAmount")%>
                </td>
                <td>
                    <%#Eval("ChildrenAmount")%>
                </td>
                <td>
                    <%#Eval("LiveDays")%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody> </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
