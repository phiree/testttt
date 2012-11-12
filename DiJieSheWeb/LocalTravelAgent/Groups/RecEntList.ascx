<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecEntList.ascx.cs" Inherits="LocalTravelAgent_Groups_RecEntList" %>
<link href="/Scripts/jqueryplugin/tablesorter/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/OrderIndex.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".tablesorter").tablesorter();
            $(".IndexTable").orderIndex();
        });
        
    </script>
<div class="detail_titlebg">
    详细奖励名单
</div>
<div class="searchdiv">
<h5>筛选条件</h5>
旅游单位类型:<asp:DropDownList ID="ddlArea" runat="server">
        <asp:ListItem Value="全部">全部</asp:ListItem>
        <asp:ListItem Value="景区">景区</asp:ListItem>
        <asp:ListItem Value="宾馆">宾馆</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="BtnSearch" runat="server" Text="搜索" onclick="BtnSearch_Click" CssClass="btn" />
</div>
<div class="detaillist">
    <div class="detailtitle">
            旅游单位列表
        </div>
    <asp:Repeater ID="rptRecList" runat="server">
        <HeaderTemplate>
            <table class="tablesorter IndexTable">
        </table>
            <table border="0" cellpadding="0" cellspacing="0"  class="tablesorter InfoTable">
                <thead>
                <tr>
                    <th>
                        类型
                    </th>
                    <th>
                        名称
                    </th>
                </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# Eval("Type")%>
                </td>
                <td>
                    <%# Eval("Name") %>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
           </tbody> </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Button ID="BtnPrint" runat="server" Text="导出成excel" 
        onclick="BtnPrint_Click" />
    <a href="/localtravelagent/RecEntList.aspx" style="margin-left:600px">返回上级</a>
</div>