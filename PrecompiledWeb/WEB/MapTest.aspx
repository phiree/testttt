<%@ page language="C#" autoeventwireup="true" inherits="MapTest, App_Web_cpmvgbmq" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.3"></script>
    <script type="text/javascript">
        function createXMLRequest() {
            if (window.ActiveXObject) {
                return new ActiveXObject("Microsoft.XMLHTTP");
            }
            return new XMLHttpRequest();
        }

        var xmlhttprequest;
        function check() {
            var url = "map.ashx";
            xmlhttprequest = createXMLRequest();
            xmlhttprequest.onreadystatechange = ReadyDo;  //ReadyDo是回调函数
            xmlhttprequest.open("GET", url, true);
            xmlhttprequest.send();
        }

        function ReadyDo() {
            if (xmlhttprequest.readyState == 4 && xmlhttprequest.status == 200) {
                var JSON = eval("(" + xmlhttprequest.responseText + ")"); //服务器端传回得也是responseText文本格式的数据，通过eval转换为JSON格式的数据
                var map = new BMap.Map("container");
                map.centerAndZoom(new BMap.Point(120.159033, 30.28376), 11);
                map.addControl(new BMap.NavigationControl());
                var infoWindow = new Array();
                for (var i = 0; i < 2; i++) {
                    if (JSON[i] == undefined)
                        break;
                    // 创建地址解析器实例
                    //var myGeo = new BMap.Geocoder();
                    if (JSON[i].position != null) {
                        var point = new BMap.Point(JSON[i].position.split(",")[0], JSON[i].position.split(",")[1]);
                        //= new BMap.Point(120.159033, 30.28376);
                        var marker = new BMap.Marker(point);
                        map.centerAndZoom(point, 15);
                        map.addOverlay(marker);

                        var sContent =
"<h4 style='margin:0 0 5px 0;padding:0.2em 0'>" + JSON[i].name + "</h4>" +
"<img style='float:right;margin:4px' id='imgDemo' src='ScenicImg/" + JSON[i].img + "' width='139' height='104' title='" + JSON[i].name + "'/>" +
"<p style='margin:0;line-height:1.5;font-size:13px;text-indent:2em'>" + JSON[i].desc + "</p>" +
"</div>";
                        infoWindow[i] = new BMap.InfoWindow(sContent);  // 创建信息窗口对象
                        marker.addEventListener("click", function () {
                            for (var i = 0; ; i++) {
                                var x = this.point.lng + "," + this.point.lat;
                                if (x == JSON[i].position) {
                                    this.openInfoWindow(infoWindow[i]);
                                    break;
                                }
                            }

                            //图片加载完毕重绘infowindow
                            //document.getElementById('imgDemo').onload = function () {
                            //infoWindow.redraw();
                            //}
                        });
                    }
                }
                //                    }, "浙江省");
                // }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input id="Button1" type="button" value="button" onclick="check()" />
    <input id="txtPosition" type="text" value="" />
&nbsp;<div style="width: 100%; height: 550px; border: 1px solid gray" id="container">
    </div>
    </form>
</body>
</html>
