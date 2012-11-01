<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="GroupEditBasicInfo.aspx.cs" Inherits="LocalTravelAgent_Groups_GroupEditBasicInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/Scripts/jqueryplugin/jqueryui/css/ui-lightness/jquery-ui-1.9.1.custom.min.css"
        rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-1.9.1.custom.min.js"></script>
    <script language="javascript" type="text/javascript">
        $(function () {
            $("#<%=tbxDateBegin.ClientID %>").datepicker();
            $("#<%=tbxDateEnd.ClientID %>").datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div>
        <table>
            <tr>
                <td>
                    团队名称
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    团队编号
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxGroupNo"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    开始时间
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxDateBegin"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    结束时间
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxDateEnd"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button runat="server" ID="btnSaveBasicInfo" OnClick="btnBasicInfo_Click" Text="保存" />
        <asp:Panel runat="server" ID="pnlLinks">
            <a href="GroupEditMember.aspx?groupid=<%=groupId %>">编辑成员信息</a>
             <a href="GroupEditBasicInfo.aspx=<%=groupId %>">
                编辑行程信息</a>
        </asp:Panel>
    </div>
</asp:Content>
