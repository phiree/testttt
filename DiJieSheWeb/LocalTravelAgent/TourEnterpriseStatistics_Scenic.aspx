<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true" CodeFile="TourEnterpriseStatistics_Scenic.aspx.cs" Inherits="LocalTravelAgent_TourEnterpriseStatistics_Scenic" %>

<%@ MasterType VirtualPath="~/LocalTravelAgent/LTA.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/Content/themes/base/minified/jquery-ui.min.css"
        rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/Sequence.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.9.2.min.js"></script>
    <link href="/Scripts/jqueryplugin/tablesorter/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/OrderIndex.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Scripts/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".tablesorter").tablesorter();
            $(".IndexTable").orderIndex('2');
            $("[id$='txtDate']").focus(function () {
                WdatePicker({ dateFmt: 'yyyy年MM月', maxDate: new Date() })
            });
        });
        function showDetail(entId) {
            $("[id$='hfentId']").val(entId);
            $("[id$='btnShowSearch']").click();
        }
    </script>
    <style type="text/css">
        .link_ent
        {
            color:Black;
            text-decoration:none;
            cursor:pointer;
        }
        .link_ent:hover
        {
            text-decoration:underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="detail_titlebg">
        景区统计信息
    </div>
    <div class="searchdiv">
        <h5>
            按条件查询</h5>
        日期&nbsp;&nbsp;<asp:TextBox ID="txtDate" runat="server"></asp:TextBox>&nbsp;&nbsp;景区名称&nbsp;&nbsp;<asp:TextBox
            ID="txtEntName" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;奖励单位;&nbsp;&nbsp;<asp:DropDownList
                ID="ddlIsReward" runat="server">
                <asp:ListItem Value="全部">全部</asp:ListItem>
                <asp:ListItem Value="是">是</asp:ListItem>
                <asp:ListItem Value="否">否</asp:ListItem>
            </asp:DropDownList>
        &nbsp;&nbsp;
        <asp:Button ID="BtnSearch" runat="server" Text="搜索" CssClass="btn2" OnClick="BtnSearch_Click" />
        <asp:Button ID="btnOutput3" Text="导出" runat="server" OnClick="btnOutput3_Click" CssClass="btn2" />
    </div>
    <div class="detaillist" runat="server" id="total_report">
        <div class="detailtitle">
            景区统计列表
        </div>
        <table class="tablesorter IndexTable">
        </table>
        <asp:Repeater ID="rptStatistic" runat="server" OnItemDataBound="rptStatistic_ItemDataBound">
            <HeaderTemplate>
                <table border="0" cellpadding="0" cellspacing="0" class="tablesorter InfoTable">
                    <thead>
                        <tr>
                            <th rowspan="2">
                                景区名称
                            </th>
                            <td>
                                本月
                            </td>
                            <td>
                                本年
                            </td>
                        </tr>
                        <tr>
                            <th>
                                景区游览人次
                            </th>
                            <th>
                                景区游览人次
                            </th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <a onclick='showDetail(<%# Eval("entid") %>)' class="link_ent">
                            <%# Eval("Name")%></a>
                    </td>
                    <td>
                        <%# Eval("month_people")%>
                    </td>
                   <td>
                        <%# Eval("year_people")%>
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
                            <asp:Literal ID="laPeople_Month_Total" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="laPeople_Year_Total" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </tfoot>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        
    </div>

    <div class="detaillist" runat="server" id="detail_report">
        <div class="detailtitle" id="entName" runat="server">
            
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
                                成人(景区游览人次)
                            </th>
                            <th>
                                儿童(景区游览人次)
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
                        <%# Eval("Adult_Count")%>
                    </td>
                    <td>
                        <%# Eval("Child_Count")%>
                    </td>
                </tr>
            </ItemTemplate>
            
        </asp:Repeater>
        </table>
    </div>
    <div style="display:none">
        <asp:Button ID="btnShowSearch" runat="server" Text="Button" OnClick="btnShowSearch_Click" />
        <asp:HiddenField runat="server" ID="hfentId" />
    </div>
</asp:Content>
