<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true"
    CodeFile="StatisInfo.aspx.cs" Inherits="ScenticManager_StatisInfo" %>

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
        账单管理</p>
    <hr />
    <div class="searchtime">
        账单日期&nbsp;<asp:TextBox ID="txtbegin" Text="201201" runat="server" CssClass="txtdate" onchange="showdate()" />&nbsp;至&nbsp;<asp:TextBox ID="txtend" Text="201212" runat="server" CssClass="txtdate" onchange="showdate()" />
    </div>
    <div id="zdmain">
       <div class="odstate">
            显示:
    <asp:CheckBox ID="unpay" Text="未结" runat="server" AutoPostBack="True" 
                oncheckedchanged="unpay_CheckedChanged" />
    <asp:CheckBox ID="paid" Text="已结" runat="server" AutoPostBack="True" 
                oncheckedchanged="unpay_CheckedChanged" />
       </div>
    <asp:Repeater ID="rptStatis" runat="server" OnItemCommand="rptStatis_ItemCommand">
        <HeaderTemplate>
            <table cellpadding="0" cellspacing="0" class="sptable">
                <tr style=" height:30px; background-color:#CBDFF2; display:block; padding:0px; margin:0px;text-align:left;">
                        <td colspan="5" style="  display:inline-block; padding:0px; margin:0px; text-align:left; border:0px solid White;" >
                            <p id="datetitle" style="">2012年7月-2012年8月</p>
                        </td>
                 </tr>
                <tr class="titlename">
                    <td style="padding-left:10px; width:150px">
                        出票日期
                    </td>
                    <td style=" width:150px;">
                        订票方式
                    </td>
                    <td style="width:100px;">
                        数量
                    </td>
                    <td style="width:100px">
                        金额
                    </td>
                    <td style="width:87px">
                        结账状态
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="odinfo">
                <td style="padding-left:10px; width:150px">
                    <%# Eval("date")%>
                </td>
                <td style=" width:150px;">
                    <%# Eval("orderway")%>
                </td>
                <td style="width:100px;">
                    <%# Eval("num")%>
                </td>
                <td style="width:100px">
                    <%# decimal.Parse( Eval("totalprice").ToString()).ToString("0")%>
                </td>
                <td style="width:87px">
                    <%#(bool)Eval("paidstate") ? "已结" : "未结"%>
                    <asp:Button ID="Button1" Text="结算" runat="server" Visible='<%# !(bool)Eval("paidstate") %>' 
                    CommandArgument='<%# Eval("date")+";"+ Eval("orderway")+";"+  Eval("num")+";"+ Eval("totalprice")%>'
                    CommandName="jiesuan" />
                </td>
            </tr> 
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    </div>
</asp:Content>
