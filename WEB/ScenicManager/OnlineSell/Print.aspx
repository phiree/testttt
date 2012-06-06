<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Print.aspx.cs" Inherits="ScenticManager_OnlineSell_Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title></title>
    <script type="text/javascript">
        function preview() {
            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";
            eprnstr = "<!--endprint-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML = prnhtml;
            window.print();
        }
    </script>
</head>
<body>
    <form id="WebForm1" method="post" runat="server">
    <table border="1px">
        <tr>
            <td>名称</td>
            <td>内容</td>
        </tr>
        <tr>
            <td>景区名称</td>
            <td><asp:Label ID="lblScenicname" Text="text" runat="server" /></td>
        </tr>
        <tr>
            <td>等级</td>
            <td><asp:Label ID="lblLevel" Text="text" runat="server" /></td>
        </tr>
        <tr>
            <td>所在区域</td>
            <td><asp:Label ID="lblArea" Text="text" runat="server" /></td>
        </tr>
        <tr>
            <td>地址</td>
            <td><asp:Label ID="lblAddress" Text="text" runat="server" /></td>
        </tr>
        <tr>
            <td>描述</td>
            <td><asp:Label ID="lblDesc" Text="text" runat="server" /></td>
        </tr>
        <tr>
            <td>景区位置</td>
            <td><asp:Label ID="lblLocation" Text="text" runat="server" /></td>
        </tr>
    </table>
    <asp:Button ID="Button1" Text="打印" runat="server" OnClientClick="window.print()"/>
    </form>
</body>
</html>
