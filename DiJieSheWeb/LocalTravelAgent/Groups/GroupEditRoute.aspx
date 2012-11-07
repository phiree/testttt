<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="GroupEditRoute.aspx.cs" Inherits="LocalTravelAgent_Groups_GroupEditRoute" %>

<%@ Register Src="~/LocalTravelAgent/Groups/RecommentEnt.ascx" TagName="recomment"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-1.9.1.custom.min.js" type="text/javascript"></script>
    <link href="/Scripts/jqueryplugin/jqueryui/css/ui-lightness/jquery-ui-1.9.1.custom.min.css"
        rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        $(function () {
            var cookieName = "djsmetab";
            $("#tabs").tabs({
                active: $.cookie(cookieName),
                activate: function (event, ui) {
                    $.cookie(cookieName, ui.newTab.index(), { expires: 365 });
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div>
        <%=CurrentGroup.Name %>行程信息录入
    </div>
    <div style="background-color: Green">
        <asp:Label runat="server" ID="lblMsg_SaveRoute"></asp:Label></div>
    <div class="box">
        提供两种录入线路的方式,您可以根据需要,选择最适合一种方式.</div>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">直接录入</a></li>
            <li><a href="#tabs-2">文本录入</a></li>
        </ul>
        <div id="tabs-1">
            <asp:Repeater runat="server" ID="rptRoutes" OnItemCommand="rptRoutes_ItemCommand"
                OnItemDataBound="rptRoutes_ItemDataBound">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <td>
                            </td>
                            <td>
                                景点
                            </td>
                            <td>
                                住宿
                            </td>
                            <td>
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("DayNo") %>
                        </td>
                        <td>
                            <asp:Repeater runat="server" ID="rptScenics">
                                <ItemTemplate>
                                    <%#Eval("Name") %>
                                </ItemTemplate>
                                <SeparatorTemplate>
                                    ,</SeparatorTemplate>
                            </asp:Repeater>
                        </td>
                        <td>
                            <asp:Repeater runat="server" ID="rptHotels">
                                <ItemTemplate>
                                    <%#Eval("Name") %>
                                </ItemTemplate>
                                <SeparatorTemplate>
                                    ,</SeparatorTemplate>
                            </asp:Repeater>
                        </td>
                        <td>
                            <asp:Button runat="server" ID="btnModifyRoute" CommandArgument='<%#Eval("DayNo") %>'
                                CommandName="Edit" Text="修改" />
                            <asp:Button runat="server" ID="Button1" CommandArgument='<%#Eval("DayNo") %>' CommandName="Delete"
                                Text="删除" OnClientClick="javascript:return confirm('确定要删除这一天的行程么?');" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Button runat="server" ID="btnAddRoute" OnClick="btnAddRoute_Click" Text="增加行程" />
            <asp:Panel runat="server" ID="pnlEditRoute" Visible="false">
                <div class="addoredit">
                    <div>
                        第<asp:RadioButtonList runat="server" ID="rblDayNo">
                        </asp:RadioButtonList>
                        天</div>
                    <div>
                        景点:<asp:Repeater runat="server" ID="rptEditScenics">
                            <ItemTemplate>
                                <asp:TextBox runat="server" Text='<%#Container.DataItem %>' CssClass="EditScenicName"
                                    ID="tbxScenicName"></asp:TextBox></ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div>
                        饭店:<asp:Repeater runat="server" ID="rptEditHotels">
                            <ItemTemplate>
                                <asp:TextBox runat="server" Text='<%#Container.DataItem %>' CssClass="EditScenicName"
                                    ID="tbxHotelName"></asp:TextBox></ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <asp:Button runat="server" ID="btnSaveRoute" OnClick="btnSaveRoute_Click" Text="保存" />
            </asp:Panel>
        </div>
        <div id="tabs-2">
            <p>
                将行程信息按照一定的格式输入,一次性导入系统
            </p>
            <p>
                格式要求:
                <ol>
                    <li>每一行表示一天的行程</li>
                    <li>每一行包含"(景点列表),(住宿点列表)",用逗号分割.</li>
                    <li>景点之间用斜线符(/)分开 ,住宿点之间用斜线符(/)分开</li>
                    <li>如果没有景区或者住宿点,则不需填写.</li>
                </ol>
                例如:
                <ul>
                    <li>西栅景区,乌镇客栈</li>
                    <li>船游西湖/花港观鱼/六合塔/龙井问茶/苏提春晓,如家快捷酒店/乌镇客栈</li>
                    <li>飞来峰</li>
                </ul>
            </p>
            <asp:TextBox TextMode="MultiLine" runat="server" ID="tbxSimple" CssClass="tbMemberSingleText"></asp:TextBox>
            <asp:Button runat="server" ID="btnSaveSimple" OnClick="btnSave_Click" OnClientClick="javascript:return confirm('原有的行程信息将清除,是否继续?');"
                Text="保存" />
            <asp:Label runat="server" ID="lblSimpleMsg" ForeColor="green"></asp:Label>
        </div>
    </div>
    <a style="display: block; padding: 3px; margin: 10px; background-color: #ddd; font-size: larger;"
        href="GroupEditMember.aspx?groupid=<%=CurrentGroup.Id%>">去编辑成员信息</a>
</asp:Content>
