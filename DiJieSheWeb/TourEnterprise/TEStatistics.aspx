<%@ Page Title="" Language="C#" MasterPageFile="~/TourEnterprise/TE.master" AutoEventWireup="true" CodeFile="TEStatistics.aspx.cs" Inherits="TourEnterprise_TEStatistics" %>
<%@ MasterType VirtualPath="~/TourEnterprise/TE.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
<link href="/Scripts/jqueryplugin/jqueryui/css/ui-lightness/jquery-ui-1.9.0.custom.min.css"
        rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-1.9.1.custom.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("[id$='txtBeginTime']").datepicker();
            $("[id$='txtEndTime']").datepicker();
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <div class="detail_titlebg">
        统计
    </div>
        <div class="searchdiv">
        <h5>按条件查询</h5>
        团队名称&nbsp;&nbsp;<asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;旅行社名称&nbsp;&nbsp;<asp:TextBox ID="txtEntName" runat="server"></asp:TextBox><br />
        验证时间&nbsp;&nbsp;<asp:TextBox ID="txtBeginTime" runat="server"></asp:TextBox>&nbsp;&nbsp;至&nbsp;&nbsp;<asp:TextBox ID="txtEndTime" runat="server"></asp:TextBox>&nbsp;&nbsp;<asp:Button
            ID="Button1" runat="server" Text="查询" CssClass="btn" onclick="Button1_Click" />
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            统计列表
        </div>
        <table border="1" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    序号
                </td>
                <td>
                    住宿时间
                </td>
                <td>
                    团队名称
                </td>
                <td>
                    旅行社名称
                </td>
                <td>
                    人数
                </td>
            </tr>
            <asp:Repeater runat="server" ID="rptTgRecord" 
                onitemdatabound="rptTgRecord_ItemDataBound">
                <ItemTemplate>
                   <tr>
                        <td>
                            <asp:Literal ID="laNo" runat="server"></asp:Literal>
                        </td>
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
                           成人<%# Eval("AdultsAmount")%>儿童<%# Eval("ChildrenAmount")%></td>
                   </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <tr>
                        <td>
                            总计
                        </td>                    
                        <td colspan="4">
                            共接待团队数<asp:Literal ID="laGuiderCount" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;
                            其中包括成人<asp:Literal ID="laAdultCount" runat="server"></asp:Literal>儿童<asp:Literal ID="laChildrenCount" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </FooterTemplate>
            </asp:Repeater>
        </table>
       
    </div>
</asp:Content>

