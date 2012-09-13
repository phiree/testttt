<%@ Page Language="C#" MasterPageFile="~/mobile.master" AutoEventWireup="true" CodeFile="QuickBook.aspx.cs"
    Inherits="Scenic_QuickBook" %>

<asp:Content ContentPlaceHolderID="head" runat="server">

<script src="/Scripts/VeriIdCard.js" type="text/javascript"></script>
<script src="/Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
<script type="text/javascript">

    $(function () {
        $("#btnOK").click(function () {

            var pricetype = 2;
            var name = $.trim($("#txtName").val());
            var idcard = $.trim($("#txtIdcard").val());
            var phone = $.trim($("#txtPhone").val());

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
                    window.location = "/Scenic/QuickError.aspx";
                }
                else {
                    $.get("/order/QuickorderHandler.ashx?ticketid=" + tid + "&phone=" + phone + "&pricetype=" + pricetype + "&a=" + escape(b), function (data) {
                 window.location = "/Scenic/QuickSuc.aspx?phone="+phone+"&psw="+resultpsw;
                    });
                 
                }
            });

            //票
         
        });
    });

</script>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="cphmain">

    <hr />
    <div>
        《江郎山+廿八都+青漾景区联票》
        <br />
    </div>
    <hr />
    <div>
        姓名:
        <input type="text" id="txtName" name="" value=" " />
        <br />
        身份证号:
        <input type="text" id="txtIdcard" name="" value=" " />
        <br />
        手机号码:
        <input type="text" id="txtPhone" name="" value=" " />
        <br />
        <input type="button" id="btnOK" name="name" value="预定" />
    </div>
</asp:Content>