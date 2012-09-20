<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true"
    CodeFile="UserList.aspx.cs" Inherits="Admin_UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="Server">
    <asp:Repeater runat="server" ID="rptUsers">
        <HeaderTemplate>
            <table>
                <tr>
                    <td>
                        用户名
                    </td>
                    <td>
                        用户类型
                    </td>
                    <td>
                        操作
                    </td>
                </tr>
          
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("Name") %>
                </td>
                <td>
                    <%# Container.DataItem.GetType() %>
                </td>
                <td>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table></FooterTemplate>
    </asp:Repeater>
</asp:Content>
