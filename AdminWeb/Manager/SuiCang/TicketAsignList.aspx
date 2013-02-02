<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="TicketAsignList.aspx.cs" Inherits="Manager_QuZhouSpring_TicketAsignList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <%--<link href="/Scripts/jqueryplugin/jqueryui/css/ui-lightness/jquery-ui-1.9.1.custom.min.css"
        rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-1.9.1.custom.min.js"></script>--%>
    <link href="/Styles/jquery-ui.min.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-ui-1.9.2.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("[id$='txtTime']").datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <div class="detail_titlebg">
        门票分配
    </div>
    <div class="searchdiv">
        日期<asp:TextBox runat="server" ID="txtTime" 
            ontextchanged="txtTime_TextChanged" AutoPostBack="true" />&nbsp;&nbsp;&nbsp;&nbsp;
        今日总票数<asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSave" Text="保存" runat="server" />
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            票数分配列表
        </div>
        <asp:Repeater runat="server" ID="rpt" >
            <HeaderTemplate>
                <table>
                    <tr>
                        <td>
                            网站名称
                        </td>
                        <td>
                            分配票数
                        </td>
                        <td>
                            已使用票数
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

