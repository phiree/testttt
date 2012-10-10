<%@ Page Title="" Language="C#" MasterPageFile="~/TourManagerDpt/manager.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="TourManagerDpt_Default" %>

<%-- 在此处添加内容控件 --%>
<asp:Content ContentPlaceHolderID="main" runat="server">
    <asp:Repeater runat="server" ID="rptEnt" OnItemCommand="rptItemCommand">
        <HeaderTemplate>
            <table>
                <thead>
                    <tr>
                        <td>
                            企业名称
                        </td>
                        <td>
                            类型
                        </td>
                        <td>
                            地址
                        </td>
                        <td>
                            奖励计划企业
                        </td>
                        <td>
                            操作
                        </td>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("Name") %>
                </td>
                <td>
                    <%#Eval("Type") %>
                </td>
                <td>
                    <%#Eval("Address") %>
                </td>
                <td>
                    <asp:CheckBox runat="server" ID="cbx" Checked='<%#Eval("IsVeryfied") %>' />
                </td>
                <td>
                    <asp:Button runat="server" ID="btnSetVerify" Text="设为奖励范围内" CommandName="SetVerify"
                        CommandArgument='<%#Eval("Id") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody> </table></FooterTemplate>
    </asp:Repeater>
</asp:Content>
