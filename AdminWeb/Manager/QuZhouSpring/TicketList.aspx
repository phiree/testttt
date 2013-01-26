<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="TicketList.aspx.cs" Inherits="Manager_QuZhouSpring_TicketList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/Styles/jquery-ui.min.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.9.2.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".time").datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
<div class="detail_titlebg">
        门票列表
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
                        <td>
                            起始时间
                        </td>
                        <td>
                            结束时间
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("Scenic.Name") %>_<%#Eval("Name") %>_<%# Eval("Id") %></td>
                    <asp:HiddenField ID="hfId" runat="server" Value='<%# Eval("Id") %>' />
                    <td>
                        <asp:TextBox ID="tbxProductCode" runat="server" Text='<%# Eval("ProductCode") %>'></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtbeginDate" runat="server" CssClass="time" Text='<%#Eval("BeginDate")%>'></asp:TextBox></td>
                    </td>
                    <td>
                        <asp:TextBox ID="txtendDate" runat="server" CssClass="time" Text='<%# Eval("EndDate")%>'></asp:TextBox></td>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <asp:Button ID="btnSaveTicket" runat="server" Text="保存门票" OnClick="btnSaveTicket_Click" />
</asp:Content>

