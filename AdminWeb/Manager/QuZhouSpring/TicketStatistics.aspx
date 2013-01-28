<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="TicketStatistics.aspx.cs" Inherits="Manager_QuZhouSpring_TicketStatistics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <div class="detail_titlebg">
        门票统计
    </div>
    <div class="searchdiv">
        本次活动共发送门票<span style="font-size:14px; font-weight:bold;"><%= allTicketCount %></span>张
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            具体日期的门票统计
        </div>
        <asp:Repeater runat="server" ID="rptDateList" 
            onitemdatabound="rptDateList_ItemDataBound">
            <HeaderTemplate>
                <table>
                    <tr>
                        <td>
                            门票名称
                        </td>
                        <asp:Literal  runat="server" id="partnerHeadList" />
                        <td>
                            总计
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><a href=""><%# Eval("Scenic.Name") %>_<%# Eval("Name") %></a></td>
                    <asp:Literal  runat="server" id="partnerCountList" />
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <tr>
                    <td>总计</td>
                    <asp:Literal  runat="server" id="partnerFooterList" />
                    <td></td>
                </tr>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

