<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ActivityDetail_TimeStatistic.aspx.cs" Inherits="ActivityManager_ActivityDetail_TimeStatistic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" Runat="Server">
    <ext:Panel ID="PanelForm" runat="server" EnableBackgroundColor="true" Layout="Form"
        ShowBorder="false" ShowHeader="false" Title="Panel">
        <Items>
            <ext:Form runat="server" ID="Form1" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                 LabelWidth="150px"  BodyPadding="20px 20px 20px 20px">
                <Rows>
                    <ext:FormRow runat="server">
                        <Items>
                            <ext:RadioButtonList runat="server" ID="rblType" Label="" ShowLabel="true" Width="400px" OnSelectedIndexChanged="rblType_SelectedIndexChanged" AutoPostBack="true">
                                <ext:RadioItem Selected="true" Text="出售数量" Value="出售数量" />
                                <ext:RadioItem Text="验票数量" Value="验票数量" />
                            </ext:RadioButtonList>
                        </Items>
                    </ext:FormRow>
                </Rows>     
            </ext:Form>
            <ext:Grid runat="server" ID="gridTimeStatistic" ShowBorder="false" ShowHeader="false"
                 EnableCheckBoxSelect="true" EnableRowNumber="true" ForceFitAllTime="true" Height="420px">
            </ext:Grid>
            <ext:Grid runat="server" ID="gridCheckTicketStatistic" ShowBorder="false" ShowHeader="false"
                 EnableCheckBoxSelect="true" EnableRowNumber="true" ForceFitAllTime="true" Height="420px">
            </ext:Grid>
        </Items>
    </ext:Panel>
</asp:Content>

