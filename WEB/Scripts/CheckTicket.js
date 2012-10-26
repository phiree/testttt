function changesumprice(obj) {
    $(obj).val($(obj).val().replace(/[^0-9]/g, ''));
    var usecount = $(obj).val();
    var yddj = $($(obj).parent().find(".num")[2]).html().substring(0, $($(obj).parent().find(".num")[2]).html().length - 1);
    var tn = $(obj).parent().find("#ticketname").html();
    if (usecount != "" && usecount!="0") {
        $(obj).parent().find("#sumprice").html(parseInt(usecount) * parseInt(yddj));
        var ydcount = parseInt($($(obj).parent().find(".num")[0]).html());
        var ydusedcount = parseInt($($(obj).parent().find(".num")[1]).html());
        if (parseInt(usecount) > (ydcount - ydusedcount)) {
            $(obj).parent().next().html("原预定&nbsp;<span style='font-weight:bold'>" + tn + "</span>&nbsp;门票&nbsp;<span class='num'>" + (ydcount - ydusedcount) + "</span>&nbsp;张&nbsp;&nbsp;" + "额外添加预定&nbsp;<span class='num'>" + (usecount - ydcount + ydusedcount) + "</span>&nbsp;张");
        }
        else {
            $(obj).parent().next().html("");
        }
    }
    else {
        $(obj).parent().find("#sumprice").html(0 + "元");
        $(obj).parent().next().html("");
    }
}

function changeolcount(obj) {
    $(obj).val($(obj).val().replace(/[^0-9]/g, ''));
    var olgpcount = parseInt($($(obj).parent().find(".num")[0]).html());
    var olusedcount = parseInt($($(obj).parent().find(".num")[1]).html());
    var wtcount = parseInt($(obj).val());
    if (wtcount > (olgpcount - olusedcount)) {
        alert("使用数超过已购买数");
        return false;
    }
    return true;
}

var v = 1;
$(document).ready(function () {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "CheckTicket.aspx/GetAllHints",
        data: "{scid:'" + $("[id$='hfscid']").val() + "'}",
        dataType: "json",
        success: function (msg) {
            var datas = eval('(' + msg.d + ')');
            $("[id$='txtinfo']").autocomplete(
                    datas, { formatItem: function (row, i, max) {
                        return "<table width='200px' cellpadding='0' cellspacing='0'><tr><td align='left' height='10px' style='padding-top:10px;line-height:10px;'>" + row.Key + "</td></tr></table>";
                    },
                        formatMatch: function (row, i, max) {
                            return row.Key;
                        },
                        matchContains: true
                    }).result(function (event, data, formatted) { $("[id$='hfdata']").val(data.Key); $("[id$='btnbind']").click(); });
        }
    });
    $("[id$='txtinfo']").InlineTip({ "tip": "录入游客身份证或名字" });
    $("body").click(function () {
        $("#listname").attr("style", "display:none");
        var list = $("#yklistt");
        $("#listname").css({ left: list.position().left + "px", top: list.position().top + 10 + "px" });
        $("#listyw").attr("style", "display:none");
    });
    if ($.cookie("idcard") == null)
        $.cookie("idcard", "");
    timedCount();
});

var state = 0;
function showyklist() {
    $("#listname").attr("style", "display:block");
    var list = $("#yklistt");
    $("#listname").css({ left: list.position().left + "px", top: list.position().top + 10 + "px" });
    state = 1;
}

function querenpay() {
    var usecount = $("[id$='txtUseCount']").val();
    var sumprice = $("#sumprice").html();
    return confirm("本次使用" + usecount + "张,共需支付金额" + sumprice + ",是否确认付款?");
}
function querenyuding() {
    var ydcount = $("[id$='txtyudingcount']").val();
    return confirm("本次预定" + ydcount + "张,是否确认预定?");
}
function querenuse() {
    var usecount = $("[id$='txtolusecount']").val();
    return confirm("本次使用" + usecount + "张,是否确认使用?");
}
function btnselectname(obj) {
    $("[id$='hfselectname']").val($.trim($(obj).parent().find("td").eq(0).find("span").html()));
    $("[id$='hfselectidcard']").val($.trim($(obj).parent().find("td").eq(1).find("span").html().toString()));
    $.cookie("idcard", $("[id$='hfselectidcard']").val());
    $("[id$='btnselect']").click();
}
var state2 = 0;
function showywrecord() {
    $("#listyw").attr("style", "display:block");
    var ywspan = $("#ywspan");
    $("#listyw").css({ left: ywspan.position().left + "px", top: ywspan.position().top + 10 + "px" });
    state2 = 1;
}

var t;
function timedCount() {
    show();
    t = setTimeout("timedCount()", 1000);
}
function show() {
    var a = document.getElementById('aaa');
    a.OnTimer();
    var strinfo = a.GetUserInfo();
    var arrys = strinfo.split(',');
    if (arrys.length > 8) {
        if ($.cookie("idcard") != arrys[5]) {
            $("[id$='txtinfo']").val(arrys[5]);
            $.cookie("idcard", arrys[5]);
            autobtn();
        }
        else {
            
        }
    }
}

function autobtn() {
    $("[id$='hfautoidcard']").val($("[id$='txtinfo']").val());
    $("[id$='btnauto']").click();
}
function hidescreen(obj) {
    $(obj).css("display", "none");
}
function cgbg(obj) {
    $(obj).find("td").css("background-color", "#E9E9E9");
}
function cgbg2(obj) {
    $(obj).find("td").css("background-color", "#F7F7F7");
}

function printTicket(info) {
    if (confirm(info)) {
        $("[id$='BtnPrint']").click(function () {
            window.open($(this).attr("href"), '', 'fullscreen=yes');
            
        });

        // 触发单击事件（会执行所有绑定的单击事件处理函数） 
        $("[id$='BtnPrint']").click();
    }
}

function noBorderWin(fileName,w,h) {
  nbw=window.open(fileName,'','fullscreen=yes');
  //nbw.resizeTo(w,h);
  //nbw.moveTo((screen.width-w)/2,(screen.height-h)/2);
  
}
