/*变量申明*/
var allCoordinates; //页面目前所查询出来的坐标
var map; //baidu地图变量
var overlayMarker = new Array(); //地图覆盖物
var infoWindow; //内容页
/*页面初始*/
$(function () {
    //cookie初始化
    $.cookie("pageindex", "");
    if ($.cookie("scname") == undefined)
        $.cookie("scname", "");
    if ($.cookie("level") == undefined)
        $.cookie("level", "");
    $.cookie("pager_currPage", "1");
    if ($.cookie("topic") == undefined)
        $.cookie("topic", "");
    var strUrl = new QueryString();
    if (strUrl.areaid != undefined) {
        $.cookie("strurlareaid", strUrl.areaid);
    }
    else {
        $.cookie("strurlareaid", "");
    }
    getCoordinatesNotScId();

});
/*查询方法*/
function getCoordinatesNotScId() {
    //显示加载提示
    $(".loaddiv").css("display", "block");
    var randomParam = new Date().toString();
    var url;
    url = "/map/map.ashx?type=2&tP=" + randomParam;
    if ($("[id$='txtSearch']").val() == "请输入您要搜索的景区")
        $.cookie("scname", "");
    else
        $.cookie("scname", $("[id$='txtSearch']").val());

    $.get(
        url,
        function (coordinates) {
            allCoordinates = eval("(" + coordinates + ")");
            //ajax分页控件配置
            $("#pager").myPagination({
                currPage: 1,
                pageCount: parseInt($.cookie("resultcount")),
                pageSize: 3,
                info: {
                    cookie_currPage: true, //开启 Coookie保存页数模式
                    cookie_currPageKey: "pager"	//保存 cookie 值为 demo1_currPage
                }
            });
            //显示搜索区域
            $(".areaname a").each(function (e) {
                var that = this;
                if ($(that).attr("class") == "highlightSelected")
                    $("#searchareaname").html($(that).html());
            });
            if (map != undefined) {
                clearOverlays();
            }
            else {
                var latlng = new BMap.Point(118.860, 28.981);
                map = new BMap.Map("container");
                map.centerAndZoom(latlng, 8);
                map.addControl(new BMap.ScaleControl());
                map.addControl(new BMap.OverviewMapControl());
                map.addControl(new BMap.NavigationControl({ offset: new BMap.Size(10, 50) }));
                map.enableScrollWheelZoom();
            }
            $.cookie("pageindex", '1');
            btnshowinfo();
            $("#countscenic").html($.cookie("numcount"));
            //添加一个地图加载完毕的事件监听
            map.addEventListener("tilesloaded", function () {
                //加载完关闭加载图片
                $(".loaddiv").css("display", "none");
            });
        }
    );
}

