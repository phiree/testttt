<%@ page title="" language="C#" masterpagefile="~/UserCenter/uc.master" autoeventwireup="true" inherits="UserCenter_MyLinks, App_Web_ze50iwky" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ucContent" Runat="Server">
<asp:Panel runat="server" ID="pnlVoteInfo">
        <asp:Repeater runat="server" ID="rptLinks">
            <HeaderTemplate>
                <table cellpadding="3" cellspacing="3">
                    <tr>
                        <td>
                            Id
                        </td>
                        <td>
                            来源
                        </td>
                        <td>
                            时间
                        </td>
                        <td>
                            是否通过
                        </td>
                    </tr>
            </HeaderTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("Id") %>
                    </td>
                    <td>
                        <%#Eval("UserFrom")%>
                    </td>
                    <td>
                        <%#Eval("Time")%>
                    </td>
                    <td>
                        <%#((bool)Eval("Validated"))?"通过":"未通过"%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <uc:AspNetPager runat="server" ID="pager" UrlPaging="true">
        </uc:AspNetPager>
    </asp:Panel>
</asp:Content>

