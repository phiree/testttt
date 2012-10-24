<%@ Page Title="" Language="C#" MasterPageFile="~/TourManagerDpt/manager.master"
    AutoEventWireup="true" CodeFile="StaticsDetail.aspx.cs" Inherits="TourManagerDpt_StaticsDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="Server">
    <asp:Repeater ID="rptStaticDetail" runat="server" OnItemDataBound="rptStaticDetail_ItemDataBound">
        <HeaderTemplate>
            <table>
                <thead>
                    <tr>
                        <td>
                            日期
                        </td>
                        <td>
                            住宿人数
                        </td>
                        <td>
                            游览人数
                        </td>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("ConsumeDate") %>
                </td>
                <td>
                    <asp:Repeater ID="rptHotels" runat="server">
                        <ItemTemplate>
                            <%#Eval("Enterprice.Name")%>:<%#Eval("Peoplenum")%>、
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
                <td>
                    <asp:Repeater ID="rptScenics" runat="server">
                        <ItemTemplate>
                            <%#Eval("Enterprice.Name")%>:<%#Eval("Peoplenum")%>、 
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
                <tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
