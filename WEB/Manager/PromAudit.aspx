<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Manager/manager.master"
    CodeFile="PromAudit.aspx.cs" Inherits="Manager_PromAudit" %>

<asp:Content ContentPlaceHolderID="cphmain" runat="server">
    <div>
        <asp:Repeater ID="rpt" runat="server" OnItemCommand="rpt_ItemCommand" OnItemDataBound="rpt_ItemDataBound">
            <HeaderTemplate>
                <table cellpadding="3" cellspacing="3">
                    <tr>
                        <td>
                            Id
                        </td>
                        <td>
                            推广人
                        </td>
                        <td>
                            来源
                        </td>
                        <td>
                            时间
                        </td>
                        <td>
                            通过
                        </td>
                    </tr>
            </HeaderTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("Id")%>
                    </td>
                    <td>
                        <%#Eval("User.Name")%>
                    </td>
                    <td>
                        <%#Eval("UserFrom")%>
                    </td>
                    <td>
                        <%#Eval("Time")%>
                    </td>
                    <td>
                        <%# ((bool)Eval("Validated")) ? "已通过" : "未通过"%>
                        <asp:Button runat="server" ID="btnValidate" Text="通过" CommandName="validate" CommandArgument='<%#Eval("Id")+"|"+Eval("User.Id") %>' />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <uc:AspNetPager runat="server" ID="pager">
        </uc:AspNetPager>
    </div>
</asp:Content>
