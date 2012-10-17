<%@ Page Title="" Language="C#" MasterPageFile="~/TourManagerDpt/manager.master" AutoEventWireup="true" CodeFile="RewordEnt.aspx.cs" Inherits="TourManagerDpt_RewordEnt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">
    <div class="detail_titlebg">
        奖励情况
    </div>
    <div class="searchdiv">
        <h5>按时间进行查询</h5>
        <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rbolistSelect" OnSelectedIndexChanged="rbolistSelect_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem Text="三个月内" Selected="True" Value="type_1"  />
            <asp:ListItem Text="半年内" Value="type_2" />
            <asp:ListItem Text="一年内" Value="type_3" />
            <asp:ListItem Text="所有奖励" Value="type_4" />
        </asp:RadioButtonList>
        </div>
    <ul style="margin-bottom:-5px">
        <li>
            1.以下统计的景区和宾馆都是为认证通过在奖励范围内的企业
        </li>
        <li>
            2.团队统计的景区宾馆也都是为认证通过在奖励范围内的企业
        </li>
    </ul>
    <div class="detaillist">
        <div class="detailtitle">
            企业奖励列表
        </div>
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    类型
                </td>
                <td>
                    名称
                </td>
                <td>
                    游玩团队数
                </td>
                <td>
                    游玩人数
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Literal ID="laType" runat="server"></asp:Literal>
                </td>
                <td>
                    <asp:Literal ID="laName" runat="server"></asp:Literal>
                </td>
                <td>
                    <asp:Literal ID="laGroupCount" runat="server"></asp:Literal>
                </td>
                <td>
                    <asp:Literal ID="laPeoCount" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

