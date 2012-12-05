$(document).ready(
            function () {
                findDimensions();
                if (winWidth < 1024) {
                    $("body").width(1024);
                }
                if (winHeight < 780) {
                    $("body").height(winHeight);
                    $("#left").height(780 - 185);
                    $("#right").height(780 - 185);
                }
                else {
                    $("#left").height(winHeight - 185);
                    $("#right").height(winHeight - 185);
                }
                $("#left").width($("body").width() - 278 - 1);
                $(".topmid").width($("body").width() - 18 - 265 - 30 - 18);
            });
window.onresize = function () {
    findDimensions();
    if (winWidth < 1024) {
        $("body").width(1024);
    }
    else {
        $("body").width(winWidth);
    }
    if (winHeight < 780) {
        $("body").height(winHeight);
        $("#left").height(780 - 185);
        $("#right").height(780 - 185);
    }
    else {
        $("body").height(winHeight);
        $("#left").height(winHeight - 185);
        $("#right").height(winHeight - 185);
    }
    $("#left").width($("body").width() - 278 - 1);
    $(".topmid").width($("body").width() - 18 - 265 - 30 - 18);
}
function qdpostion() {
    findDimensions();
    if (winWidth < 1024) {
        $("body").width(1024);
    }
    else {
        $("body").width(winWidth);
    }
    if (winHeight < 780) {
        $("body").height(winHeight);
        $("#left").height(780 - 185);
        $("#right").height(780 - 185);
    }
    else {
        $("body").height(winHeight);
        $("#left").height(winHeight - 185);
        $("#right").height(winHeight - 185);
    }
    $("#left").width($("body").width() - 278 - 1);
    $(".topmid").width($("body").width() - 18 - 265 - 30 - 18);
}
$(function () {
    $(".areaname a").each(function (e) {
        var that = this;
        var type = $(that).parent().attr("id");

        var href = $(that).attr("href");

        if (getParameterByName(type, window.location.href) == getParameterByName(type, href) || getParameterByName(type, window.location.href) + "areaid=1018" == getParameterByName(type, href)) {
            $(that).addClass("highlightSelected");
            $(that).css("color", "White");

        }
        else {
            $(that).removeClass("highlightSelected");
        }
    });
    function getParameterByName(name, query) {
        query = query.replace("#m", "");
        var match = RegExp('[?&]' + name + '=([^&]*)')
                    .exec(query);
        return match && decodeURIComponent(match[1].replace(/\+/g, ' '));
    }
    //绑定级别主题高亮
    if ($.cookie("level") != undefined) {
        var level = $.cookie("level");
        $(".sellevelinfo a").removeAttr('style');
        $(".sellevelinfo a").each(function () {
            var that = this;
            if ($.trim($(that).html()) == "全部" && level == "") {
                $(that).attr("style", "border:1px solid #F9CD8A;background-color:#FDF0CA;color:#E8641B");
            }
            if ($.trim($(that).html()) == level) {
                $(that).attr("style", "border:1px solid #F9CD8A;background-color:#FDF0CA;color:#E8641B");
            }
        });
    }
    if ($.cookie("topic") != undefined) {
        var topic = $.cookie("topic");
        $(".selthemeinfo a").removeAttr("style");
        $(".selthemeinfo a").each(function () {
            var that = this;
            if ($.trim($(that).html()) == "全部" && topic == "") {
                $(that).attr("style", "border:1px solid #F9CD8A;background-color:#FDF0CA;color:#E8641B");
            }
            if ($.trim($(that).html()) == topic) {
                $(that).attr("style", "border:1px solid #F9CD8A;background-color:#FDF0CA;color:#E8641B;padding-bottom:0px;");
            }
        });
    }

    $("#txtSearch").InlineTip({ "tip": "请输入您要搜索的景区" });

    /*搜索框*/
    $(".sellevel").click(function () {
        $(".sellevelinfo").slideToggle();
        if (/1\.png$/.test($(".sellevel img").attr("src"))) {
            $(".sellevel img").attr("src", "/Img/yuansu/jiantouicon2.png");
        }
        else {
            $(".sellevel img").attr("src", "/Img/yuansu/jiantouicon1.png");
        }
    });
    $(".selarea").click(function () {
        $(".selareainfo").slideToggle();
        if (/1\.png$/.test($(".selarea img").attr("src"))) {
            $(".selarea img").attr("src", "/Img/yuansu/jiantouicon2.png");
        }
        else {
            $(".selarea img").attr("src", "/Img/yuansu/jiantouicon1.png");
        }
    });
    $(".seltheme").click(function () {
        $(".selthemeinfo").slideToggle();
        if (/1\.png$/.test($(".seltheme img").attr("src"))) {
            $(".seltheme img").attr("src", "/Img/yuansu/jiantouicon2.png");
        }
        else {
            $(".seltheme img").attr("src", "/Img/yuansu/jiantouicon1.png");
        }
    });

    areabg();

    /*表面搜索结果*/
    $(".sellevelinfo a").each(function () {
        if ($(this).css("color") == "#e8641b" || $(this).css("color") == "rgb(232, 100, 27)") {
            if ($(this).html() != "全部") {
                $(".sellevel span").html("级别：" + $(this).html());
            }
            else {
                $(".sellevel span").html("选择级别");
            }
        }
    });
    $(".selareainfo a").each(function () {
        if ($(this).css("color") == "#e8641b" || $(this).css("color") == "rgb(232, 100, 27)") {
            if ($(this).html() != "全部") {
                $(".selarea span").html("城市:" + $(this).html());
            }
            else {
                $(".selarea span").html("选择城市");
            }
        }
    });
});
document.onkeydown = function (e) {
    if (window.event)
        e = window.event;
    var int_keycode = e.charCode || e.keyCode;
    if (int_keycode == 13 && $("#txtSearch").val() != "请输入您要搜索的景区" && $("#txtSearch").val() != "") {
        getCoordinatesNotScId(null);
    }
}

