<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="ScenicAdminSetting.aspx.cs" Inherits="Manager_ScenicAdminSetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
    <asp:Repeater ID="rptScenicAdmin" runat="server">
        <HeaderTemplate>
            <table class="tblist" cellpadding="0" cellspacing="1" border="1px">
                <tr>
                    <td>
                        账户名称
                    </td>
                    <td>
                        所属景区
                    </td>
                    <td>
                        操作
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("Membership.Name")%>
                </td>
                <td>
                    <%#Eval("Scenic.Name")%>
                </td>
                <td>
                    <a href="/manager/ScenicAdminDetail.aspx?userid=<%#Eval("Membership.Id") %>">修改</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <uc:AspNetPager runat="server" ID="pager" UrlPaging="true">
    </uc:AspNetPager>
</asp:Content>
