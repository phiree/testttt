<%@ Page Title="" Language="C#" MasterPageFile="~/TourEnterprise/TE.master" AutoEventWireup="true" CodeFile="TE_UnLiveStatistics.aspx.cs" Inherits="TourEnterprise_TE_UnLiveStatistics" %>
<%@ MasterType VirtualPath="~/TourEnterprise/TE.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
    <link href="/Content/themes/base/minified/jquery-ui.min.css"
        rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.9.2.min.js"></script>
    <link href="/Scripts/jqueryplugin/tablesorter/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="../Scripts/jqueryplugin/OrderIndex.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("[id$='txtTime']").datepicker({ minDate: new Date() });
            $("#myTable").tablesorter({ headers: { 4: { sorter: false }, 5: { sorter: false}} });
            $(".IndexTable").orderIndex();

        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
     <div class="detail_titlebg">
        拟入住统计
    </div>
    <div class="searchdiv">
        <h5>按条件查询</h5>
        旅行社名称<asp:TextBox ID="txtEntName" runat="server" Width="100px"></asp:TextBox>
        验证时间<asp:TextBox ID="txtTime" runat="server" Width="100px"></asp:TextBox>
        <asp:Button ID="BtnSearch" runat="server" Text="查询" CssClass="btn2" onclick="BtnSearch_Click" />
            <asp:Button ID="BtnCreatexls" runat="server" Text="导出成excel" 
                onclick="BtnCreatexls_Click" CssClass="btn2" />
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            拟入住统计
        </div>
        <table class="tablesorter IndexTable">
        </table>
        <table  id="myTable" class="tablesorter InfoTable">
            <thead>
            <tr>
                <th>
                    预住时间
                </th>
                <th>
                    旅行社名称
                </th>
                <th>
                    住宿天数
                </th>
                <th>
                    成人/儿童(人数)
                </th>
                <th>
                    导游
                </th>
                <th>
                    联系电话
                </th>
            </tr>
        </thead>
         <tbody>
            <asp:Repeater runat="server" ID="rptTgRecord" >
                <ItemTemplate>
                   <tr>
                       
                       <td> <%# Eval("Time")%></td>
                       <td>
                           <%# Eval("entName")%>
                       </td>
                       <td>
                           <%# Eval("LiveCount")%>
                       </td>
                       <td>
                           <%# Eval("PeopleCount")%></td>
                        <td>
                            <%# Eval("guidername")%>
                        </td>
                        <td>
                            <%# Eval("telephone")%>
                        </td>
                   </tr>
                </ItemTemplate>
                <FooterTemplate>
                </tbody>
                </FooterTemplate>
            </asp:Repeater>
        </table>
</asp:Content>

