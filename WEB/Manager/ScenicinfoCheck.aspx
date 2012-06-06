<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Manager/manager.master"
    CodeFile="ScenicinfoCheck.aspx.cs" EnableEventValidation="false" Inherits="Manager_ScenicinfoCheckaspx" %>

<asp:Content runat="server" ContentPlaceHolderID="cphmain">
    <asp:Repeater runat="server" ID="rpt" OnItemCommand="rpt_ItemCommand" OnItemDataBound="rpt_ItemDataBound">
        <HeaderTemplate>
            <table class="tblist" cellpadding="0" cellspacing="0" border="0">
            <thead>
                <tr>
                    <td>
                        名称
                    </td>
                    <td>
                        地址
                    </td>
                    <td>
                        A级
                    </td>
                    <td>
                        图片
                    </td>
                    <td>
                        审核
                    </td>
                    <td>
                        管理员
                    </td>
                </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <FooterTemplate>
           </tbody> </table></FooterTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("Name") %>
                </td>
                <td>
                    <%#Eval("Address") %>
                </td>
                <td>
                    <%#Eval("Level") %>
                </td>
                <td>
                    <%#Eval("Photo") %>
                </td>
                <td>
                    <%# ((bool)Eval("Validated"))?"已通过":"未通过"%>
                    <asp:Button runat="server" ID="btnValidate" Text="通过" CommandName="validate" CommandArgument='<%#Eval("Id") %>' />
                </td>
                <td>
                指定管理员/验票员/会计对账员
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    <uc:AspNetPager runat="server" CssClass="paginator" CurrentPageButtonClass="cpb" ID="pager" UrlPaging="true">
    </uc:AspNetPager>
</asp:Content>
