<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true" CodeFile="DptStatistic.aspx.cs" Inherits="LocalTravelAgent_DptStatistic" %>
<%@ MasterType VirtualPath="~/LocalTravelAgent/LTA.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="/Scripts/jqueryplugin/jqueryui/css/ui-lightness/jquery-ui-1.9.0.custom.min.css"
        rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-1.9.0.custom.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("[id$='txtDate']").datepicker();
        });
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<div class="detail_titlebg">
        旅游管理部门统计信息
    </div>
<div class="searchdiv">
        <h5>按条件查询</h5>
        日期&nbsp;&nbsp;<asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
        旅游管理部门名称&nbsp;&nbsp;<asp:TextBox ID="txtEntName" runat="server"></asp:TextBox>
         <asp:Button ID="BtnSearch" runat="server" Text="搜索" CssClass="btn" 
             onclick="BtnSearch_Click" />
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            统计列表
        </div>
        <asp:Repeater ID="rptDpt" runat="server" onitemdatabound="rptDpt_ItemDataBound">
            <HeaderTemplate>
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td rowspan="2">
                            序号
                        </td>
                        <td rowspan="2">
                            旅游管理部门名称
                        </td>
                        <td colspan="3">
                            本月
                        </td>
                        <td colspan="3">
                            本年
                        </td>
                    </tr>
                    <tr>
                        <td>
                            总人数
                        </td>
                        <td>
                            住宿人天数
                        </td>
                        <td>
                            游玩人数
                        </td>
                        <td>
                            总人数
                        </td>
                        <td>
                            住宿人天数
                        </td>
                        <td>
                            游玩人数
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td>
                            <%= Index++ %>
                        </td>
                        <td>
                            <a runat="server" id="anamehref" href='/LocalTravelAgent/DptDetailStatistic.aspx?dptid=<%# Eval("Id") %>'>
                            <%# Eval("Name") %>
                            </a>
                        </td>
                        <td>
                            <asp:Literal ID="laTotal_Month" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="laLive_Month" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="laVisited_Month" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="laTotal_Year" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="laLive_Year" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="laVisited_Year" runat="server"></asp:Literal>
                        </td>
                    </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

