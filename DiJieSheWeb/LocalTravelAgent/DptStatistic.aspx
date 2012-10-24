<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true" CodeFile="DptStatistic.aspx.cs" Inherits="LocalTravelAgent_DptStatistic" %>
<%@ MasterType VirtualPath="~/LocalTravelAgent/LTA.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="/Scripts/jqueryplugin/jqueryui/css/ui-lightness/jquery-ui-1.9.0.custom.min.css"
        rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/Sequence.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-1.9.1.custom.min.js"></script>
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
                            <a class="sequence">旅游管理部门名称<span class="orderspan">↓</span></a>
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
                            <a class="sequence">总人数<span class="orderspan">↓</span></a>
                        </td>
                        <td>
                            <a class="sequence">住宿人天数<span class="orderspan">↓</span></a>
                        </td>
                        <td>
                            <a class="sequence">游玩人数<span class="orderspan">↓</span></a>
                        </td>
                        <td>
                             <a class="sequence">总人数<span class="orderspan">↓</span></a>
                        </td>
                        <td>
                            <a class="sequence">住宿人天数<span class="orderspan">↓</span></a>
                        </td>
                        <td>
                            <a class="sequence">游玩人数<span class="orderspan">↓</span></a>
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td>
                            <%#　Eval("Id") %>
                        </td>
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
    </div>
</asp:Content>

