<%@ Page Title="" Language="C#" MasterPageFile="~/TourEnterprise/TE.master" AutoEventWireup="true" CodeFile="TEStatistics.aspx.cs" Inherits="TourEnterprise_TEStatistics" %>
<%@ MasterType VirtualPath="~/TourEnterprise/TE.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
<link href="/Content/themes/base/minified/jquery-ui.min.css"
        rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.9.2.min.js"></script>
    <link href="/Scripts/jqueryplugin/tablesorter/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="../Scripts/jqueryplugin/OrderIndex.js" type="text/javascript"></script>
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
            $("[id$='txtTime']").focus(function () {
                WdatePicker({ dateFmt: 'yyyy年MM月',maxDate:new Date() })
            });
            $("#myTable").tablesorter({ headers: { 5: { sorter: false }, 4: { sorter: false}} });
            $("#detailTable").tablesorter();
            $(".IndexTable").orderIndex();

        });

        function showDetail(djsid) {
            $("[id$='hfdetail']").val(djsid);
            $("[id$='btndetail']").click();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <div class="detail_titlebg">
        已入住统计
    </div>
        <div class="searchdiv">
        <h5>按条件查询</h5>
        旅行社名称<asp:TextBox ID="txtEntName" runat="server" Width="100px"></asp:TextBox>
        验证时间<asp:TextBox ID="txtTime" runat="server" Width="100px"></asp:TextBox>
        <asp:Button ID="BtnSearch" runat="server" Text="查询" CssClass="btn2" onclick="BtnSearch_Click" />
            <asp:Button ID="BtnCreatexls" runat="server" Text="导出成excel" 
                onclick="BtnCreatexls_Click" CssClass="btn2" />
    </div>
    <div class="detaillist" runat="server" id="report_total" >
        <div class="detailtitle">
            已入住统计列表
        </div>
        <table class="tablesorter IndexTable">
        </table>
        <table  id="myTable" class="tablesorter InfoTable">
            <thead>
            <tr>
                <th rowspan="2">
                    旅行社名称
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
                    入住天数
                </th>
                <th>
                    房间数
                </th>
                <th>
                    加床数
                </th>
                <th>
                    入住天数
                </th>
                <th>
                    房间数
                </th>
                <th>
                    加床数
                </th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="rptTgRecord" >
                <ItemTemplate>
                   <tr>
                       <td>
                           <a class="link_djs" onclick='showDetail(<%# Eval("djsId") %>)'><%# Eval("EntName")%></a></td>
                       <td>
                           <%# Eval("LiveCount_Month")%>
                       </td>
                       <td>
                           <%# Eval("RoomCount_Month")%>
                       </td>
                       <td>
                           <%# Eval("AppendBed_Month")%>
                       </td>
                       <td>
                           <%# Eval("LiveCount_Year")%>
                       </td>
                       <td>
                           <%# Eval("RoomCount_Year")%>
                       </td>
                       <td>
                           <%# Eval("AppendBed_Year")%></td>
                   </tr>
                </ItemTemplate>
                <FooterTemplate>
                </tbody>
                </FooterTemplate>
            </asp:Repeater>
        </table>
    </div>

    <div class="detaillist" runat="server" id="report_detail">
        <div class="detailtitle">
            地接社详细列表
        </div>
        <table class="tablesorter IndexTable report_2">
        </table>
         <table  id="detailTable" class="tablesorter InfoTable">
            <thead>
                <tr>
                    <th>
                        入住时间
                    </th>
                    <th>
                        团队名称
                    </th>
                    <th>
                        旅行社名称
                    </th>
                    <th>
                        成人/儿童(人数)
                    </th>
                    <th>
                        入住天数
                    </th>
                    <th>
                        房间数
                    </th>
                    <th>
                        加床数
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptDetail" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("ConsumeTime","{0:yyyy-MM-dd}")%>
                            </td>
                            <td>
                                <%# Eval("Route.DJ_TourGroup.Name")%>
                            </td>
                            <td>
                                <%# Eval("Route.DJ_TourGroup.DJ_DijiesheInfo.Name")%>
                            </td>
                            <td>
                                <%# Eval("AdultsAmount")%>/<%# Eval("ChildrenAmount")%>
                            </td>
                            <td>
                                <%# Eval("LiveDay")%>
                            </td>
                            <td>
                                <%# Eval("RoomNum")%>
                            </td>
                            <td>
                                <%# Eval("AppendBed")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
         </table>
    </div>
    <div style="display:none">
        <asp:Button ID="btndetail" runat="server" Text="Button" OnClick="btndetail_Click" />
        <asp:HiddenField ID="hfdetail" runat="server" />
    </div>
</asp:Content>

