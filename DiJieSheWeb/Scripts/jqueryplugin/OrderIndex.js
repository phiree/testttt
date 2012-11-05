(function ($) {
    $.fn.orderIndex = function () {
        $(this).append("<thead><tr><th>序号</th></tr></thead>");
        $(this).append("<tbody>");
        for (var i = 1; i <= $(".InfoTable").find("tbody").find("tr").length; i++) {
            $(this).append("<tr><td>" + i + "</td></tr>");
        }
        $(this).append("</tbody>");
        if ($(".InfoTable").find("tfoot") != null || $(".InfoTable").find("tfoot") != undefined) {
            $(this).append("<tfoot><tr><td>总计</td></tr></tfoot>");
        }
    }
})($)