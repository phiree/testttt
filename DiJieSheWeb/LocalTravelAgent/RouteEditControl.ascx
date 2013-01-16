<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RouteEditControl.ascx.cs" Inherits="LocalTravelAgent_RouteEditControl" %>
    <link href="/Content/themes/base/minified/jquery-ui.min.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/routeedit.css" rel="stylesheet" type="text/css" />
    <link href="/Scripts/jqueryplugin/tablesorter/style.css" rel="stylesheet" type="text/css" />
<script src="/Scripts/jqueryplugin/OrderIndex.js" type="text/javascript"></script>
<script src="/Scripts/jqueryplugin/jquery.tablesorter.js" type="text/javascript"></script>
  <script language="javascript" type="text/javascript">

      $(function () {
          /*记住最后一次选择的tab*/
          var cookieName = "djsmetab";
          //            $("#tabs").tabs({
          //                active: $.cookie(cookieName),
          //                activate: function (event, ui) {
          //                    $.cookie(cookieName, ui.newTab.index(), { expires: 365 });
          //                }
          //            });
          $(".tablesorter").tablesorter();
          $(".IndexTable").orderIndex({ columnName: "行程日" });
          /*输入企业名称时的智能提示*/

          $(".EditEntName").autocomplete({
              //source: "/ajaxservice/EntpriseAutoCompleteHanlder.ashx"
              source: function (request, response) {
                  var tbx = this.element[0];
                  var entType = $(tbx).attr("entType");
                  $.get("/ajaxservice/EntpriseAutoCompleteHanlder.ashx?entName=" + request.term + "&entType=" + entType
                    , function (data) {
                        response($.map(data, function (item) {
                            var labelStr = item.Name;
                            var verifyState = 0;
                            if (item.CityVeryfyState == 1 || item.CountryVeryfyState == 1 || item.ProvinceVeryfyState == 1) {
                                labelStr = "☆" + labelStr;
                                verifyState = 1;
                            }
                            return {
                                label: labelStr,
                                value: item.Name,
                                verifyState: verifyState
                            }
                        }));
                    });
              },
              //                focus: function (event, ui) {
              //                    event.target.className -= " rewardbg";
              //                },
              select: function (event, ui) {
                  if (ui.item.verifyState == 1)
                      event.target.className += " rewardbg";
                  else {
                      event.target.className = event.target.className.replace("rewardbg", "");
                  }
                  event.target.value = ui.item.Name;
              }
          });

          /*隐藏/显示多余的文本框*/
          $(".EditEntName[entType='景点']").each(
          function (index) {
              if (index >= 4 && $(this).val() == "")
                  $(this).hide();
          }
          );
          $(".EditEntName[entType='宾馆']").each(function (index) { if (index >= 2) $(this).hide(); });
          $("#btnAddMoreScenic").click(function () { $(".EditEntName[entType='景点']").show(); });
          $("#btnAddMoreHotel").click(function () { $(".EditEntName[entType='宾馆']").show(); });
      });
    </script>
<asp:Repeater runat="server" ID="rptRoutes" OnItemCommand="rptRoutes_ItemCommand"
                OnItemDataBound="rptRoutes_ItemDataBound">
                <HeaderTemplate>
                    <table class="tablesorter IndexTable" style="margin-top: 0px !important;">
                    </table>
                    <table class="tablesorter InfoTable" style="width: 650px; margin: 0px; margin-top: 2px">
                        <thead>
                            <tr>
                                <td>
                                    景点
                                </td>
                                <td>
                                    住宿
                                </td>
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
                                CommandName="Edit" Text="修改" CssClass="btn2" />
                            <asp:Button runat="server" ID="btnClear" CommandArgument='<%#Eval("DayNo") %>' CommandName="Delete"
                                CssClass="btn2" Text="清空" OnClientClick="javascript:return confirm('确定要清空这一天的行程么?');" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody></table>
                </FooterTemplate>
            </asp:Repeater>
               <asp:Panel runat="server" ID="pnlEditRoute" CssClass="pnlEditRoute" Visible="false">
                <fieldset>
                    <legend>第
                        <asp:Label runat="server" Font-Size="Large" ID="lblDayNo"></asp:Label>
                        天行程</legend>
                    <div class="addoredit" style="margin-top: 15px; padding-left: 15px;">
                        <div style="float: left; width: 150px; font-weight: bold;">
                        </div>
                        <div style="float: left; width: 300px;">
                            <asp:RadioButtonList runat="server" Visible="false" ID="rblDayNo" RepeatDirection="Horizontal">
                            </asp:RadioButtonList>
                        </div>
                        <div style="clear: both">
                            <div style="font-weight: bold;">
                                景点:</div>
                            <div>
                                <asp:Repeater runat="server" ID="rptEditScenics" OnItemDataBound="rptEditEnt_ItemDataBound">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" Text='<%#Container.DataItem %>' CssClass="EditEntName"
                                            ID="tbxEntEdit" entType="景点"></asp:TextBox></ItemTemplate>
                                </asp:Repeater>
                                <input type="button" id="btnAddMoreScenic" value="增加更多" class="btn2" /></div>
                        </div>
                        <div>
                            <div style="font-weight: bold;">
                                饭店:</div>
                            <div>
                                <asp:Repeater runat="server" ID="rptEditHotels" OnItemDataBound="rptEditEnt_ItemDataBound">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" Text='<%#Container.DataItem %>' CssClass="EditEntName"
                                            ID="tbxEntEdit" entType="宾馆"></asp:TextBox></ItemTemplate>
                                </asp:Repeater>
                                <input type="button" style="display: none" id="btnAddMoreHotel" value="增加更多" class="btn2" /></div>
                        </div>
                        <asp:Button runat="server" ID="btnSaveRoute" OnClick="btnSaveRoute_Click" Text="保存"
                            CssClass="btn2" />
                    </div>
                </fieldset>
            </asp:Panel>