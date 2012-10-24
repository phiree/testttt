<%@ Page Title="" Language="C#" MasterPageFile="~/TourEnterprise/TE.master" AutoEventWireup="true" CodeFile="TEGroupForecast.aspx.cs" Inherits="TourEnterprise_TEGroupForecast" %>
<%@ MasterType VirtualPath="~/TourEnterprise/TE.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
<link href="/Scripts/jqueryplugin/jqueryui/css/ui-lightness/jquery-ui-1.9.0.custom.min.css"
        rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-1.9.0.custom.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("[id$='txtBeginTime']").datepicker();
            $("[id$='txtEndTime']").datepicker();
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <div class="detail_titlebg">
        预订单详情
    </div>
    <div class="searchdiv">
        <h5>按条件查询</h5>
        团队名称 &nbsp;&nbsp;<asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox> &nbsp;&nbsp;旅行社名称 &nbsp;&nbsp;<asp:TextBox ID="txtEntName" runat="server"></asp:TextBox>
        <br />抵达时间 &nbsp;&nbsp;<asp:TextBox ID="txtBeginTime" runat="server"></asp:TextBox>&nbsp;&nbsp;至&nbsp;&nbsp;<asp:TextBox ID="txtEndTime" runat="server"></asp:TextBox>
        <asp:Button  ID="BtnSearch" runat="server" Text="搜索" CssClass="btn" 
            style="margin-left:15px" onclick="BtnSearch_Click" />
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            预定列表
        </div>
        <table border="1" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    序号
                </td>
                <td>
                    抵达时间
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
        <asp:Repeater runat="server" ID="rptTgInfo" OnItemDataBound="rptTgInfo_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Literal ID="laNo" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:Literal ID="ArriveTime" runat="server" />     
                    </td>
                    <td>
                        <a href='/TourEnterprise/GroupDetail.aspx?id=<%# Eval("DJ_TourGroup.Id")%>'>
                        <%# Eval("DJ_TourGroup.Name")%></a>
                    </td>
                    <td>
                        <%# Eval("DJ_TourGroup.DJ_DijiesheInfo.Name")%>
                    </td>
                    <td>
                        成人<%# Eval("DJ_TourGroup.AdultsAmount")%>儿童<%# Eval("DJ_TourGroup.ChildrenAmount")%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        </table>
    </div>
</asp:Content>

