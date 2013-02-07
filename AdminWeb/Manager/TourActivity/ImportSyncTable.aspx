<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="ImportSyncTable.aspx.cs" Inherits="Manager_TourActivity_ImportSyncTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="/Scripts/jquery-1.6.4.js" type="text/javascript"></script>
<script>
    var totalRecords = 0;
    var currentRecord = 1;
    function Import() {
        $.get("ImportData_GetDataHander.ashx",
        function (data) {
            //data:获取到的需要处理的数据$_$分隔
            var arrdata = data.split("$_$");
            if (data == "finished") {
                importLog("处理完毕");
                return;
            }
            if (arrdata.length != 8) {
                importLog("参数有误:" + data);
            }
            importLog("开始处理第" + currentRecord + "条:" + data);
            $("#spCurrentIndex").text(currentRecord);
            currentRecord += 1;

            $.get("ImportData_ImportDataHander.ashx",
                {
                    id: arrdata[0],
                    idcardno: arrdata[1],
                    buyTime: arrdata[2],
                    typeid: arrdata[3],
                    ticketCode: arrdata[4],
                    partnerCode: arrdata[5],
                    syncstate: arrdata[6],
                    phone: arrdata[7]
                },
                function (data) {
                    importLog("处理结果:"+data);
                    Import();


                });


        }
        );
    }
    function importLog(content) {
        if (currentRecord % 100 == 0) {
            $("#log").html("");
        }
        $("#log").html($("#log").html() + content + "<br />")
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
<div>信息中心订票数据导入</div>

需要处理的总条数:<%=TotalRecords%><br />
<input type="button"  onclick="Import()" value="测试"/>
正在处理第<span id="spCurrentIndex"></span>条
<div id="log"></div>
</asp:Content>

