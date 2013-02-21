<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintScenicPrice.aspx.cs"
    Inherits="ScenicManager_PrintScenicPrice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function pp() {
            var bdhtml = window.document.body.innerHTML;
            var hh = bdhtml;
            var sprnstr = "<!--startprint-->";
            var eprnstr = "<!--endprint-->";
            var prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML = prnhtml;
            window.print();
            window.document.body.innerHTML = hh;
        }
    </script>
    <style type="text/css">
        table
        {
            border-right:1px solid Black;
            border-bottom:1px solid Black;
        }
        table tr td
        {
            border-left:1px solid Black;
            border-top:1px solid Black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!--startprint-->
        <h2 id="title" runat="server" style="text-align:center"></h2>
        <table cellpadding=5 cellspacing=0 style="width:600px; margin:10px auto;">
            <tr>
                <td>
                    景区门票名称
                </td>
                <td style="text-align:center">
                    门市价(原价)
                </td>
                <td style="text-align:center">
                    景区现付价
                </td>
                <td style="text-align:center">
                    网上订购价
                </td>
            </tr>
            <asp:Repeater ID="rptScenicTicket" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("Name")%>
                        </td>
                        <td style="text-align:center">
                            <%# Eval("TicketPrice[0].Price","{0:0}")%>
                        </td>
                        <td style="text-align:center">
                            <%# Eval("TicketPrice[1].Price","{0:0}")%>
                        </td>
                        <td style="text-align:center">
                            <%# Eval("TicketPrice[2].Price","{0:0}")%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <!--endprint-->
        <div style="width:600px; margin:10px auto;font-size:12px;">
            如果已经发传真给我们，或者通知我们更改了价格不需要此表格的可以跳过此步<br />
            <input id="Button2" type="button" value="打印" onclick="pp()" style="margin:20px 0px 0px 250px" /><a style="margin-left:230px" href="Uploadscenicprice.aspx" >进入下一步</a>
        </div>
    </div>
    </form>
</body>
</html>
