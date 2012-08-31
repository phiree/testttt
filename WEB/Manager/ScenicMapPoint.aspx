<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="ScenicMapPoint.aspx.cs" Inherits="Manager_ScenicMapPoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" Runat="Server">
<script type="text/javascript" src="http://api.map.baidu.com/api?v=1.3"></script>
<script type="text/javascript">
    var flagGetData = 0;
    var flagZh = 0;
    var flagTransSQL = 0;
    var zx1 = 0;
    var zx2 = 0;
    function GetAndUpdate() {
        $.ajax({
            type: "get",
            url: "UpdatePosition.ashx?id=2",
            dataType: "json",
            success: function (data, status) {
                var JSON = eval(data);
                for (var i = 0; ; i++) {
                    if (JSON[i] == undefined)
                        break;
                    var add = JSON[i].name;
                    name[count++] = add;
                }
                flagGetData = 1;
            }
        });
    }
    function sss() {
        alert(name.length);
        alert(sendJSON.length);
    }

    function testbtn() {
        for (var i = 0; i < name.length; i++) {
            var myGeo = new BMap.Geocoder();
            myGeo.getPoint(name[i], function (point) {
                if (point) {
                    sendJSON[xx++] = point.lng + "," + point.lat;
                }
                else {
                    sendJSON[xx++] = "";
                }
            }, "浙江省");
        }
        flagZh=1;
    }


    function getposition() {
        var ddd = "";
        for (var i = 0; i < sendJSON.length; i++) {
            ddd += i.toString() + "=" + sendJSON[i] + "&";
        }
        $.ajax({
            type: "post",
            url: "GetPosition.ashx?id=2",
            data: ddd,
            success: function () {
                flagTransSQL = 1;
            }
        });
    }
    var sendJSON = new Array();
    var name = new Array();
    var count = 0;
    var xx = 0;
    function updateposition(obj) {
        var myGeo = new BMap.Geocoder();
        myGeo.getPoint(obj, function (point) {
            if (point) {
                sendJSON[count++] = point.lng + "," + point.lat;
            }
        }, "浙江省");
    }

    function btn_zh() {
        GetAndUpdate();
        timedCount();
    }
    function timedCount() {
        if (flagGetData == 1) {
            if (zx1 == 0) {
                testbtn();
                zx1 = 1;
            }
            if (name.length == sendJSON.length) {
                if (name.length == sendJSON.length) {
                    if (zx2 == 0)
                        getposition();
                    else
                        zx2 = 1;
                    if (flagTransSQL == 1) {
                        $("#statezh").html("转换成功！");
                    }
                }
            }
            else {
                $("#statezh").html("正在转换景区坐标...");
            }
        }
        else {
            $("#statezh").html("正在获取景区信息...");
        }
        t = setTimeout("timedCount()", 1000);
    }



    </script>
    <div>
        <%--<input id="Button1" type="button" value="获取景区信息" onclick="GetAndUpdate()" /><br />
        <input id="Button4" type="button" value="生成坐标" onclick="testbtn()" /><span>生成坐标需要时间，请稍等</span><br />
        <input id="Button3" type="button" value="显示景区数量" onclick="sss();" /><span>第一个为景区数量，第二个为生成的景区坐标数量,两者应该为相同，如果不相同，则刷新页面重新开始第一步</span><br />
        <input id="Button5" type="button" value="提交" onclick="getposition();" /><span>更新数据库坐标</span>--%>
        <input id="zh" type="button" onclick="btn_zh()" value="坐标转换" />
        <div id="statezh">
            显示状态
        </div>
    </div>
</asp:Content>

