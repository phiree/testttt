var maptype;
var map; //百度地图
var xmlhttprequest;
var scenicpos;
var marker2 = new Array();
var shiji = new Array();
var map2;
var infoWindow;
var points;
var numcount;
var allpoint; //所有的点
function createXMLRequest() {
    if (window.ActiveXObject) {
        return new ActiveXObject("Microsoft.XMLHTTP");
    }
    return new XMLHttpRequest();
}



function check() {
    var url = "/map/map.ashx?type=1";
    xmlhttprequest = createXMLRequest();
    xmlhttprequest.onreadystatechange = ReadyDo;  //ReadyDo是回调函数
    xmlhttprequest.open("GET", url, true);
    xmlhttprequest.send();
}

function check2() {
    var randomParam = new Date().toString();
    var url = "/map/map.ashx?type=2&tP=" + randomParam;
    if ($("[id$='txtSearch']").val() == "请输入您要搜索的景区")
        $.cookie("scname", "");
    else
        $.cookie("scname", $("[id$='txtSearch']").val());
    xmlhttprequest = createXMLRequest();
    xmlhttprequest.onreadystatechange = ReadyDo;  //ReadyDo是回调函数
    xmlhttprequest.open("GET", url, true);
    xmlhttprequest.send();
}

//为了便于查看大图使用
function check3(obj) {
    var url = "/map/SearchBigMap.ashx?scenicid=" + obj;
    xmlhttprequest = createXMLRequest();
    xmlhttprequest.onreadystatechange = ReadyDo;  //ReadyDo是回调函数
    xmlhttprequest.open("GET", url, true);
    xmlhttprequest.send();
}



function findallpoint() {
    var randomParam = new Date().toString();
    var url = "/map/map.ashx?tP=" + randomParam;
    xmlhttprequest = createXMLRequest();
    xmlhttprequest.onreadystatechange = bindallpoint;  //ReadyDo是回调函数
    xmlhttprequest.open("GET", url, true);
    xmlhttprequest.send();
}
function bindallpoint() {
    if (xmlhttprequest.readyState == 4 && xmlhttprequest.status == 200) {
        allpoint = eval("(" + xmlhttprequest.responseText + ")"); //服务器端传回得也是responseText文本格式的数据，通过eval转换为JSON格式的数据
    }
}




function mapscenic(pos, pos2) {
    scenicpos = pos + "," + pos2;
    var randomParam = new Date().toString();
    var url = "/map/mapscenic.ashx?pos=" + pos + "," + pos2+"&tp="+randomParam;
    xmlhttprequest = createXMLRequest();
    xmlhttprequest.onreadystatechange = ReadyDo2;  //ReadyDo是回调函数
    xmlhttprequest.open("GET", url, true);
    xmlhttprequest.send();
}

function ReadyDo2() {
    if (xmlhttprequest.readyState == 4 && xmlhttprequest.status == 200) {
        var JSON = eval("(" + xmlhttprequest.responseText + ")"); //服务器端传回得也是responseText文本格式的数据，通过eval转换为JSON格式的数据
        maptype = $.cookie("maptype");
        if (maptype != "1") { //百度地图
            for (var i = 0; i < map.getOverlays().length; i++) {
                var p;
                if (map.getOverlays()[i].point != null)
                    p = map.getOverlays()[i].point.lng + "," + map.getOverlays()[i].point.lat;
                else
                    p = map.getOverlays()[i]._point.lng + "," + map.getOverlays()[i]._point.lat;
                if (p == scenicpos) {
                    var sContent =
                            "<div style='width:300px; height:100px;margin:0px; padding:0px;'>" +
                            "<div style='width:100px; height:100px; float:left; margin-right:10px;padding:0px; margin-bottom:0px'>" +
                              "<a class='mapimg' style=' color:White;margin:0px;padding:0px;width:100%; height:100%;border:0px none White;' href='/"+JSON[0].areaseoname+"/"+JSON[0].scseoname+".html '><img src='/ScenicImg/" + JSON[0].img + "' style='width:100%; height:100%;' /></a>" +
                            "</div>" +
                            "<div style='width:180px; float:left;padding:0px; margin:0px'>" +
                            "<div style='margin-top:5px;margin-bottom:0px; padding:0px'><a class='mapname' href='/" + JSON[0].areaseoname + "/" + JSON[0].scseoname + ".html' font-size:14px;'>" + JSON[0].name + "</a></div>" +
                            "<p style=' padding:0px; margin-top:12px; margin-bottom:0px; font-size:12px;'>级别:<font style=' color:#E49821;'>" + JSON[0].level + "</font></p>" +
                            "<p style='padding:0px; margin-top:12px; margin-bottom:0px;font-size:12px;'>在线优惠价:<font style='color:Red'>" + JSON[0].price + "</font></p>" +
                            "<div style='font-size:12px; margin-top:8px;margin-bottom:0px; padding-bottom:0px;'><a class='mapyuding'  href='/" + JSON[0].areaseoname + "/" + JSON[0].scseoname + ".html'>[预定]</a></div>" +
                            "</div>" +

                            "</div>";
                    var infoWindow = new BMap.InfoWindow(sContent);  // 创建信息窗口对象
                    map.openInfoWindow(infoWindow, new BMap.Point(JSON[0].position.split(",")[0], JSON[0].position.split(",")[1]));
                    map.centerAndZoom(new BMap.Point(JSON[0].position.split(",")[0], JSON[0].position.split(",")[1]), 15);
                    break;
                }
            }
        }
    }
}

