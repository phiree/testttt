<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ActivityEdit.aspx.cs" Inherits="ActivityManager_ActivityEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        function updateAssign(obj) {
              var id = $(obj).attr("commanArgument");
              var ataCount = $(obj).parent().prev().children().val();
              $.get("Assign.ashx?id=" + id + "&ataCount=" + ataCount + "", function () {
                  Ext.Msg.alert("提示","更新成功");
              });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" runat="Server">
    <ext:Panel ID="PanelForm" runat="server" EnableBackgroundColor="true" Layout="Fit"
        ShowBorder="false" ShowHeader="false" Title="Panel">
        <Items>
            <ext:TabStrip ID="ActivityTabStrip" EnableTabCloseMenu="true" AutoPostBack="false"
                ShowBorder="false" runat="server" EnableFrame="true">
                <Tabs>
                    <ext:Tab ID="Tab1" Title="活动编辑" Layout="Fit" Icon="None" runat="server">
                        <Items>
                            <ext:Form ID="Form1" runat="server" EnableBackgroundColor="true" ShowHeader="false"
                                ShowBorder="true" LabelWidth="300px" Title="Form" BodyStyle="padding:20px 20px 20px 20px;">
                                <Rows>
                                    <ext:FormRow runat="server">
                                        <Items>
                                            <ext:TextBox runat="server" ID="txtName" Label="活动名称" ShowLabel="true" Width="200px"
                                                Required="true" ShowRedStar="true">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow runat="server">
                                        <Items>
                                            <ext:TextBox runat="server" ID="txtCode" Label="活动编号(用于第三方接口，可选)" ShowLabel="true"
                                                Width="200px">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow runat="server">
                                        <Items>
                                            <ext:DatePicker ID="txtBeginDate" runat="server" Required="true" Label="活动开始日期" ShowLabel="true"
                                                ShowRedStar="true" DateFormatString="yyyy-MM-dd" Width="200px" EmptyText="请选择开始日期">
                                            </ext:DatePicker>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow runat="server">
                                        <Items>
                                            <ext:DatePicker ID="txtEndDate" runat="server" Required="true" Label="活动结束日期" ShowLabel="true"
                                                ShowRedStar="true" DateFormatString="yyyy-MM-dd" Width="200px" EmptyText="请选择结束日期"
                                                CompareControl="txtBeginDate" CompareOperator="GreaterThanEqual" CompareMessage="结束日期应该大于开始日期">
                                            </ext:DatePicker>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow runat="server">
                                        <Items>
                                            <ext:TextBox runat="server" ID="txtBeginHour" Label="每日开始时间" ShowLabel="true" Width="200px"
                                                RegexPattern="NUMBER" Text="7" Required="true" ShowRedStar="true">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow runat="server">
                                        <Items>
                                            <ext:TextBox runat="server" ID="txtEndHour" Label="每日结束时间" ShowLabel="true" Width="200px"
                                                RegexPattern="NUMBER" Text="24" Required="true" ShowRedStar="true">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow runat="server">
                                        <Items>
                                            <ext:TextBox runat="server" ID="txtAmountPerIdcardTicket" Label="每张身份证每个景区购买的最大数量"
                                                ShowLabel="true" Width="200px" RegexPattern="NUMBER" Text="5">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow runat="server">
                                        <Items>
                                            <ext:TextBox runat="server" ID="txtAmountPerIdcardInActivity" Label="身份证号在本次活动中能购买的最大数量"
                                                ShowLabel="true" Width="200px" RegexPattern="NUMBER" Text="5">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow runat="server">
                                        <Items>
                                            <ext:Button runat="server" ID="btnEdit" OnClick="btnEdit_Click" Text="保存" ValidateForms="Form1">
                                            </ext:Button>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:Tab>
                    <ext:Tab ID="Tab2" Title="合作商列表" Layout="Container" Icon="None" runat="server" EnableBackgroundColor="true">
                        <Items>
                            <ext:Grid runat="server" ID="gridPartner" ShowBorder="true" ShowHeader="false" EnableCheckBoxSelect="True"
                                EnableRowNumber="true" ForceFitAllTime="true" CssStyle="height:500px" DataKeyNames="Id"
                                OnRowCommand="gridPartner_RowCommand">
                                <Toolbars>
                                    <ext:Toolbar runat="server">
                                        <Items>
                                            <ext:Button runat="server" Icon="Add" ID="btnAddPartner" Text="新增">
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </Toolbars>
                                <Columns>
                                    <ext:BoundField DataField="Name" HeaderText="供应商名称" Width="300px" />
                                    <ext:BoundField DataField="PartnerCode" HeaderText="编号" Width="300px" />
                                    <ext:WindowField Width="200px" WindowID="winPartner" HeaderText="编辑" Icon="Pencil"
                                        ToolTip="编辑" DataTextFormatString="{0},{1}" DataIFrameUrlFields="Id,TourActivity.Id"
                                        DataIFrameUrlFormatString="Partner_iframe_window.aspx?paId={0}&actId={1}" DataWindowTitleField="Name"
                                        DataWindowTitleFormatString="编辑 - {0}" />
                                    <ext:LinkButtonField CommandName="delete" HeaderText="删除" Width="200px" ConfirmTarget="Top"
                                        ConfirmTitle="警告" ConfirmText="删除供应商会删除该供应商的门票分配！" Icon="Delete" />
                                </Columns>
                            </ext:Grid>
                        </Items>
                    </ext:Tab>
                    <ext:Tab ID="Tab3" Title="门票列表" Layout="Container" Icon="None" runat="server" EnableBackgroundColor="true">
                        <Items>
                            <ext:Form ID="Form2" runat="server" EnableBackgroundColor="true" ShowHeader="false"
                                ShowBorder="false" LabelWidth="100px" Title="Form" BodyStyle="padding:20px 20px 20px 20px;">
                                <Rows>
                                    <ext:FormRow runat="server">
                                        <Items>
                                            <ext:TriggerBox runat="server" ID="txtTicketId" Label="门票名称" ShowLabel="true" TriggerIcon="Search"
                                                OnTriggerClick="txtTicketId_TriggerClick">
                                            </ext:TriggerBox>
                                        </Items>
                                        <Items>
                                            <ext:Button runat="server" ID="btnAdd" OnClick="btnAdd_Click" Text="添加">
                                            </ext:Button>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                            <ext:Panel ID="Panel1" runat="server" EnableBackgroundColor="true" Layout="Container"
                                ShowBorder="false" ShowHeader="false" Title="Panel" AutoScroll="true">
                                <Items>
                                    <ext:Grid runat="server" ID="gridTicket" ShowBorder="true" ShowHeader="false" EnableCheckBoxSelect="True"
                                        EnableRowNumber="true" ForceFitAllTime="true" Height="450px" AllowPaging="true"
                                        PageSize="9999" DataKeyNames="Id" OnRowCommand="gridTicket_RowCommand">
                                        <Columns>
                                            <ext:BoundField DataField="Scenic.Name" HeaderText="门票所属单位" />
                                            <ext:BoundField DataField="Name" HeaderText="门票名称" />
                                            <ext:BoundField DataField="ProductCode" HeaderText="门票编号" />
                                            <ext:BoundField DataField="BeginDate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="门票起始时间" />
                                            <ext:BoundField DataField="EndDate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="门票结束时间" />
                                            <ext:WindowField WindowID="winTicketEdit" HeaderText="编辑" Icon="Pencil" ToolTip="编辑"
                                                DataTextFormatString="{0}" DataIFrameUrlFields="Id" DataIFrameUrlFormatString="TicketEdit_iframe_window.aspx?Id={0}"
                                                DataWindowTitleField="Name" DataWindowTitleFormatString="编辑 - {0}" />
                                            <ext:LinkButtonField CommandName="delete" HeaderText="删除" ConfirmTarget="Top" ConfirmTitle="警告"
                                                ConfirmText="删除门票会删除该门票的门票分配！" Icon="Delete" />
                                        </Columns>
                                    </ext:Grid>
                                </Items>
                            </ext:Panel>
                        </Items>
                    </ext:Tab>
                    <ext:Tab ID="Tab4" Title="门票分配列表" Layout="Fit" Icon="None" runat="server" EnableBackgroundColor="true">
                        <Items>
                            <ext:RegionPanel ID="RegionPanel1" runat="server" ShowBorder="false" AutoScroll="true">
                                <Regions>
                                    <ext:Region ID="Region1" runat="server" Position="Left" ShowHeader="true" Split="true"
                                        Layout="Form" EnableCollapse="true" EnableSplitTip="true" CollapseMode="Mini"
                                        Title="活动日期" AutoScroll="true" Width="150px" EnableBackgroundColor="true">
                                        <Items>
                                            <ext:Grid ID="gridDate" runat="server" EnableCheckBoxSelect="false" EnableRowNumber="true"
                                                ShowHeader="false" ForceFitAllTime="true" EnableRowClick="true" Title="Grid" EnableAjax="false"
                                                  OnRowClick="gridDate_RowClick">
                                                <Columns>
                                                    <ext:TemplateField HeaderText="时间">
                                                        <ItemTemplate>
                                                            <span>
                                                                <%# DateTime.Parse((Container.DataItem).ToString()).ToString("yyyy-MM-dd") %></span>
                                                        </ItemTemplate>
                                                    </ext:TemplateField>
                                                </Columns>
                                            </ext:Grid>
                                        </Items>
                                    </ext:Region>
                                    <ext:Region ID="Region2" runat="server" Position="Center" ShowHeader="true" Title="具体分配情况"
                                        EnableBackgroundColor="true" Layout="Form" AutoScroll="true">
                                        <Items>
                                            <ext:Grid ID="gridAssign" ShowBorder="true" ShowHeader="false" Height="470px"
                                               runat="server" DataKeyNames="Id" ExpandAllRowExpanders="true"  EnableCheckBoxSelect="false" EnableRowNumber="true"
                                                OnRowDataBound="gridAssign_RowDataBound">
                                                <Columns>
                                                    <ext:TemplateField RenderAsRowExpander="true" Width="550px">
                                                        <ItemTemplate>
                                                            <asp:Repeater runat="server" ID="rptAssign">
                                                                <HeaderTemplate>
                                                                    <table border="0" cellpadding="5" cellspacing="5" width="500px" style="margin-left:50px">
                                                                        <tr>
                                                                            <td>
                                                                                供应商名称
                                                                            </td>
                                                                            <td>
                                                                                分配票数
                                                                            </td>
                                                                        </tr>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td>
                                                                            <%# Eval("Partner.Name")%>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox runat="server" ID="txtAssignCount" Text='<%# Eval("AssignedAmount") %>' />
                                                                        </td>
                                                                        <td>
                                                                            <input type="button" name="name" value="更新" commanArgument='<%# Eval("Id") %>' onclick="updateAssign(this)" />
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    </table>
                                                                </FooterTemplate>
                                                            </asp:Repeater>
                                                        </ItemTemplate>
                                                    </ext:TemplateField>
                                                    <ext:BoundField DataField="Ticket.Scenic.Name" HeaderText="景区" Width="500px" />
                                                    <ext:BoundField DataField="Name" HeaderText="门票名称" Width="200px" />
                                                </Columns>   
                                            </ext:Grid>
                                        </Items>
                                    </ext:Region>
                                </Regions>
                            </ext:RegionPanel>
                        </Items>
                    </ext:Tab>
                </Tabs>
                <Toolbars>
                    <ext:Toolbar runat="server" Position="Footer" ID="toolFoot" >
                        <Items>
                            <ext:Button runat="server" Text="返回活动列表" ID="btnReturnList" Icon="HouseConnect" OnClick="btnReturnList_Click"></ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
            </ext:TabStrip>
        </Items>
    </ext:Panel>
    <ext:Window ID="winPartner" Title="景区单位选择" EnableIFrame="true" runat="server" CloseAction="HidePostBack"
        EnableConfirmOnClose="true" IFrameUrl="about:blank" EnableMaximize="false" EnableResize="true"
        Target="Top" Hidden="true" IsModal="True" Width="450px" Height="160px" OnClose="winPartner_Close">
    </ext:Window>
    <ext:Window ID="winTicket" Title="门票选择" EnableIFrame="true" runat="server" CloseAction="HidePostBack"
        EnableConfirmOnClose="true" IFrameUrl="/ActivityManager/Ticket_iframe_window.aspx"
        EnableMaximize="false" EnableResize="true" Target="Top" Hidden="true" IsModal="True"
        Width="560px" Height="416px" OnClose="winTicket_Close">
    </ext:Window>
    <ext:Window ID="winTicketEdit" Title="门票编辑" EnableIFrame="true" runat="server" CloseAction="HidePostBack"
        EnableConfirmOnClose="true" IFrameUrl="about:blank" EnableMaximize="false" EnableResize="true"
        Target="Top" Hidden="true" IsModal="True" Width="450px" Height="240px" OnClose="winTicketEdit_Close">
    </ext:Window>
</asp:Content>
