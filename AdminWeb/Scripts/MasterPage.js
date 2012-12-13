function showtimer() {
    var text = "现在时间:&nbsp;";
    var tody = new Date();
    var year = tody.getFullYear();
    var month = tody.getMonth() + 1;
    if (month < 10) month = "0" + month;
    var day = tody.getDate();
    if (day < 10) day = "0" + day;
    var hour = tody.getHours();
    if (hour < 10) hour = "0" + hour;
    var min = tody.getMinutes();
    if (min < 10) min = "0" + min;
    var second = tody.getUTCSeconds().toString();
    if (second < 10) second = "0" + second;
    var week = tody.getDay();
    var weekname;
    if (week == 0) {
        weekname = "星期天";
    }
    if (week == 1) {
        weekname = "星期一";
    }
    if (week == 2) {
        weekname = "星期二";
    }
    if (week == 3) {
        weekname = "星期三";
    }
    if (week == 4) {
        weekname = "星期四";
    }
    if (week == 5) {
        weekname = "星期五";
    }
    if (week == 6) {
        weekname = "星期六";
    }
    text = text + year + "年" + month + "月" + day + "日" + "&nbsp;" + weekname + "&nbsp;" + hour + ":" + min + ":" + second;
    $("#timer").html(text);
}
function startshowtime() {
    showtimer();
    t = setTimeout("startshowtime()", 500);
}
$(function () {
    startshowtime();
});