////////////////////////////////////////////////复杂覆盖物
// 复杂的自定义覆盖物1
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
    //    div.style.backgroundColor = "#0978AD";
    //    div.style.border = "1px solid White";
    //    div.style.color = "white";
    //    div.style.height = "15px";
    //    div.style.padding = "1px \0";
    //    div.style.padding = "2px !important";
    //    div.style.lineHeight = "15px";
    //    div.style.whiteSpace = "nowrap";
    div.className = "divicon";
    div.style.MozUserSelect = "none";
    div.style.fontSize = "12px";
    div.id = this._div;
    div.name = this._name;

    //    var span = this._div = document.createElement("span");
    //    //span.innerHTML = "西湖风景区";
    //    span.style.height = "15px";
    //    span.style.float = "left";
    //    span.style.display = "inline-block";
    //    //span.style.width = "15px";
    //    span.style.color = "Black";
    //    span.style.margin = "0px 5px 0px 3px";
    //    span.appendChild(document.createTextNode("100"));

    //    div.appendChild(span);



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
    arrow.style.background = "url('/Img/yuansu/largeicon2.gif') no-repeat";
    arrow.style.position = "absolute";
    arrow.style.width = "14px";
    arrow.style.height = "15px";
    arrow.style.top = "19px";
    arrow.style.left = "10px";
    arrow.style.overflow = "hidden";
    div.appendChild(arrow);

    div.onclick = function () {
        for (var i = 0; ; i++) {
            if (allpoint[i] == undefined)
                break;
            if (allpoint[i].position != null) {
                if (this.name == (allpoint[i].name)) {
                    map.openInfoWindow(infoWindow[i], new BMap.Point(allpoint[i].position.split(",")[0], allpoint[i].position.split(",")[1]));
                    break;
                }

            }
        }
    }
    map.getPanes().labelPane.appendChild(div);

    return div;
}
ComplexCustomOverlay1.prototype.draw = function () {
    var map = this._map;
    var pixel = map.pointToOverlayPixel(this._point);
    this._div.style.left = pixel.x - parseInt(this._arrow.style.left) + "px";
    this._div.style.top = pixel.y - 30 + "px";
}
////////////////////////////////////////////////

////////////////////////////////////////////////复杂覆盖物
// 复杂的自定义覆盖物2
// 复杂的自定义覆盖物
function ComplexCustomOverlay2(point, text, mouseoverText) {
    this._point = point;
    this._text = text;
    this._overText = mouseoverText;
}
ComplexCustomOverlay2.prototype = new BMap.Overlay();
ComplexCustomOverlay2.prototype.initialize = function (map) {
    this._map = map;
    var div = this._div = document.createElement("div");
    div.style.position = "absolute";
    div.style.zIndex = BMap.Overlay.getZIndex(this._point.lat);
    div.style.background = "url('/Img/yuansu/smallicon6.gif') no-repeat";
    //div.style.border = "1px solid #BC3B3A";
    div.style.color = "white";
    div.style.height = "13px";
    div.style._height = "16px";
    div.style.width = "8px";
    div.style.padding = "2px";
    div.style.fontSize = "12px";
    div.style.cursor = "pointer";
    div.style.whiteSpace = "nowrap";
    div.style.MozUserSelect = "none";
    div.name = this._text;
    div.onclick = function () {
        for (var i = 0; ; i++) {
            if (allpoint[i] == undefined)
                break;
            if (allpoint[i].position != null) {
                if (this.name == allpoint[i].name) {
                    map.openInfoWindow(infoWindow[i], new BMap.Point(allpoint[i].position.split(",")[0], allpoint[i].position.split(",")[1]));
                    break;
                }

            }
        }
    }

    map.getPanes().labelPane.appendChild(div);

    return div;
}
ComplexCustomOverlay2.prototype.draw = function () {
    var map = this._map;
    var pixel = map.pointToOverlayPixel(this._point);
    this._div.style.left = pixel.x-3+"px";
    this._div.style.top = pixel.y-16  + "px";
}
////////////////////////////////////





