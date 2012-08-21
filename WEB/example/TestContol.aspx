<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestContol.aspx.cs" Inherits="example_TestContol" %>
<%@ Register TagPrefix="self" Namespace="TourControls" Assembly="TourControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <self:ContentReader runat="server" ID="ss" scid="0" scFuncType="0" type="首页" />
    </div>
    </form>
</body>
</html>
