<%@ Page Title="" Language="C#" MasterPageFile="~/Dijieshe/admin.master" AutoEventWireup="true"
    CodeFile="EnterpriseList.aspx.cs" Inherits="Admin_EnterpriseList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="Server">
    <div class="detail_titlebg">
        企业列表
    </div>
    <div class="searchdiv">
        名称<asp:TextBox runat="server" ID="txtEntName" />&nbsp;&nbsp;&nbsp;&nbsp;
        类型<asp:DropDownList
            ID="ddlType" runat="server">
            <asp:ListItem Text="所有" Value="所有"></asp:ListItem>
            <asp:ListItem Text="旅行社" Value="旅行社"></asp:ListItem>
            <asp:ListItem Text="宾馆" Value="宾馆"></asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnSearch" Text="查询" runat="server" OnClick="btnSearch_Click" />
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
                            认证状态(省，市，县）
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
                        <asp:Label runat="server" ID="lblAdmin"></asp:Label>
                        <asp:Button runat="server" CommandArgument='<%#Eval("Id") %>' Text="指派" ID="btnadmin"
                            CommandName="AddAdmin" CssClass="btn" />
                        <asp:Button runat="server" CommandArgument='<%#Eval("Id") %>' Text="重置密码" ID="btnreset"
                            CommandName="ResetPwd" CssClass="btn" />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblVerify"  />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
