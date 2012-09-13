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
                    document.write("恭喜你，已成功预定江山联票1张。<br/> " +
                        "详细信息请登陆网站<a href='http://www.tourol.cn'>http://www.tourol.cn</a><br/> " +
                        "用户名:" + phone + "  密码:" + resultpsw);
                }
            });

            //票
            $.get("/order/QuickorderHandler.ashx?ticketid=" + tid + "&phone=" + phone + "&pricetype=" + pricetype + "&a=" + escape(b), function (data) {

            });
        });
    });

</script>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="cphmain">

    <div>
        预定大优惠，景区取票打9折，快快抢订~
    </div>
    <div>
        <asp:Image ID="Image1" runat="server" />
    </div>
    <hr />
    <div>
        <br />
        江郎山位于浙江省衢州市江山市江郎乡境内。 江郎山景区由三爿石、十八曲、塔山、牛鼻峰、须女湖（青龙湖）和仙居寺等部分组成，面积11.86平方公里，景源类型以自然景观为主，
        同时也有丰富的人文景观。江郎山景区为国家级重点风景名胜区和国家级AAAA级景区。 2010年8月作为“中国丹霞”的系列提名地之一列入世界自然遗产名录。
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