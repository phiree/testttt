<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="GroupMemberid.aspx.cs" Inherits="LocalTravelAgent_GroupMemberid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        function calc() {
            var tabledom = $("tbody>tr");
            var result = true;
            var datas = '';
            tabledom.each(function () {
                var ticketname = $(this).children().children().val();
                var yuanjia = $(this).children().next().children().val();
                var xianfujia = $(this).children().next().next().children().val();
                var zaixianjia = $(this).children().next().next().next().children().val();
                var ticketid = $(this).children().next().next().next().next().children().val();
                var scid = $("input[id*=hidden_scid]").val();
                datas += '{' + ticketname + ',' + yuanjia + ',' + xianfujia + ',' + zaixianjia + ',' + ticketid + ',' + scid;
            });
            $.ajax({
                type: "Post",
                url: "TicketPriceHandler.ashx",
                dataType: "json",
                data: datas,
                success: function (data, status) {
                }
            });
            if (result)
                alert("修改成功！");
            else
                alert("修改失败！");
            //return false;
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

        //导入excel
        $(function () {
            $("#btnExcel").click(function () {
                var datas = "";
                $.ajax({
                    type: "Post",
                    url: "ExcelHandler.ashx?filename=" + fullname,
                    dataType: "text",
                    data: datas,
                    success: function (data, status) {
                        var tbody = $("#addrow").parent().parent().parent().next();
                        tbody.html(data);
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table class="tableMemberid" id="tptable">
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
    <input type="button" value="确定" onclick="calc()" />
    <input type="hidden" id="hidden_scid" runat="server" />
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="btnUpload" runat="server" Text="上传" OnClientClick="return checkEditing();"
        OnClick="btnUpload_Click" />
    <input id="btnExcel" type="button" name="name" value="导入数据" />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
