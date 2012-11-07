<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="GroupEditRoute.aspx.cs" Inherits="LocalTravelAgent_Groups_GroupEditRoute" %>

<%@ Register Src="~/LocalTravelAgent/Groups/RecommentEnt.ascx" TagName="recomment"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-1.9.1.custom.min.js" type="text/javascript"></script>
    <link href="/Scripts/jqueryplugin/jqueryui/css/smoothness/jquery-ui-1.9.1.custom.min.css"
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
    <div class="detail_titlebg">
        修改行程信息
    </div>
    <div class="navstate">
        <a runat="server" id="a_link_1" href="/LocalTravelAgent/Groups/GroupEditBasicInfo.aspx">修改基本信息</a>一<a runat="server" id="a_link_2" href="/LocalTravelAgent/Groups/GroupEditMember.aspx" >修改成员信息</a>一<a runat="server" id="a_link_3" href="/LocalTravelAgent/Groups/GroupEditRoute.aspx" class="selectstate">修改行程信息</a>
    </div>
    <div style="clear:both">
        </div>

    <h3 style="margin-left:15px;">
        <b>
            <%=CurrentGroup.Name %>行程信息录入</b></h3>
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
                                <asp:TextBox runat="server" Text='<%#Container.DataItem %>'  CssClass="EditScenicName" ID="tbxScenicName"></asp:TextBox></ItemTemplate>
                        </asp:Repeater>
                    </div>
                     <div>
                        饭店:<asp:Repeater runat="server" ID="rptEditHotels">
                            <ItemTemplate>
                                <asp:TextBox runat="server" Text='<%#Container.DataItem %>'  CssClass="EditScenicName" ID="tbxHotelName"></asp:TextBox></ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <asp:Button runat="server" ID="btnSaveRoute"  OnClick="btnSaveRoute_Click" Text="保存"/>
                <asp:Label runat="server" ID="lblMsg_SaveRoute"></asp:Label>
            </asp:Panel>
        </div>
        <div id="tabs-2">
            <p>
                将行程信息按照一定的格式输入,一次性导入系统
            </p>
            <p>
                格式要求: 1)单个游客的资料用逗号分隔,按序依次为:天次,景区,住宿(多个景区用"-"分割).如果没有对应信息,请保留逗号. 不同天数用回车分隔. 比如:<br />
                1,西栅景区,乌镇客栈<br />
                2,鲁迅故里-兰亭-沈园,如家快捷酒店<br />
                3,船游西湖-花港观鱼-六合塔-龙井问茶-苏提春晓,如家快捷酒店<br />
                4,飞来峰,<br />
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
