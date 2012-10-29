<%@ Page Title="" Language="C#" MasterPageFile="~/TourManagerDpt/manager.master"
    AutoEventWireup="true" CodeFile="StaticsList.aspx.cs" Inherits="TourManagerDpt_StaticsList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/Scripts/jqueryplugin/jqueryui/css/ui-lightness/jquery-ui-1.9.0.custom.min.css"
        rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-1.9.0.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("[id$='txt_yijiedai']").datepicker();
            $("[id$='txt_yijiedai_end']").datepicker();
            $("[id$='txt_yijiedai2']").datepicker();
            $("[id$='txt_yijiedai2_end']").datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="Server">
    <div class="detaillist">
        <div class="detailtitle"style="display:none">
            原数据</div>
        <asp:Repeater ID="rptOrigin" runat="server">
            <HeaderTemplate>
                <table border="1" cellpadding="1" cellspacing="1"style="display:none">
                    <thead>
                        <tr>
                            <td>
                                序号
                            </td>
                            <td>
                                地接社名称
                            </td>
                            <td>
                                成人数
                            </td>
                            <td>
                                儿童数
                            </td>
                            <td>
                                住宿天数
                            </td>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%=xuhao_orig++%>
                    </td>
                    <td>
                        <%#Eval("Route.DJ_TourGroup.DJ_DijiesheInfo.Name")%>
                    </td>
                    <td>
                        <%#Eval("AdultsAmount")%>
                    </td>
                    <td>
                        <%#Eval("ChildrenAmount")%>
                    </td>
                    <td>
                        <%#Eval("LiveDay")%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
        
        <div class="detailtitle">
            已接待情况</div>
        <div class="searchdiv">
            日期：<asp:TextBox ID="txt_yijiedai" runat="server" /> 至 <asp:TextBox ID="txt_yijiedai_end" runat="server" />
            地接社名称：<asp:TextBox ID="txt_name1" runat="server" />
            <asp:Button ID="btn_yijiedai" Text="查询" runat="server" OnClick="btn_yijiedai_Click" CssClass="btn" />
            </div>
        <table border="1" cellpadding="1" cellspacing="1">
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
        </table>
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
                        游览人数
                    </td>
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
        </table>--%>
        <hr />
        <div class="detailtitle">
            旅游企业接待情况明细表</div>
        <div class="searchdiv">
            日期：<asp:TextBox ID="txt_yijiedai2" runat="server" /> 至 <asp:TextBox ID="txt_yijiedai2_end" runat="server" />
            地接社名称：<asp:TextBox ID="txt_name2" runat="server" />
            <asp:Button ID="btn_yijiedai2" Text="查询" runat="server" OnClick="btn_yijiedai2_Click" CssClass="btn" /></div>
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
        <div class="detailtitle">
            团队旅游情况表</div>
        <div class="searchdiv">
            日期：<asp:TextBox ID="txt_yijiedai3" runat="server" /> 至 <asp:TextBox ID="txt_yijiedai3_end" runat="server" />
            地接社名称：<asp:TextBox ID="txt_name3djs" runat="server" />
              团队：<asp:TextBox ID="txt_name3" runat="server" />
            <asp:Button ID="btn_yijiedai3" Text="查询" runat="server" OnClick="btn_yijiedai3_Click" CssClass="btn" /></div>
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
                                浏览情况
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
                        <a href='/TourManagerDpt/GroupDetail.aspx?gid=<%#Eval("GId")%>'>查看详情</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
