<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="GroupEditRoute.aspx.cs" Inherits="LocalTravelAgent_Groups_GroupEditRoute" %>

<%@ Register Src="~/LocalTravelAgent/Groups/RecommentEnt.ascx" TagName="recomment"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-1.9.1.custom.min.js" type="text/javascript"></script>
    <link href="/Scripts/jqueryplugin/jqueryui/css/smoothness/jquery-ui-1.9.1.custom.min.css"
        rel="stylesheet" type="text/css" />
    <link href="/Scripts/jqueryplugin/tablesorter/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/OrderIndex.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        $(function () {
            /*记住最后一次选择的tab*/
            var cookieName = "djsmetab";
            $("#tabs").tabs({
                active: $.cookie(cookieName),
                activate: function (event, ui) {
                    $.cookie(cookieName, ui.newTab.index(), { expires: 365 });
                }
            });
            $(".tablesorter").tablesorter();
            $(".IndexTable").orderIndex();
            /*输入企业名称时的智能提示*/

            $(".EditEntName").autocomplete({
                //source: "/ajaxservice/EntpriseAutoCompleteHanlder.ashx"
                source: function (request, response) {
                    var tbx = this.element[0];
                    var entType = $(tbx).attr("entType");
                    $.get("/ajaxservice/EntpriseAutoCompleteHanlder.ashx?entName=" + request.term + "&entType=" + entType
                    , function (data) { 
                    response( $.map( data, function( item ) {
                    var labelStr=item.Name;
                    var verifyState=0;
                          if(item.CityVeryfyState==1||item.CountryVeryfyState==1||item.ProvinceVeryfyState==1)
                          {
                            labelStr="☆"+labelStr;
                            verifyState=1;
                          }
                        return {
                            label: labelStr,
                            value: item.Name,
                            verifyState:verifyState
                        }
                    })); 
                    });
                },
                select: function (event, ui) {
                    if(ui.item.verifyState==1)
                    event.target.className+=" rewardbg";
                    event.target.value = ui.item.Name;
                }
            });
          
          /*隐藏/显示多余的文本框*/
          $(".EditEntName[entType='景点']").each(
          function(index){
          if(index>=4 && $(this).val()=="")
          $(this).hide();
          }
          );
           $(".EditEntName[entType='宾馆']").each(function(index){if(index>=2)$(this).hide();});
           $("#btnAddMoreScenic").click(function(){ $(".EditEntName[entType='景点']").show();});
           $("#btnAddMoreHotel").click(function(){$(".EditEntName[entType='宾馆']").show();});
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="navlist">
        <a runat="server" id="a_link_1" href="/LocalTravelAgent/Groups/GroupEditBasicInfo.aspx">录入团队基本信息</a>
        <a runat="server" id="a_link_2" href="/LocalTravelAgent/Groups/GroupEditMember.aspx">录入游客信息</a>
        <a runat="server" id="a_link_3" href="/LocalTravelAgent/Groups/GroupEditRoute.aspx" class="selectstate">录入行程信息</a>
    </div>

     <h3 style="margin-left:15px;margin-top:30px">
        <b>
        团队名称:<%=CurrentGroup.Name %>行程信息录入
        </b>
    </h3>
    <div style="background-color: Green">
        <asp:Label runat="server" ID="lblMsg_SaveRoute"></asp:Label></div>
    <div class="tabintro">
        根据您方便，选择其中一种方式录入游客信息</div>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">直接录入</a></li>
            <li><a href="#tabs-2">文本录入</a></li>
        </ul>
        <div id="tabs-1">
            <asp:Repeater runat="server" ID="rptRoutes" OnItemCommand="rptRoutes_ItemCommand"
                OnItemDataBound="rptRoutes_ItemDataBound">
                <HeaderTemplate>
                    <table class="tablesorter IndexTable" style="margin:0px">
        </table>
                    <table class="tablesorter InfoTable" style="width:650px;margin:0px;margin-top:2px">
                        <thead>
                        <tr>
                            <th>
                                景点
                            </th>
                            <th>
                                住宿
                            </th>
                            <td>
                                操作
                            </td>
                        </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Repeater runat="server" ID="rptScenics">
                                <ItemTemplate>
                                    <span class='<%#((bool)Eval("IsVerified"))?"rewardbg":"" %>'>
                                        <%#Eval("Name") %></span>
                                </ItemTemplate>
                                <SeparatorTemplate>
                                    ,</SeparatorTemplate>
                            </asp:Repeater>
                        </td>
                        <td>
                            <asp:Repeater runat="server" ID="rptHotels">
                                <ItemTemplate>
                                    <span class='<%#((bool)Eval("IsVerified"))?"rewardbg":"" %>'>
                                        <%#Eval("Name") %></span>
                                </ItemTemplate>
                                <SeparatorTemplate>
                                    ,</SeparatorTemplate>
                            </asp:Repeater>
                        </td>
                        <td>
                            <asp:Button runat="server" ID="btnModifyRoute" CommandArgument='<%#Eval("DayNo") %>'
                                CommandName="Edit" Text="修改" CssClass="btn" />
                            <asp:Button runat="server" ID="Button1" CommandArgument='<%#Eval("DayNo") %>' CommandName="Delete" CssClass="btn"
                                Text="删除" OnClientClick="javascript:return confirm('确定要删除这一天的行程么?');" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody></table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Button runat="server" ID="btnAddRoute" OnClick="btnAddRoute_Click" Text="增加行程" CssClass="btn" style="margin-top:10px" />
            <asp:Panel runat="server" ID="pnlEditRoute" Visible="false">
                <div class="addoredit" style="margin-top:15px">
                    <div style="float:left;width:150px;font-weight:bold;">
                        行程日期（第几天）
                    </div>
                    <div  style="float:left;width:300px;">
                        <asp:RadioButtonList runat="server" ID="rblDayNo" RepeatDirection="Horizontal">
                        </asp:RadioButtonList>
                    </div>
                    <div style="clear:both">
                        <div style="font-weight:bold;">
                            景点:</div>
                        <div>
                            <asp:Repeater runat="server" ID="rptEditScenics" OnItemDataBound="rptEditEnt_ItemDataBound">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Container.DataItem %>' CssClass="EditEntName"
                                        ID="tbxEntEdit" entType="景点"></asp:TextBox></ItemTemplate>
                            </asp:Repeater>
                            <input type="button" id="btnAddMoreScenic" value="增加更多" class="btn" /></div>
                    </div>
                    <div>
                        <div style="font-weight:bold;">
                            饭店:</div>
                        <div>
                            <asp:Repeater runat="server" ID="rptEditHotels" OnItemDataBound="rptEditEnt_ItemDataBound">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Container.DataItem %>' CssClass="EditEntName"
                                        ID="tbxEntEdit" entType="宾馆"></asp:TextBox></ItemTemplate>
                            </asp:Repeater>
                            <input type="button" id="btnAddMoreHotel" value="增加更多" class="btn" /></div>
                    </div>
                </div>
                <asp:Button runat="server" ID="btnSaveRoute" OnClick="btnSaveRoute_Click" Text="保存" CssClass="btn" />
            </asp:Panel>
        </div>
        <div id="tabs-2">
            <p>
                将行程信息按照一定的格式输入,一次性导入系统
            </p>
            <p>
                格式要求:
                <ol>
                    <li>一行表示一天的行程</li>
                    <li>每一行包含当天游玩的<b>景点</b>和入住的<b>宾馆</b>,用反斜杠"\"隔开</li>
                </ol>
                例如:
                <ul>
                    <li>西湖风景区\乌镇客栈</li>
                    <li>遂昌神龙谷景区</li>
                </ul>
            </p>
            <asp:TextBox TextMode="MultiLine" runat="server" ID="tbxSimple" CssClass="tbMemberSingleText" Width="100%"></asp:TextBox>
            <asp:Button runat="server" ID="btnSaveSimple" OnClick="btnSave_Click" OnClientClick="javascript:return confirm('原有的行程信息将清除,是否继续?');"
                Text="保存" CssClass="btn" />
                 <asp:Button runat="server" ID="btnClose" OnClick="btnClose_Click"
                Text="关闭" CssClass="btn" />
            <asp:Label runat="server" ID="lblSimpleMsg" ForeColor="green"></asp:Label>
        </div>
    </div>
</asp:Content>
