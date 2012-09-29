<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="ManageDptImport.aspx.cs" Inherits="Admin_ManageDptImport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">
<fieldset>
<legend>从Excel文件导入</legend>
</fieldset>
 <asp:FileUpload runat="server" ID="fuDptList"  /><asp:Button runat="server" ID="btnImport" Text="导入" />
</asp:Content>

