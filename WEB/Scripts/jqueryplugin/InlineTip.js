$.fn.InlineTip = function (option) {

    var params = $.extend({ tip: "在此输入",
        style: {
            color: "#777"
        }
    },
     option);
    var that = this;
    $(that).val(params.tip);
    $(that).css(params.style);
    $(that).focus(function () {
        var val = $(that).val().replace(/(^\s*)|(\s*$)/g, "");
        if (val == params.tip) {
            $(that).val("");
            $(that).removeAttr("style");
        }
    });
    $(that).blur(function () {
        var val = $(that).val().replace(/(^\s*)|(\s*$)/g, "");
        if (val == "") {
            $(that).val(params.tip);
            $(that).css(params.style);
        }
    });

}