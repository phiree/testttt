<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true" CodeFile="checkTicketStatis.aspx.cs" Inherits="ScenicManager_checkTicketStatis" %>
<%@ MasterType VirtualPath="~/ScenicManager/sm.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" Runat="Server">
    <link href="/theme/default/css/smdefault.css" rel="stylesheet" type="text/css" />
    <link href="/Scripts/jqueryplugin/jqueryui/css/ui-lightness/jquery-ui-1.9.1.custom.min.css"
        rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-1.9.1.custom.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("[id$='txtbegin']").datepicker();
            $("[id$='txtend']").datepicker();
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <p class="fuctitle">
        验票账单</p>
    <hr />
    <div class="searchtime">
        验票日期&nbsp;<asp:TextBox ID="txtbegin" runat="server" CssClass="txtdate" />&nbsp;至&nbsp;<asp:TextBox ID="txtend" runat="server" CssClass="txtdate" />
        <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
    </div>
    <div id="wlmain" style=" height:500px; overflow:scroll">
        <asp:Repeater ID="rptCheckTicketStatis" runat="server">
            <HeaderTemplate>
                <table class="wltable" cellpadding="0" cellspacing="0" >
                    <tr style="background-color: #E9E9E9">
                        <td>
                            序号
                        </td>
                        <td>
                            验票时间
                        </td>
                        <td>
                            门票名称
                        </td>
                        <td>
                            验票者姓名
                        </td>
                        <td>
                            验票者省份证号
                        </td>
                        <td>
                            验票员姓名
                        </td>
                        
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr style="background-color: #F9F9F9">
                    <td>
                        <%=index++ %>
                    </td>
                    <td style="background-color: #F9F9F9">
                        <%# Eval("UsedTime")%>
                    </td>
                    <td style="background-color: #F9F9F9">
                        <%# Eval("OrderDetail.TicketPrice.Ticket.Name")%>
                    </td>
                    <td style="background-color: #F9F9F9">
                        <%# Eval("Name")%>
                    </td>
                    <td style="background-color: #F9F9F9">
                        <%# Eval("IdCard")%>
                    </td>
                    <td style="background-color: #F9F9F9">
                        <%# Eval("saName")%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