/*辅助方法*/
/*去除地图上的所有覆盖物*/
function clearOverlays() {
    map.clearOverlays();
    overlayMarker.length = 0;

}
/*关闭所有的窗口*/
function closeWinInfo() {
    map.closeInfoWindow();
}
/*创建baidu自定义覆盖物*/
function customOverlay_Large(options) {
    //初始化参数
    this._latlng = options.latlng; //设置图标位置
    this._text = options.text;
    this._id = options.id;
    this._scid = options.scid;
}
customOverlay_Large.prototype = new BMap.Overlay();
//初始化图标
customOverlay_Large.prototype.initialize = function () {
    this._map = map;
    var div = this._div = document.createElement("div");
    div.style.position = "absolute";
    div.style.zIndex = BMap.Overlay.getZIndex(this._latlng.lat);
    div.className = "divicon";
    div.style.MozUserSelect = "none";
    div.style.fontSize = "12px";
    div.id = this._div;
    div.name = this._name;

    var span = this._span = document.createElement("span");
    div.appendChild(span);
    span.style.height = "15px";
    div.style.cursor = "pointer";
    span.style.display = "inline-block";
    span.style.color = "Black";
    span.style.margin = "0px 5px 2px 3px";
    span.appendChild(document.createTextNode(this._id));
    var that = this;

    var spanscenic = this._span = document.createElement("span");
    div.appendChild(spanscenic);
    spanscenic.height = "15px";
    spanscenic.style.position = "relative";
    spanscenic.style.top = "-2px \0";
    spanscenic.style.display = "inline-block";
    spanscenic.style.lineHeight = "15px";
    spanscenic.style.color = "White";
    spanscenic.appendChild(document.createTextNode(this._text))


    var arrow = this._arrow = document.createElement("div");
    arrow.style.background = "url('/Img/yuansu/largeicon3.gif') no-repeat";
    arrow.style.position = "absolute";
    arrow.style.width = "15px";
    arrow.style.height = "14px";
    arrow.style.top = "19px";
    arrow.style.left = "10px";
    arrow.style.overflow = "hidden";
    div.appendChild(arrow);
        //注册div点击事件
        $(div).click(function () {
            closeWinInfo();
            var randomParam = new Date().toString();
            $.get(
                '/map/mapscenic.ashx?t=' + randomParam + '&scid=' + that._scid,
                function (detail_scenic) {
                    var ds = eval("(" + detail_scenic + ")");
                    infoWindow = new BMap.InfoWindow(InfoWindowContent(ds));
                    map.openInfoWindow(infoWindow, that._latlng);
                }
            )
        });
    map.getPanes().labelPane.appendChild(div);
    return div;
}
//绘制图标，主要用于控制图标的位置
customOverlay_Large.prototype.draw = function () {
    var map = this._map;
    var pixel = map.pointToOverlayPixel(this._latlng);
    this._div.style.left = pixel.x - parseInt(this._arrow.style.left) + "px";
    this._div.style.top = pixel.y - 30 + "px";
}
function customOverlay_Small(options) {
    //初始化参数
    this._latlng = options.latlng; //设置图标位置
    this._id = options.id;
    this._scid = options.scid;
}
customOverlay_Small.prototype = new BMap.Overlay();
//初始化图标
customOverlay_Small.prototype.initialize = function () {
    this._map = map;
    var div = this._div = document.createElement("div");
    div.style.position = "absolute";
    div.style.zIndex = BMap.Overlay.getZIndex(this._latlng.lat);
    div.style.background = "url('/Img/yuansu/smallicon7.gif') no-repeat";
    div.style.color = "white";
    div.style.height = "13px";
    div.style._height = "16px";
    div.style.width = "8px";
    div.style.padding = "2px";
    div.style.fontSize = "12px";
    div.style.cursor = "pointer";
    div.style.whiteSpace = "nowrap";
    div.style.MozUserSelect = "none";
    var that = this;
    //注册div点击事件
    $(div).click(function () {
        closeWinInfo();
        var randomParam = new Date().toString();
        $.get(
            '/map/mapscenic.ashx?t=' + randomParam + '&scid=' + that._scid,
            function (detail_scenic) {
                var ds = eval("(" + detail_scenic + ")");
                infoWindow = new BMap.InfoWindow(InfoWindowContent(ds));
                map.openInfoWindow(infoWindow, that._latlng);
            }
        )
    });
    map.getPanes().labelPane.appendChild(div);
    return div;
}
//绘制图标，主要用于控制图标的位置
customOverlay_Small.prototype.draw = function () {
    var map = this._map;
    var pixel = map.pointToOverlayPixel(this._latlng);
    this._div.style.left = pixel.x - 3 + "px";
    this._div.style.top = pixel.y - 16 + "px";
}

