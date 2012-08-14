$(function () {
    $(".tbvisitedsc tr td").each(function () {
        $(this).mouseover(function () {
            $(this).find("img").attr("src", "/theme/default/image/newversion/jt1.gif");
            $(this).find("a").css("color", "#EC6B9E");
        });
        $(this).mouseout(function () {
            $(this).find("img").attr("src", "/theme/default/image/newversion/jt2.gif");
            $(this).find("a").css("color", "");
        });
    });
});