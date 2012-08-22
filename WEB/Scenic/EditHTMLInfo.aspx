<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeFile="EditHTMLInfo.aspx.cs" Inherits="Scenic_EditHTMLInfo" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="/Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <title></title>
    <script type="text/javascript">
    var temp=0;
        window.onunload = function () {   
            var num = window.location.href.indexOf("?")
            var str = window.location.href.substr(num + 1); //截取“?”后面的参数串 
            var oEditor = CKEDITOR.instances.CKHTML;
            $.ajax({
                type: 'post',
                url: 'SaveHTML.ashx?' + str,
                data: { html: oEditor.getData() }
            });
            var parentWin = window.opener.document;
            $(parentWin).find(".otinfo").html(oEditor.getData());
        }

        function bc() {
            var num = window.location.href.indexOf("?")
            var str = window.location.href.substr(num + 1); //截取“?”后面的参数串 
            var oEditor = CKEDITOR.instances.CKHTML;
            $.ajax({
                type: 'post',
                url: 'SaveHTML.ashx?' + str,
                data: { html: oEditor.getData() }
            });
            var parentWin = window.opener.document;
            $(parentWin).find(".otinfo").html(oEditor.getData());
            temp = 1;
            window.close();
        }
        function qx() {
            temp = 1;
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CKEditor:CKEditorControl ID="CKHTML" runat="server" Width="710px" Height="500px">
        </CKEditor:CKEditorControl>
        <input type="button" name="name" value="保存" onclick="bc();" />
        <input type="button" name="name" value="取消" onclick="qx();" />
    </div>
    </form>
</body>
</html>
