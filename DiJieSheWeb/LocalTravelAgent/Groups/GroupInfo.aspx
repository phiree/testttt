<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="GroupInfo.aspx.cs" Inherits="Groups_GroupInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script type="text/javascript">

        function calc() {

            //保存校验
            var tbmem = $("#tbMember>tbody>tr");
            var idvali = true;
            tbmem.each(function () {
                if ($(this).children().next().next().next().next().next().html() != "通过") {
                    idvali = false;
                    alert("请重新导入人员信息，身份证号码有误");
                    return false;
                }
            });
            if (!idvali) {
                return false;
            }

            //保存提示
            var bool = window.confirm("请确定是否需要保存!");
            if (!bool) {
                return false;
            }
            var gid = getArgs("id");
            //            if (gid == undefined) {
            //                alert("没有找到相应的团队, 请确定团队编号");
            //                return;
            //            }

            //新版本 2012-10-10
            //基本信息
            var dateString = $("#txtDate").html();
            var dateArray = dateString.split("-", 2);
            var datas = "";
            var djsid = $.cookie('DJSID');
            datas += "{\"DjsId\":\"" + djsid + "\",";
            datas += "\"GroupBasic\":";
            datas += "{\"Name\":\"" + $("#txtName").html();
            datas += "\",\"Begindate\":\"" + dateArray[0];
            datas += "\",\"Enddate\":\"" + dateArray[1];
            datas += "\",\"GroupNo\":\"" + $("#txtGroupNo").html();
            datas += "\",\"Days\":\"" + $("#txtDays").html();
            datas += "\",\"PeopleTotal\":\"" + $("#txtPnum").html();
            datas += "\",\"PeopleAdult\":\"" + $("#txtPadult").html();
            datas += "\",\"PeopleChild\":\"" + $("#txtPchild").html();
            datas += "\",\"StartPlace\":\"" + $("#txtGether").html();
            datas += "\",\"EndPlace\":\"" + $("#txtBack").html();

            //人员信息
            var tabledom = $("#tbMember>tbody>tr");
            datas += "\"},\"GroupMemberList\":[";
            tabledom.each(function () {
                //alert('tbmem=' + $(this).children().next().html());
                datas += "{\"Memtype\":\"" + $(this).children().html();
                datas += "\",\"Memname\":\"" + $(this).children().next().html();
                datas += "\",\"Memid\":\"" + $(this).children().next().next().html();
                datas += "\",\"Memphone\":\"" + $(this).children().next().next().next().html();
                datas += "\",\"Cardno\":\"" + $(this).children().next().next().next().next().html();
                datas += "\",\"IdValidate\":\"" + $(this).children().next().next().next().next().next().html();
                datas += "\"},";   //最后记得去掉这个,逗号
            });
            datas = datas.substring(0, datas.length - 1) + "]";

            //行程信息
            var tbRoute = $("#tbRoute>tbody>tr");
            datas += ",\"GroupRouteList\":[";
            tbRoute.each(function () {
                datas += "{\"RouteDate\":\"" + $(this).children().html();
                datas += "\",\"Breakfast\":\"" + $(this).children().next().next().html();
                datas += "\",\"Lunch\":\"" + $(this).children().next().next().next().html();
                datas += "\",\"Dinner\":\"" + $(this).children().next().next().next().next().html();

                var hotelString = $(this).children().next().next().next().next().next().html();
                var hotelArray = hotelString.split("-", 5);
                for (var i = 0; i < hotelArray.length; i++) {
                    datas += "\",\"Hotel" + (i + 1) + "\":\"" + hotelArray[i];
                }

                var scString = $(this).children().next().next().next().next().next().next().html();
                var scArray = scString.split("-", 5);
                for (var i = 0; i < scArray.length; i++) {
                    datas += "\",\"Scenic" + (i + 1) + "\":\"" + scArray[i];
                }

                var spString = $(this).children().next().next().next().next().next().next().next().html();
                var spArray = spString.split("-", 5);
                for (var i = 0; i < spArray.length; i++) {
                    datas += "\",\"ShoppingPoint" + (i + 1) + "\":\"" + spArray[i];
                }

                datas += "\"},"; //最后记得去掉这个,逗号
            });
            datas = datas.substring(0, datas.length - 1) + "]}";

            $.ajax({
                type: "Post",
                url: "GroupHandler.ashx",
                dataType: "text",
                data: datas,
                success: function (data, status) {
                    if (data == '成功') {
                        alert("修改成功！");
                        window.navigate("/LocalTravelAgent/Grouplist.aspx");
                    }
                    else
                        alert("修改失败！");
                }
            });

            //           //老版本2012-9-29
            //            var tabledom = $("#tbMember>tbody>tr");
            //            var result = false;
            //            var djsid = $.cookie('DJSID');
            //            tabledom.each(function () {
            //                var memtype = $(this).children().children().html();
            //                var memname = $(this).children().next().children().html();
            //                var memid = $(this).children().next().next().children().html();
            //                var memphone = $(this).children().next().next().next().children().html();
            //                //var scid = $("input[id*=hidden_scid]").val();
            //                datas += '{' + memtype + ',' + memname + ',' + memid + ',' + memphone;
            //            });
            //            $.ajax({
            //                type: "Post",
            //                url: "MemidHandler.ashx",
            //                dataType: "json",
            //                data: datas,
            //                success: function (data, status) {
            //                    if (data == "成功")
            //                        alert("修改成功！");
            //                    else
            //                        alert("修改失败！");
            //                }
            //            });
        }

        //删除行
        function delrow(obj) {
            $(obj).parent().parent().remove();
        }

        //检查是否在编辑状态
        function checkEditing() {
            var body = $("#addrow").parent().parent().parent().next();
            var textboxList = $("table>tbody>tr>td>input:text");
            for (var i = 0; i < textboxList.size(); i++) {
                if ($(textboxList[i]).val() != "") {
                    alert("页面正在编辑中，是否继续导入数据？");
                    return false;
                }
            }
            alert("上传成功, 请导入!");
            return true;
        }

        //加载制定group的数据
        $(function () {
            var gid = getArgs("id");
            if (gid != undefined) {
                $.ajax({
                    type: "Get",
                    url: "MemdataHandler.ashx?id=" + gid,
                    dataType: "text",
                    success: function (data, status) {
                        if (data != "") {
                            var tbody = $("#addrow").parent().parent().parent().next();
                            tbody.html(data);
                        }
                    }
                });
            }
        });

        function getArgs(strParame) {
            var args = new Object();
            var query = location.search.substring(1); // Get query string
            var pairs = query.split("&"); // Break at ampersand
            for (var i = 0; i < pairs.length; i++) {
                var pos = pairs[i].indexOf('='); // Look for "name=value"
                if (pos == -1) continue; // If not found, skip
                var argname = pairs[i].substring(0, pos); // Extract the name
                var value = pairs[i].substring(pos + 1); // Extract the value
                value = decodeURIComponent(value); // Decode it, if needed
                args[argname] = value; // Store as a property
            }
            return args[strParame]; // Return the object
        };

        //导入excel
        $(function () {
            $("#btnExcel").click(function () {
                var datas = "";
                $.ajax({
                    type: "Post",
                    url: "ExcelHandler.ashx?filename=" + $("#<%=Label1.ClientID%>").html(),
                    dataType: "json",
                    data: datas,
                    success: function (data, status) {
                        //var tbody = $("#addrow").parent().parent().parent().next();
                        var tbmember = $("#tbMember>tbody");
                        var tbroute = $("#tbRoute>tbody");
                        if (data == "") {
                            alert('内容已导入!');
                        }
                        else {
                            var j = eval(data);
                            $("#txtGroupNo").html(j.GroupNo);
                            $("#txtName").html(j.Name);
                            $("#txtDate").html(j.Bedate);
                            $("#txtDays").html(j.Days);
                            $("#txtPnum").html(j.PeopleTotal);
                            $("#txtPadult").html(j.PeopleAdult);
                            $("#txtPchild").html(j.PeopleChild);
                            $("#txtGether").html(j.StartPlace);
                            $("#txtBack").html(j.EndPlace);
                            $("#txtForeigners").html(j.Foreigners);
                            $("txtGroupNo").html(j.GroupNo);
                            tbmember.html(j.Member);
                            tbroute.html(j.Route);
                        }
                    }
                });
            });
        });

        //添加行
        $(function () {
            $("#addrow").click(function () {
                var tbody = $(this).parent().parent().parent().next();
                tbody.append("<tr><td>" +
                "</td><td><input type='text' />" +
                "</td><td><input type='text' /></td><td><input type='text' /></td><td><input type='hidden' /><input type='hidden' />");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="detail_titlebg">
        基本信息导入
    </div>
    <!-- 基本信息begin -->
    <div class="detaillist">
        <div class="detailtitle">
            基本信息
        </div>
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 15%">
                    团队编号：
                </td>
                <td>
                    <h6 id="txtGroupNo">
                    </h6>
                </td>
                <td style="width: 15%">
                    团队名称：
                </td>
                <td>
                    <h6 id="txtName">
                    </h6>
                </td>
            </tr>
            <tr>
                <td style="width: 15%">
                    起止时间：
                </td>
                <td>
                    <h6 id="txtDate">
                    </h6>
                </td>
                <td>
                    游玩天数：
                </td>
                <td>
                    <h6 id="txtDays">
                    </h6>
                </td>
            </tr>
            <tr>
                <td>
                    游玩人数：
                </td>
                <td>
                    <h6 id="txtPnum">
                    </h6>
                </td>
                <td>
                    成人人数：
                </td>
                <td>
                    <h6 id="txtPadult">
                    </h6>
                </td>
            </tr>
            <tr>
                <td>
                    儿童人数：
                </td>
                <td>
                    <h6 id="txtPchild">
                    </h6>
                </td>
                <td>
                    外宾人数：
                </td>
                <td>
                    <h6 id="txtForeigners">
                    </h6>
                </td>
            </tr>
            <tr>
                <td>
                    上车集合点：
                </td>
                <td>
                    <h6 id="txtGether">
                    </h6>
                </td>
                <td>
                    返程点：
                </td>
                <td>
                    <h6 id="txtBack">
                    </h6>
                </td>
            </tr>
        </table>
        <!-- 基本信息end -->
        <!-- 人员begin -->
        <div class="detailtitle">
            人员信息
        </div>
        <table class="tableMemberid" id="tbMember" cellpadding="0" cellspacing="0">
            <thead>
                <tr>
                    <td>
                        类型
                    </td>
                    <td>
                        姓名
                    </td>
                    <td>
                        身份证号
                    </td>
                    <td>
                        联系方式
                    </td>
                    <td>
                        证件号
                    </td>
                    <td>
                        证件校验
                    </td>
                </tr>
            </thead>
            <tbody>
                <tr>
                </tr>
            </tbody>
        </table>
        <!-- 人员end -->
        <!-- 行程begin -->
        <div class="detailtitle">
            行程信息
        </div>
        <table id="tbRoute">
            <thead>
                <tr>
                    <td>
                        日期
                    </td>
                    <td>
                        地点
                    </td>
                    <td>
                        早餐
                    </td>
                    <td>
                        中餐
                    </td>
                    <td>
                        晚餐
                    </td>
                    <td>
                        住宿
                    </td>
                    <td>
                        景点
                    </td>
                    <td>
                        购物点
                    </td>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>
    <!-- 行程end -->
    <!-- 操作begin -->
    <hr />
    <input type="hidden" id="hidden_scid" runat="server" />
    <div class="detaillist">
        <p style="margin-left: 5px; margin-top: 5px; margin-bottom: 5px; color: #999999">
            导入信息操作步骤:
        </p>
        <ol style="margin-left: 5px; color: #999999">
            <li>点击“浏览”，选择要导入的excel文件
                <br />
                注意：确定excel文件中第一行包含：类型，姓名，身份证号，电话号码四个标题</li>
            <li>点击“上传”，将文件上传到服务器 </li>
            <li>点击“导入数据”，将excel内容导入到表格中 </li>
            <li>点击“确定”，存储表格数据 </li>
            <li>确保excel正确，保存后无法修改！ </li>
        </ol>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="btnUpload" runat="server" Text="上传" OnClientClick="return checkEditing();"
            OnClick="btnUpload_Click" CssClass="btn" />
        <input id="btnExcel" type="button" name="name" value="导入数据" class="btn" />
        <asp:Label ID="Label1" runat="server" Text="" Style="display: none"></asp:Label>
        <input type="button" value="保存" onclick="return calc()" class="btn" />
        <!-- 操作end -->
    </div>
</asp:Content>
