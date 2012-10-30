<%@ Page Title="" Language="C#" MasterPageFile="~/TourManagerDpt/manager.master"
    AutoEventWireup="true" CodeFile="StaticsDetail.aspx.cs" Inherits="TourManagerDpt_StaticsDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="Server">
    <div class="detaillist">
        <div class="detailtitle">
            已接待情况
        </div>
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
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("ConsumeDate") %>
                    </td>
                    <td>
                        <ul>
                            <asp:Repeater ID="rptHotels" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <%#Eval("Enterprice.Name")%>：<%#Eval("Peoplenum")%>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </td>
                    <td>
                        <ul>
                            <asp:Repeater ID="rptScenics" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <%#Eval("Enterprice.Name")%>：<%#Eval("Peoplenum")%>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
