<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true" CodeFile="DptStatistic.aspx.cs" Inherits="LocalTravelAgent_DptStatistic" %>
<%@ MasterType VirtualPath="~/LocalTravelAgent/LTA.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<div class="detail_titlebg">
        旅游管理部门统计信息
    </div>
<div class="searchdiv">
        <h5>按条件查询</h5>
        日期&nbsp;&nbsp;<asp:TextBox ID="txtBeginDate" runat="server"></asp:TextBox>&nbsp;&nbsp;至&nbsp;&nbsp;<asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
        旅游管理部门名称&nbsp;&nbsp;<asp:TextBox ID="txtEntName" runat="server"></asp:TextBox>
        日期统计<asp:DropDownList ID="ddlDateStatistic" runat="server">
            <asp:ListItem Value="全部">全部</asp:ListItem>
            <asp:ListItem Value="本年">本月</asp:ListItem>
            <asp:ListItem Value="本年">本年</asp:ListItem>
         </asp:DropDownList>
         <asp:Button ID="BtnSearch" runat="server" Text="搜索" CssClass="btn" 
             onclick="BtnSearch_Click" />
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            统计列表
        </div>
        <asp:Repeater ID="rptDpt" runat="server" onitemdatabound="rptDpt_ItemDataBound">
            <HeaderTemplate>
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            序号
                        </td>
                        <td>
                            旅游管理部门名称
                        </td>
                        <td>
                            总人数
                        </td>
                        <td>
                            住宿人天数
                        </td>
                        <td>
                            游玩人数
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td>
                            <%= Index++ %>
                        </td>
                        <td>
                            <a href='/LocalTravelAgent/DptDetailStatistic.aspx?dptid=<%# Eval("Id") %>'>
                            <%# Eval("Name") %>
                            </a>
                        </td>
                        <td>
                            <asp:Literal ID="laTotalCount" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="laLiveCount" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="laVisitedCount" runat="server"></asp:Literal>
                        </td>
                    </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

