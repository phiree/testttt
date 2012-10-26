<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintCer.aspx.cs" Inherits="TourEnterprise_PrintCer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <link href="/theme/default/css/Print.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            printInfo();
        });
        function printInfo() {
            var bdhtml = window.document.body.innerHTML;
            var hh = bdhtml;
            var sprnstr = "<!--startprint-->";
            var eprnstr = "<!--endprint-->";
            var prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML = prnhtml;
            window.print();
            window.document.body.innerHTML = hh;
            window.onafterprint = wclose();
        }
        function wclose() {
            window.opener = null;
            window.open('', '_self');
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <!--startprint-->
        <h2 id="title" runat="server">西湖宾馆验证凭证</h2>
    <asp:Repeater ID="rptPrint" runat="server" onitemdatabound="rptPrint_ItemDataBound">
        <ItemTemplate>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width:150px;">
                        团队名称:
                    </td>   
                    <td style="width:250px;">
                        <%# Eval("Route.DJ_TourGroup.Name")%>
                    </td>
                    <td style="width:150px;">
                        导游姓名:
                    </td>
                    <td style="width:200px;">
                        <asp:Literal ID="laGuiderName" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>游玩时间:</td>
                    <td colspan="3">
                        <%# Eval("Route.DJ_TourGroup.BeginDate", "{0:yyyy-MM-dd}")%>至<%# Eval("Route.DJ_TourGroup.EndDate", "{0:yyyy-MM-dd}")%></td>
                </tr>
                <tr>
                    <td>
                        预订成人人数:
                    </td>
                    <td>
                        <%# Eval("Route.DJ_TourGroup.AdultsAmount")%>
                    </td>
                    <td>
                        预订儿童人数:
                    </td>
                    <td>
                        <%# Eval("Route.DJ_TourGroup.ChildrenAmount")%>
                    </td>
                </tr>
                <tr>
                    <td>
                        实到成人人数:
                    </td>
                    <td>
                        <%# Eval("AdultsAmount")%>
                    </td>
                    <td>
                        实到儿童人数:
                    </td>
                    <td>
                        <%# Eval("ChildrenAmount")%>
                    </td>
                </tr>
                <tr>
                    <td>
                        验证时间:
                    </td>
                    <td colspan="3">
                        <%# Eval("ConsumeTime","{0:yyyy-MM-dd}")%>
                    </td>
                </tr>
                <tr>
                    <td>
                        备注:
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtRemark" runat="server" Text='<%# Eval("Remarks") %>' Width="95%" TextMode="MultiLine" Height="35px" style="margin-top:5px;;margin-bottom:5px;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:left;padding-left:10px;">
                        旅游企业签名:
                    </td>
                    <td colspan="2" style="text-align:left;padding-left:10px;">
                        团队负责人签名:
                    </td>
                </tr>
             </table>
        </ItemTemplate>
    </asp:Repeater>
    <!--endprint-->
    </form>
</body>
</html>
