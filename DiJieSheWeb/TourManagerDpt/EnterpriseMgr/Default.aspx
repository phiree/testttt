<%@ Page Title="" Language="C#" MasterPageFile="~/TourManagerDpt/manager.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="TourManagerDpt_EnterpriseMgr_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/Content/themes/base/minified/jquery-ui.min.css"
        rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="/Scripts/jquery-ui-1.9.2.min.js"></script>
    <script language="javascript" type="text/javascript" src="/Scripts/json2.js"></script>
    <link href="/Scripts/jqueryplugin/tablesorter/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/OrderIndex.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".tablesorter").tablesorter();
            $(".IndexTable").orderIndex();
            if ($.cookie("select_tab") != null || $.cookie("select_tab") != undefined) {
                var index = $.cookie("select_tab");
                $(".tabSelect a").removeClass("Select_Tab");
                $(".tabSelect a").eq(index).addClass("Select_Tab");
            }

            $(".tabSelect a").each(function () {
                var that = this;
                $(that).click(function () {
                    var index = $(".tabSelect a").index(that);
                    $.cookie("select_tab", index);
                    $("[id$='hfState']").val(index);
                    $("[id$='btnSearch']").click();
                });
            });
        });
    </script>
    <script language="javascript" type="text/javascript">
        var entNames = JSON.parse("<%=EntNames %>");
        $(function () {
            $("#<%=tbxName.ClientID %>").autocomplete({
                source: entNames
            });
        });
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <div class="detail_titlebg">
        <%=ParamEntType %>管理
    </div>
    <div class="searchdiv">
            企业名称:&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox runat="server" ID="tbxName" style="width:150px"></asp:TextBox>
      
        <asp:Button runat="server" ID="btnAdd" Text="纳入奖励范围" OnClick="btnAdd_Click" CssClass="btn2"/>
        <asp:Label runat="server" ID="lblMsg" CssClass="success" Visible="false">操作成功</asp:Label><br />
            
        </div>
    <div class="detaillist">
        <div style="display:none">
            <asp:Button ID="btnSearch" runat="server" Text="Button" OnClick="btnSearch_Click" />
            <asp:HiddenField runat="server" ID="hfState" Value="1" />
        </div>
         <div class="tabSelect">
            <a class="Select_Tab">全部</a><a>已纳入</a><a style="border:none">已移除</a>
        </div>
        <table class="tablesorter IndexTable">
        </table>
        <asp:Repeater runat="server" ID="rptEntList" OnItemCommand="rptEntList_ItemCommand"
            OnItemDataBound="rptEntList_ItemDataBound">
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
                                操作
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
                        <asp:Button runat="server" ID="btnVerifyState" CommandArgument='<%#Eval("Id") %>'
                            CommandName="Verify" CssClass="btn2" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table></FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
