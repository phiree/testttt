<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true" CodeFile="RouteEdit.aspx.cs" Inherits="LocalTravelAgent_RouteEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" Runat="Server">
         <asp:Repeater runat="server" ID="rptRoute">
                        <HeaderTemplate>
                            <table>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        时间
                                    </td>
                                    <td>
                                        地点
                                    </td>
                                    <td>
                                        安排
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    第<%#Eval("DayNo") %>天
                                </td>
                                <td>
                                    <%#Eval("BeginTime") %>--<%#Eval("EndTime") %>
                                </td>
                                <td>
                                    <%# ((Model.DJ_TourEnterprise) Eval("Enterprise")).Name%>
                                </td>
                                <td>
                                    <%#Eval("Behavior")%>
                                </td>
                                <td>
                                    <a href='ProductEdit.aspx?pid=<%=ProductId %>&rid=<%Eval("Id") %>'>编辑</a>
                                    <asp:Button runat="server" ID="btnDelete" CommandArgument='<%#Eval("Id") %>' CommandName="delete" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
            
</asp:Content>

