function btnselect(obj) {
    var that = obj;
    $(".selectinfospan span").attr("class", "");
    $(that).attr("class", "highselected");
    var f = $("#plate1").html();
    var t = $("#plate2").html();
    if ($(".highselected").html().toString().trim() == "交通指南") {
        $("#changeinfo").html("<div id='plate1'>" + f + "</div>" + "<p id='plap'>" + "景区简介" + "</p>" + "<div id='plate2'>" + t + "</div>");
    }
    if ($(".highselected").html().toString().trim() == "景区简介") {
        $("#changeinfo").html("<div id='plate2'>" + t + "</div>" + "<p id='plap'>" + "交通指南" + "</p>" + "<div id='plate1'>" + f + "</div>");
    }
    showmap();
    
}

$(window).scroll(function () {
    findDimensions();
    $(".backtop").css("right", (winWidth - 950) / 2 - 50);
    $(".backtop").click(function () {
        window.scrollTo(0, 0);
    });
    $(".backtop").css("position", "fixed");
    if (document.documentElement.scrollTop + document.body.scrollTop > 100) {
        $(".backtop").fadeIn("fast");
    }
    else {
        $(".backtop").fadeOut("fast");
    }
    if (document.body.scrollHeight - document.documentElement.scrollTop - document.body.scrollTop - winHeight < 135) {
        $(".backtop").css("position", "absolute");
    }
});

$(function () {
    $("#priceinfo table tr").each(function () {
        if ($(this).attr("class") != "tstr") {
            $(this).mouseover(function () {
                $(this).find("td").css("background-color", "#FFFCE6");
            });
            $(this).mouseout(function () {
                $(this).find("td").css("background-color", "");
            });
        }
    });
});
var boderwidth;
function EditHTMLInfo(obj) {
    boderwidth = $(obj).css("boder-width");
    $(obj).css("border", "1px solid #FAF707");
}
function CancelHTMLInfo(obj) {
    if (boderwidth!=null)
        $(obj).css("border-color", "");
    else
        $(obj).css("border-width", "0px");
}
function EditHTMLInfoBtn(obj, scname, scfunctype) {
    var flag = $(obj).attr("class");
    if (flag == "" || flag == undefined || flag == null) {
        flag = $(obj).attr("id");
        flag = "#" + flag;
    }
    else {
        flag = "." + flag;
    }
    findDimensions();
    var w = (winWidth - 740) / 2;
    var h = (winHeight - 600) / 2;
    window.open(encodeURI('/Scenic/EditHTMLInfo.aspx?scname=' + scname + '&scfunctype=' + scfunctype + '&type=景区&flag='+flag+''), 'newwindow', 'height=600,width=740,top=' + h + ',left=' + w + ',toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no');
}