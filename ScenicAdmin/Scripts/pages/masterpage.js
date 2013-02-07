var tip = "输入景区或景点名称";
$(function () {
    $("#tbxKeywords").InlineTip({ "tip": tip });

    $("#btnSearch").click(
            function () {
                var that = this;
                var keyword = $("#tbxKeywords").val();
                if (keyword == "" || keyword == tip) {
                    return false;
                }
            }
            );
    $("#cart").mouseover(function () {
        $("#popcart").show();
    });
    $("#cart").mouseout(function () {
        $("#popcart").hide();
        $("#popcart").mouseover(function () {
            $("#popcart").show();
        });
        $("#popcart").mouseout(function () {
            $("#popcart").hide();
        });
    });

    var cart = new Cart();
    $(".cartdelete").click(function () {
        cart.Delete($(this).attr("tid"));
        $(this).parent().parent().addClass("deleted");
    });
    //每张门票数量.
    $("#pcbody .pcqty").each(function () {
        var that = this;
        var pid = $($($(that).parent().siblings()[0]).children()[0]).attr("tid");
        var qty = cart.GetQty(pid);
        $(that).text(qty);
    });
    //购物车内的统计数据
    $("#ticketsSum").text(cart.TotalQty);
    $("#scenicSum").text(cart.CartItems.length);

    //var pleft = $("#cart").position().left;
    //var ptop = $("#cart").position().top;
    //$("#popcart").css({ left: pleft -90+ "px", top: ptop+50 + "px" });
    $(".chartdiv").mouseover(function () {
        $(this).css("background-color", "#4FA600");
        var pleft = $(".chartdiv").position().left;
        var ptop = $(".chartdiv").position().top;
        $("#popcart").css({ left: pleft + 410 + "px", top: ptop + 30 + "px", display: "block" });
        if ($.browser.msie && (jQuery.browser.version == "6.0") && !$.support.style) {
            $("#popcart").css({ left: pleft + 335 + "px", top: ptop + 30 + "px", display: "block" });
        }
        //购物车背景高度
        var pcheight = $("#pcbody").height();
        if (navigator.appName == "Microsoft Internet Explorer") {
            if (navigator.appVersion.match(/7./i) == '7.') {
                $("#popcart").css("height", pcheight + "px");
            }
            else {
                $("#popcart").css("height", pcheight + "px");
            }
        }
        else {
            $("#popcart").css("height", pcheight + "px");
        }
    });
    $(".chartdiv").mouseout(function () {
        $(this).css("background-color", "");
        $("#popcart").hide();
        $("#popcart").mouseout(function () {
            $(this).css("background-color", "");
            $("#popcart").hide();
        });
        $("#popcart").mouseover(function () {
            $("#popcart").show();
            //购物车背景高度
            var pcheight = $("#pcbody").height();
            if (navigator.appName == "Microsoft Internet Explorer") {
                if (navigator.appVersion.match(/7./i) == '7.') {
                    $("#popcart").css("height", pcheight + "px");
                }
                else {
                    $("#popcart").css("height", pcheight + "px");
                }
            }
            else {
                $("#popcart").css("height", pcheight + "px");
            }
        });
    });
    var ileft = $(".logoleft").position().left;
    var itop = $(".logoleft").position().top;
    $(".mainarea").css({ left: ileft + 370 + "px", top: itop + 60 + "px" });
    //var h = $(".popcartbg").css("height");
    //$(".popmain").css("height",  120 + "px");
    findDimensions();
    var ll = (winWidth - 955) / 2;
    $(".Filldiv").css("width", ll);
    navshow();


    $(".navlistnb a").each(function () {
        if ($(this).attr("class") == "navhight") {
            $(this).next().css("display", "none");
            $(".chartdiv").css("display", "block");
        }
        else {
            $(this).next().css("display", "");
            $(".chartdiv").css("display", "block");
            $(this).click(function () {
                $(this).next().css("display", "none");
                $(".chartdiv").css("display", "block");
            });
            $(this).mouseover(function () {
                $(this).next().css("display", "none");
                $(".chartdiv").css("display", "block");
            });
            $(this).mouseout(function () {
                $(this).next().css("display", "");
                $(".chartdiv").css("display", "block");
            });
        }
    });
});
window.onresize = function () {
    findDimensions();
    var pleft = $(".chartdiv").position().left;
    var ptop = $(".chartdiv").position().top;
    $("#popcart").css({ left: pleft + 410 + "px", top: ptop + 30 + "px" });
    var ileft = $(".logoleft").position().left;
    var itop = $(".logoleft").position().top;
    $(".mainarea").css({ left: ileft + 370 + "px", top: itop + 60 + "px" });
    var ll = (winWidth - 955) / 2;
    $(".Filldiv").css("width", ll);
}


function navshow() {
    var thishref = window.location.href;
    $(".navlistnb a").attr("class", "");
    if (/^.*map.*$/.test(thishref)) {
        $(".navlistnb a:eq(3)").attr("class", "navhight");
    } else if (/www.tourol.cn\/($|[D|d]efault.aspx)/.test(thishref)) {
        $(".navlistnb a:eq(0)").attr("class", "navhight");
    } else {
        $(".navlistnb a:eq(1)").attr("class", "navhight");
    }
}