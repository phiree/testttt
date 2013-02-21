<%@ Page Title="" Language="C#" MasterPageFile="~/sm.master" AutoEventWireup="true"
    CodeFile="ScenicInfoEdit.aspx.cs" Inherits="ScenicManager_Default2" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ MasterType VirtualPath="~/sm.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" runat="Server">
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/Verification.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.uploadify.min.js" type="text/javascript"></script>
    <link href="/Styles/uploadify.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/swfobject.js" type="text/javascript"></script>
    <link href="/theme/default/css/smdefault.css" rel="stylesheet" type="text/css" />
    <script src="/ckeditor/ckeditor.js" type="text/javascript"></script>
    <link href="/theme/default/css/scenic.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/EditHTML.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            var editor = CKEDITOR.replace("ctl00$cphmain$CkBookNote", {
                toolbar: [
                //加粗     斜体，     下划线      穿过线      下标字        上标字
                ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript'],
                // 数字列表          实体列表            减小缩进    增大缩进
                ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent'],
                //左对齐             居中对齐          右对齐          两端对齐
                ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'],
                //超链接  取消超链接 锚点
                ['Link', 'Unlink', 'Anchor'],
                //图片    flash    表格       水平线            表情       特殊字符        分页符
                ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak'],
                '/',
                // 样式       格式      字体    字体大小
                ['Styles', 'Format', 'Font', 'FontSize'],
                //文本颜色     背景颜色
                ['TextColor', 'BGColor'],
                //全屏           显示区块        源码
                ['Maximize', '-', 'ShowBlocks'], ['Source']
             ]
            });
            editor.config['contentsCss'] = ['/theme/default/css/scenic.css', '/theme/default/css/TCCSS.css', '/theme/default/css/global.css', '/theme/default/css/default.css', '/theme/bp/screen.css',
            '/theme/bp/print.css', '/theme/default/css/MasterPage.css', '/theme/default/css/EditHTML.css'];
            var editor2 = CKEDITOR.replace("ctl00$cphmain$CkScjj", {
                toolbar: [
                //加粗     斜体，     下划线      穿过线      下标字        上标字
                ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript'],
                // 数字列表          实体列表            减小缩进    增大缩进
                ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent'],
                //左对齐             居中对齐          右对齐          两端对齐
                ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'],
                //超链接  取消超链接 锚点
                ['Link', 'Unlink', 'Anchor'],
                //图片    flash    表格       水平线            表情       特殊字符        分页符
                ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak'],
                '/',
                // 样式       格式      字体    字体大小
                ['Styles', 'Format', 'Font', 'FontSize'],
                //文本颜色     背景颜色
                ['TextColor', 'BGColor'],
                //全屏           显示区块        源码
                ['Maximize', '-', 'ShowBlocks'], ['Source']
             ]
            });
            editor2.config['contentsCss'] = ['/theme/default/css/scenic.css', '/theme/default/css/TCCSS.css', '/theme/default/css/global.css', '/theme/default/css/default.css', '/theme/bp/screen.css',
            '/theme/bp/print.css', '/theme/default/css/MasterPage.css'];
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <p class="fuctitle">
        景区信息编辑</p>
    <hr />
    <div id="scinfoedit">
        <p class="scinfoedittitle">
            订票说明</p>
        <CKEditor:CKEditorControl ID="CkBookNote" runat="server"></CKEditor:CKEditorControl>
        <p class="scinfoedittitle">
            景区详情</p>
        <CKEditor:CKEditorControl ID="CkScjj" runat="server"></CKEditor:CKEditorControl>
    </div>
    <asp:Button ID="BtnSave" runat="server" CssClass="btnsaveimg enable" Style="margin-left: 20px;
        margin-bottom: 20px;" OnClick="BtnSave_Click" />
</asp:Content>
