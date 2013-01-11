<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RouteEditControl.ascx.cs" Inherits="LocalTravelAgent_RouteEditControl" %>
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