<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="ScenicMapPoint.aspx.cs" Inherits="Manager_ScenicMapPoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.3"></script>
  ``<script type="text/javascript"
    src="https://maps.google.com/maps/api/js?sensor=true">
</script>
    <div>
        <%--<input id="Button1" type="button" value="获取景区信息" onclick="GetAndUpdate()" /><br />
        <input id="Button4" type="button" value="生成坐标" onclick="testbtn()" /><span>生成坐标需要时间，请稍等</span><br />
        <input id="Button3" type="button" value="显示景区数量" onclick="sss();" /><span>第一个为景区数量，第二个为生成的景区坐标数量,两者应该为相同，如果不相同，则刷新页面重新开始第一步</span><br />
        <input id="Button5" type="button" value="提交" onclick="getposition();" /><span>更新数据库坐标</span>--%>
        <input id="zh" type="button" onclick="btn_zh(1)" value="baidu坐标转换" />
        <input type="button" onclick="btn_zh(2)" value="google坐标转换" />
        <div>
            正在从地图api获取景区坐标:第<span id="spGetPosition"></span>个
        </div>
        <div id="statezh" style="height:500px;  overflow:scroll;">
        </div>
    </div>
      <script type="text/javascript">
       //供保存的json
          var jsonAllPositions = new Array();
          //所有景区的名称
          var scenicnames = new Array();
          ///循环标志
          var loopIndex = 0;

          function btn_zh(mapType) {
              jsonAllPositions = new Array();
              cenicnames = new Array();
              loopIndex = 0;
              ProgressMessage("开始获取所有景区的名称");
              $.ajax({
                  type: "get",
                  url: "UpdatePosition.ashx?id=2",
                  dataType: "json",
                  success: function (data, status) {
                      var jsonScenics = eval(data);
                      for (var i = 0; i < jsonScenics.length; i++) {
                          if (jsonScenics[i] == undefined)
                              continue;
                          if (jsonScenics[i].name == "" || jsonScenics[i].name + "" == "undefined")
                              continue;

                          scenicnames.push(jsonScenics[i].name);
                      }
                      ProgressMessage("共有景点:" + jsonScenics.length + "个");
                      ProgressMessage("开始获取所有景区坐标");
                      //get position 
                      if (mapType == "1")
                          GetPositionFromBaiduAPI();
                      else
                          GetPositionFromGoogleAPI();
                      flagGetData = 1;
                  }
              });
          }
          //get position from Baiduapi
          function GetPositionFromBaiduAPI() {
              $("#spGetPosition").text(loopIndex+1);
              var scenicName = scenicnames[loopIndex];
              var myGeo = new BMap.Geocoder();
              myGeo.getPoint(scenicName, function (point) {
                  if (point) { jsonAllPositions[loopIndex] = point.lng + "," + point.lat; }

                  else { jsonAllPositions[loopIndex] = ""; ProgressMessage("ERROR:没有获得该景点的信息:" + scenicName); }


                  if (loopIndex >= scenicnames.length-1) {
                      ProgressMessage("获取坐标完成,开始保存");
                      SavePosition();
                  }
                  else {
                      loopIndex++;
                      if (point) { ProgressMessage(scenicName + "的坐标:" + point.lng + "," + point.lat); }

                      GetPositionFromBaiduAPI();
                  }


              }, "浙江省");
          }
          //get position from Googleapi
          function GetPositionFromGoogleAPI() {
              $("#spGetPosition").text(loopIndex + 1);
              var scenicName = scenicnames[loopIndex];
              var myGeo = new google.maps.Geocoder();
              myGeo.geocode({ 'address': scenicName }, function (results, status) {
                  if (status == google.maps.GeocoderStatus.OK) {
                      if (results[0].geometry.location) { jsonAllPositions[loopIndex] = results[0].geometry.location.lng() + "," + results[0].geometry.location.lat(); }

                      else { jsonAllPositions[loopIndex] = ""; ProgressMessage("ERROR:没有获得该景点的信息:" + scenicName); }

                      if (loopIndex >= scenicnames.length - 1) {
                          ProgressMessage("获取坐标完成,开始保存");
                          SavePosition();
                      }
                      else {
                          loopIndex++;
                          if (results[0].geometry.location) { ProgressMessage(scenicName + "的坐标:" + results[0].geometry.location.lng() + "," + results[0].geometry.location.lat()); }

                          GetPositionFromGoogleAPI();
                      }
                  }
                  else {
                      if (loopIndex >= scenicnames.length - 1) {
                          ProgressMessage("获取坐标完成,开始保存");
                          SavePosition();
                      }
                      else {
                          jsonAllPositions[loopIndex] = ""; ProgressMessage("ERROR:没有获得该景点的信息:" + scenicName);
                          loopIndex++;
                          setTimeout("GetPositionFromGoogleAPI()", 1000);
                      }

                  }
              });
          }
          //保存
          function SavePosition() {
              var ddd = "";
              for (var i = 0; i < jsonAllPositions.length; i++) {
                  ddd += i.toString() + "=" + jsonAllPositions[i] + "&";
              }
              $.ajax({
                  type: "post",
                  url: "GetPosition.ashx?id=2",
                  data: ddd,
                  success: function () {
                      ProgressMessage("保存成功");
                      alert("操作完成");
                  }
              });
          }
          //更新信息
          var divStateZh = $("#statezh");
          function ProgressMessage(msg) {
            
              divStateZh.html(divStateZh.html() + "<br/>" + msg);
          }
    </script>
</asp:Content>