var JSON2;
function ReadyDo() {
    if (xmlhttprequest.readyState == 4 && xmlhttprequest.status == 200) {
        allpoint = eval("(" + xmlhttprequest.responseText + ")"); //服务器端传回得也是responseText文本格式的数据，通过eval转换为JSON格式的数据
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
        

        maptype = $.cookie("maptype");
        infoWindow = new Array();
        points = new Array();
        $("#resultlist").html("");
        if (maptype != "1") {//百度地图
            if (map != undefined) {
                map.clearOverlays();
            }
            else {
                map = new BMap.Map("container");
            }
            map.enableScrollWheelZoom(false);


            map.centerAndZoom("浙江省", 8);
            map.addControl(new BMap.NavigationControl());
            numcount = 0;
            var loadstr = ""; //右边加载的数据

            for (var i = 0; ; i++) {
                if (allpoint[i] == undefined) {
                    break;
                }
                // 创建地址解析器实例
                //var myGeo = new BMap.Geocoder();
                if (allpoint[i].position != null) {
                    numcount++;
                    var point = new BMap.Point(allpoint[i].position.split(",")[0], allpoint[i].position.split(",")[1]);
                    var txt = allpoint[i].name;

                    if (i < 15) {
                        var myCompOverlay1 = new ComplexCustomOverlay1(point, txt, i+1);
                        map.addOverlay(myCompOverlay1);
                        loadstr += "<div class='scenicinfo'>";
                        loadstr += "<span class='sceincnum'>" + ((parseInt($.cookie("pager_currPage")) - 1) * 15 + numcount) + "</span><span class='spansceincname' onclick='mapscenic(" + allpoint[i].position + ")'>" + allpoint[i].name + "</span><a href='/" + allpoint[i].areaseoname + "/" + allpoint[i].scseoname + ".html' >[预定]</a>"
                        loadstr += "</div>"; 
                            
                       // loadstr += "<tr><td><font class='num'>" + ((parseInt($.cookie("pager_currPage")) - 1) * 15 + numcount) + "</font></td><td><a style='cursor: pointer;' onclick='mapscenic(" + allpoint[i].position + ")'>" + allpoint[i].name + " </a> </td><td>" + allpoint[i].level + "</td><td>" + allpoint[i].price + "</td></tr>";
                    
                    }
                    else {
                        var myCompOverlay2 = new ComplexCustomOverlay2(point, txt, i+1);
                        map.addOverlay(myCompOverlay2);
                    }


                    var sContent =
                            "<div style='width:300px; height:100px;margin:0px; padding:0px;'>" +
                            "<div style='width:100px; height:100px; float:left; margin-right:10px;padding:0px; margin-bottom:0px'>" +
                              "<a class='mapimg' style=' color:White;margin:0px;padding:0px;width:100%; height:100%;border:0px none White;' href='/"+allpoint[i].areaseoname+"/"+allpoint[i].scseoname+".html'><img src='/ScenicImg/" + allpoint[i].img + "' style='width:100%; height:100%;' /></a>" +
                            "</div>" +
                            "<div style='width:180px; float:left;padding:0px; margin:0px'>" +
                            "<div style='margin-top:5px;margin-bottom:0px; padding:0px'><a class='mapname' href='/" + allpoint[i].areaseoname + "/" + allpoint[i].scseoname + ".html' font-size:14px;'>" + allpoint[i].name + "</a></div>" +
                            "<p style=' padding:0px; margin-top:12px; margin-bottom:0px; font-size:12px;'>级别:<font style=' color:#E49821;'>" + allpoint[i].level + "</font></p>" +
                            "<p style='padding:0px; margin-top:12px; margin-bottom:0px;font-size:12px;'>在线优惠价:<font style='color:Red'>" + allpoint[i].price + "</font></p>" +
                            "<div style='font-size:12px; margin-top:8px;margin-bottom:0px; padding-bottom:0px;'><a class='mapyuding'  href='/" + allpoint[i].areaseoname + "/" + allpoint[i].scseoname + ".html'>[预定]</a></div>" +
                            "</div>" +

                            "</div>";

                    infoWindow[i] = new BMap.InfoWindow(sContent);  // 创建信息窗口对象     
                }
                map.enableScrollWheelZoom(true);

            }
            $("#resultscenic").html(loadstr);
            $("#countscenic").html($.cookie("numcount"));

        }
    }

}

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

