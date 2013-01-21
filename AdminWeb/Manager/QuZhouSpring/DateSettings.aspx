<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="DateSettings.aspx.cs" Inherits="Manager_QuZhouSpring_DateSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/Styles/jquery-ui.min.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.9.2.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("[id$='tbxStart']").datepicker();
            $("[id$='tbxEnd']").datepicker();
            $(".time").datepicker();
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
            具体日期的门票分配情况
        </div>
        <asp:Repeater runat="server" ID="rptDateList" 
            onitemdatabound="rptDateList_ItemDataBound">
            <HeaderTemplate>
                <table>
                    <tr>
                        <td>日期</td>
                        <td>设置</td>
                        <td>已售出票数</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# DateTime.Parse((Container.DataItem).ToString()).ToString("yyyy-MM-dd") %></td>
                    <td><a href='/Manager/QuZhouSpring/DateTicketAsign.aspx?date=<%# DateTime.Parse((Container.DataItem).ToString()).ToString("yyyy-MM-dd") %>'>分配门票</a></td>
                    <td>
                        <asp:Literal Text="text" runat="server" ID="solidAmount"  />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
