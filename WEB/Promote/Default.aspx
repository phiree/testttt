<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Promote_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
    <style type="text/css">
        .popupcontent
        {
            position: absolute;
            visibility: hidden;
            overflow: hidden;
            border: 1px solid #CCC;
            background-color: #F9F9F9;
            border: 1px solid #333;
            padding: 5px;
        }
    </style>
    <script type="text/javascript">
        function showPopup() {
            $("#registdiv").css("top", ($(window).height() - $("#registdiv").height()) / 2 + $(window).scrollTop() + "px"); //窗口距离浏览器内容区最上方的偏移值
            $("#registdiv").css("left", ($(window).width() - $("#registdiv").width()) / 2 + $(window).scrollLeft() + "px"); //窗口距离浏览器内容区最左边的偏移值
            $("#registdiv").css("width", "270px"); //窗口的宽度
            $("#registdiv").css("height", "200px"); //窗口的高度
            $("#registdiv").css("visibility", "visible");
        }
        function hidePopup() {
            $("#registdiv").css("visibility", "hidden");
        }
    </script>
</head>
<body>
</body>
</html>
