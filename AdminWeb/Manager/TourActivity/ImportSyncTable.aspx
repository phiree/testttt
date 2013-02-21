<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="ImportSyncTable.aspx.cs" Inherits="Manager_TourActivity_ImportSyncTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/theme/bp/screen.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <div class="notice">
        <div class="notice">
            <span>是否使用存储过程:</span><span class="alert"><%=SiteConfig.ImportUsingProc %></span>
        </div>
        <div class="notice">
            <span>使用的远程数据库:</span><span class="alert"><%=SiteConfig.SyncServerConnection %></span>
        </div>
        <div class="notice">
            <span>使用的同步表名:</span><span class="alert"><%=SiteConfig.SyncTableName %></span>
        </div>
    </div>
    <div>
        信息中心订票数据导入</div>
    需要处理的总条数:<%=TotalRecords%><br />
    <input type="button" onclick="Import()" value="开始导入" />
    正在处理第<span id="spCurrentIndex"></span>条 
    开始时间<div id="spBeginTime">
    </div>
    结束时间<div id="spEndTime">
    </div>
    <div id="log">
    </div>
    <script type="text/javascript" language="javascript">
        var totalRecords = 0;
        var currentRecord = 1;
        var executeTimes = 1;
        //两次同步的时间间隔(毫秒
        var excuteSpanMinute = 10;
        var excuteSpan = 1000*60*excuteSpanMinute;
        function Import() {
            if (currentRecord == 1) {
                document.getElementById("spBeginTime").innerHTML = new Date();
            }
            //    $("#spBeginTime").html(new Date().toString());
            $.get("ImportData_GetDataHander.ashx",
        function (data) {
            //data:获取到的需要处理的数据$_$分隔
            var arrdata = data.split("$_$");
            if (data == "finished") {

                var nowtime = new Date();
                importLog("第" + executeTimes + "次处理完毕,下一次导入将在" + excuteSpanMinute + "分钟后开始");
                executeTimes++;
                setTimeout(Import, excuteSpan);
                document.getElementById("spEndTime").innerHTML = new Date();
                setTimeout(Import, excuteSpan);
                //     $("#spEndTime").html(new Date().toString());
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
                    importLog("处理结果:" + data);
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