function btnarea(obj) {
    if (obj.innerHTML == "全部") {
        $.cookie("level", "");
    }
    else {
        $.cookie("level", obj.innerHTML);
    }
    $(".sellevelinfo a").removeAttr('style');
    $(obj).attr("style", "border:1px solid #F9CD8A;background-color:#FDF0CA;color:#E8641B");
    /*表面搜索结果*/
    $(".sellevelinfo a").each(function () {
        if ($(this).css("color") == "#e8641b" || $(this).css("color") == "rgb(232, 100, 27)") {
            if ($(this).html() != "全部") {
                $(".sellevel span").html("级别：" + $(this).html());
            }
            else {
                $(".sellevel span").html("选择级别");
            }
        }
    });
    getCoordinatesNotScId(null);
    $(".sellevelinfo").slideToggle();
}


function areabg() {
    var h = window.location.href;
    h = h.match(/areaid.*/ig);
    if (h != null) {
        $(".selareainfo a").each(function () {
            var ih = $(this).attr("href");
            ih = ih.match(/areaid.*/ig);
            if (h.toString() == ih.toString()) {
                $(this).attr("style", "border:1px solid #F9CD8A;background-color:#FDF0CA;color:#E8641B");
            }
            else {
                $(this).attr("style", "");
            }
        });
    }
    else {
        $($(".selareainfo a")[0]).attr("style", "border:1px solid #F9CD8A;background-color:#FDF0CA;color:#E8641B");
    }
}

function changescnamecl(obj) {
    $(obj).css("color", "#8BB06D");
}
function changescnamecl2(obj) {
    $(obj).css("color", "");
}
function qdtopic(obj) {
    if (obj.innerHTML == "全部") {
        $.cookie("topic", "");
    }
    else {
        $.cookie("topic", obj.innerHTML);
    }
    $(".selthemeinfo a").removeAttr("style");
    $(obj).attr("style", "border:1px solid #F9CD8A;background-color:#FDF0CA;color:#E8641B;padding-bottom:0px;");
    /*表面搜索结果*/
    $(".selthemeinfo a").each(function () {
        if ($(this).css("color") == "#e8641b" || $(this).css("color") == "rgb(232, 100, 27)") {
            if ($.trim($(this).html()) != "全部") {
                $(".seltheme span").html("旅游主题：" + $(this).html());
            }
            else {
                $(".seltheme span").html("旅游主题");
            }
        }
    });
    getCoordinatesNotScId(null);
    $(".selthemeinfo").slideToggle();
}
