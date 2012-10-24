<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecommentEnt.ascx.cs"
    Inherits="LocalTravelAgent_Groups_RecommentEnt" %>

<div class="detail_titlebg">

</div>
<div class="searchdiv">
<h5>筛选条件</h5>
行政区域:<asp:DropDownList ID="ddlArea" runat="server">
        <asp:ListItem Value="全部">全部</asp:ListItem>
        <asp:ListItem Value="市级">市级</asp:ListItem>
        <asp:ListItem Value="区县">区县</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="BtnSearch" runat="server" Text="搜索" onclick="BtnSearch_Click" CssClass="btn" />
</div>
   
<div class="detaillist">
<div class="detailtitle">
            列表统计
        </div>
<asp:Repeater runat="server" ID="rptRecomEnt">
    <HeaderTemplate>
        <table>
            <tr>
                <td>
                    序号
                </td>
                <td>
                    名称
                </td>
                <td>
                    奖励政策
                </td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <%# Container.ItemIndex+1 %>
            </td>
            <td>
                <a href='#'><%#Eval("Name")%></a>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
    <tr>
    <td colspan="3"><asp:Button runat="server" ID="btnExport"  Text="导出为Excel表格"/></td>
    </tr>
        </table></FooterTemplate>
</asp:Repeater>
</div>