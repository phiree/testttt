<%@ Page Title="" Language="C#" MasterPageFile="~/TourManagerDpt/manager.master"
    AutoEventWireup="true" CodeFile="StaticsList.aspx.cs" Inherits="TourManagerDpt_StaticsList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/Scripts/jqueryplugin/tablesorter/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/OrderIndex.js" type="text/javascript"></script>
    <link href="../Scripts/jqueryplugin/jqueryui/css/smoothness/jquery-ui-1.9.1.custom.min.css"
        rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-1.9.1.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Scripts/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#tabs").tabs();
            $("#tbGov1").tablesorter();
            $("#tbGov2").tablesorter();
            $("#tbGov3").tablesorter({ headers: { 3: { sorter: false}} });
            $("#tabs").bind('tabsselect', function (event, ui) {
                if ($.cookie("tabIndex") != ui.index) {
                    if (ui.index == "0") {
                        $("[id$='btn_yijiedai']").click();
                    }
                    if (ui.index == "1") {
                        $("[id$='btn_yijiedai2']").click();
                    }
                    if (ui.index == "2") {
                        $("[id$='btn_yijiedai3']").click();
                    }
                }
                $.cookie("tabIndex", ui.index);
            });
            if ($.cookie("tabIndex") != null) {
                $("#tabs").tabs('select', parseInt($.cookie("tabIndex")));
            }
            $("#tbMain").tablesorter();
            $(".IndexTable").eq(0).orderIndex();
            $(".IndexTable").eq(1).orderIndex({ tableindex: '2' });
            $(".IndexTable").eq(2).orderIndex({ tableindex: '3' });
        });
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="Server">
    <div class="detaillist" style="width: 100%; padding: 0px">
        <div id="tabs" class="tabs" style="margin: 0px; padding: 0px">
            <ul>
                <li><a href="#tabs-1">已接待情况</a></li>
                <li><a href="#tabs-2">旅游企业接待情况明细表</a></li>
                <li><a href="#tabs-3">团队旅游情况表</a></li>
            </ul>
            <div id="tabs-1">
                <div class="detailtitle">
                    已接待情况</div>
                <div class="searchdiv">
                    日期：<asp:TextBox ID="txt_yijiedai" runat="server" onfocus="WdatePicker({dateFmt:'yyyy年MM月'})" />
                    地接社名称：<asp:TextBox ID="txt_name1" runat="server" />
                    <asp:Button ID="btn_yijiedai" Text="查询" runat="server" OnClick="btn_yijiedai_Click"
                        CssClass="btn" />
                </div>
                <table class="tablesorter IndexTable">
                </table>
                <table id="tbGov1" class="tablesorter InfoTable">
                    <thead>
                        <tr>
                            <th rowspan="2">
                                地接社名称
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
                                游览人数
                            </th>
                            <th>
                                住宿人天数
                            </th>
                            <th>
                                总人数
                            </th>
                            <th>
                                游览人数
                            </th>
                            <th>
                                住宿人天数
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptGov1" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <a href='/TourManagerDpt/StaticsDetail.aspx?=<%#Eval("Name")%>'>
                                            <%#Eval("Name")%></a>
                                    </td>
                                    <td>
                                        <%#(int)Eval("m_AdultsAmount") + (int)Eval("m_ChildrenAmount")%>
                                    </td>
                                    <td>
                                        <%#Eval("m_Playnums")%>
                                    </td>
                                    <td>
                                        <%#Eval("m_LiveDays")%>
                                    </td>
                                    <td>
                                        <%#(int)Eval("y_AdultsAmount") + (int)Eval("y_ChildrenAmount")%>
                                    </td>
                                    <td>
                                        <%#Eval("y_Playnums")%>
                                    </td>
                                    <td>
                                        <%#Eval("y_LiveDays")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                    <tfoot>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <%=m_total%>
                            </td>
                            <td>
                                <%=m_play%>
                            </td>
                            <td>
                                <%=m_hotel%>
                            </td>
                            <td>
                                <%=y_total%>
                            </td>
                            <td>
                                <%=y_play%>
                            </td>
                            <td>
                                <%=y_hotel%>
                            </td>
                        </tr>
                    </tfoot>
                </table>
                <div style="clear: both">
                    <asp:Button ID="btnOutput" Text="导出" runat="server" OnClick="btnOutput1_Click" />
                </div>
            </div>
            <div id="tabs-2">
                <div class="detailtitle">
                    旅游企业接待情况明细表</div>
                <div class="searchdiv">
                    日期：<asp:TextBox ID="txt_yijiedai2" runat="server" onfocus="WdatePicker({dateFmt:'yyyy年MM月'})" />
                    企业名称(*必填)：<asp:TextBox ID="txt_name2" runat="server" />
                    <asp:Button ID="btn_yijiedai2" Text="查询" runat="server" OnClick="btn_yijiedai2_Click"
                        CssClass="btn" /></div>
                <asp:Repeater ID="rptGov2" runat="server">
                    <HeaderTemplate>
                        <table class="tablesorter IndexTable">
                        </table>
                        <table id="tbGov2" class="tablesorter InfoTable">
                            <thead>
                                <tr>
                                    <th>
                                        地接社名称
                                    </th>
                                    <th>
                                        拟接待人数
                                    </th>
                                    <th>
                                        实际接待人数
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <a href='/TourManagerDpt/StaticsDetail.aspx?=<%#Eval("Name")%>'>
                                    <%#Eval("Name")%></a>
                            </td>
                            <td>
                                共<%#(int)Eval("AdultsAmount_pre") + (int)Eval("ChildrenAmount_pre")%>人： 成人<%#Eval("AdultsAmount_pre")%>人，儿童<%#Eval("ChildrenAmount_pre")%>人
                            </td>
                            <td>
                                共<%#(int)Eval("AdultsAmount_act") + (int)Eval("ChildrenAmount_act")%>人： 成人<%#Eval("AdultsAmount_act")%>人，儿童<%#Eval("ChildrenAmount_act")%>人
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody> </table>
                    </FooterTemplate>
                </asp:Repeater>
                <div style="clear: both">
                    <asp:Button ID="btnOutput2" Text="导出" runat="server" OnClick="btnOutput2_Click" />
                </div>
            </div>
            <div id="tabs-3">
                <div class="detailtitle">
                    团队旅游情况表</div>
                <div class="searchdiv">
                    日期：<asp:TextBox ID="txt_yijiedai3" runat="server" onfocus="WdatePicker({dateFmt:'yyyy年MM月'})" />
                    企业名称(*必填)：<asp:TextBox ID="txt_name3djs" runat="server" />
                    <asp:Button ID="btn_yijiedai3" Text="查询" runat="server" OnClick="btn_yijiedai3_Click"
                        CssClass="btn" /></div>
                <asp:Repeater ID="rptGov3" runat="server">
                    <HeaderTemplate>
                        <table class="tablesorter IndexTable">
                        </table>
                        <table id="tbGov3" class="tablesorter InfoTable">
                            <thead>
                                <tr>
                                    <th>
                                        地接社名称
                                    </th>
                                    <th>
                                        团队名称
                                    </th>
                                    <th>
                                        时间
                                    </th>
                                    <th>
                                        游览情况
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("Name")%></a>
                            </td>
                            <td>
                                <a href='/TourManagerDpt/GroupDetail.aspx?gid=<%#Eval("GId")%>'>
                                    <%#Eval("Gname")%></a>
                            </td>
                            <td>
                                <%#Eval("Bedate")%></a>
                            </td>
                            <td>
                                上一日住宿：<%#Eval("y_hotel")%>，准备入住：<%#Eval("t_hotel")%><br />
                                今日游览：<%#Eval("t_scenic")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody> </table>
                    </FooterTemplate>
                </asp:Repeater>
                <div style="clear: both">
                    <asp:Button ID="btnOutput3" Text="导出" runat="server" OnClick="btnOutput3_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
