<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="AccountManager.aspx.cs" Inherits="Manager_AccountManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
    <asp:Repeater runat="server" ID="rpt" OnItemDataBound="rpt_DataBound">
        <HeaderTemplate>
            <table border="1">
                <tr>
                    <td>
                        帐号名称
                    </td>
                    <td>
                        目前角色
                    </td>
                    <td>
                        操作
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("Name")%>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblRoles"></asp:Label>
                </td>
                <td>
                    <a href='AccountDetail.aspx?userid=<%#Eval("Id") %>'>修改</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table></FooterTemplate>
    </asp:Repeater>
    <uc:AspNetPager runat="server" ID="pager" FirstPageText="首页" LastPageText="末页" 
        NextPageText="下一页" OnPageChanging="pager_PageChanging" PrevPageText="上一页">
    </uc:AspNetPager>
</asp:Content>
