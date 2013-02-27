<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TicketEdit.aspx.cs" Inherits="TicketManager_TicketEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" runat="Server">
    <ext:Panel ID="PanelForm" runat="server" EnableBackgroundColor="true" Layout="Fit"
        ShowBorder="false" ShowHeader="false" Title="Panel">
        <Items>
            <ext:TabStrip ID="TicketTabStrip" EnableTabCloseMenu="true" AutoPostBack="false"
                ShowBorder="false" runat="server" EnableFrame="true">
                <Tabs>
                    <ext:Tab ID="Tab1" Title="门票编辑" Layout="Fit" Icon="None" runat="server">
                        <Items>
                            <ext:Form ID="Form1" runat="server" EnableBackgroundColor="true" ShowHeader="false"
                                ShowBorder="true" LabelWidth="200px" Title="Form" BodyStyle="padding:20px 20px 20px 20px;">
                                <Rows>
                                    <ext:FormRow ID="FormRow1" runat="server">
                                        <Items>
                                            <ext:RadioButtonList ID="rblTicketType" Label="门票列表" ShowLabel="true" runat="server"
                                                Width="200px">
                                                <ext:RadioItem Text="普通门票" Value="1" Selected="true" />
                                                <ext:RadioItem Text="套票(联票)" Value="2" />
                                            </ext:RadioButtonList>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow2" runat="server">
                                        <Items>
                                            <ext:TextBox runat="server" ID="tbxName" Label="名称" ShowLabel="true" Width="200px"
                                                Required="true" ShowRedStar="true">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow3" runat="server">
                                        <Items>
                                            <ext:TriggerBox ID="tbxOwner" Label="所属单位" ShowLabel="true" Width="200px" Required="true" ShowRedStar="true" TriggerIcon="Search"
                                             runat="server" OnTriggerClick="tbxOwner_TriggerClick"></ext:TriggerBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow4" runat="server">
                                        <Items>
                                            <ext:TextBox runat="server" ID="tbxProductCode" Label="门票代码(用于第三方接口，可选)" ShowLabel="true"
                                                Width="200px">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow5" runat="server">
                                        <Items>
                                            <ext:CheckBox ID="cbxIsMain" runat="server" Checked="true" Label="是否主票" ShowLabel="true">
                                            </ext:CheckBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow6" runat="server">
                                        <Items>
                                            <ext:CheckBox ID="cbxLock" runat="server" Label="是否锁住" ShowLabel="true">
                                            </ext:CheckBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow7" runat="server">
                                        <Items>
                                            <ext:DatePicker ID="tbxBeginDate" runat="server" Required="true" Label="验票有效期开始日期"
                                                ShowLabel="true" ShowRedStar="true" DateFormatString="yyyy-MM-dd" Width="200px"
                                                EmptyText="请选择开始日期">
                                            </ext:DatePicker>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow8" runat="server">
                                        <Items>
                                            <ext:DatePicker ID="tbxEndDate" runat="server" Required="true" Label="验票有效期结束日期"
                                                ShowLabel="true" ShowRedStar="true" DateFormatString="yyyy-MM-dd" Width="200px"
                                                EmptyText="请选择结束日期" CompareControl="tbxBeginDate" CompareOperator="GreaterThanEqual"
                                                CompareMessage="结束日期应该大于开始日期">
                                            </ext:DatePicker>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow9" runat="server">
                                        <Items>
                                            <ext:TextBox runat="server" ID="tbxPriceNormal" Label="原价" ShowLabel="true" Width="200px">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow runat="server">
                                        <Items>
                                            <ext:TextBox runat="server" ID="tbxPricePayOnline" Label="在线支付价" ShowLabel="true"
                                                Width="200px">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow runat="server">
                                        <Items>
                                            <ext:TextBox runat="server" ID="tbxPricePreOrder" Label="景区现付价" ShowLabel="true"
                                                Width="200px">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow runat="server">
                                        <Items>
                                            <ext:HyperLink ID="hlActivity" Label="参与的活动" ShowLabel="true" Target="parent" runat="server">
                                            </ext:HyperLink>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow runat="server">
                                        <Items>
                                            <ext:HyperLink ID="hlUnionTicket" runat="server" Label="所属联票" ShowLabel="true">
                                            </ext:HyperLink>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow11" runat="server">
                                        <Items>
                                            <ext:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" ValidateForms="Form1">
                                            </ext:Button>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:Tab>
                    <ext:Tab ID="Tab2" Title="联票门票管理" Layout="VBox" Icon="None" runat="server" EnableBackgroundColor="true"
                        BoxConfigChildMargin="20 0 0 20" Visible="false">
                        <Items>
                            <ext:ContentPanel ID="ContentPanel2" runat="server" EnableBackgroundColor="true"
                                ShowBorder="false" ShowHeader="false">
                                <ext:Grid ID="gridTicketList" runat="server" ShowBorder="true" EnableCheckBoxSelect="True"
                                    ShowHeader="true" Title="该联票已经绑定的门票" Width="600px" EnableRowNumber="true" ForceFitAllTime="true"
                                    OnRowCommand="gridTicketList_RowCommand" DataKeyNames="Id" EnableAjax="false">
                                    <Columns>
                                        <ext:BoundField DataField="Name" HeaderText="门票名称" Width="450px" />
                                        <ext:LinkButtonField HeaderText="删除" CommandName="delete" Text="删除" ConfirmText="是否确认删除"
                                            ConfirmTarget="Top" />
                                    </Columns>
                                </ext:Grid>
                            </ext:ContentPanel>
                        </Items>
                        <Items>
                            <ext:ContentPanel ID="ContentPanel1" runat="server" EnableBackgroundColor="true"
                                ShowBorder="false" ShowHeader="false">
                                <ext:Form ID="Form2" runat="server" EnableBackgroundColor="true" ShowHeader="false"
                                    ShowBorder="false" LabelWidth="100px" Title="Form" BodyStyle="margin-top:20px;">
                                    <Rows>
                                        <ext:FormRow runat="server">
                                            <Items>
                                                <ext:TextBox runat="server" ID="tbxKeyword" Label="景区名称关键字" ShowLabel="true" Width="200px">
                                                </ext:TextBox>
                                            </Items>
                                            <Items>
                                                <ext:Button runat="server" ID="btnSearch" Text="搜索/添加" OnClick="btnSearch_Click"></ext:Button>
                                            </Items>
                                        </ext:FormRow>
                                    </Rows>
                                </ext:Form>
                                <ext:Grid ID="gridAllTicket" runat="server" ShowBorder="true" ShowHeader="false" EnableCheckBoxSelect="True"
                                 EnableRowNumber="true" ForceFitAllTime="true" PageSize="10" AllowPaging="true" OnPageIndexChange="gridAllTicket_PageIndexChange"
                                  DataKeyNames="Id"  OnRowCommand="gridAllTicket_RowCommand"  Width="600px"  >
                                    <Columns>
                                        <ext:BoundField DataField="Scenic.Name" HeaderText="景区名称" width="200px" />
                                        <ext:BoundField DataField="Name" HeaderText="门票名称" width="250px" />
                                        <ext:LinkButtonField HeaderText="添加" CommandName="add" Text="添加" />
                                    </Columns>
                                </ext:Grid>
                            </ext:ContentPanel>
                        </Items>
                    </ext:Tab>
                </Tabs>
            </ext:TabStrip>
        </Items>
    </ext:Panel>
    <ext:Window ID="winScenic" Title="景区单位选择" EnableIFrame="true" runat="server"
        CloseAction="HidePostBack" EnableConfirmOnClose="true" IFrameUrl="/TicketManager/Owner_iframe_window.aspx"
        EnableMaximize="false" EnableResize="true"  Target="Top" Hidden="true"
        IsModal="True" Width="560px" Height="416px" OnClose="winScenic_Close">
        </ext:Window>
</asp:Content>
