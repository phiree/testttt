<%@ Page Title="" Language="C#" MasterPageFile="~/TourManagerDpt/manager.master"
    AutoEventWireup="true" CodeFile="StaticsList.aspx.cs" Inherits="TourManagerDpt_StaticsList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/Scripts/jqueryplugin/tablesorter/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/OrderIndex.js" type="text/javascript"></script>
    <link href="/Scripts/jqueryplugin/jqueryui/css/ui-lightness/jquery-ui-1.9.1.custom.min.css"
        rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-1.9.1.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("[id$='txt_yijiedai']").datepicker();
            $("[id$='txt_yijiedai2']").datepicker();
            $("[id$='txt_yijiedai3']").datepicker();
            $("#tabs").tabs();
            $("#tbMain").tablesorter();
            $(".IndexTable").orderIndex('2');
        });
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="Server">
    <div class="detaillist">
        <div id="tabs">
            <ul>
                <li><a href="#tabs-1">已接待情况</a></li>
                <li><a href="#tabs-2">旅游企业接待情况明细表</a></li>
                <li><a href="#tabs-3">团队旅游情况表</a></li>
            </ul>
            <div id="tabs-1">
                <div class="detailtitle">
                    已接待情况</div>
                <div class="searchdiv">
                    日期：<asp:TextBox ID="txt_yijiedai" runat="server" />
                    地接社名称：<asp:TextBox ID="txt_name1" runat="server" />
                    <asp:Button ID="btn_yijiedai" Text="查询" runat="server" OnClick="btn_yijiedai_Click"
                        CssClass="btn" />
                </div>
                <%--<table border="1" cellpadding="1" cellspacing="1">
            <thead>
                <tr>
                    <td rowspan="2">
                        序号
                    </td>
                    <td rowspan="2">
                        地接社名称
                    </td>
                    <td colspan="3">
                        总计
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
                        游览人数
                    </td>
                </tr>
            </thead>
             <tbody>
                <asp:Repeater ID="rptGov1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%=xuhao_1++ %>
                            </td>
                            <td>
                                <a href='/TourManagerDpt/StaticsDetail.aspx?=<%#Eval("Name")%>'>
                                    <%#Eval("Name")%></a>
                            </td>
                            <td>
                                <%#(int)Eval("AdultsAmount")+(int)Eval("ChildrenAmount")%>
                            </td>
                            <td>
                                <%#Eval("LiveDays")%>
                            </td>
                            <td>
                                <%#Eval("Playnums")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>--%>
                <table class="tablesorter IndexTable">
                </table>
                <table id="tbMain" class="tablesorter InfoTable">
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
                                住宿人天数
                            </th>
                            <th>
                                游览人数
                            </th>
                            <th>
                                总人数
                            </th>
                            <th>
                                住宿人天数
                            </th>
                            <th>
                                游览人数
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
                                        <%#(int)Eval("AdultsAmount")+(int)Eval("ChildrenAmount")%>
                                    </td>
                                    <td>
                                        <%#Eval("LiveDays")%>
                                    </td>
                                    <td>
                                        <%#Eval("Playnums")%>
                                    </td>
                                    <td>
                                        <%#(int)Eval("y_AdultsAmount") + (int)Eval("y_ChildrenAmount")%>
                                    </td>
                                    <td>
                                        <%#Eval("y_LiveDays")%>
                                    </td>
                                    <td>
                                        <%#Eval("y_Playnums")%>
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
                                    <%=m_hotel%>
                                </td>
                                <td>
                                    <%=m_play%>
                                </td>
                                <td>
                                    <%=y_total%>
                                </td>
                                <td>
                                    <%=y_hotel%>
                                </td>
                                <td>
                                    <%=y_play%>
                                </td>
                            </tr>
                        </tfoot>
                </table>
                <hr />
            </div>
            <div id="tabs-2">
                <div class="detailtitle">
                    旅游企业接待情况明细表</div>
                <div class="searchdiv">
                    日期：<asp:TextBox ID="txt_yijiedai2" runat="server" />
                    企业名称(*必填)：<asp:TextBox ID="txt_name2" runat="server" />
                    <asp:Button ID="btn_yijiedai2" Text="查询" runat="server" OnClick="btn_yijiedai2_Click"
                        CssClass="btn" /></div>
                <asp:Repeater ID="rptGov2" runat="server">
                    <HeaderTemplate>
                        <table border="1" cellpadding="1" cellspacing="1">
                            <thead>
                                <tr>
                                    <td>
                                        序号
                                    </td>
                                    <td>
                                        地接社名称
                                    </td>
                                    <td>
                                        拟接待人数
                                    </td>
                                    <td>
                                        实际接待人数
                                    </td>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%=xuhao_2++%>
                            </td>
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
                <hr />
            </div>
            <div id="tabs-3">
                <div class="detailtitle">
                    团队旅游情况表</div>
                <div class="searchdiv">
                    日期：<asp:TextBox ID="txt_yijiedai3" runat="server" />
                    企业名称(*必填)：<asp:TextBox ID="txt_name3djs" runat="server" />
                    <asp:Button ID="btn_yijiedai3" Text="查询" runat="server" OnClick="btn_yijiedai3_Click"
                        CssClass="btn" /></div>
                <asp:Repeater ID="rptGov3" runat="server">
                    <HeaderTemplate>
                        <table border="1" cellpadding="1" cellspacing="1">
                            <thead>
                                <tr>
                                    <td>
                                        序号
                                    </td>
                                    <td>
                                        地接社名称
                                    </td>
                                    <td>
                                        团队名称
                                    </td>
                                    <td>
                                        时间
                                    </td>
                                    <td>
                                        游览情况
                                    </td>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%=xuhao_3++ %>
                            </td>
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
            </div>
        </div>
    </div>
</asp:Content>
