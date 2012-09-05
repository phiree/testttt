<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapNav.aspx.cs" Inherits="map_MapNav" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.2"></script>
    <script src="/Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="/map/mapnav.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../Styles/page.css" />
    <link href="/theme/default/css/map.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div style="width: 80%; height: 550px; border: 1px solid gray; float: left" id="container">
    </div>
    <div id="posall" style="width: 15%; float: left">
        <input type="text" value="" name="postion" />
    </div>
    <input type='button' value='增加' onclick='createpostion()' />
    <input type='button' value='标注' onclick='getpostion()' />
    <input type='button' value='开始' onclick='run();' />
</body>
</html>
