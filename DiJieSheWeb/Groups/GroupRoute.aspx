<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true" CodeFile="GroupRoute.aspx.cs" Inherits="LocalTravelAgent_GroupRoute" %>

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
            var tabledom = $("tbody>tr");
            var result = false;
            var datas = '';
            var djsid = $.cookie('DJSID');
            tabledom.each(function () {
                var memtype = $(this).children().children().val();
                var memname = $(this).children().next().children().val();
                var memid = $(this).children().next().next().children().val();
                var memphone = $(this).children().next().next().next().children().val();
                //var scid = $("input[id*=hidden_scid]").val();
                datas += '{' + memtype + ',' + memname + ',' + memid + ',' + memphone;
            });
            $.ajax({
                type: "Post",
                url: "MemidHandler.ashx",
                dataType: "text",
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
                    dataType: "text",
                    data: datas,
                    success: function (data, status) {
                        var tbody = $("#addrow").parent().parent().parent().next();
                        if (data == "") {
                            alert('内容已导入!');
                        }
                        else {
                            tbody.html(data);
                        }
                    }
                });
            });
        });

        //添加行
        $(function () {
            $("#addrow").click(function () {
                var tbody = $(this).parent().parent().parent().next();
                tbody.append("<tr><td><select>" +
                "<option value='成人游客'>成人游客</option><option value='儿童游客'>儿童游客</option><option value='导游'>导游</option><option value='司机'>司机</option></select>" +
                "</td><td><input type='text' />" +
                "</td><td><input type='text' /></td><td><input type='text' /></td><td><input type='hidden' /><input type='hidden' />" +
                "<input onclick='delrow(this)' class='delrow' type='button' style='width: 25px;' value='-' /></td></tr>");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table class="tableMemberid" id="tptable">
        <thead>
            <tr>
                <td>
                    日期
                </td>
                <td>
                    活动
                </td>
                <td>
                    活动地点
                </td>
                <td>
                    联系方式
                </td>
                <td>
                    <input id="addrow" type="button" style="width: 25px;" value="+" />
                </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>
                    <select>
                        <option value='成人游客'>成人游客</option>
                        <option value='儿童游客'>儿童游客</option>
                        <option value='导游'>导游</option>
                        <option value='司机'>司机</option>
                    </select>
                </td>
                <td>
                    <input type='text' />
                </td>
                <td>
                    <input type='text' />
                </td>
                <td>
                    <input type='text' />
                </td>
                <td>
                    <input type='hidden' /><input type='hidden' />
                    <input onclick='delrow(this)' class='delrow' type='button' style='width: 25px;' value='-' />
                </td>
            </tr>
        </tbody>
    </table>
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
    <asp:Button ID="btnNext" Text="下一步" runat="server" OnClick="btnNext_Click" />
</asp:Content>

