<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true"
    CodeFile="EnterpriseList.aspx.cs" Inherits="Admin_EnterpriseList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="Server">
    <div class="detail_titlebg">
        企业列表
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            企业列表
        </div>
        <asp:Repeater runat="server" ID="rpt" OnItemCommand="rpt_ItemCommand" OnItemDataBound="rpt_ItemDataBound">
            <HeaderTemplate>
                <table>
                    <tr>
                        <td>
                            企业类型
                        </td>
                        <td>
                            名称
                        </td>
                        <td>
                            修改
                        </td>
                        <td>
                            管理员
                        </td>
                        <td>
                            认证状态
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("Type").ToString()%>
                    </td>
                    <td>
                        <%#Eval("Name") %>
                    </td>
                    <td>
                        <a href='enterpriseedit.aspx?entid=<%#Eval("Id") %>'>修改企业信息</a>
                    </td>
                    <td>
                        <asp:Label Visible="false" runat="server" ID="lblAdmin"></asp:Label>
                        <asp:TextBox runat="server" ID="tbxAccount"></asp:TextBox>
                        <asp:Button runat="server" CommandArgument='<%#Eval("Id") %>' Text="指派" ID="btnadmin"
                            CommandName="AddAdmin" CssClass="btn" />
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnSetVerify" CommandArgument='<%#Eval("Id") %>' CssClass="btn"
                            CommandName="SetVerify" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
