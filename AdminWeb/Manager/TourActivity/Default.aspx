<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Manager_TourActivity_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
活动管理
    <asp:Repeater ID="rptActive" runat="server">
        <HeaderTemplate>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        活动名称
                    </td>
                    <td>
                        活动编号
                    </td>
                    <td>
                        起止时间
                    </td>
                    <td>
                        详情
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# Eval("Name") %>
                </td>
                <td>
                    <%# Eval("ActivityCode") %>
                </td>
                <td>
                    <%# Eval("BeginDate","{0:yyyy-MM-dd}")%>- <%# Eval("EndDate", "{0:yyyy-MM-dd}")%>
                </td>
                <td>
                    <a href="">编辑详情</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Button ID="btnAdd" runat="server" Text="新增" onclick="btnAdd_Click" />
</asp:Content>

