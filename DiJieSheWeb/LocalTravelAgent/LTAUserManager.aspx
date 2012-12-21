<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="LTAUserManager.aspx.cs" Inherits="LocalTravelAgent_LTAUserManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/Scripts/jqueryplugin/tablesorter/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/OrderIndex.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#tbUser").tablesorter();
            $(".IndexTable").orderIndex();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="detail_titlebg">
        用户管理
    </div>
    <div class="detaillist">
        <table class="tablesorter IndexTable">
        </table>
        <asp:Repeater ID="rptUser" runat="server" OnItemDataBound="rptUser_ItemDataBound"
            OnItemCommand="rptUser_ItemCommand">
            <HeaderTemplate>
                <table id="tbUser" class="tablesorter InfoTable">
                    <thead>
                        <tr>
                            <th>
                                用户名
                            </th>
                            <th>
                                权限
                            </th>
                            <td>
                                操作
                            </td>
                        </tr>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("Name")%>
                    </td>
                    <td>
                        <asp:Literal ID="laPermis" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <a runat="server" id="aedit" href="">编辑</a>
                        <asp:Button ID="btnReset" runat="server" Text="重置密码" CommandArgument='<%# Eval("Id") %>'
                            CommandName="reset" Style="margin-left: 15px; border: none; background: none;
                            cursor: pointer;" />
                        <asp:Button ID="btndelete" runat="server" Text="删除" CommandArgument='<%# Eval("Id") %>'
                            CommandName="delete" Style="margin-left: 15px; border: none; background: none;
                            cursor: pointer;" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <div>
            <asp:Button ID="BtnAdd" runat="server" Text="新增" CssClass="btn2" OnClick="BtnAdd_Click" />
        </div>
    </div>
</asp:Content>
