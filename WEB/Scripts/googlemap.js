function createXMLRequest() {
    if (window.ActiveXObject) {
        return new ActiveXObject("Microsoft.XMLHTTP");
    }
    return new XMLHttpRequest();
}

var xmlhttprequest;
function check() {
    var url = "map.ashx?type=1";
    xmlhttprequest = createXMLRequest();
    xmlhttprequest.onreadystatechange = ReadyDo;  //ReadyDo是回调函数
    xmlhttprequest.open("GET", url, true);
    xmlhttprequest.send();
}

function check2() {
    var url = "map.ashx?type=2";
    $.cookie("scname", $("[id$='txtPosition']").val());
    $.cookie("level", $("[id$='Level']").val());
    xmlhttprequest = createXMLRequest();
    xmlhttprequest.onreadystatechange = ReadyDo;  //ReadyDo是回调函数
    xmlhttprequest.open("GET", url, true);
    xmlhttprequest.send();
}

var scenicpos;
function mapscenic(pos, pos2) {
    scenicpos = pos + "," + pos2;
    var url = "/map/mapscenic.ashx?pos=" + pos + "," + pos2;
    xmlhttprequest = createXMLRequest();
    xmlhttprequest.onreadystatechange = ReadyDo2;  //ReadyDo是回调函数
    xmlhttprequest.open("GET", url, true);
    xmlhttprequest.send();
}


function ReadyDo2() {
    if (xmlhttprequest.readyState == 4 && xmlhttprequest.status == 200) {
        var JSON = eval("(" + xmlhttprequest.responseText + ")"); //服务器端传回得也是responseText文本格式的数据，通过eval转换为JSON格式的数据
        for (var i = 0; i < marker.length; i++) {
            var p = shiji[i].position.split(",")[0] + "," + shiji[i].position.split(",")[1];
            if (p == scenicpos) {
                var sContent =
                        "<div>" +
"<h4 style='margin:0 0 5px 0;padding:0.2em 0'>" + "<a href='../Scenic/?id=" + JSON[0].id + "'>" + JSON[0].name + "</a></h4>" +
"<img style='float:right;margin:4px' id='imgDemo' src='ScenicImg/" + JSON[0].img + "' width='139' height='104' title='" + JSON[0].name + "'/>" +
"<p style='margin:0;line-height:1.5;font-size:13px;text-indent:2em'>" + JSON[0].desc + "</p>" +
"</div>";
                var infoWindow = new google.maps.InfoWindow({ content: sContent });  // 创建信息窗口对象
                infoWindow.open(map2, marker[i]);
                map2.setCenter(new google.maps.LatLng(JSON[0].position.split(",")[1], JSON[0].position.split(",")[0]), 15);
            }
        }
    }
}



var marker = new Array();
var shiji = new Array();
var map2;
function ReadyDo() {
    if (xmlhttprequest.readyState == 4 && xmlhttprequest.status == 200) {
        var JSON = eval("(" + xmlhttprequest.responseText + ")"); //服务器端传回得也是responseText文本格式的数据，通过eval转换为JSON格式的数据
        var myLatlng = new google.maps.LatLng(30.28376, 120.159033);
        var myOptions = {
            zoom: 11,
            center: myLatlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        map2 = new google.maps.Map(document.getElementById("container"), myOptions);
        var infoWindow = new Array();
        var markerpos = new Array();
        map2.setCenter(new google.maps.LatLng(30.28376, 120.159033), 11);
        var infoWindow = new Array();

        for (var i = 0, j = 0; ; i++) {
            if (JSON[i] == undefined)
                break;
            // 创建地址解析器实例
            //var myGeo = new BMap.Geocoder();
            if (JSON[i].position != null) {
                var myLatlng = new google.maps.LatLng(JSON[i].position.split(",")[1], JSON[i].position.split(",")[0])
                //= new BMap.Point(120.159033, 30.28376);
                marker[i] = new google.maps.Marker({ position: myLatlng, map: map2, title: "" });
                markerpos[i] = marker[i].position;
                shiji[i] = JSON[i];
                map2.setCenter(myLatlng, 15);
            }

            var sContent =
                    "<div>" +
"<h4 style='margin:0 0 5px 0;padding:0.2em 0'>" + "<a href='../Scenic/?id=" + JSON[i].id + "'>" + JSON[i].name + "</a></h4>" +
"<img style='float:right;margin:4px' id='imgDemo' src='ScenicImg/" + JSON[i].img + "' width='139' height='104' title='" + JSON[i].name + "'/>" +
"<p style='margin:0;line-height:1.5;font-size:13px;text-indent:2em'>" + JSON[i].desc + "</p>" +
"</div>";
            infoWindow[i] = new google.maps.InfoWindow({ content: sContent });   // 创建信息窗口对象

            if (JSON[i].position != null) {
                google.maps.event.addListener(marker[i], 'click',
                     function () {
                         for (var i = 0; ; i++) {
                             if (markerpos[i] == this.position) {
                                 map2.setCenter(new google.maps.LatLng(this.position.Ta, this.position.Ua), 11);
                                 infoWindow[i].open(map2, marker[i]);
                                 break;
                             }
                         }
                     });
            }
            map2.setCenter(new google.maps.LatLng(30.28376, 120.159033), 10);

        }
    }
}
window.onload = check;
    