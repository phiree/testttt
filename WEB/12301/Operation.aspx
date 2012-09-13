<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Operation.aspx.cs" Inherits="_12301_Operation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/theme/default/css/12301.css" rel="stylesheet" type="text/css" />
<script src="/Scripts/VeriIdCard.js" type="text/javascript"></script>
<script src="/Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
<script type="text/javascript">

    $(function () {
        $("#BtnOK").click(function () {

            var pricetype = 2;
            var name = $.trim($("#txtname").val());
            var idcard = $.trim($("#txtidcard").val());
            var phone = $.trim($("#txtmobile").val());

            //姓名验证
            if (name == "") {
                alert("游览者姓名不能为空");
                return false;
            }

            //id认证
            if (idcard == "") {
                alert("游览者身份证号码不能为空");
                return false;
            }
            var vali_id = test(idcard);
            if (vali_id != "验证通过") {
                alert("身份证格式不正确，请重新输入！");
                return false;
            }

            //手机号认证
            if (phone == "") {
                alert("游览者手机号码不能为空");
                return false;
            }
            if (!isMobil(phone)) {
                alert("手机号码不正确，请重新输入！");
                return false;
            }

            var tid = "55";
            var sid = "29";
            var b = tid + "-" + name + "-" + idcard + "-" + sid + "_";

            var resultpsw;
            //注册
            $.get("/Account/RegistHandler.ashx?phone=" + phone + "&idcard=" + idcard, function (data) {
                resultpsw = data;
                if (resultpsw == "false") {
                    $("#ydinfo").html("对不起，你输入的手机号码已与其他身份证绑定，请重新输入!");
                }
                else {
                    $.get("/order/QuickorderHandler.ashx?ticketid=" + tid + "&phone=" + phone + "&pricetype=" + pricetype + "&a=" + escape(b), function (data) {
                        $("#ydinfo").html("预定成功<br/> 手机号码: " + phone + " 密码: " + resultpsw);
                        $("#txtname").val("");
                        $("#txtidcard").val("");
                        $("#txtmobile").val("");
                    });
                }
            });
        });
    });

</script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <div id="top">
            <h3>12301协助订票平台</h3>
        </div>
        <div id="chooselist">
            <h3>请选择所需要预定的联票</h3>
            <asp:RadioButton ID="rbjs" runat="server" Checked="true" />
            江郎山，江郎山-廿八都-清漾联票
        </div>
        <div class="userinfo">
            <h3 style=" text-align:center">预定用户信息</h3>
            <table border="0" cellpadding="5" cellspacing="0">
                <tr>
                    <td>
                        姓名
                    </td>
                    <td>
                        <input type="text"  ID="txtname" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        身份证号
                    </td>
                    <td>
                        <input type="text"  ID="txtidcard" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        手机号
                    </td>
                    <td>
                        <input type="text" ID="txtmobile" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="ydinfo">
            
        </div>
        <input type="button"  ID="BtnOK" value="预定" style="margin:0px auto; margin-left:460px;"  />
        <div class="odinfo">
            告知用户提示<br />
                1 此联票的所在景区开放时间为8:00-17:00<br />
                2 取票时请用户务必携带本人身份证到联票中任意景区刷卡取票<br />
                3 网络预订的景区门票,网站不提供发票,敬请谅解.

        </div>
    </div>
    
    </form>
    
</body>
</html>
