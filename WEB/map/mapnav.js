//全局变量
var pos_Mark;//标注在地图的坐标
var map;//页面中饭的地图
var myIcon = new BMap.Icon("http://dev.baidu.com/wiki/static/map/API/examples/images/Mario.png", new BMap.Size(32, 70), {    //小车图片
    //offset: new BMap.Size(0, -5),    //相当于CSS精灵
    imageOffset: new BMap.Size(0, 0)    //图片的偏移量。为了是图片底部中心对准坐标点。
});
var pall=new Array();//地图上形成路径的所有坐标
//创建坐标，实际使用时不需要此方法，坐标通过其他途径获取
function createpostion() {
    $("<input/>", {
        type: "text",
        name: "postion"
    }).appendTo("#posall");
}
//获取坐标，可以使用ajax，也可以直接获取
function getpostion() {
    pos_Mark = new Array();
    $("#posall>input").each(function () {
        var point = new BMap.Point($(this).val().split(",")[0], $(this).val().split(",")[1]);
        pos_Mark.push(point);
        var myCompOverlay1 = new ComplexCustomOverlay1(point, $(this).val().split(",")[2], 0);
        map.addOverlay(myCompOverlay1);
    });
    var driving = new BMap.DrivingRoute(map);    //创建驾车实例
    for (var i = 0; i < pos_Mark.length - 1; i++) {
        var pos_1 = pos_Mark[i];
        var pos_2 = pos_Mark[i + 1];
        driving.search(pos_1,pos_2);
    }

    driving.setSearchCompleteCallback(function () {
        var pts = driving.getResults().getPlan(0).getRoute(0).getPath();    //通过驾车实例，获得一系列点的数组
        for (var i = 0; i < pts.length; i++) {
            pall.push(pts[i]);
        }
        var paths = pts.length;
        var disinfo = driving.getResults().getPlan(0).getDistance();//距离的信息
        var durinfo = driving.getResults().getPlan(0).getDuration(); //路况的信息
        var lab_info = new BMap.Label("距离为" + disinfo + "时间为" + durinfo, { position: pts[parseInt(paths / 2)] }); //放在地图中的距离信息
        var polyline = new BMap.Polyline(pts, { strokeColor: "blue", strokeWeight: 6, strokeOpacity: 0.5 });
        map.addOverlay(polyline);
        map.addOverlay(lab_info);
        map.setViewport(pos_Mark);          //调整到最佳视野
    });
}

//初始化地图
function init() {
    map = new BMap.Map("container");
    map.centerAndZoom(new BMap.Point(120.159033, 30.28376), 8);
    map.addControl(new BMap.NavigationControl());               // 添加平移缩放控件
    map.addControl(new BMap.ScaleControl());                    // 添加比例尺控件
    map.addControl(new BMap.OverviewMapControl());              //添加缩略地图控件
}

$(function () {
    init();
});

var i;
var t;
function run() {
    if (flag == 1) {
        clearTimeout(t);
        map.removeOverlay(carMk);
        carMk = new BMap.Marker(pall[0], { icon: myIcon });
        map.addOverlay(carMk);
        i = 0;
        timecount();
    }
}


function timecount() {
    carMk.setPosition(pall[i]);
    if (i < pall.length) {
        i++;
    }
    t = setTimeout("timecount()", 100);
}











//地图中的坐标样式
function ComplexCustomOverlay1(point, text, id) {
    this._point = point;
    this._text = text;
    this._id = id;
    this._name = text;
}
ComplexCustomOverlay1.prototype = new BMap.Overlay();
ComplexCustomOverlay1.prototype.initialize = function (mapp) {
    this._map = mapp;
    var div = this._div = document.createElement("div");
    div.style.position = "absolute";
    div.style.zIndex = BMap.Overlay.getZIndex(this._point.lat);
    div.className = "divicon";
    div.style.MozUserSelect = "none";
    div.style.fontSize = "12px";
    div.id = this._div;
    div.name = this._name;
    var span = this._span = document.createElement("span");
    //div.appendChild(span);
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
    spanscenic.style.top = "-0px \0";
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
    map.getPanes().labelPane.appendChild(div);
    return div;
}
ComplexCustomOverlay1.prototype.draw = function () {
    var map = this._map;
    var pixel = map.pointToOverlayPixel(this._point);
    this._div.style.left = pixel.x - parseInt(this._arrow.style.left) + "px";
    this._div.style.top = pixel.y - 30 + "px";
}