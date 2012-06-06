<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="ScenicMapPoint.aspx.cs" Inherits="Manager_ScenicMapPoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" Runat="Server">
<script type="text/javascript">
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
                    //                        if (add == null || add == undefined || add == "") {
                    //                            sendJSON[count++] = "";
                    //                        }
                    //                        else {
                    //                            updateposition(add);
                    //                        }
                }

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
    }


    function getposition() {
        var ddd = "";
        for (var i = 0; i < sendJSON.length; i++) {
            ddd += i.toString() + "=" + sendJSON[i] + "&";
        }
        $.ajax({
            type: "post",
            url: "GetPosition.ashx?id=2",

            data: ddd
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
    </script>
    <div>
        <input id="Button1" type="button" value="获取景区信息" onclick="GetAndUpdate()" /><br />
        <input id="Button4" type="button" value="生成坐标" onclick="testbtn()" /><span>生成坐标需要时间，请稍等</span><br />
        <input id="Button3" type="button" value="显示景区数量" onclick="sss();" /><span>第一个为景区数量，第二个为生成的景区坐标数量,两者应该为相同，如果不相同，则刷新页面重新开始第一步</span><br />
        <input id="Button5" type="button" value="提交" onclick="getposition();" /><span>更新数据库坐标</span>
    </div>
</asp:Content>

