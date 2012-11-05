(function ($) {
    $.fn.orderIndex = function (rowcount) {
        var rh = parseInt(rowcount) * 20+12;
        $(this).append("<thead><tr><th style='height:" + rh +"px'>序号</th></tr></thead>");
        $(this).append("<tbody>");
        for (var i = 1; i <= $(".InfoTable").find("tbody").find("tr").length; i++) {
            $(this).append("<tr><td>" + i + "</td></tr>");
        }
        $(this).append("</tbody>");
        var tfootinfo = $(".InfoTable").find("tfoot").find("tr").eq(0).find("td").eq(0).html();
        if (tfootinfo != null || tfootinfo != undefined) {
            $(this).append("<tfoot><tr><td>总计</td></tr></tfoot>");
        }
    }
})($)