<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Owner_iframe_window.aspx.cs" Inherits="TicketManager_Owner_iframe_window" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" runat="Server">
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
                <ext:Form runat="server" EnableBackgroundColor="true" ShowBorder="false" ShowHeader="false"
                    BodyStyle="padding:20px 20px 20px 20px;" LabelWidth="120px" AutoWidth="true">
                    <Rows>
                        <ext:FormRow runat="server">
                            <Items>
                                <ext:Label runat="server" ID="lblOwnerScenic" ShowLabel="true" Width="200px" Label="选择的所属单位名称"
                                    Text="">
                                </ext:Label>
                            </Items>
                        </ext:FormRow>
                        <ext:FormRow runat="server">
                            <Items>
                                <ext:TextBox runat="server" ID="tbxOwnerName" Label="单位名称" Width="300px">
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
            <ext:Grid ID="gridOwner" runat="server" ShowBorder="true" ShowHeader="false" EnableCheckBoxSelect="True"
                EnableRowNumber="true" ForceFitAllTime="true" PageSize="10" AllowPaging="true"
                OnPageIndexChange="gridOwner_PageIndexChange" DataKeyNames="Name" OnRowCommand="gridOwner_RowCommand">
                <Columns>
                    <ext:BoundField DataField="Name" HeaderText="所属单位名称" />
                    <ext:LinkButtonField CommandName="select" HeaderText="选择" Text="选择" />
                </Columns>
            </ext:Grid>
        </Items>
    </ext:Panel>
</asp:Content>
