<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="GroupInfo.aspx.cs" Inherits="Groups_GroupInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script type="text/javascript">
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
                    url: "ExcelHandler.ashx?djsid="+ <%=DJSId %>+"&filename=" + $("#<%=Label1.ClientID%>").html(),
                    dataType: "text",
                    data: datas,
                    success: function (data, status) {
                        var splititems = data.split(":");
                        window.location="/LocalTravelAgent/Groups/GroupDetail.aspx?id=" + splititems[1];
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
                    港澳台人数：
                </td>
                <td>
                    <h6 id="txtGangaotais">
                    </h6>
                </td>
                <td>
                    上车集合点：
                </td>
                <td>
                    <h6 id="txtGether">
                    </h6>
                </td>
            </tr>
            <tr>
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
        </ol>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="btnUpload" runat="server" Text="上传" OnClientClick="return checkEditing();"
            OnClick="btnUpload_Click" CssClass="btn" />
        <input id="btnExcel" type="button" name="name" value="导入数据" class="btn" />
        <asp:Label ID="Label1" runat="server" Text="" Style="display: none"></asp:Label>
        <!-- 操作end -->
    </div>
</asp:Content>
