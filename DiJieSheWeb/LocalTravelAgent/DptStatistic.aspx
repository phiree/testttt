<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true" CodeFile="DptStatistic.aspx.cs" Inherits="LocalTravelAgent_DptStatistic" %>
<%@ MasterType VirtualPath="~/LocalTravelAgent/LTA.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="/Content/themes/base/minified/jquery-ui.min.css"
        rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.9.2.min.js"></script>
    <link href="/Scripts/jqueryplugin/tablesorter/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/OrderIndex.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Scripts/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".tablesorter").tablesorter();
            $(".IndexTable").orderIndex();
        });
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div class="detail_titlebg">
        旅游管理部门统计信息
    </div>
<div class="searchdiv">
        <h5>按条件查询</h5>
        日期&nbsp;&nbsp;<asp:TextBox ID="txtDate" runat="server" onfocus="WdatePicker({dateFmt:'yyyy年MM月'})"></asp:TextBox>
        旅游管理部门名称&nbsp;&nbsp;<asp:TextBox ID="txtEntName" runat="server"></asp:TextBox>
         <asp:Button ID="BtnSearch" runat="server" Text="搜索" CssClass="btn" 
             onclick="BtnSearch_Click" />
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            统计列表
        </div>
        <table class="tablesorter IndexTable">
        </table>



        <asp:Repeater ID="rptDpt" runat="server" onitemdatabound="rptDpt_ItemDataBound">
            <HeaderTemplate>
                <table border="0" cellpadding="0" cellspacing="0" class="tablesorter InfoTable">
                    <thead>
                    <tr>
                        <th rowspan="2">
                            旅游管理部门名称
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
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td>
                            <a runat="server" id="anamehref" href='/LocalTravelAgent/DptDetailStatistic.aspx?dptid=<%# Eval("Id") %>'>
                            <%# Eval("dptName")%>
                            </a>
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
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Button ID="btnOutput3" Text="导出" runat="server" OnClick="btnOutput3_Click" CssClass="btn" />
    </div>
</asp:Content>