$(document).ready(function () {
    $.cookie("pageindex", "")
    $.cookie("scname", "");
    $.cookie("level", "");
    $.cookie("pager_currPage", "1");
    var strUrl = new QueryString();
    //findallpoint();
    if (strUrl.areaid != undefined) {
        $.cookie("strurlareaid", strUrl.areaid);
    }
    else {
        $.cookie("strurlareaid", "");
    }
    if (strUrl.scenicid != undefined) {
        check3(strUrl.scenicid);
    }
    else {
        check2();
    }

});



function showscenic() {
    var url = "showscenic.ashx";
    $.cookie("scname", $("[id$='txtPosition']").val());
    $.cookie("level", "");
    xmlhttprequest = createXMLRequest();
    xmlhttprequest.onreadystatechange = show;  //ReadyDo是回调函数
    xmlhttprequest.open("GET", url, true);
    xmlhttprequest.send();
}

function show() {
    if (xmlhttprequest.readyState == 4 && xmlhttprequest.status == 200) {
        var JSON = eval("(" + xmlhttprequest.responseText + ")"); //服务器端传回得也是responseText文本格式的数据，通过eval转换为JSON格式的数据
        document.getElementById("showscenic").innerHTML = "";
        for (var i = 0; ; i++) {
            if (JSON[i] == undefined)
                break;
            document.getElementById("showscenic").innerHTML += "<a style='cursor: pointer;' onclick='mapscenic(" + JSON[i].position + ")'>" + JSON[i].name + " </a> <br />";
        }
    }
}
//function ResumeError() {
//    return true;
//}
//window.onerror = ResumeError;


function btn(obj) {
    $.cookie("pageindex", obj.title);
    btnshowinfo();
}

function btnshowinfo() {
    $("#resultscenic").html("");
    //check2();
    var loadstr = "";
    var sc = 0;
    map.clearOverlays();
    var begin = (parseInt($.cookie("pageindex")) - 1) * 15;
    for (var k = 0; ; k++) {
        if (allpoint[k] == undefined)
            break;
        if (allpoint[k].position != null) {
            var point = new BMap.Point(allpoint[k].position.split(",")[0], allpoint[k].position.split(",")[1]);
            var txt = allpoint[k].name;
            var myCompOverlay1 = new ComplexCustomOverlay1(point, txt, k+1);
            var myCompOverlay2 = new ComplexCustomOverlay2(point, txt, k+1);
            if (k < begin || k >= begin + 15)
                map.addOverlay(myCompOverlay2);
            else
                map.addOverlay(myCompOverlay1);
        }
    }
    for (var i = begin; ; i++) {
        if (sc >= 15)
            break;
        sc++;
        if (allpoint[i] == undefined)
            break;
        //loadstr += "<tr><td><font class='num'>" + parseInt(i + 1) + "</font></td><td><a style='cursor: pointer;' onclick='mapscenic(" + allpoint[i].position + ")'>" + allpoint[i].name + " </a> </td><td>" + allpoint[i].level + "</td><td>" + allpoint[i].price + "</td></tr>";
        loadstr += "<div class='scenicinfo'>";
        loadstr += "<span class='sceincnum'>" + parseInt(i + 1) + "</span><span class='spansceincname' onclick='mapscenic(" + allpoint[i].position + ")'>" + allpoint[i].name + "</span><a href='/"+allpoint[i].areaseoname+"/"+allpoint[i].scseoname+".html' >[预定]</a>"
        loadstr += "</div>"; 
    }
    $("#resultscenic").html(loadstr);
}


