/*变量申明*/
var allCoordinates; //页面目前所查询出来的坐标
var map; //google地图变量
var overlayMarker = new Array(); //地图覆盖物
var numcount; //右侧编码序号
var infoWindow; //内容页集合
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
    if (strUrl.scenicid != undefined) {
        //带有地区的页面查询
        getCoordinatesNotScId(strUrl.scenicid);
    }
    else {
        //不带有地区的页面查询
        getCoordinatesNotScId(null);
    }
});
/*不带有地区id的查询方法*/
function getCoordinatesNotScId(scid) {
    //显示加载提示
    $(".loaddiv").css("display", "block");
    var randomParam = new Date().toString();
    var url;
    if(scid==null)
        url = "/map/map.ashx?type=2&tP=" + randomParam;
    else
        url = "/map/SearchBigMap.ashx?scenicid=" + scid;
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
                var latlng = new google.maps.LatLng(30.303563, 120.141175);
                var myOptions = {
                    zoom: 8,
                    center: latlng,
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                };
                numcount = 0;
                infoWindow = new Array();
                map = new google.maps.Map(document.getElementById("container"), myOptions);
            }
            numcount=0;
            var loadstr = ""; //右边加载的数据
            for (var i = 0; ; i++) {
                if (allCoordinates[i] == undefined)
                    break;
                if (allCoordinates[i].position != null) {
                    numcount++;
                    var point = new google.maps.LatLng(allCoordinates[i].position.split(",")[1], allCoordinates[i].position.split(",")[0]);
                    var txt = allCoordinates[i].name;
                    var overlay;
                    if (numcount <= 15) {
                        overlay = new customOverlay_Large(map, { latlng: point, text: txt, id: i + 1 });
                        loadstr += "<div class='scenicinfo'>";
                        loadstr += "<span class='sceincnum'>" + ((parseInt($.cookie("pager_currPage")) - 1) * 15 + numcount) + "</span><span onmouseover='changescnamecl(this)' onmouseout='changescnamecl2(this)' class='spansceincname' onclick='mapscenic(" + i + ")'>" + allCoordinates[i].name + "</span><a href='/Tickets/" + allCoordinates[i].areaseoname + "/" + allCoordinates[i].scseoname + ".html' >[预定]</a>"
                        loadstr += "</div>";
                    }
                    else {
                        overlay = new customOverlay_Small(map, { latlng: point, id: i + 1 });
                    }
                    overlayMarker.push(overlay);
                    infoWindow[i] = new google.maps.InfoWindow({
                        content: InfoWindowContent(allCoordinates[i]),
                        position: point
                    });
                }
            }

            $("#resultscenic").html(loadstr);
            $("#countscenic").html($.cookie("numcount"));
            //加载完关闭加载图片
            $(".loaddiv").css("display", "none");
            //添加一个地图加载完毕的事件监听
            google.maps.event.addListener(map, "tilesloaded", function () {
                //加载完关闭加载图片
                $(".loaddiv").css("display", "none");
                //为了兼容crome和ff的不兼容，不添加讲无法点击图标，具体原因不详
                var condiv = $(".divicon").parent().parent();
                $(condiv).css("z-index", "202");
            });
        }
    );
}

