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
            $(".fu").change(function(){
                $("#selecfile").html($(".fu").val());
            });

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
        新建团队(EXCEL导入)
    </div>
    <div class="drInfo">
        <h1>Excel导入新建团队</h1>
        <div class="drbtn">
            <input type="button" class="but" value="选择文件" /><span id="selecfile">未选择文件</span>
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="fu" />
            <asp:Button ID="btnUpload" runat="server" Text="上传" OnClick="btnUpload_Click" CssClass="but" style="margin-left:200px;" />
        </div>
        <div class="drIntrod">
        点击"选择文件"按钮,从电脑里选择已经保存好的团队信息文件，再点击“上传”,即完成
        </div>
    </div>
    <div class="exdrintro">
        <h3>
            Excel表格导入说明:
        </h3>
        <p>
            1.使用地接社管理专用Excel模板填写团队信息，保存类型：<span style="color:#049286">Excel工作簿(*.xlsx)</span>
        </p>
        <p>
            2.一份表格只能输入一个团队信息
        </p>
        <div class="downloadexcel">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="">下载地接社管理专用Excel模板</asp:HyperLink>
        </div>
    </div>




    <input type="hidden" id="hidden_scid" runat="server" />
        <asp:Label ID="Label1" runat="server" />
</asp:Content>
