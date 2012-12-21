<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="TEDetailStatistics.aspx.cs" Inherits="LocalTravelAgent_TEDetailStatistics" %>

<%@ MasterType VirtualPath="~/LocalTravelAgent/LTA.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/Scripts/jqueryplugin/tablesorter/style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="detail_titlebg">
        旅游企业详细信息
    </div>
    <div class="searchdiv">
        旅游企业的名称:<span runat="server" id="ETName" style="font-size: 14px; font-weight: bold"></span><asp:Button
            ID="btnExcel" runat="server" Text="导出" CssClass="btn2" 
            onclick="btnExcel_Click" />
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            详细列表
        </div>
        <asp:Repeater ID="rptETDetail" runat="server" OnItemDataBound="rptETDetail_ItemDataBound">
            <HeaderTemplate>
                <table border="0" cellpadding="0" cellspacing="0" class="tablesorter" style="margin-top:3px;width:100%">
                    <thead>
                        <tr>
                            <th>
                                日期
                            </th>
                            <th>
                                游玩人数或住宿人天数
                            </th>
                        </tr>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Repeater ID="rptETMonthDetail" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("ConsumeTime","{0:yyyy-MM-dd}")%>
                            </td>
                            <td>
                                <asp:Literal ID="laCountInfo" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td>
                        <%# Eval("MonthIndex")%>月份小计
                    </td>
                    <td>
                        <asp:Literal ID="laMonthTotal" runat="server"></asp:Literal>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <tr>
                    <td>
                        总计
                    </td>
                    <td>
                        <asp:Literal ID="laYearTotal" runat="server"></asp:Literal>
                    </td>
                </tr>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
