function AddTab(obj,index) {
    var info = obj;
    var mainTabStrip = Ext.getCmp(IDS.mainTabStrip);
    //X.util.addMainTab(mainTabStrip, info.split('_')[1], info.split('_')[1].split('#')[1], info.split('_')[0], '/icon/page.png');
    //window.location.href = info.split('_')[1];
    //$("[id$='btnChangeIndex']").click();
    //$.cookie('tabUrl', info.split('_')[1].split('#')[1]);
//    for (var i = 1; i <= mainTabStrip.items.length; i++) {
//        mainTabStrip.items.itemAt(i).setIconClass('_icon_page_png');
//    }
}

function onReady() {
    var mainTabStrip = Ext.getCmp(IDS.mainTabStrip);
    var mainMenu = Ext.getCmp(IDS.mainMenu);
    //    // 初始化主框架中的树(或者Accordion+Tree)和选项卡互动，以及地址栏的更新
    var taburl = window.location.href;
    //X.util.addMainTab(mainTabStrip, taburl.split('#')[2], taburl.split('#')[2], "", '/icon/page.png');
    // 公开添加示例标签页的方法
    window.addExampleTab = function (id, url, text) {
        X.util.addMainTab(mainTabStrip, id, url, text, '/icon/page.png');
    };
    X.util.initTreeTabStrip(mainMenu, mainTabStrip, null);
    //$("head").append("<style type='text/css'>._icon_bullet_right_png{background-image:url('/icon/page.png') !important;}</style>");
//    if (mainTabStrip.items.length > 1) {
//        mainTabStrip.items.itemAt(1).setIconClass('_icon_page_png');
//    }
    //mainTabStrip = null;
}
function TabUrl() {
    var taburl = window.location.href;
    if (taburl.split('#')[2] != undefined && taburl.split('#')[2] != "" && taburl.split('#')[2] != null) {
        $.cookie('tabUrl', taburl.split('#')[2]);
    }
    else {
        $.cookie('tabUrl', "");
    }
   // window.location = window.location;
}

function showtimer() {
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
    text = year + "年" + month + "月" + day + "日" + "&nbsp;" + weekname + "&nbsp;" + hour + ":" + min + ":" + second;
    $("[id$='lblTime']").find("span").html(text);
}
function startshowtime() {
    showtimer();
    t = setTimeout("startshowtime()", 500);
}
$(function () {
    startshowtime();
});