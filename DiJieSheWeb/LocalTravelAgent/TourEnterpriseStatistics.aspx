<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="TourEnterpriseStatistics.aspx.cs" Inherits="LocalTravelAgent_TourEnterpriseStatistics" %>

<%@ MasterType VirtualPath="~/LocalTravelAgent/LTA.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/Scripts/jqueryplugin/jqueryui/css/smoothness/jquery-ui-1.9.1.custom.min.css"
        rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/Sequence.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-1.9.1.custom.min.js"></script>
    <link href="/Scripts/jqueryplugin/tablesorter/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/OrderIndex.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Scripts/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".tablesorter").tablesorter();
            $(".IndexTable").orderIndex('2');
        });
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="detail_titlebg">
        旅游企业统计信息
    </div>
    <div class="searchdiv">
        <h5>
            按条件查询</h5>
        日期&nbsp;&nbsp;<asp:TextBox ID="txtDate" runat="server" onfocus="WdatePicker({dateFmt:'yyyy年MM月'})"></asp:TextBox>&nbsp;&nbsp;旅游企业名称&nbsp;&nbsp;<asp:TextBox
            ID="txtEntName" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;企业类型;&nbsp;&nbsp;<asp:DropDownList
                ID="ddlType" runat="server">
                <asp:ListItem Value="0">全部</asp:ListItem>
                <asp:ListItem Value="1">景区</asp:ListItem>
                <asp:ListItem Value="3">宾馆</asp:ListItem>
            </asp:DropDownList>
        &nbsp;&nbsp;
        <asp:Button ID="BtnSearch" runat="server" Text="搜索" CssClass="btn" OnClick="BtnSearch_Click" />
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            统计列表
        </div>
        <table class="tablesorter IndexTable">
        </table>
        <asp:Repeater ID="rptStatistic" runat="server" OnItemDataBound="rptStatistic_ItemDataBound">
            <HeaderTemplate>
                <table border="0" cellpadding="0" cellspacing="0" class="tablesorter InfoTable">
                    <thead>
                        <tr>
                            <th rowspan="2">
                                企业类型
                            </th>
                            <th rowspan="2">
                                企业名称
                            </th>
                            <td colspan="3">
                                本月
                            </td>
                            <td colspan="3">
                                本年
                            </td>
                        </tr>
                        <tr>
                            <th>
                                总人数
                            </th>
                            <th>
                                住宿人天数
                            </th>
                            <th>
                                游玩人数
                            </th>
                            <th>
                                总人数
                            </th>
                            <th>
                                住宿人天数
                            </th>
                            <th>
                                游玩人数
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
                        <a href="" runat="server" id="aname">
                            <%# Eval("Name")%></a>
                    </td>
                    <td>
                        <%# Eval("month_total")%>
                    </td>
                    <td>
                        <%# Eval("month_live")%>
                    </td>
                    <td>
                        <%# Eval("month_visited")%>
                    </td>
                    <td>
                        <%# Eval("year_total")%>
                    </td>
                    <td>
                        <%# Eval("year_live")%>
                    </td>
                    <td>
                        <%# Eval("year_visited")%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                <tfoot>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Literal ID="laCount_Month_Total" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="laLive_Month_Total" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="laVisited_Month_Total" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="laCount_Year_Total" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="laLive_Year_Total" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="laVisited_Year_Total" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </tfoot>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Button ID="btnOutput3" Text="导出" runat="server" OnClick="btnOutput3_Click" CssClass="btn" />
    </div>
</asp:Content>
