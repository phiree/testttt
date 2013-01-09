(function ($) {
    $.fn.orderIndex = function (param) {
        var options = $.extend(
        {
            tableindex: "1",
            columnName: "序号"
        },
         param
    );
        var LinkTable = $(".InfoTable").eq(parseInt(options.tableindex) - 1);
        $(this).html("");
        var rh = $(LinkTable).find("thead").find("tr").eq(0).find("th").eq(0).height();
        if (rh == 0) {
            rh = $(LinkTable).find("thead").find("tr").eq(0).find("td").eq(0).height();
            var rowcount = $(LinkTable).find("thead").find("tr").eq(0).find("th").eq(0).attr("rowspan");
            if (rowcount != null && rowcount != undefined) {
                rh = parseInt(rh) * parseInt(rowcount) + (parseInt(rowcount) - 1) * 2;
            }
        }
        $(this).append("<thead><tr><th style='line-height:" + rh + "px'>" + options.columnName + "</th></tr></thead>");
        $(this).append("<tbody>");
        for (var i = 1; i <= $(LinkTable).find("tbody").find("tr").length; i++) {
            var tdheight = $(LinkTable).find("tbody").find("tr").eq(i - 1).find("td").eq(0).height();
            $(this).append("<tr><td style='line-height:" + tdheight + "px'>" + i + "</td></tr>");
        }
        $(this).append("</tbody>");
        var tfootinfo = $(LinkTable).find("tfoot").find("tr").eq(0).find("td").eq(0).html();
        if (tfootinfo != null || tfootinfo != undefined) {
            var tfheight = $(LinkTable).find("tfoot").find("tr").eq(0).find("td").eq(0).height();
            $(this).append("<tfoot><tr><td style='line-height:" + tdheight + "px'>总计</td></tr></tfoot>");
        }
    }
})($)