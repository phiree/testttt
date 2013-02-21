<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Manager_ScenicManage_TicketManage_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <div>
        门票列表</div>
    <div>
        景区名称或者门票名称:<asp:TextBox runat="server" ID="tbxKeyWords"></asp:TextBox><asp:Button
            runat="server" ID="btnSearch" OnClick="btnSearch_Click" Text="搜索" />
    </div>
    <asp:Repeater runat="server" ID="rptOwnerList">
        <HeaderTemplate>
            <table>
                <tr>
                    <td>
                        门票所有者
                    </td>
                    <td>
                        门票列表
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                <%#Eval("Name")%>
                </td>
                <td>
                    <asp:Repeater runat="server" ID="rptTicket" OnItemCommand="rptTicket_ItemCommand" >
                        <HeaderTemplate>
                            <table>
                                <tr>
                                    <td>
                                        名称
                                    </td>
                                    <td>
                                        类型
                                    </td>
                                    <td>
                                        价格
                                    </td>
                                    <td>
                                        操作
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                           <a href='TicketEdit2.aspx?id=<%#Eval("Id") %>'><%#Eval("Name") %></a>     
                                </td>
                                <td>
                                <%# Container.DataItem.GetType()%>
                                </td>
                                <td>
                                </td>
                                <td>
                                <%#Eval("Enabled") %>
                                <asp:Button runat="server"  CommandArgument=<%#Eval("Id") %> CommandName="disable"  Text="禁用"/>
                                  <asp:Button ID="Button1" runat="server"  CommandArgument=<%#Eval("Id") %> CommandName="enable"  Text="启用"/>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table></FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table></FooterTemplate>
    </asp:Repeater>
</asp:Content>
