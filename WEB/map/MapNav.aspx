<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapNav.aspx.cs" Inherits="map_MapNav" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.2"></script>
    <script src="/Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="/map/mapnav.js" type="text/javascript"></script>

    <link rel="stylesheet" type="text/css" href="../Styles/page.css" />
    <link href="/theme/default/css/map.css" rel="stylesheet" type="text/css" />
    <%--<script type="text/javascript">
        var dd = "";
        var ss = "";
        var flag = 0;
        var xzzd = 0;
        var pall = new Array();
        var carMk;
        var map; //页面中饭的地图
        $(function () {
            map = new BMap.Map("container");
            map.centerAndZoom(new BMap.Point(120.159033, 30.28376), 8);
            map.addControl(new BMap.NavigationControl());               // 添加平移缩放控件
            map.addControl(new BMap.ScaleControl());                    // 添加比例尺控件
            map.addControl(new BMap.OverviewMapControl());              //添加缩略地图控件
            //var driving = new BMap.DrivingRoute(map, { renderOptions: { map: map, panel: "results", autoViewport: true} });
            var driving = new BMap.DrivingRoute(map);    //创建驾车实例
            var myP1 = new BMap.Point(120.129915, 30.253567);    //
            var myP2 = new BMap.Point(120.154138, 30.235483);    //
            var myP3 = new BMap.Point(119.989839, 30.152772);    //

            driving.search(myP1, myP2);                 //第一个驾车搜索


            driving.setSearchCompleteCallback(function () {
                var pts = driving.getResults().getPlan(0).getRoute(0).getPath();    //通过驾车实例，获得一系列点的数组
                //alert(pts.length);
                for (var i = 0; i < pts.length; i++) {
                    pall.push(pts[i]);
                }
                //alert(pall.length);
                var paths = pts.length;
                dd = driving.getResults().getPlan(0).getDistance();
                ss = driving.getResults().getPlan(0).getDuration();
                var polyline = new BMap.Polyline(pts, { strokeColor: "blue", strokeWeight: 6, strokeOpacity: 0.5 });
                map.addOverlay(polyline);

                var m1 = new BMap.Marker(myP1);         //创建3个marker
                var m2 = new BMap.Marker(myP2);
                var m3 = new BMap.Marker(myP3);
                map.addOverlay(m1);
                map.addOverlay(m2);
                map.addOverlay(m3);
                if (flag == 0) {
                    var lab2 = new BMap.Label("途径点", { position: myP2 });
                    var lab22 = new BMap.Label("从起点到中途点的距离为" + dd + "时间为" + ss, { position: pts[parseInt(paths / 2)] });
                }
                var lab1 = new BMap.Label("起点", { position: myP1 });        //创建3个label
                if (flag == 1) {
                    var lab3 = new BMap.Label("终点", { position: myP3 });
                    var lab33 = new BMap.Label("从中途点到终点的距离为" + dd + "时间为" + ss, { position: pts[parseInt(paths / 2)] });
                }

                map.addOverlay(lab1);
                map.addOverlay(lab2);
                map.addOverlay(lab22);
                map.addOverlay(lab3);
                map.addOverlay(lab33);

                map.setViewport([myP1, myP2, myP3]);          //调整到最佳视野
                if (flag == 0) {
                    driving.search(myP2, myP3);                 //第二个驾车搜索
                }

                flag = 1;
            });

        });

        var myIcon = new BMap.Icon("http://dev.baidu.com/wiki/static/map/API/examples/images/Mario.png", new BMap.Size(32, 70), {    //小车图片
            //offset: new BMap.Size(0, -5),    //相当于CSS精灵
            imageOffset: new BMap.Size(0, 0)    //图片的偏移量。为了是图片底部中心对准坐标点。
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
    </script>--%>
</head>
<body>
    <div style="width: 80%; height: 550px; border: 1px solid gray; float: left" id="container">
    </div>
    <div id="posall" style="width: 15%; float: left">
        <input type="text" value="" name="postion" />
    </div>
    <input type='button' value='增加' onclick='createpostion()' />
    <input type='button' value='标注' onclick='getpostion()' />
    <input type='button' value='开始' onclick='run();' />
</body>
</html>
