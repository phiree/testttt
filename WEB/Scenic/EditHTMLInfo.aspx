<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeFile="EditHTMLInfo.aspx.cs" Inherits="Scenic_EditHTMLInfo" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="/Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <title></title>
    <script type="text/javascript">
        window.onunload = function () {   
            var num = window.location.href.indexOf("?")
            var str = window.location.href.substr(num + 1); //截取“?”后面的参数串 
            var oEditor = CKEDITOR.instances.CKHTML;
            $.ajax({
                type: 'post',
                url: 'SaveHTML.ashx?' + str,
                data: { html: oEditor.getData() }
            });
            var parentWin = window.opener;
            $(parentWin).find(".otinfo").html(oEditor.getData());
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CKEditor:CKEditorControl ID="CKHTML" runat="server" Width="710px" Height="500px">
        </CKEditor:CKEditorControl>
    </div>
    </form>
</body>
</html>
