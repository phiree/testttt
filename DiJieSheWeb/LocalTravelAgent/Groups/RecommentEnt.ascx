<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecommentEnt.ascx.cs"
    Inherits="LocalTravelAgent_Groups_RecommentEnt" %>

<fieldset>
<legend>
筛选条件
</legend><div> 企业类型:<asp:CheckBoxList runat="server" ID="cbxType" RepeatDirection="Horizontal"
        RepeatLayout="Flow">
        <asp:ListItem>景点</asp:ListItem>
        <asp:ListItem>宾馆</asp:ListItem>
    </asp:CheckBoxList></div>
</fieldset>
   

<asp:Repeater runat="server" ID="rptRecomEnt">
    <HeaderTemplate>
        <table>
            <tr>
                <td>
                    序号
                </td>
                <td>
                    类型
                </td>
                <td>
                    名称
                </td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <%# Container.ItemIndex+1 %>
            </td>
            <td>
                <%#Eval("Type")%>
            </td>
            <td>
                <a href='#'>
                    <%#Eval("Name") %></a>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
    <tr>
    <td colspan="3"><asp:Button runat="server" ID="btnExport"  Text="导出为Excel表格"/></td>
    </tr>
        </table></FooterTemplate>
</asp:Repeater>