/*返回信息框中的内容*/
function InfoWindowContent(point) {
    var sContent =
        "<div style='width:300px; height:100px;margin:0px; padding:0px;'>" +
        "<div style='width:100px; height:100px; float:left; margin-right:10px;padding:0px; margin-bottom:0px'>" +
            "<a class='mapimg' style=' color:White;margin:0px;padding:0px;width:100%; height:100%;border:0px none White;' href='/Tickets/" + point.areaseoname + "/" + point.scseoname + ".html'><img src='/ScenicImg/small/" + point.img + "' style='width:100%; height:100%;' /></a>" +
        "</div>" +
        "<div style='width:180px; float:left;padding:0px; margin:0px'>" +
        "<div style='margin-top:5px;margin-bottom:0px; padding:0px'><a class='mapname' href='/Tickets/" + point.areaseoname + "/" + point.scseoname + ".html' font-size:14px;'>" + point.name + "</a></div>" +
        "<p style=' padding:0px; margin-top:12px; margin-bottom:0px; font-size:12px;'>级别:<font style=' color:#E49821;'>" + point.level + "</font></p>" +
        "<p style='padding:0px; margin-top:12px; margin-bottom:0px;font-size:12px;'>在线优惠价:<font style='color:Red'>" + point.price + "</font></p>" +
        "<div style='font-size:12px; margin-top:8px;margin-bottom:0px; padding-bottom:0px;'><a class='mapyuding'  href='/Tickets/" + point.areaseoname + "/" + point.scseoname + ".html'>[预定]</a></div>" +
        "</div>" +
        "</div>";
    return sContent;
}
/*分页控件的点击事件*/
function btn(obj) {
    $.cookie("pageindex", obj.title);
    btnshowinfo();
}
/*分页之后右侧显示的内容*/
function btnshowinfo() {
    $("#resultscenic").html("");
    var loadstr = "";
    var sc = 0;
    clearOverlays();
    var begin = (parseInt($.cookie("pageindex")) - 1) * 15; //起始页码
    var numCount = 0;
    for (var k = 0; ; k++) {
        if (allCoordinates[k] == undefined)
            break;
        if (allCoordinates[k].position != null && allCoordinates[k].position != "undefined") {
            numCount++;
            var point = new BMap.Point(allCoordinates[k].position.split(",")[0], allCoordinates[k].position.split(",")[1]);
            var txt = allCoordinates[k].name;
            var scenicid = allCoordinates[k].id;
            var overlay;
            if (numCount <= begin || numCount > begin + 15) {
                overlay = new customOverlay_Small({ latlng: point, id: numCount, scid: scenicid });
                map.addOverlay(overlay);
            }
            else {
                overlay = new customOverlay_Large({ latlng: point, text: txt, id: numCount, scid: scenicid });
                map.addOverlay(overlay);
            }
            overlayMarker.push(overlay);
        }
    }
    for (var i = begin; ; i++) {
        if (sc >= 15)
            break;
        sc++;
        if (allCoordinates[i] == undefined)
            break;
        else if (allCoordinates[i].position == "undefined" || allCoordinates[i].position == null)
            break;
        //loadstr += "<tr><td><font class='num'>" + parseInt(i + 1) + "</font></td><td><a style='cursor: pointer;' onclick='mapscenic(" + allpoint[i].position + ")'>" + allpoint[i].name + " </a> </td><td>" + allpoint[i].level + "</td><td>" + allpoint[i].price + "</td></tr>";
        loadstr += "<div class='scenicinfo'>";
        loadstr += "<span class='sceincnum'>" + parseInt(i + 1) + "</span><span class='spansceincname' onmouseout='changescnamecl2(this)' onmouseover='changescnamecl(this)' onclick='mapscenic(" + allCoordinates[i].id + "," + allCoordinates[i].position + ")'>" + allCoordinates[i].name + "</span><a href='/Scenic/Default.aspx?sname=" + allCoordinates[i].scseoname + "' >[预定]</a>"
        loadstr += "</div>";
    }
    $("#resultscenic").html(loadstr);
}
/*打开指定信息窗口*/
function mapscenic(iwId, lat, lng) {
    var point = new BMap.Point(lat, lng);
    closeWinInfo();
    var randomParam = new Date().toString();
    $.get(
            '/map/mapscenic.ashx?t=' + randomParam + '&scid=' + iwId,
            function (detail_scenic) {
                var ds = eval("(" + detail_scenic + ")");
                infoWindow = new BMap.InfoWindow(InfoWindowContent(ds));
                map.openInfoWindow(infoWindow, point);
            }
        )
}

/*获取url所带参数*/
function QueryString() {
    //构造参数对象并初始化    
    var name, value, i;
    var str = location.href; //获得浏览器地址栏URL串    
    var num = str.indexOf("?")
    str = str.substr(num + 1); //截取“?”后面的参数串    
    var arrtmp = str.split("&"); //将各参数分离形成参数数组    
    for (i = 0; i < arrtmp.length; i++) {
        num = arrtmp[i].indexOf("=");
        if (num > 0) {
            name = arrtmp[i].substring(0, num); //取得参数名称    
            value = arrtmp[i].substr(num + 1); //取得参数值    
            this[name] = value;                    //定义对象属性并初始化    
        }
    }
}