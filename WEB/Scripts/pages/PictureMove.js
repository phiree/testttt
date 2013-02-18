var t = n = 0, count = $(".content a").size();
$(function () {
    var play = ".play";
    var playText = ".play .text";
    var playNum = ".play .num a";
    var playConcent = ".play .content a";

    $(playConcent + ":not(:first)").hide();
    $(playText).html($(playConcent + ":first").find("img").attr("alt"));
    $(playNum + ":first").addClass("on");
    $(playText).click(function () { window.open($(playConcent + ":first").attr('href'), "_blank") });
    $(playNum).click(function () {
        var i = $(this).text() - 1;
        n = i;
        if (i >= count) return;
        $(playText).html($(playConcent).eq(i).find("img").attr('alt'));
        $(playText).unbind().click(function () { window.open($(playConcent).eq(i).attr('href'), "_blank") })
        $(playConcent).filter(":visible").hide().parent().children().eq(i).fadeIn(1200);
        $(this).removeClass("on").siblings().removeClass("on");
        $(this).removeClass("on2").siblings().removeClass("on2");
        $(this).addClass("on").siblings().addClass("on2");
    });
    t = setInterval("showAuto()", 5000);
    $(play).hover(function () { clearInterval(t) }, function () { t = setInterval("showAuto()", 5000); });
})
function showAuto() {
    n = n >= (count - 1) ? 0 : ++n;
    $(".num a").eq(n).trigger('click');
}
