﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="DateSettings.aspx.cs" Inherits="Manager_QuZhouSpring_DateSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/Styles/jquery-ui.min.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.9.2.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("[id$='tbxStart']").datepicker();
            $("[id$='tbxEnd']").datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <div class="detail_titlebg">
        门票分配
    </div>
    <div class="searchdiv">
        活动开始日期<asp:TextBox runat="server" ID="tbxStart"></asp:TextBox>
        活动结束日期<asp:TextBox runat="server" ID="tbxEnd"></asp:TextBox>
        <asp:Button runat="server" ID="btnSave" Text="保存活动日期" OnClick="btnSave_Click" />
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            参与活动的门票列表.格式: 门票ID|门票代码
        </div>
        <asp:Repeater runat="server" ID="rptTicketList">
            <HeaderTemplate>
                <table>
                    <tr>
                        <td>门票ID</td>
                        <td>门票代码</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("Id") %></td>
                    <asp:HiddenField ID="hfId" runat="server" Value='<%# Eval("Id") %>' />
                    <td>
                        <asp:TextBox ID="tbxProductCode" runat="server" Text='<%# Eval("ProductCode") %>'></asp:TextBox></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <asp:Button ID="btnSaveTicket" runat="server" Text="保存门票" OnClick="btnSaveTicket_Click" />
    <div class="detaillist">
        <div class="detailtitle">
            具体日期的门票分配情况
        </div>
        <asp:Repeater runat="server" ID="rptDateList">
            <HeaderTemplate>
                <table>
                    <tr>
                        <td>日期</td>
                        <td>设置</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# DateTime.Parse((Container.DataItem).ToString()).ToString("yyyy-MM-dd") %></td>
                    <td><a href='/Manager/QuZhouSpring/DateTicketAsign.aspx?date=<%# DateTime.Parse((Container.DataItem).ToString()).ToString("yyyy-MM-dd") %>'>分配门票</a></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>