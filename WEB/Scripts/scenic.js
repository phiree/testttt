function btnselect(obj) {
    var that = obj;
    $(".selectinfospan span").attr("class", "");
    $(that).attr("class", "highselected");
    var f = $("#plate1").html();
    var t = $("#plate2").html();
    if ($(".highselected").html().toString().trim() == "订票说明") {
        $("#changeinfo").html("<div id='plate1'>" + f + "</div>" + "<p id='plap'>" + "景区简介" + "</p>" + "<div id='plate2'>" + t + "</div>");
    }
    if ($(".highselected").html().toString().trim() == "景区简介") {
        $("#changeinfo").html("<div id='plate2'>" + t + "</div>" + "<p id='plap'>" + "订票说明" + "</p>" + "<div id='plate1'>" + f + "</div>");
    }
}