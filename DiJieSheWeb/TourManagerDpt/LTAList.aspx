<%@ Page Title="" Language="C#" MasterPageFile="~/TourManagerDpt/manager.master"
    AutoEventWireup="true" CodeFile="LTAList.aspx.cs" Inherits="TourManagerDpt_LTAList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/Content/themes/base/minified/jquery-ui.min.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="/Scripts/json2.js"></script>
    <link href="/Scripts/jqueryplugin/tablesorter/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/OrderIndex.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".tablesorter").tablesorter();
            $(".IndexTable").orderIndex();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <div class="detail_titlebg">
        地接社列表
    </div>
    <div class="searchdiv">
        地接社名称:&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox runat="server" ID="tbxName" Style="width: 150px"></asp:TextBox>
        <asp:Button runat="server" ID="btnSearch" Text="搜索" OnClick="btnSearch_Click"  CssClass="btn2" />
    </div>
    <div class="detaillist">
        <table class="tablesorter IndexTable">
        </table>
        <asp:Repeater runat="server" ID="rptEntList">
            <HeaderTemplate>
                <table class="InfoTable tablesorter">
                    <thead>
                        <tr>
                            <th>
                                名称
                            </th>
                            <th>
                                负责人
                            </th>
                            <th>
                                负责人电话
                            </th>
                            <th>
                                负责人邮箱
                            </th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("Name") %>
                    </td>
                    <td>
                        <%#Eval("ChargePersonName")%>
                    </td>
                    <td>
                        <%#Eval("ChargePersonPhone")%>
                    </td>
                    <td>
                        <%# Eval("Email") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table></FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
