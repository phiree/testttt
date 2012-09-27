<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RouteListControl.ascx.cs"
    Inherits="LocalTravelAgent_RouteListControl" %>
<asp:Repeater runat="server" ID="rptRoute">
    <HeaderTemplate>
        <table>
            <tr>
                <td>
                </td>
                <td>
                    时间
                </td>
                <td>
                    地点
                </td>
                <td>
                    安排
                </td>
                <td>
                </td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                第<%#Eval("DayNo") %>天
            </td>
            <td>
                <%#Eval("BeginTime") %>--<%#Eval("EndTime") %>
            </td>
            <td>
                <%# ((Model.DJ_TourEnterprise) Eval("Enterprise")).Name%>
            </td>
            <td>
                <%#Eval("Behavior")%>
            </td>
            <td>
                <div style="">
                    <a href='RouteEdit.aspx?rid=<%#Eval("Id") %>'>编辑</a>
                    <asp:Button runat="server" ID="btnDelete" Text="删除" CommandName="delete" />
                </div>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
