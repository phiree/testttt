<%@ page title="" language="C#" masterpagefile="~/ScenticManager/sm.master" autoeventwireup="true" inherits="ScenticManager_UpdateScenticInfo, App_Web_hlxbshxx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" Runat="Server">
    <title>景区管理员</title>
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.2&amp;services=true"> </script>
    <script src="../Scripts/jquery.cookie.js" type="text/javascript"></script>
<script type="text/javascript">
    function selectimg(url) {
        $("[id$='ScenicImg']").src = $("[id$='FileUpload1']").value;
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="adminright">
        <table>
            <tr>
                <td>景区名称</td>
                <td>
                    <asp:TextBox ID="ScenicName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>等级</td>
                <td>
                    <asp:TextBox ID="ScenicLevel" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>所在区域</td>
                <td>
                    <asp:TextBox ID="ScenicArea" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>验证通过</td>
                <td>
                    <asp:Label ID="IsPass" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td>地址</td>
                <td>
                    <asp:TextBox ID="Address" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>描述</td>
                <td>
                    <asp:TextBox ID="Desc" TextMode="MultiLine" runat="server" Height="76px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>景区图片</td>
                <td>
                    <asp:Image ID="ScenicImg" runat="server" Width="250px" Height="200px" /></td>
            </tr>
            <tr>
                <td>上传景区图片</td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" onchange="selectimg(this)" />
                </td>
            </tr>
            <tr>
                <td>
                    景区位置
                </td>
                <td>
                    <asp:HiddenField ID="hfposition" runat="server" />
        <div style="width: 650px; height: 440px; border: 1px solid gray" id="container">
            
                </div>
                <script type="text/javascript">
                    var map = new BMap.Map("container");            // 创建Map实例
                    var position = $.cookie("unitposition");
                    var point = new BMap.Point(position.split(",")[0], position.split(",")[1]);    // 创建点坐标
                    map.centerAndZoom(point, 15);                     // 初始化地图,设置中心点坐标和地图级别。
                    if (position != "120.159033,30.28376") {
                        $("[id$='hfposition']").val(position);
                        var marker = new BMap.Marker(new BMap.Point(position.split(",")[0], position.split(",")[1]));  // 创建标注
                        map.addOverlay(marker);              // 将标注添加到地图中
                    }
                    map.addEventListener("click", function (e) {
                        //alert(e.point.lng + ", " + e.point.lat);

                    });
                    map.addControl(new BMap.NavigationControl());


                    function search(obj) {
                        var local = new BMap.LocalSearch("杭州市", {
                            renderOptions: {
                                map: map,
                                autoViewport: true,
                                selectFirstResult: false
                            }
                        });
                        local.search(obj.value);
                    }

                    var contextMenu = new BMap.ContextMenu();
                    var txtMenuItem = [
                      {
                          text: '在此添加景区位置',
                          callback: function (p) {
                              map.clearOverlays();
                              var marker = new BMap.Marker(p), px = map.pointToPixel(p);
                              //alert(p.lat+','+p.lng);
                              map.addOverlay(marker);
                              $("[id$='hfposition']").val(p.lng + ',' + p.lat);
                              $.cookie("unitposition", p.lng + ',' + p.lat);
                          }
                      }
                     ];
                    for (var i = 0; i < txtMenuItem.length; i++) {
                        contextMenu.addItem(new BMap.MenuItem(txtMenuItem[i].text, txtMenuItem[i].callback, 100));
                        if (i == 1 || i == 3) {
                            contextMenu.addSeparator();
                        }
                    }
                    map.addContextMenu(contextMenu);
                </script>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnOK" runat="server" Text="确定" onclick="btnOK_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

