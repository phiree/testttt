$(function () {

    if ($.cookie("orderstr") == null || $.cookie("orderstr") == "") {
        $.cookie("orderstr", "0_desc");
    }
    $(".sequence").each(function () {
        var orderindex = $.cookie("orderstr").split('_')[0];
        var orderstate = $.cookie("orderstr").split('_')[1];
        if ($(".sequence").index(this) == orderindex) {
            if (orderstate == "asc") {
                $(this).find(".orderspan").html("↑");
            }
            else
                $(this).find(".orderspan").html("↓");
        }
        $(this).click(function () {
            var orderby = "";
            if ($(this).find(".orderspan").html() == "↓") {
                $(this).find(".orderspan").html("↑");
                orderby += $(".sequence").index(this) + "_" + "asc";
            }
            else {
                $(this).find(".orderspan").html("↓");
                orderby += $(this).index() + "_" + "desc";
            }
            $.cookie("orderstr", orderby);
            $("[id$='BtnSearch']").click();
        });
    });
});

