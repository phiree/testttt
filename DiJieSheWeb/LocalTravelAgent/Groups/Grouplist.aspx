<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="Grouplist.aspx.cs" Inherits="Groups_Grouplist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/Scripts/jqueryplugin/tablesorter/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/OrderIndex.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".tablesorter").tablesorter({ headers: { 3: { sorter: false }, 4: { sorter: false}} });
            $(".IndexTable").orderIndex();
            if ($.cookie("select_tab") != null || $.cookie("select_tab") != undefined) {
                var index = $.cookie("select_tab");
                $(".tabSelect a").removeClass("Select_Tab");
                $(".tabSelect a").eq(index).addClass("Select_Tab");
            }

            //hide noused columns
            var state = $("[id$='hfState']").val();
            if (state + "" != "1") {
                $(".coltohide").hide();
            }

            $(".tabSelect a").each(function () {
                var that = this;
                $(that).click(function () {
                    var index = $(".tabSelect a").index(that);
                    var indexvalue = parseInt(index) * 2;
                    if (indexvalue == 0)
                        indexvalue = 1;
                    $.cookie("select_tab", index);
                    $("[id$='hfState']").val(indexvalue);
                    $("[id$='btnSearch']").click();
                });
            });
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="detail_titlebg">
        团队管理
    </div>
    <div style="clear: both">
    </div>
    <div class="detaillist">
        <div class="actiondiv">
            <h3 style="margin-top: 5px">
                新增团队</h3>
            <asp:Button ID="Btnzjlr" runat="server" Text="直接录入" CssClass="btn2" OnClick="Btnzjlr_Click" />&nbsp;&nbsp;或&nbsp;&nbsp;
            <asp:Button ID="Btnxlslr" runat="server" Text="Excel导入" CssClass="btn2" OnClick="Btnxlslr_Click" />
            <div>
                操作提示：选择其中一种方式新增团队
            </div>
        </div>
        <div class="actiondiv" style="display: none">
            <h3 style="margin-top: 5px">
                选择条件查询</h3>
            <asp:RadioButtonList runat="server" ID="cblState" OnSelectedIndexChanged="cblState_Changed"
                RepeatDirection="Horizontal" AutoPostBack="true">
                <asp:ListItem Value="1" Selected="True">未发团队</asp:ListItem>
                <asp:ListItem Value="2">已发团队</asp:ListItem>
                <asp:ListItem Value="4">完成团队</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div style="display: none">
            <asp:Button ID="btnSearch" runat="server" Text="Button" OnClick="btnSearch_Click" />
            <asp:HiddenField runat="server" ID="hfState" Value="1" />
        </div>
        <div class="tabSelect">
            <a class="Select_Tab">未发团队</a><a>已发团队</a><a style="border: none">完成团队</a>
            <asp:Button ID="btnOutput3" Text="导出列表" runat="server" OnClick="btnOutput3_Click"
                CssClass="btn2 Select_Btn" />
        </div>
        <asp:Repeater ID="rptGroups" runat="server" OnItemDataBound="rptGroups_ItemDataBound"
            OnItemCommand="rptGroups_ItemCommand">
            <HeaderTemplate>
                <table class="IndexTable tablesorter">
                </table>
                <table class="InfoTable tablesorter">
                    <thead>
                        <tr>
                            <th>
                                <asp:LinkButton ID="lbname" runat="server" Text="名称" CommandName="lbname"></asp:LinkButton>
                            </th>
                            <th>
                                <asp:LinkButton ID="lbdate" runat="server" Text="时间" CommandName="lbdate"></asp:LinkButton>
                            </th>
                            <th>
                                <asp:LinkButton ID="lbdays" runat="server" Text="天数" CommandName="lbdays"></asp:LinkButton>
                            </th>
                            <th class="coltohide">
                                团队编辑
                            </th>
                            <th class="coltohide">
                                团队资料录入提示
                            </th>
                        </tr>
                    </thead>
                    <tbody id="routeList">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <a href='/LocalTravelAgent/Groups/GroupDetail.aspx?id=<%#Eval("Id")%>'><%#Eval("Name")%></a>
                    </td>
                    <td>
                        <%#((DateTime)Eval("BeginDate")).Year == DateTime.Now.Year ? ((DateTime)Eval("BeginDate")).ToString("MM月dd日") : ((DateTime)Eval("BeginDate")).ToString("yyyy年MM月dd日")%>
                    </td>
                    <td>
                        <%#Eval("DaysAmount")%>日游
                    </td>
                    <td class="coltohide">
                        <asp:Panel runat="server" ID="pnlOperation">
                            <a href='GroupEditBasicInfo.aspx?groupid=<%#Eval("id") %>'>修改</a> <a href='/LocalTravelAgent/Groups/GroupInfo.aspx?groupid=<%#Eval("id") %>'>
                                更新</a>
                            <asp:Button runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="delete"
                                Text="删除" OnClientClick='javascript:return confirm("您确认要删除这个团队么?");' CssClass="a_btn" />
                            <a href='/LocalTravelAgent/Groups/GroupDetail.aspx?id=<%#Eval("Id")%>'>查询</a>
                        </asp:Panel>
                        <asp:Button runat="server" Visible="false" ID="btnCopy" CommandArgument='<%#Eval("Id") %>'
                            CommandName="Copy" Text="复制" CssClass="btn2" />
                    </td>
                    <td class="coltohide">
                        <asp:LinkButton ID="lblMember_bz" Text="" runat="server" Style="color: #F19145" />
                        <asp:LinkButton ID="lblRoute_bz" Text="" runat="server" Style="color: #F19145" />
                        <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
        <div class="NoRecord" runat="server" id="NoRecord">
            <asp:Label runat="server" ID="lblMsg" Text="您目前没有团队记录" Style="font-size: 14px"></asp:Label>
        </div>
    </div>
</asp:Content>
