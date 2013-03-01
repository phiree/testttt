<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Ticket_iframe_window.aspx.cs" Inherits="ActivityManager_Ticket_iframe_window" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" Runat="Server">
     <ext:Panel ID="PanelForm" runat="server" EnableBackgroundColor="true" Layout="VBox"
        ShowBorder="false" ShowHeader="false" Title="Panel">
        <Toolbars>
            <ext:Toolbar runat="server" ID="Toolbar1" Position="Top">
                <Items>
                    <ext:Button ID="btnClose" runat="server" Text="关闭" Icon="SystemClose">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:ContentPanel ID="ContentPanel1" runat="server" EnableBackgroundColor="true"
                ShowBorder="false" ShowHeader="false">
                <ext:Form ID="Form1" runat="server" EnableBackgroundColor="true" ShowBorder="false" ShowHeader="false"
                    BodyStyle="padding:20px 20px 20px 20px;" LabelWidth="120px" AutoWidth="true">
                    <Rows>
                        <ext:FormRow ID="FormRow1" runat="server">
                            <Items>
                                <ext:Label runat="server" ID="lblOwnerScenic" ShowLabel="true" Width="200px" Label="选择的所属单位名称"
                                    Text="">
                                </ext:Label>
                            </Items>
                        </ext:FormRow>
                        <ext:FormRow ID="FormRow2" runat="server">
                            <Items>
                                <ext:TextBox runat="server" ID="tbxOwnerName" Label="门票名称" Width="300px">
                                </ext:TextBox>
                            </Items>
                            <Items>
                                <ext:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="搜索">
                                </ext:Button>
                            </Items>
                        </ext:FormRow>
                    </Rows>
                </ext:Form>
            </ext:ContentPanel>
        </Items>
        <Items>
            <ext:Grid ID="gridTicketOwner" runat="server" ShowBorder="true" ShowHeader="false" EnableCheckBoxSelect="True"
                EnableRowNumber="true" ForceFitAllTime="true" PageSize="10" AllowPaging="true"
                OnPageIndexChange="gridTicketOwner_PageIndexChange" DataKeyNames="Id,Name,Scenic.Name" OnRowCommand="gridTicketOwner_RowCommand">
                <Columns>
                    <ext:BoundField DataField="Scenic.Name" HeaderText="门票所属单位名称" />
                    <ext:BoundField DataField="Name" HeaderText="门票名称" />
                    <ext:LinkButtonField CommandName="select" HeaderText="选择" Text="选择" />
                </Columns>
            </ext:Grid>
        </Items>
    </ext:Panel>
</asp:Content>

