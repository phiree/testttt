<%@ Page Title="" Language="C#" MasterPageFile="~/Groups/Groups.master" AutoEventWireup="true" CodeFile="GroupInfo.aspx.cs" Inherits="Groups_GroupInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script type="text/javascript">

        function calc() {
            var gid = getArgs("id");
            if (gid == undefined) {
                alert("没有找到相应的团队, 请确定团队编号");
                return;
            }
            var tabledom = $("#tbMember>tbody>tr");
            var result = false;
            var datas = '';
            var djsid = $.cookie('DJSID');
            tabledom.each(function () {
                var memtype = $(this).children().children().html();
                var memname = $(this).children().next().children().html();
                var memid = $(this).children().next().next().children().html();
                var memphone = $(this).children().next().next().next().children().html();
                //var scid = $("input[id*=hidden_scid]").val();
                datas += '{' + memtype + ',' + memname + ',' + memid + ',' + memphone;
            });
            $.ajax({
                type: "Post",
                url: "MemidHandler.ashx",
                dataType: "json",
                data: datas,
                success: function (data, status) {
                    if (data == "成功")
                        alert("修改成功！");
                    else
                        alert("修改失败！");
                }
            });
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
                            debugger;
                            var j = eval(data);
                            //alert(j.Name);
                            $("#txtName").html(j.Name);
                            $("#txtDate").html(j.Bedate);
                            $("#txtDays").html(j.Days);
                            $("#txtPnum").html(j.PeopleTotal);
                            $("#txtPadult").html(j.PeopleAdult);
                            $("#txtPchild").html(j.PeopleChild);
                            $("#txtGether").html(j.StartPlace);
                            $("#txtBack").html(j.EndPlace);
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
//                +"<input onclick='delrow(this)' class='delrow' type='button' style='width: 25px;' value='-' /></td></tr>");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<!-- 基本信息begin -->
<div>
    团队名称：<h6 id="txtName"></h6><br />
    起止时间：<h6 id="txtDate"></h6>
    天数：<h6 id="txtDays"></h6><br />
    人数：<h6 id="txtPnum"></h6>
    成人：<h6 id="txtPadult"></h6>
    儿童：<h6 id="txtPchild"></h6><br />
    上车集合点：<h6 id="txtGether"></h6>
    返程点：<h6 id="txtBack"></h6>
</div>
<!-- 基本信息end -->
<!-- 人员begin -->
<div>
<table class="tableMemberid" id="tbMember">
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
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>
                    <%--<select>
                        <option value='成人游客'>成人游客</option>
                        <option value='儿童游客'>儿童游客</option>
                        <option value='导游'>导游</option>
                        <option value='司机'>司机</option>
                    </select>--%>
                </td>
                <td>
                    <%--<input type='text' />--%>
                </td>
                <td>
                    <%--<input type='text' />--%>
                </td>
                <td>
                    <%--<input type='text' />--%>
                </td>
                <%--<td>
                    <input type='hidden' /><input type='hidden' />
                    <input onclick='delrow(this)' class='delrow' type='button' style='width: 25px;' value='-' />
                </td>--%>
            </tr>
        </tbody>
    </table>
</div>
<!-- 人员end -->
<!-- 行程begin -->
<div>
    <table id="tbRoute">
    <thead>
        <tr>
            <td>日期</td>
            <td>早餐</td>
            <td>中餐</td>
            <td>晚餐</td>
            <td>住宿</td>
            <td>景点</td>
            <td>购物点</td>
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
    <p>
        导入信息操作步骤:
    </p>
    <ol>
        <li>点击“浏览”，选择要导入的excel文件 </li>
        <br />
        注意：确定excel文件中第一行包含：类型，姓名，身份证号，电话号码四个标题
        <li>点击“上传”，将文件上传到服务器 </li>
        <li>点击“导入数据”，将excel内容导入到表格中 </li>
        <li>点击“确定”，存储表格数据 </li>
    </ol>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="btnUpload" runat="server" Text="上传" OnClientClick="return checkEditing();"
        OnClick="btnUpload_Click" />
    <input id="btnExcel" type="button" name="name" value="导入数据" />
    <asp:Label ID="Label1" runat="server" Text="Label" Visible="True"></asp:Label>
    <input type="button" value="保存" onclick="calc()" />
<!-- 操作end -->
</asp:Content>

