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
    <style type="text/css">
        .report_2 th
        {
            line-height:15px !important;
        }
        .link_djs
        {
            color:Black;
            text-decoration:none;
            cursor:pointer;
        }
        .link_djs:hover
        {
            text-decoration:underline;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $(".tablesorter").tablesorter({ headers: { 1: { sorter: false }, 2: { sorter: false }, 3: { sorter: false }, 4: { sorter: false }, 5: { sorter: false }, 6: { sorter: false }, 7: { sorter: false }, 8: { sorter: false}} });
            $(".IndexTable").orderIndex();
            $("[id$='txtDate']").focus(function () {
                WdatePicker({ dateFmt: 'yyyy年MM月', maxDate: new Date() })
            });
        });

        function showDetail(DptId) {
            $("[id$='hfdetail']").val($(".link_djs").attr("dptid"));
            $("[id$='btndetail']").click();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div class="detail_titlebg">
        旅游管理部门统计信息
    </div>
<div class="searchdiv">
        日期&nbsp;&nbsp;<asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
        旅游管理部门名称&nbsp;&nbsp;<asp:TextBox ID="txtEntName" runat="server"></asp:TextBox>奖励单位:
        <asp:DropDownList ID="ddlIsReward" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlIsReward_SelectedIndexChanged">
                <asp:ListItem Value="0">全部</asp:ListItem>
                <asp:ListItem Value="1">是市级奖励</asp:ListItem>
                <asp:ListItem Value="2">否市级奖励</asp:ListItem>
                <asp:ListItem Value="3">是县级奖励</asp:ListItem>
                <asp:ListItem Value="4">否县级奖励</asp:ListItem>
            </asp:DropDownList>
         <asp:Button ID="BtnSearch" runat="server" Text="搜索" CssClass="btn2" 
             onclick="BtnSearch_Click" />
        
    </div>
    <div class="detaillist" runat="server" id="report_total">
        <div class="tabSelect">
            <a class="Select_Tab">旅游管理部门</a>
            <asp:Button ID="btnOutput3" Text="导出列表" runat="server" OnClick="btnOutput3_Click" CssClass="btn2 Select_Btn" />
        </div>
        <table class="tablesorter IndexTable" >
        </table>
        <table border="0" cellpadding="0" cellspacing="0" class="tablesorter InfoTable" >
                    <thead>
                    <tr>
                        <th rowspan="2">
                            管理部门名称
                        </th>
                        <td colspan="4">
                            本月
                        </td>
                        <td colspan="4">
                            本年
                        </td>
                    </tr>
                    <tr>
                        <th>
                           住宿人天数
                        </th>
                        <th>
                            房间数
                        </th>
                        <th>
                           加床数
                        </th>
                        <th>
                           景区游览人次
                        </th>
                        <th>
                           住宿人天数
                        </th>
                        <th>
                            房间数
                        </th>
                        <th>
                           加床数
                        </th>
                        <th>
                           景区游览人次
                        </th>
                    </tr>
                </thead>
        <asp:Repeater ID="rptDpt" runat="server">
            <HeaderTemplate>
                
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td>
                            <a class="link_djs" dptid='<%# Eval("DptId") %>' onclick='showDetail()' >
                                <%# Eval("dptName")%>
                            </a>
                        </td>
                        <td>
                            <%# Eval("month_people")%>
                        </td>
                        <td>
                            <%# Eval("month_room")%>
                        </td>
                        <td>
                            <%# Eval("month_appendbed")%>
                        </td>
                        <td>
                            <%# Eval("month_visited")%>
                        </td>
                        <td>
                            <%# Eval("year_people")%>
                        </td>
                        <td>
                            <%# Eval("year_room")%>
                        </td>
                        <td>
                            <%# Eval("year_appendbed")%>
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


    <div class="detaillist" runat="server" id="report_detail">
        <div class="detailtitle" runat="server" id="dptname">
            旅游管理部门统计列表
        </div>
        <asp:Repeater ID="rptETDetail" runat="server" >
            <HeaderTemplate>
                <table border="0" cellpadding="0" cellspacing="0" class="tablesorter" style="margin-top:3px;width:100%">
                    <thead>
                        <tr>
                            <th>
                                日期
                            </th>
                            <th>
                                成人/儿童(住宿人天数)
                            </th>
                            <th>
                                房间数
                            </th>
                            <th>
                                加床数
                            </th>
                            <th>
                                成人/儿童(景区游览人次)
                            </th>
                        </tr>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("Date")%>
                    </td>
                    <td>
                        <%# Eval("People")%>
                    </td>
                    <td>
                        <%# Eval("Room")%>
                    </td>
                    <td>
                        <%# Eval("Appendbed")%>
                    </td>
                    <td>
                        <%# Eval("Visited")%>
                    </td>
                </tr>
            </ItemTemplate>
            
        </asp:Repeater>
        </table>
    </div>
    <div style="display:none">
        <asp:Button ID="btndetail" runat="server" Text="Button" OnClick="btndetail_Click" />
        <asp:HiddenField ID="hfdetail" runat="server" />
    </div>
</asp:Content>

