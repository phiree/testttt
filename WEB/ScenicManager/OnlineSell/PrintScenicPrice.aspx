<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintScenicPrice.aspx.cs"
    Inherits="ScenicManager_PrintScenicPrice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <form id="form1" runat="server">
    <div>
        <table border="1px">
            <tr>
                <td>
                    名称
                </td>
                <td>
                    内容
                </td>
            </tr>
            <tr>
                <td>
                    景区名称
                </td>
                <td>
                    <asp:Label ID="lblScenicname" Text="text" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    原价
                </td>
                <td>
                    <asp:Label ID="lblyj" Text="text" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    预订价
                </td>
                <td>
                    <asp:Label ID="lblydj" Text="text" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    优惠价
                </td>
                <td>
                    <asp:Label ID="lblyhj" Text="text" runat="server" />
                </td>
            </tr>
        </table>
        <asp:Button ID="Button1" Text="打印" runat="server" OnClientClick="window.print()" /><a
            style="float: right; margin-right: 350px;" href="Pricesetting.aspx">返回上一层</a>
    </div>
    </form>
</body>
</html>
