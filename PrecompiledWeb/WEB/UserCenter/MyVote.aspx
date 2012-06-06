<%@ page title="" language="C#" masterpagefile="~/UserCenter/uc.master" autoeventwireup="true" inherits="UserCenter_MyVote, App_Web_ze50iwky" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ucContent" runat="Server">
    <asp:Label runat="server" ID="lblLastVotes">
    </asp:Label>
    <p>
        拥有的总票数<span><asp:Label ID="lblTotalVotes" Text="0" runat="server" /></span></p>
    <p>
        已经使用票数<span><asp:Label ID="lblUsedVotes" Text="0" runat="server" /></span></p>
    <asp:Panel runat="server" ID="pnlVoteInfo">
        <asp:Repeater runat="server" ID="rptVotes">
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("Id") %>
                    </td>
                    <td>
                        <%#Eval("Scenic.Name") %>
                    </td>
                    <td>
                        <%#Eval("Num")%>
                    </td>
                    <td>
                        <%#Eval("Type")%>
                    </td>
                    <td>
                        <%#Eval("Time")%>
                    </td>
                    <td>
                        <%#Eval("Note")%>
                    </td>
                </tr>
            </ItemTemplate>
            <HeaderTemplate>
                <table>
                    <tr>
                        <td>
                            Id
                        </td>
                        <td>
                            景区
                        </td>
                        <td>
                            票数
                        </td>
                        <td>
                            类型
                        </td>
                        <td>
                            时间
                        </td>
                        <td>
                            备注
                        </td>
                    </tr>
            </HeaderTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <uc:AspNetPager runat="server" ID="pager" UrlPaging="true">
        
        </uc:AspNetPager>
    </asp:Panel>
</asp:Content>
