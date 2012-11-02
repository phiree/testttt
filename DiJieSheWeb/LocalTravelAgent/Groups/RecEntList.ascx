<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecEntList.ascx.cs" Inherits="LocalTravelAgent_Groups_RecEntList" %>
<div class="detail_titlebg">
    详细奖励名单
</div>
<div class="searchdiv">
<h5>筛选条件</h5>
行政区域:<asp:DropDownList ID="ddlArea" runat="server">
        <asp:ListItem Value="全部">全部</asp:ListItem>
        <asp:ListItem Value="景区">景区</asp:ListItem>
        <asp:ListItem Value="宾馆">宾馆</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="BtnSearch" runat="server" Text="搜索" onclick="BtnSearch_Click" CssClass="btn" />
</div>
<div class="detaillist">
    <div class="detailtitle">
            列表统计
        </div>
    <asp:Repeater ID="rptRecList" runat="server">
        <HeaderTemplate>
            <table border="0" cellpadding="0" cellspacing="0">
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
                    <%= Index++ %>
                </td>
                <td>
                    <%# Eval("Type")%>
                </td>
                <td>
                    <%# Eval("Name") %>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <tr>
                <td colspan="3">
                    <asp:Button ID="Button1" runat="server" Text="导出成excel" />
                </td>
            </tr>
        </FooterTemplate>
    </asp:Repeater>
</div>