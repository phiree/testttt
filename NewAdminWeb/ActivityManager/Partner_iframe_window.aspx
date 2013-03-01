<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Partner_iframe_window.aspx.cs" Inherits="ActivityManager_Partner_iframe_window" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" Runat="Server">
     <ext:Form ID="Form1" runat="server" EnableBackgroundColor="true" ShowHeader="false"
         ShowBorder="true" LabelWidth="100px" Title="Form" BodyStyle="padding:20px 20px 30px 20px;">
         <Rows>
            <ext:FormRow runat="server">
                <Items>
                    <ext:TextBox runat="server" ID="txtName" Required="true" ShowRedStar="true" Label="供应商名称" ShowLabel="true"></ext:TextBox>
                </Items>
            </ext:FormRow>
            <ext:FormRow runat="server">
                <Items>
                    <ext:TextBox runat="server" ID="txtPartnerCode" Required="true" ShowRedStar="true" Label="编号" ShowLabel="true"></ext:TextBox>
                </Items>
            </ext:FormRow>
            <ext:FormRow runat="server">
                <Items>
                    <ext:Button runat="server" ID="btnOK" OnClick="btnOK_Click" ValidateForms="Form1" Text="编辑"></ext:Button>
                </Items>
            </ext:FormRow>
         </Rows>
     </ext:Form>
</asp:Content>

