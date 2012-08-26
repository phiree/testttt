<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="example_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script type="text/ecmascript">
        $(function () {
            timedCount();
        });
        var t;
        function timedCount() {
            show();
            t = setTimeout("timedCount()", 5000);
        }
        function show() {
            var a = document.getElementById('aaa');
            var myzp = document.getElementById('zp');
            a.OnTimer();
            var strinfo = a.GetUserInfo();
            var arrys = strinfo.split(',');
            if (arrys.length > 8) {
                document.getElementById("td1").innerHTML = arrys[5];
                document.getElementById("td2").innerHTML = arrys[0];
                document.getElementById("td3").innerHTML = arrys[1];
                document.getElementById("td4").innerHTML = arrys[2];
                document.getElementById("td5").innerHTML = arrys[3];
                document.getElementById("td6").innerHTML = arrys[4];
                document.getElementById("td7").innerHTML = arrys[6];
                document.getElementById("td8").innerHTML = arrys[7];
                document.getElementById("td9").innerHTML = arrys[8];
            }
        }
    </script>
    <object id="aaa" classid="clsid:6c78bcd1-ac43-4fb9-8d89-d9f7b717d025" codebase="/ScenicManager/DONETCAB.cab" >
    </object>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;" border="1" width="100%" bordercolordark="#FFFFFF" cellspacing="0"
            cellpadding="2" bordercolor="#000000">
            <tr>
                <td style="width: 33.3%; text-align: right;">
                    证件号码：
                </td>
                <td style="width: 33.3%" id="td1">
                    &nbsp;
                </td>
                <td style="width: 33.3%; text-align: left;" rowspan="6">
                    <%--<img id="zp" src="D:\zp.bmp" alt="照片" />--%>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    姓名：
                </td>
                <td id="td2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    性别：
                </td>
                <td id="td3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    民族：
                </td>
                <td id="td4">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    出生日期：
                </td>
                <td id="td5">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    地址：
                </td>
                <td id="td6">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    签发机关：
                </td>
                <td id="td7">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    签发时间：
                </td>
                <td id="td8">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    有效截止时间：
                </td>
                <td id="td9">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <input id="Button1" type="button" value="读卡" onclick="Demo();" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div>
        <input type="button" id="ben" onclick='show()' value="显示" />
    </div>
    </form>
</body>
</html>
