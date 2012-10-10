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
                        return "<table width='200px' cellpadding='0' cellspacing='0'><tr><td align='left' height='10px' style='padding-top:10px;line-height:10px;'>" + row.Key + "</td></tr></table>";
                    },
                        formatMatch: function (row, i, max) {
                            return row.Key;
                        },
                        matchContains: true
                    }).result(function (event, data, formatted) { $("[id$='txtTE_info']").val(data.Key); $("[id$='BtnCheck']").click(); });
        }
    });



    $("body").click(function () {
        $("#listname").attr("style", "display:none");
        var list = $("#yklistt");
        $("#listname").css({ left: list.position().left + "px", top: list.position().top + 10 + "px" });
    });
});
function cgbg(obj) {
    $(obj).find("td").css("background-color", "#E9E9E9");
}
function cgbg2(obj) {
    $(obj).find("td").css("background-color", "#F7F7F7");
}