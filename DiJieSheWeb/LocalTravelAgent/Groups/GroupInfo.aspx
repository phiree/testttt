<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="GroupInfo.aspx.cs" Inherits="Groups_GroupInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script type="text/javascript">
        //删除行
        function delrow(obj) {
            $(obj).parent().parent().remove();
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
                    团队名称：
                </td>
                <td>
                    <asp:Label ID="lblname" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 15%">
                    开始时间：
                </td>
                <td>
                    <asp:Label ID="lblbegin" runat="server" />
                </td>
                <td>
                    游玩天数：
                </td>
                <td>
                    <asp:Label ID="lbldays" runat="server" />
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
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptMember" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("Memtype")%>
                            </td>
                            <td><%#Eval("Memname")%>
                            </td>
                            <td><%#Eval("Memid")%>
                            </td>
                            <td><%#Eval("Memphone")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
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
                    </td>
                    <td>
                        景点
                    </td>
                    <td>
                        住宿
                    </td>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptRoutes" runat="server" >
                    <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("dayno")%>
                        </td>
                        <td>
                            <%#Eval("scenics")%>
                        </td>
                        <td>
                            <%#Eval("hotels")%>
                        </td>
                    </tr>
                    </ItemTemplate>
                </asp:Repeater>
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
        <asp:Button ID="btnUpload" runat="server" Text="上传并保存" OnClick="btnUpload_Click" />
        <asp:Label ID="Label1" runat="server" />
        <a href="/LocalTravelAgent/Groups/Grouplist.aspx">返回</a>
    </div>
</asp:Content>
