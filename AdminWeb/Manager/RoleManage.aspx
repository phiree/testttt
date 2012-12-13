<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="RoleManage.aspx.cs" Inherits="Manager_RoleManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
    <div>
        <table>
            <tr>
                <td>
                    角色名称
                </td>
                <td>
                    操作
                </td>
            </tr>
            <asp:Repeater runat="server" ID="rptRoles" OnItemCommand="rptRoles_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td>
                            <a href="#">
                                <asp:Label runat="server" ID="lblRoleName" Text='<%# Container.DataItem %>'></asp:Label>
                            </a>
                        </td>
                        <td>
                            <asp:Button runat="server" CommandName="delete" CommandArgument='<%# Container.DataItem %>'
                                Text="删除" OnClientClick="javascript:return confirm('确认删除?')" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="tbxRoleName"></asp:TextBox>
                </td>
                <td>
                    <asp:Button runat="server" Text="增加" ID="btnOK" OnClick="btnOK_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
