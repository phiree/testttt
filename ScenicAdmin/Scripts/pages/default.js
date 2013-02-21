$(function () {

    $(".scoloum a").each(function () {
        $(this).mouseover(function () {
            $(".scoloum").find("span").css("color", "White");
            $(".scoloum").find("span").css("font-weight", "");
            $(".scoloum").find(".mark").css("display", "block");
            $(this).find(".mark").css("display", "none");
            $(this).find("span").css("color", "#FFFF00");
            $(this).find("span").css("font-weight", "600");
        });
        $(this).mouseout(function () {
            //$(this).find("span").css("color", "White");
            //$(this).find("span").css("font-weight", "");

        });
    });
    $(".scoloum").mouseout(function () {
        $(".scoloum").find(".mark").css("display", "none");
    });


    $(".t_sdiv a").each(function () {
        $(this).mouseover(function () {
            if ($(this).attr("class") != "dj") {
                $(".t_sdiv").find(".mark").css("display", "block");
                $(this).find(".mark").css("display", "none");
            }
        });
    });
    $(".t_sdiv").mouseout(function () {
        $(".t_sdiv").find(".mark").css("display", "none");
    });
});
      