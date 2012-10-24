<%@ Page Title="" Language="C#" MasterPageFile="~/TourEnterprise/TE.master" AutoEventWireup="true" CodeFile="TEGroupForecast.aspx.cs" Inherits="TourEnterprise_TEGroupForecast" %>
<%@ MasterType VirtualPath="~/TourEnterprise/TE.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <div class="detail_titlebg">
        预订单详情
    </div>
    <div class="searchdiv">
        <h5>按时间进行查询</h5>
        <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rbolistSelect" OnSelectedIndexChanged="rbolistSelect_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem Text="3天内抵达" Selected="True" Value="type_1"  />
            <asp:ListItem Text="一周内抵达" Value="type_2" />
            <asp:ListItem Text="一个月内抵达" Value="type_3" />
            <asp:ListItem Text="所有预订单(未验证)" Value="type_4" />
        </asp:RadioButtonList>
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            预定列表
        </div>
        <table border="1" cellpadding="0" cellspacing="0">
            <tr>
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

