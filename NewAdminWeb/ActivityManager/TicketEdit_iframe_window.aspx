<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TicketEdit_iframe_window.aspx.cs" Inherits="ActivityManager_TicketEdit_iframe_window" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" runat="Server">
    <ext:Form ID="Form1" runat="server" EnableBackgroundColor="true" ShowHeader="false"
        ShowBorder="true" LabelWidth="100px" Title="Form" BodyStyle="padding:20px 20px 30px 20px;">
        <Rows>
            <ext:FormRow ID="FormRow1" runat="server">
                <Items>
                    <ext:Label runat="server" ID="txtOwnerName"  Label="门票所属单位"
                        ShowLabel="true">
                    </ext:Label>
                </Items>
            </ext:FormRow>
            <ext:FormRow ID="FormRow2" runat="server">
                <Items>
                    <ext:TextBox runat="server" ID="txtTicketName" Required="true" ShowRedStar="true"
                        Label="门票名称" ShowLabel="true">
                    </ext:TextBox>
                </Items>
            </ext:FormRow>
            <ext:FormRow ID="FormRow3" runat="server">
                <Items>
                    <ext:TextBox runat="server" ID="txtTicketCode" Required="true" ShowRedStar="true"
                        Label="门票编号" ShowLabel="true">
                    </ext:TextBox>
                </Items>
            </ext:FormRow>
            <ext:FormRow runat="server">
                <Items>
                    <ext:DatePicker ID="txtBeginDate" runat="server" Required="true" Label="门票开始日期" ShowLabel="true"
                        ShowRedStar="true" DateFormatString="yyyy-MM-dd" EmptyText="请选择开始日期">
                    </ext:DatePicker>
                </Items>
            </ext:FormRow>
            <ext:FormRow runat="server">
                <Items>
                    <ext:DatePicker ID="txtEndDate" runat="server" Required="true" Label="门票结束日期" ShowLabel="true"
                        ShowRedStar="true" DateFormatString="yyyy-MM-dd" EmptyText="请选择结束日期" CompareControl="txtBeginDate"
                        CompareOperator="GreaterThanEqual" CompareMessage="结束日期应该大于开始日期">
                    </ext:DatePicker>
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
</asp:Content>
