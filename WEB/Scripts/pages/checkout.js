$(function () {

    /**/

    $("#scenicSum").text($(".hdId").length);

    var cart = new Cart();
    $("#cticketsSum").text(cart.TotalQty);
    var totalOnlinePrice = 0;
    var totalPreorderPrice = 0;
    $(".orderlist tbody tr").each(function () {
        var that = this;
        var tid = $(that).find(".hdId").val();
        var qty = parseInt(cart.GetQty(tid));
        var priceorder = parseFloat($(that).find(".priceorder").text().trim());
        var priceonline = parseFloat($(that).find(".priceonline").text().trim());
        totalOnlinePrice += qty * priceonline;
        totalPreorderPrice += qty * priceorder;
        $(that).find(".qtyfinal").text(qty);

    });
    $("#totalonline,#bpricepreorder").text(totalOnlinePrice);
    $("#totalpreorder,#bpriceonline").text(totalPreorderPrice);


    /**/


    var pricetype = null;
    $("#cart").hide();
    //init qty

    for (var i in cart.CartItems) {
        var item = cart.CartItems[i];
        var ticketId = item.TicketId;
        var qty = item.Qty;
        $(".qty[tid='" + ticketId + "']").text(qty);
    }

    //ticketsSum
    function TicketSum() {
        var totalQty = 0;
        $(".qty").each(function () {
            var qty = parseInt($(this).text());
            totalQty += qty;

        });
        $("#ticketsSum").text(totalQty);
    };
    TicketSum();

    //鼠标放到输入联系人文本框时,自动显示常用联系人
    var originalTop;
    $(".assignName").hover(function () {
        $("#contactlist").show();
        var rowIndex = $(this).parent().parent().index();
        var contactlist = $("#contactlist");
        contactlist.show();
        if (originalTop == null) {
            originalTop = contactlist.position().top;
        }
        var left = $(this).position().left;
        var width = $(this).width();

        var height = $(this).parent().parent().height() * rowIndex;
        contactlist.css({ left: left + width + "px", top: originalTop + height + 5 + "px" });

        contactlist.attr("tid", $(this).attr("tid"));

    });

    //点击常用联系人之后,确定一种分配关系
    //生成门票分配数据
    var assign = new Array();

    $(".assignitem").click(function () {
        var that = this;
        var ticketid = $("#contactlist").attr("tid");

        var nameinput = ".assignName[tid='" + ticketid + "']";
        var idcardinput = ".assignIdcard[tid='" + ticketid + "']";
        //if ($(that).attr("all") != undefined) {
        nameinput = ".assignName";
        idcardinput = ".assignIdcard";
        //that = $(that).prev();
        // }
        var commuserId = $(that).attr("cid");
        var name = $(that).text().trim();
        var idcard = $(that).attr("idcard").trim();

        var inputname = $(nameinput);
        var inputidcard = $(idcardinput);
        for (var i = 0; i < inputname.length; i++) {
            $(inputname[i]).val(name);
            $(inputidcard[i]).val(idcard);
            $(inputidcard[i]).attr("cid", commuserId);

        }
        $("#contactlist").hide();
        veriidcard();

    });

    $("body").click(function () {
        $("#contactlist").hide();
    });

    $(".priceselection").click(function () {
        $(this).find("input").attr("checked", true);
        pricetype = $(this).attr("pricetype");
    });
    $("#btnCheckout").click(function () {
        if (pricetype == null) {
            alert("您需要先选择一种支付方式");
            return false;
        }

        var a = veriname();
        if (a == false) {
            alert("游览者姓名不能为空");
            return false;
        }
        var b = buildassign();
        if (b == false) {
            alert(errmsg);
            return false
        };

        //assign data
        $.get("/order/checkout.ashx?pricetype=" + pricetype + "&a=" + escape(b), function (data) {

            document.write(data);
        });
        $(this).text("正在提交.............");
        $(this).attr("disabled", "disabled");

        $(this).css({
            color: "#ddd",
            cursor: "none"
        });
    });
    var errmsg;
    function buildassign() {
        var items = $(".assignIdcard");
        var ap = "";
        var commonusers = "";
        var hasAssigned = true;
        for (var i = 0; i < items.length; i++) {
            var item = $(items[i]);
            var tid = item.attr("tid");
            var cid = item.attr("cid");
            var idcardno = item.val();
            var returnmsg = test(idcardno);
            if (returnmsg != "验证通过") {
                item.focus();
                errmsg = returnmsg;
                return false;
            }

            var name = item.parent().prev().children().val().trim();
            //验证数据有效性(身份证)
            ap += tid + "-" + name + "-" + idcardno + "_";



        }

        //保存常用联系人信息.

        return ap;
    }


    function veriname() {
        var items = $(".assignName");
        for (var i = 0; i < items.length; i++) {
            var item = $(items[i]);
            var name = item.val();
            if (name == "") {
                item.focus();
                return false;
            }
        }
    }

});

function veriidcard() {
    var items = $(".assignIdcard");
    for (var i = 0; i < items.length; i++) {
        var item = $(items[i]);
        var idcardno = item.val();
        if (idcardno != "") {
            var returnmsg = test(idcardno);
            if (returnmsg != "验证通过") {
                item.focus();
                $($(".assignIdcard")[i]).focus();
                $($(".veritext")[i]).html(returnmsg);
                $($(".veritext")[i]).css("display", "");
            }
            else {
                $($(".veritext")[i]).css("display", "none");
            }
        }
    }
}