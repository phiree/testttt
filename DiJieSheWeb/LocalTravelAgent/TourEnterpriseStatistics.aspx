<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true" CodeFile="TourEnterpriseStatistics.aspx.cs" Inherits="LocalTravelAgent_TourEnterpriseStatistics" %>
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
        旅游企业统计信息
    </div>
     <div class="searchdiv">
        <h5>按条件查询</h5>
        日期&nbsp;&nbsp;<asp:TextBox ID="txtDate" runat="server"></asp:TextBox>&nbsp;&nbsp;旅游企业名称&nbsp;&nbsp;<asp:TextBox
            ID="txtEntName" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;企业类型;&nbsp;&nbsp;<asp:DropDownList
                ID="ddlType" runat="server">
             <asp:ListItem Value="0">全部</asp:ListItem>
             <asp:ListItem Value="1">景区</asp:ListItem>
             <asp:ListItem Value="3">宾馆</asp:ListItem>
            </asp:DropDownList>&nbsp;&nbsp;
         <asp:Button ID="BtnSearch" runat="server" Text="搜索" CssClass="btn" 
             onclick="BtnSearch_Click" />
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            统计列表
        </div>
        <asp:Repeater ID="rptStatistic" runat="server" 
            onitemdatabound="rptStatistic_ItemDataBound">
            <HeaderTemplate>
                <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td rowspan="2">
                    序号
                </td>
                <td rowspan="2">
                    企业类型
                </td>
                <td rowspan="2">
                    企业名称
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
                        <asp:Literal ID="laNo" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:Literal ID="laType" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <a href="" runat="server" id="aname">
                        <%# Eval("Name") %></a>
                    </td>
                    <td>
                        <asp:Literal ID="laCount_Month" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:Literal ID="laLive_Month" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:Literal ID="laVisited_Month" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:Literal ID="laCount_Year" runat="server"></asp:Literal>
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
                <tr>
                    <td>
                        总计
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
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
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

