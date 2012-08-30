<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeFile="EditHTMLInfo.aspx.cs" Inherits="Scenic_EditHTMLInfo" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="/Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <link href="/theme/default/css/TCCSS.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/global.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/default.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/scenic.css" rel="stylesheet" type="text/css" />

    <title></title>
    <script type="text/javascript">
        var parentid;
        $(function () {

            var parentWin = window.opener.document;
            var editor = CKEDITOR.replace("CKHTML", {
                width: 730, height: 450,
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
            '/theme/bp/print.css', '/theme/default/css/MasterPage.css'];
            parentid = window.location.href.match(/flag.*$/)[0];
            parentid = parentid.substr(5);
            editor.setData($(parentWin).find(parentid).html());
        });
        function bc() {
            var num = window.location.href.indexOf("?");
            var str = window.location.href.substr(num + 1); //截取“?”后面的参数串 
            var oEditor = CKEDITOR.instances.CKHTML;
            $.ajax({
                type: 'post',
                url: 'SaveHTML.ashx?' + str,
                data: { html: oEditor.getData() }
            });
            var parentWin = window.opener.document;
            $(parentWin).find(parentid).html(oEditor.getData());
        }
        function qx() {
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <CKEditor:CKEditorControl ID="CKHTML" runat="server" Width="710px" Height="500px">
        </CKEditor:CKEditorControl>
        <input type="button" name="name" value="保存" onclick="bc();" />
        <input type="button" name="name" value="取消" onclick="qx();" />
    </div>
    </form>
</body>
</html>
