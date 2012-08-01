<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true" CodeFile="ScenicInfoEdit.aspx.cs" Inherits="ScenicManager_Default2" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ MasterType VirtualPath="~/ScenicManager/sm.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" Runat="Server">
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/Verification.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.uploadify.min.js" type="text/javascript"></script>
    <link href="/Styles/uploadify.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/swfobject.js" type="text/javascript"></script>
    <link href="/theme/default/css/smdefault.css" rel="stylesheet" type="text/css" />
    <script src="/ckeditor/ckeditor.js" type="text/javascript"></script>
    <link href="/theme/default/css/scenic.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <p class="fuctitle">
        景区信息编辑</p>
    <hr />
    <div id="scinfoedit">
        <p class="scinfoedittitle">订票说明</p>
            <CKEditor:CKEditorControl ID="CkBookNote" runat="server"></CKEditor:CKEditorControl>
        <p class="scinfoedittitle">景区简介</p>
            <CKEditor:CKEditorControl ID="CkScjj" runat="server"></CKEditor:CKEditorControl>

    </div>
    <asp:Button ID="BtnSave" runat="server" CssClass="btnsaveimg" 
        style=" margin-left:20px; margin-bottom:20px;" onclick="BtnSave_Click" />
</asp:Content>

