<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true"
    CodeFile="ProductEdit.aspx.cs" Inherits="LocalTravelAgent_ProductDetail" %>

<%@ Register src="RouteEditControl.ascx" tagname="RouteEditControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <div>
        <table>
            <tr>
                <td>
                    产品名称
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    天数
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxDayAmount"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    备注
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxMemo"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                天数
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
                        <asp:Repeater ID="rptRoute" runat="server" onitemcommand="rptRoute_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%#Eval("DayNo") %>
                                    </td>
                                    <td>
                                        <%#Eval("BeginTime") %> --><%#Eval("EndTime") %></td>
                                    <td>
                                        <%#((Model.DJ_TourEnterprise)Eval("Enterprise")).Name%>
                                    </td>
                                    <td>
                                       <%#Eval("Behavior") %>
                                    </td>
                                    <td>
                                        <asp:Button runat="server" ID="btnEdit" CommandArgument='<%#Eval("Id") %>'  CommandName="Edit" Text="编辑" />
                                        <asp:Button runat="server" ID="btnDelete" CommandArgument='<%#Eval("Id") %>' CommandName="Delete" Text="删除" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr>
                            <td colspan="5">
                                <asp:Button runat="server" ID="btnAdd" Text="增加地点" />
                            </td>
                        </tr>
                    </table>
                  
                </td>
            </tr>
        </table>
                           <uc1:RouteEditControl ID="ucRouteEditor" Visible="false"  runat="server" />

        <asp:Button runat="server" ID="btnSaveProduct" Text="保存" />
    </div>
</asp:Content>
