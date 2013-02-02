<%@ Page Language="C#" AutoEventWireup="true" CodeFile="idcard.aspx.cs" Inherits="example_idcard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/VeriIdCard.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            var msg = test("110101199701017154");
            alert(msg);
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
