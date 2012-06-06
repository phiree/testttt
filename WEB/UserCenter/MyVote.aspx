<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/uc.master" AutoEventWireup="true"
    CodeFile="MyVote.aspx.cs" Inherits="UserCenter_MyVote" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ucContent" runat="Server">
<div style="height:1000px">
    <asp:Label runat="server" ID="lblLastVotes">
    </asp:Label>
    <p>
        拥有的总票数<span><asp:Label ID="lblTotalVotes" Text="0" runat="server"  Font-Bold="true" Font-Size="Large"/></span></p>
    <asp:Repeater ID="rptGot" runat="server">
        <ItemTemplate>
        <tr>
                <td><%#Eval("Id") %></td>
                <td><%#Eval("EarnWay")%></td>
                <td><%#Eval("Amount")%></td>
                <td><%#Eval("EarnDate")%></td>
            </tr>
        </ItemTemplate>
        <HeaderTemplate>
            <table class=" table table-bordered"><tr>
                <td>ID</td>
                <td>方式</td>
                <td>数量</td>
                <td>时间</td>
            </tr>
        </HeaderTemplate>
        <FooterTemplate>
        </table>
        </FooterTemplate>
    </asp:Repeater>
        <uc:AspNetPager runat="server" ID="pagerGot" UrlPaging="true" UrlPageIndexName="pgotindex">
        </uc:AspNetPager>
    <p>
        已经使用票数:<span><asp:Label ID="lblUsedVotes" Text="0" runat="server" Font-Bold="true" Font-Size="Large"/></span></p>
    <asp:Panel runat="server" ID="pnlVoteInfo">
        <asp:Repeater runat="server" ID="rptVoted">
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
                <table class=" table table-bordered">
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
        <uc:AspNetPager runat="server" ID="pagerVoted" UrlPaging="true" UrlPageIndexName="pvoteindex">
        </uc:AspNetPager>
    </asp:Panel>
    </div>
</asp:Content>
