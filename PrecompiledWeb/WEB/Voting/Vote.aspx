<%@ page language="C#" autoeventwireup="true" inherits="Voting_Vote, App_Web_cxsm5bsl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <style type="text/css">
        .popupcontent
        {
            position: absolute;
            visibility: hidden;
            overflow: hidden;
            border: 1px solid #CCC;
            background-color: #F9F9F9;
            border: 1px solid #333;
            padding: 5px;
        }
        div table tr td button
        {
            margin-right: 10px;
        }
    </style>
    <script type="text/javascript">
        var baseText = null;
        function showPopup(div, w, h) {
            $("#" + div).css("top", "200px"); //窗口距离浏览器内容区最上方的偏移值
            $("#" + div).css("left", "200px"); //窗口距离浏览器内容区最左边的偏移值
            $("#" + div).css("width", w + "px"); //窗口的宽度
            $("#" + div).css("height", h + "px"); //窗口的高度
            $("#" + div).css("visibility", "visible");
            return false;
        }
        function hidePopup(div) {
            $("#" + div).css("visibility", "hidden");
        }
        function show(divid) {
            $("#errormsg").css("display", "block");
            $("#visitor").css("display", "none");
            $("#register").css("display", "none");
            $("#" + divid).css("display", "block");
        }
        function loginUser() {
            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    document.getElementById("myDiv").innerHTML = xmlhttp.responseText;
                }
            }
            if (document.getElementById("myDiv").innerHTML == "yes") {
                msgconfirm();
            }
            else {
                $("#errormsg").html(xmlhttp.responseText);
            }
            xmlhttp.open("GET", "Vote.aspx?name=" + $("#username") + " && pwd=" + $("#userpsw"), true);
            xmlhttp.send();
        }
        function msgconfirm() {
            hidePopup("logindiv");
            if (isLogin()) {
                $("#confirmdiv").html("姓名:" + $.cookie["username"] + "\n\r 身份证号码:******** \n 投给景区:******"
                + "<input type='button' onclick=''>");
                addVote(null, null, 1, "注册用户");         //--------------修改--------------
            }
            else {
                $("#confirmdiv").html("姓名:" + $("#visitorname").val()
                + "\n 身份证号码:" + $("#visitorid").val() + "\n 联系方式:" + $("#visitorphone").val()
                + " \n 投给景区:");
                addVote($("#visitorid").val(), 1, 1, "游客"); //--------------修改--------------
            }
            showPopup("confirmdiv", 270, 140);
            $("#confirmdiv").fadeOut(2000);
        }

        function addVote(idcard, scenicid, num, type) {
            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    document.getElementById("myDiv").innerHTML = xmlhttp.responseText;
                }
            }
            xmlhttp.open("GET", "Vote.aspx?idcard=" + idcard + "&&scenicid=" + scenicid
            + "&&num=" + num + "&&type=" + type, true);
            xmlhttp.send();
            if (document.getElementById("myDiv").innerHTML == "voteok") {
                alert("ok");
            }
            else {
                alert($("#myDiv").val());
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:LoginName ID="LoginName1" runat="server" />
            <asp:LoginStatus ID="LoginStatus1" runat="server" />
            <br />
            <p>
                拥有的总票数<span><asp:Label ID="lblTotalVotes" Text="0" runat="server" /></span></p>
            <p>
                已经使用票数<span><asp:Label ID="lblUsedVotes" Text="0" runat="server" /></span></p>
        </div>
        <br />
    </div>
    <div id="myDiv" style="display: none">
    </div>
    <div class="popupcontent" id="logindiv">
        <div>
            <span onclick="show('register')">登陆</span><span onclick="show('visitor')">游客</span></div>
        <hr />
        <div>
            <div id="visitor" style="display: none">
                <table>
                    <tr>
                        <td>
                            姓名:
                        </td>
                        <td>
                            <input type="text" id="visitorname" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            身份证:
                        </td>
                        <td>
                            <input type="text" id="visitorid" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            联系电话:
                        </td>
                        <td>
                            <input type="text" id="visitorphone" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <input type="button" value="关闭" style="float: right" onclick="hidePopup()" />
                            <input type="button" value="确定" style="float: right" onclick="msgconfirm()" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="register" style="display: block">
                <div id="errormsg" style="display: block">
                </div>
                <table>
                    <tr>
                        <td>
                            用户名:
                        </td>
                        <td>
                            <input type="text" id="username" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            密码:
                        </td>
                        <td>
                            <input type="text" id="userpsw" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <input type="button" value="关闭" style="float: right" onclick="hidePopup()" />
                            <input type="button" value="确定" style="float: right" onclick="loginUser()" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div class="popupcontent" id="confirmdiv">
    </div>
    </form>
    <p>
        &nbsp;</p>
    <p>
        c</p>
</body>
</html>
