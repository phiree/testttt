<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true" CodeFile="GroupTestatistics.aspx.cs" Inherits="ScenicManager_GroupTestatistics" %>
<%@ MasterType VirtualPath="~/ScenicManager/sm.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" Runat="Server">
    <link href="/Scripts/jqueryplugin/jqueryui/css/ui-lightness/jquery-ui-1.9.1.custom.min.css"
        rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-1.9.1.custom.min.js"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <link href="../theme/default/css/smdefault.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("[id$='txtBeginTime']").datepicker();
            $("[id$='txtEndTime']").datepicker();
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <p class="fuctitle">
        团队信息统计</p>
    <hr />
    <div class="searchtime">
        团队名称<asp:TextBox ID="txtGroupName" runat="server" Width="80px"></asp:TextBox>旅行社名称<asp:TextBox ID="txtEntName" runat="server" Width="80px"></asp:TextBox>
        验证时间<asp:TextBox ID="txtBeginTime" runat="server" Width="80px" />至<asp:TextBox ID="txtEndTime" runat="server" Width="80px" />
        验证状态<asp:DropDownList runat="server" ID="ddlState">
            <asp:ListItem Value="全部">全部</asp:ListItem>
            <asp:ListItem Value="已验证">已验证</asp:ListItem>
            <asp:ListItem Value="未验证">未验证</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="BtnSearch" runat="server" Text="查询" />
    </div>
    <div id="zdmain">
        <asp:Repeater ID="rptTgRecord" runat="server" 
            onitemdatabound="rptTgRecord_ItemDataBound">
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0" class="sptable">
                    <tr class="titlename">
                        <td style="padding-left:10px; width:60px">
                            序号
                        </td>
                        <td style=" width:150px;">
                            游玩时间
                        </td>
                        <td style="width:100px;">
                            团队名称
                        </td>
                        <td style="width:100px">
                            旅行社名称
                        </td>
                        <td style="width:87px">
                            游玩人数
                        </td>
                        <td style="width:87px">
                            验证状态
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td style="padding-left:10px; width:60px">
                        <%= Index++ %>
                    </td>
                    <td style=" width:150px;">
                        <%# Eval("ConsumeTime","{0:yyyy-MM-dd}")%>
                    </td>
                    <td style="width:100px;">
                        <%# Eval("Route.DJ_TourGroup.Name")%>
                    </td>
                    <td style="width:100px">
                        <%# Eval("Route.DJ_TourGroup.DJ_DijiesheInfo.Name")%>
                    </td>
                    <td style="width:87px">
                        成人<%# Eval("AdultsAmount")%>儿童<%# Eval("ChildrenAmount")%></td>
                    <td style="width:87px">
                        <asp:Literal ID="laIsChecked" runat="server"></asp:Literal>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <tr>
                        <td style=" width:53px">
                            总计
                        </td>                    
                        <td colspan="6" style="width:530px">
                            共接待团队数<asp:Literal ID="laGuiderCount" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;
                            其中包括成人<asp:Literal ID="laAdultCount" runat="server"></asp:Literal>儿童<asp:Literal ID="laChildrenCount" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

