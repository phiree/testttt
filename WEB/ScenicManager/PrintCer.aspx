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
        <h2>游玩凭证</h2>
    <asp:Repeater ID="rptPrint" runat="server" onitemdatabound="rptPrint_ItemDataBound">
        <ItemTemplate>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width:150px;">
                        单位名称:
                    </td>
                    <td style="width:250px;">
                        <%# Eval("Enterprise.Name")%>
                        <%--<%# Eval("Route.DJ_TourGroup.DJ_DijiesheInfo.Name")%>--%>
                    </td>
                    <td style="width:150px;">
                         验证时间:
                    </td>
                    <td  style="width:200px;">
                        <%# Eval("ConsumeTime")%>
                    </td>
                </tr>
                <tr>
                    <td >
                        人数:
                    </td>   
                    <td colspan="3">
                        成人<%# Eval("AdultsAmount")%>人&nbsp;&nbsp;儿童<%# Eval("ChildrenAmount")%>人
                    </td>
                </tr>
                <tr>
                    <td>
                        备注:
                    </td>
                    <td colspan="3" style="height:100px; text-align:left; vertical-align:top;">
                        团队编号:<%# Eval("Route.DJ_TourGroup.No")%>&nbsp;&nbsp;团队名称:<%# Eval("Route.DJ_TourGroup.Name")%>
                        &nbsp;&nbsp;地接社名称:<%# Eval("Route.DJ_TourGroup.DJ_DijiesheInfo.Name")%>
                    </td>
                    
                </tr>
             </table>
             <table border="0" cellpadding="0" cellspacing="0" style="border: none; margin-top: 10px;">
                <tr style="border: none">
                    <td colspan="2" style="text-align: left; padding-left: 10px; border: none;">
                        宾馆签名或盖章:
                    </td>
                    <td colspan="2" style="text-align: left; padding-left: 10px; border: none;">
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
