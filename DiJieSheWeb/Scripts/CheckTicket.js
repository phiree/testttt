function showyklist() {
    $("#listname").attr("style", "display:block");
    var list = $("#yklistt");
    $("#listname").css({ left: list.position().left + "px", top: list.position().top + 10 + "px" });
}
$(function () {
    //autocomplete的ajax方法
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "TECheckTicket.aspx/GetAllHints",
        data: "{etid:'" + $("[id$='hfetid']").val() + "'}",
        dataType: "json",
        success: function (msg) {
            var datas = eval('(' + msg.d + ')');
            $("[id$='txtTE_info']").autocomplete(
                    datas, { formatItem: function (row, i, max) {
                        return "<table width='200px' cellpadding='0' cellspacing='0'><tr><td align='left' height='10px' style='padding-top:10px;line-height:10px;'>" + row.Value + "</td></tr></table>";
                    },
                        formatMatch: function (row, i, max) {
                            return row.Value;
                        },
                        matchContains: true
                    }).result(function (event, data, formatted) { $("[id$='txtTE_info']").val(data.Value); $("[id$='BtnCheck']").click(); });
        }
    });



   

    //读卡器验票操作
    if ($.cookie("idcard") == null)
        $.cookie("idcard", "");
    timedCheck();
});
function cgbg(obj) {
    $(obj).find("td").css("background-color", "#E9E9E9");
}
function cgbg2(obj) {
    $(obj).find("td").css("background-color", "#F7F7F7");
}
var t;
function timedCheck() {
    show();
    t = setTimeout("timedCheck()", 1000);
}
function show() {
    var a = document.getElementById('aaa');
    a.OnTimer();
    var strinfo = a.GetUserInfo();
    var arrys = strinfo.split(',');
    if (arrys.length > 8) {
        if ($.cookie("idcard") != arrys[5]) {
            $("[id$='txtTE_info']").val(arrys[0]+'/'+arrys[5]);
            $.cookie("idcard", arrys[5]);
            $("[id$='BtnCheck']").click();
        }
        else {

        }
    }
}