<%@ Page Title="" Language="C#" MasterPageFile="~/TourManagerDpt/manager.master" AutoEventWireup="true" CodeFile="RewordInfo.aspx.cs" Inherits="TourManagerDpt_RewordInfol" %>

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
        <li>
            3.所列团队都为本地接社下的团队
        </li>
    </ul>
    <div class="detaillist">
        <div class="detailtitle">
            团队奖励列表
        </div>
        <asp:Repeater ID="RptGroupReword" runat="server" 
            onitemdatabound="RptGroupReword_ItemDataBound">
            <HeaderTemplate>
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            团队名称
                        </td>
                        <td>
                            只去景点(人数)
                        </td>
                        <td>
                            只去宾馆(人数)
                        </td>
                        <td>
                            去了景区、宾馆(人数)
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("Name")%>
                    </td>
                    <td>
                        <asp:Literal ID="laOnlyScenic" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:Literal ID="laOnlyGuesthouse" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:Literal ID="Both" runat="server"></asp:Literal>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <tr>
                    <td>
                        总计
                    </td>
                    <td>
                        <asp:Literal ID="laOnlyScenicCount" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:Literal ID="laOnlyGuesthouseCount" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:Literal ID="BothCount" runat="server"></asp:Literal>
                    </td>
                </tr>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

