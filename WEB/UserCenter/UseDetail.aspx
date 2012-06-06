<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UseDetail.aspx.cs" Inherits="UserCenter_UseDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div><span id="scenicname" runat="server"></span><span id="ticketcount" runat="server"></span>张门票</div>
    <asp:Repeater ID="Repeater1" runat="server" 
        onitemdatabound="Repeater1_ItemDataBound">
        <HeaderTemplate>
            <table border="0" cellpadding="5" cellspacing="5">
                <tr>
                    <td>
                        使用人姓名
                    </td>
                    <td>
                        使用人身份证号
                    </td>
                    <td>
                        使用时间
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <span id="usename" runat="server"></span>
                </td>
                <td>
                    <span id="idcard" runat="server"><%# Eval("IdCard")%></span>
                </td>
                <td>
                    <%# Eval("UsedTime")%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    </form>
</body>
</html>
