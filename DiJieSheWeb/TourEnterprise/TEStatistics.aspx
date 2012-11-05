<%@ Page Title="" Language="C#" MasterPageFile="~/TourEnterprise/TE.master" AutoEventWireup="true" CodeFile="TEStatistics.aspx.cs" Inherits="TourEnterprise_TEStatistics" %>
<%@ MasterType VirtualPath="~/TourEnterprise/TE.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
<link href="/Scripts/jqueryplugin/jqueryui/css/ui-lightness/jquery-ui-1.9.1.custom.min.css"
        rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-1.9.1.custom.min.js"></script>
    <link href="/Scripts/jqueryplugin/tablesorter/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="../Scripts/jqueryplugin/OrderIndex.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("[id$='txtBeginTime']").datepicker();
            $("[id$='txtEndTime']").datepicker();
            $("#myTable").tablesorter({ headers: { 5: { sorter: false}} });
            $(".IndexTable").orderIndex();
            
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <asp:HiddenField ID="hforder" runat="server" Value="0_desc" />
    <div class="detail_titlebg">
        统计
    </div>
        <div class="searchdiv">
        <h5>按条件查询</h5>
        团队名称<asp:TextBox ID="txtGroupName" runat="server" Width="100px"></asp:TextBox>
        旅行社名称<asp:TextBox ID="txtEntName" runat="server" Width="100px"></asp:TextBox>
        验证时间<asp:TextBox ID="txtBeginTime" runat="server" Width="100px"></asp:TextBox>至<asp:TextBox ID="txtEndTime" runat="server" Width="100px"></asp:TextBox>
        验证状态<asp:DropDownList ID="ddlState" runat="server">
            <asp:ListItem Value="全部">全部</asp:ListItem>
            <asp:ListItem Value="已认证">已认证</asp:ListItem>
            <asp:ListItem Value="未认证">未认证</asp:ListItem>
            </asp:DropDownList>
        <asp:Button ID="BtnSearch" runat="server" Text="查询" CssClass="btn" onclick="BtnSearch_Click" />
            <asp:Button ID="BtnCreatexls" runat="server" Text="导出成excel" 
                onclick="BtnCreatexls_Click" />
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            统计列表
        </div>
        <table class="tablesorter IndexTable">
        </table>
        <table  id="myTable" class="tablesorter InfoTable">
            <thead>
            <tr>
                
                <th>
                    住宿时间
                </th>
                <th>
                    团队名称
                </th>
                <th>
                    旅行社名称
                </th>
                <th>
                    住宿天数
                </th>
                <th>
                    人数
                </th>
                <th>
                    验证状态
                </th>
            </tr>
        </thead>
        
        <tbody>
            <asp:Repeater runat="server" ID="rptTgRecord" 
                onitemdatabound="rptTgRecord_ItemDataBound">
                <ItemTemplate>
                   <tr>
                       
                       <td>
                           <%# Eval("ConsumeTime")%>
                       <td>
                           <a href='/TourEnterprise/GroupDetail.aspx?id=<%# Eval("Route.DJ_TourGroup.Id")%>'>
                           <%# Eval("Route.DJ_TourGroup.Name")%></a>
                       </td>
                       <td>
                           <%# Eval("Route.DJ_TourGroup.DJ_DijiesheInfo.Name")%>
                       </td>
                       <td>
                           <%# Eval("LiveDay")%>
                       </td>
                       <td>
                           成人<%# Eval("AdultsAmount")%>儿童<%# Eval("ChildrenAmount")%></td>
                        <td>
                            <asp:Literal ID="laIsChecked" runat="server"></asp:Literal>
                        </td>
                   </tr>
                </ItemTemplate>
                <FooterTemplate>
                </tbody>
                <tfoot>
                    <tr>
                                        
                        <td colspan="6">
                            共接待团队数<asp:Literal ID="laGuiderCount" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;
                            其中包括成人<asp:Literal ID="laAdultCount" runat="server"></asp:Literal>儿童<asp:Literal ID="laChildrenCount" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </tfoot>
                </FooterTemplate>
            </asp:Repeater>
        </table>
       
    </div>
</asp:Content>

