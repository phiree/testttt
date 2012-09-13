<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Operation.aspx.cs" Inherits="_12301_Operation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/theme/default/css/12301.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <div id="top">
            <h3>12301帮助平台</h3>
        </div>
        <div id="chooselist">
            <h3>请选择所需要预定的联票</h3>
            <asp:CheckBox ID="Cbjltp" runat="server" />
            江郎山，江郎山-廿八都-清漾联票
        </div>
        <div class="userinfo">
            <h3 style=" text-align:center">所需要填写的用户信息</h3>
            <table border="0" cellpadding="5" cellspacing="0">
                <tr>
                    <td>
                        姓名
                    </td>
                    <td>
                        <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        身份证号
                    </td>
                    <td>
                        <asp:TextBox ID="txtidcard" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        手机号
                    </td>
                    <td>
                        <asp:TextBox ID="txtmobile" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <asp:Button ID="BtnOK" runat="server" Text="预定" style="margin:0px auto; margin-left:460px;"  />
        <div class="odinfo">
            联票预订说明<br />
1 开放时间:8:00-17:00<br />
2 取票地点:江郎山,廿八都,清漾景区售票处均可取票<br />
3 取票凭证:身份证<br />
4 发票说明:网络预订的景区门票,网站不提供发票,敬请谅解.

        </div>
    </div>
    
    </form>
    
</body>
</html>
