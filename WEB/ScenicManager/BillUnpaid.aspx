<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true"
    CodeFile="BillUnpaid.aspx.cs" Inherits="ScenicManager_BillUnpaid" %>

<%@ MasterType VirtualPath="~/ScenicManager/sm.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" runat="Server">
    <link href="/theme/default/css/smdefault.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            showdate();
        });
        function showdate() {
            var str = "";
            str += $("[id$='txtbegin']").val().toString().substring(0, 4);
            str += "年" + $("[id$='txtbegin']").val().toString().substring(4, 6) + "月";
            str += "-" + $("[id$='txtend']").val().toString().substring(0, 4) + "年" + $("[id$='txtend']").val().toString().substring(4, 6) + "月";
            $("#datetitle").html(str);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <p class="fuctitle">
        售票查询</p>
    <hr />
    <div class="searchtime">
        查询日期&nbsp;<asp:TextBox ID="txtbegin" Text="201201" runat="server" CssClass="txtdate"
            onchange="showdate()" />&nbsp;至&nbsp;<asp:TextBox ID="txtend" Text="201212" runat="server"
                CssClass="txtdate" onchange="showdate()" />
    </div>
    <div id="spmain">
        <div class="odstate">
            订单状态&nbsp;
            <asp:DropDownList ID="ddlCondition" runat="server" CssClass="ddlstate" AutoPostBack="True"
                OnSelectedIndexChanged="ddlCondition_SelectedIndexChanged">
                <asp:ListItem Text="所有" />
                <asp:ListItem Text="已结单" />
                <asp:ListItem Text="未结单" />
            </asp:DropDownList>
            &nbsp;
        </div>
        <asp:Repeater ID="rptStatis" runat="server">
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0" class="sptable">
                    <tr style="height: 30px; background-color: #CBDFF2; display: block; padding: 0px;
                        margin: 0px; text-align: left;">
                        <td colspan="8" style="display: inline-block; padding: 0px; margin: 0px; text-align: left;
                            border: 0px none;">
                            <p id="datetitle" style="">
                                2012年7月-2012年8月</p>
                        </td>
                    </tr>
                    <tr class="titlename">
                        <td style="padding-left: 10px; width: 50px">
                            订单号
                        </td>
                        <td style="width: 100px;">
                            名称
                        </td>
                        <td style="width: 80px">
                            类型
                        </td>
                        <td style="width: 50px">
                            票数
                        </td>
                        <td style="width: 80px">
                            单价
                        </td>
                        <td style="width: 80px">
                            总价
                        </td>
                        <td style="width: 80px">
                            订单时间
                        </td>
                        <td style="width: 60px">
                            是否结算
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="odinfo">
                    <td style="padding-left: 10px; width: 50px">
                        <%# Eval("Order.Id")%>
                    </td>
                    <td style="width: 100px;">
                        <%# Eval("TicketPrice.Ticket.Name")%>
                    </td>
                    <td style="width: 80px">
                        <%# Eval("TicketPrice.PriceType")%>
                    </td>
                    <td style="width: 50px">
                        <%# Eval("Quantity")%>
                    </td>
                    <td style="width: 80px">
                        <%# ((Model.Ticket)Eval("TicketPrice.Ticket")).GetPrice((Model.PriceType)Eval("TicketPrice.PriceType"))%>
                    </td>
                    <td style="width: 80px">
                        <%# ((int)Eval("Quantity")) * ((Model.Ticket)Eval("TicketPrice.Ticket")).GetPrice((Model.PriceType)Eval("TicketPrice.PriceType"))%>
                    </td>
                    <td style="width: 80px">
                        <%#Eval("Order.BuyTime")%>
                    </td>
                    <td style="width: 60px">
                        <%#(bool)Eval("Order.IsPaid")?"已付款":"未付款"%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
