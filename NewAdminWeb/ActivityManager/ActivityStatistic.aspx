<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ActivityStatistic.aspx.cs" Inherits="ActivityManager_ActivityStatistic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" runat="Server">
    <ext:Panel ID="PanelForm" runat="server" EnableBackgroundColor="false" Layout="Form"
        ShowBorder="false" ShowHeader="false" Title="Panel">
        <Items>
            <ext:RadioButtonList runat="server" ID="rblwd" AutoPostBack="true" OnSelectedIndexChanged="rblwd_SelectedIndexChanged"
                CssStyle="margin:20px 0px 0px 0px" Width="400px">
                <ext:RadioItem Selected="true" Text="按时间维度" Value="按时间维度" />
                <ext:RadioItem Text="按供应商维度" Value="按供应商维度" />
                <ext:RadioItem Text="按门票维度" Value="按门票维度" />
            </ext:RadioButtonList>
            <ext:Grid runat="server" ID="gridStatistic" ShowBorder="true" ShowHeader="false"
                ForceFitAllTime="true" EnableCheckBoxSelect="true" Height="420px" EnableRowNumber="true"
                OnRowDataBound="gridStatistic_RowDataBound">
                <Columns>
                    <ext:TemplateField HeaderText="活动日期">
                        <ItemTemplate>
                            <span>
                                <%# DateTime.Parse((Container.DataItem).ToString()).ToString("yyyy-MM-dd") %></span>
                        </ItemTemplate>
                    </ext:TemplateField>
                    <ext:TemplateField HeaderText="售出票总数">
                        <ItemTemplate>
                            <asp:Literal ID="laSolidAmount" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </ext:TemplateField>
                    <ext:TemplateField HeaderText="验票总数">
                        <ItemTemplate>
                            <asp:Literal ID="laCheckAmount" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </ext:TemplateField>
                    <ext:TemplateField HeaderText="详细情况">
                        <ItemTemplate>
                            <a href='/ActivityManager/ActivityDetail_TimeStatistic.aspx?actId=<%= Request.QueryString["actId"] %>&dt=<%# DateTime.Parse((Container.DataItem).ToString()).ToString("yyyy-MM-dd")  %>'>
                                详细情况</a>
                        </ItemTemplate>
                    </ext:TemplateField>
                </Columns>
            </ext:Grid>
            <ext:Grid runat="server" ID="gridStatistic2" ShowBorder="true" ShowHeader="false"
                ForceFitAllTime="true" EnableCheckBoxSelect="true" Height="420px" EnableRowNumber="true"
                OnRowDataBound="gridStatistic2_RowDataBound">
                <Columns>
                    <ext:BoundField HeaderText="供应商名称" DataField="Name" />
                    <ext:TemplateField HeaderText="售出总数">
                        <ItemTemplate>
                            <asp:Literal ID="laCount" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </ext:TemplateField>
                </Columns>
            </ext:Grid>
            <ext:Grid runat="server" ID="gridStatistic3" ShowBorder="true" ShowHeader="false"
                ForceFitAllTime="true" EnableCheckBoxSelect="true" Height="420px" EnableRowNumber="true"
                OnRowDataBound="gridStatistic3_RowDataBound">
                <Columns>
                    <ext:BoundField HeaderText="景区名称" DataField="Scenic.Name" />
                    <ext:BoundField HeaderText="门票名称" DataField="Name" />
                    <ext:TemplateField HeaderText="售出数量">
                        <ItemTemplate>
                            <asp:Literal ID="laTicketSolidAmount" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </ext:TemplateField>
                    <ext:TemplateField HeaderText="验票数量">
                        <ItemTemplate>
                            <asp:Literal ID="laTicketCheckAmount" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </ext:TemplateField>
                </Columns>
            </ext:Grid>
            <ext:Label runat="server" ID="lblTotal" ShowLabel="true" Label="总计" CssStyle="margin:10px 10px 10px 10px"></ext:Label>
        </Items>
        <Toolbars>
            <ext:Toolbar runat="server" Position="Footer">
                <Items>
                    <ext:Button runat="server" ID="btnReturn" OnClick="btnReturn_Click" Icon="HouseConnect" Text="返回活动列表"></ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
    </ext:Panel>
</asp:Content>