/*辅助方法*/
/*去除地图上的所有覆盖物*/
function clearOverlays() {
    for (var i = 0; i < overlayMarker.length; i++) {
        overlayMarker[i].setMap(null);
    }
    overlayMarker.length = 0;

}
/*关闭所有的窗口*/
function closeWinInfo() {
    for (var i = 0; i < infoWindow.length; i++) {
        infoWindow[i].close();
    }
}
/*创建google自定义覆盖物*/
function customOverlay_Large(map, options) {
    //初始化参数
    this._latlng = options.latlng; //设置图标位置
    this._text = options.text;
    this._id = options.id;
    this._map = map;
    this._div = null;
    this.setMap(map);
}
customOverlay_Large.prototype = new google.maps.OverlayView();
//初始化图标
customOverlay_Large.prototype.onAdd = function () {
    var that = this;
    var div = document.createElement("div"); //创建存放文字的div
    div.style.position = "absolute";
    div.style.zIndex = '1';
    div.className = "divicon";
    div.style.MozUserSelect = "none";
    div.style.fontSize = "12px";
    var span = document.createElement("span"); //创建序号span
    div.appendChild(span);
    span.style.height = "15px";
    div.style.cursor = "pointer";
    span.style.display = "inline-block";
    span.style.color = "Black";
    span.style.margin = "0px 5px 2px 3px";
    span.appendChild(document.createTextNode(this._id));
    var spanscenic = document.createElement("span"); //创建文字标题
    div.appendChild(spanscenic);
    spanscenic.height = "15px";
    spanscenic.style.position = "relative";
    spanscenic.style.top = "-2px \0";
    spanscenic.style.display = "inline-block";
    spanscenic.style.lineHeight = "15px";
    spanscenic.style.color = "White";
    spanscenic.appendChild(document.createTextNode(this._text));
    var arrow = document.createElement("div"); //三角形图标
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
        var index = that._id;
        infoWindow[index - 1].open(map);
    });
    this._div = div;
    var panes = this.getPanes();
    panes.overlayLayer.appendChild(div);
}
//绘制图标，主要用于控制图标的位置
customOverlay_Large.prototype.draw = function () {
    var overlayProjection = this.getProjection();
    var position = overlayProjection.fromLatLngToDivPixel(this._latlng); //将地图坐标转换成屏幕坐标
    var div = this._div;
    div.style.left = position.x - 5 + 'px';
    div.style.top = position.y - 5 + 'px';
}
//增加一个删除图标属性
customOverlay_Large.prototype.onRemove = function () {
    this._div.parentNode.removeChild(this._div);
    this._div = null;
}
function customOverlay_Small(map, options) {
    //初始化参数
    this._latlng = options.latlng; //设置图标位置
    this._map = map;
    this._div = null;
    this._id = options.id;
    this.setMap(map);
}
customOverlay_Small.prototype = new google.maps.OverlayView();
//初始化图标
customOverlay_Small.prototype.onAdd = function () {
    var that = this;
    var div = document.createElement("div"); //创建存放文字的div
    div.style.position = "absolute";
    div.style.zIndex = '1';
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
    //注册div点击事件
    $(div).click(function () {
        closeWinInfo();
        var index = that._id;
        infoWindow[index - 1].open(map);
    });
    this._div = div;
    var panes = this.getPanes();
    panes.overlayLayer.appendChild(div);
}
//绘制图标，主要用于控制图标的位置
customOverlay_Small.prototype.draw = function () {
    var overlayProjection = this.getProjection();
    var position = overlayProjection.fromLatLngToDivPixel(this._latlng); //将地图坐标转换成屏幕坐标
    var div = this._div;
    div.style.left = position.x - 5 + 'px';
    div.style.top = position.y - 5 + 'px';
}
//增加一个删除图标属性
customOverlay_Small.prototype.onRemove = function () {
    this._div.parentNode.removeChild(this._div);
    this._div = null;
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
        if (allCoordinates[k].position != null) {
            numCount++;
            var point = new google.maps.LatLng(allCoordinates[k].position.split(",")[1], allCoordinates[k].position.split(",")[0]);
            var txt = allCoordinates[k].name;
            var overlay;
            if (numCount < begin || numCount >= begin + 15)
                overlay = new customOverlay_Small(map, { latlng: point, id: k + 1 });
            else
                overlay = new customOverlay_Large(map, { latlng: point, text: txt, id: k + 1 });
            overlayMarker.push(overlay);
        }
    }
    for (var i = begin; ; i++) {
        if (sc >= 15)
            break;
        sc++;
        if (allCoordinates[i] == undefined)
            break;
        //loadstr += "<tr><td><font class='num'>" + parseInt(i + 1) + "</font></td><td><a style='cursor: pointer;' onclick='mapscenic(" + allpoint[i].position + ")'>" + allpoint[i].name + " </a> </td><td>" + allpoint[i].level + "</td><td>" + allpoint[i].price + "</td></tr>";
        loadstr += "<div class='scenicinfo'>";
        loadstr += "<span class='sceincnum'>" + parseInt(i + 1) + "</span><span class='spansceincname' onmouseout='changescnamecl2(this)' onmouseover='changescnamecl(this)' onclick='mapscenic(" + i + ")'>" + allCoordinates[i].name + "</span><a href='/Tickets/" + allCoordinates[i].areaseoname + "/" + allCoordinates[i].scseoname + ".html' >[预定]</a>"
        loadstr += "</div>";
    }
    $("#resultscenic").html(loadstr);
}
/*打开指定信息窗口*/
function mapscenic(iwId) {
    var index = iwId;
    infoWindow[index].open(map);
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