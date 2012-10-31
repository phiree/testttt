<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="GroupEditRoute.aspx.cs" Inherits="LocalTravelAgent_Groups_GroupEditRoute" %>

<%@ Register Src="~/LocalTravelAgent/Groups/RecommentEnt.ascx" TagName="recomment"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--SigmaGrid-->
    <script src="/Scripts/sigmagrid/gt_msg_en.js" type="text/javascript"></script>
    <script src="/Scripts/sigmagrid/gt_grid_all.js" type="text/javascript"></script>
    <script src="/Scripts/sigmagrid/gt_msg_cn.js" type="text/javascript"></script>
    <!--jQueryUI-->
    <link href="/Scripts/jqueryplugin/jqueryui/css/ui-lightness/jquery-ui-1.9.0.custom.min.css"
        rel="stylesheet" type="text/css" />
    <link href="/Scripts/sigmagrid/gt_grid_height.css" rel="stylesheet" type="text/css" />
    <link href="/Scripts/sigmagrid/gt_grid.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-1.9.1.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <!--身份证正则验证-->
    <script src="/Scripts/VeriIdCard.js" type="text/javascript"></script>
    <script src="/Scripts/json2.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        var __TEST_DATA__ = JSON.parse("<%=RouteJsonList %>");
        var grid_demo_id = "myGrid1";
        var dsOption = {
            fields: [
                { name: 'dayno' },
                { name: 'scenic' },
                { name: 'hotel' }
            ],
            recordType: 'array',
            data: __TEST_DATA__
        }

        var membertypeEditorCreator = function () {
            var myd = new Sigma.Dialog({
                id: "membertypeEditor",
                gridId: "myGrid1",
                width: 150,
                height: 150,
                title: '选择成员类型',
                body: [
                    '<input type="text" id="inputte" />',
                    '<input type="button" value="OK" ',
                    'onclick="Sigma.$grid(\'myGrid1\').activeDialog.confirm()"/>'].join(''),
                getValue: function () {
                    return Sigma.$("inputte").value;
                },
                setValue: function (value) {
                    Sigma.$("inputte").value = value;
                },
                active: function () {
                    Sigma.Util.focus(Sigma.$("inputte"));
                }
            });
            return myd;
        }

        var colsOption = [
        { id: "", width: 5 },
        { id: 'dayno',
            header: "行程日",
            width: 80,
            editor: { type: "text" }
        },
        { id: 'scenic', header: "景点", width: 200, editor: { type: "text"} },
        { id: 'hotel', header: "住宿", width: 200, editor: { type: "text"} }
        ];

        var gridOption = {
            id: grid_demo_id,
            width: "750", // 700,
            height: "350",  //"100%", // 330,

            container: 'gridbox',
            replaceContainer: true,
            dataset: dsOption,
            columns: colsOption,

            toolbarContent: 'add del save',
            saveURL: "GroupEditRouteHanlder.ashx",
            parameters: { "groupid": "<%=CurrentGroup.Id %>" },

            saveResponseHandler: function (r, d) {
                window.location.href = "/localtravelagent/Groups/GroupList.aspx";
            },
            showIndexColumn: true
        };
        var mygrid = new Sigma.Grid(gridOption);
        Sigma.Util.onLoad(Sigma.Grid.render(mygrid));
    </script>
    <script language="javascript" type="text/javascript">
        $(function () {
            var cookieName = "djsmetab";
            $("#tabs").tabs({
                active: $.cookie(cookieName),
                activate: function (event, ui) {
                    $.cookie(cookieName, ui.newTab.index(), { expires: 365 });
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div>
        <%=CurrentGroup.Name %>行程信息录入</div>
       <div class="box">提供两种录入线路的方式,您可以根据需要,选择最适合一种方式.</div>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">直接录入</a></li>
            <li><a href="#tabs-2">文本录入</a></li>
        </ul>
        <div id="tabs-1">
            <div id="gridbox" style="border: 0px solid #cccccc; background-color: #f3f3f3;">
            </div>
        </div>
        <div id="tabs-2">
            <p>
                将行程信息按照一定的格式输入,一次性导入系统
            </p>
            <p>
                格式要求: 1)单个游客的资料用逗号分隔,按序依次为:天数,景区,住宿(多个景区用"-"分割).如果没有对应信息,请保留逗号. 不同天数用回车分隔. 比如:<br />
                1,西栅景区,乌镇客栈<br />
                2,鲁迅故里-兰亭-沈园,如家快捷酒店<br />
                3,船游西湖-花港观鱼-六合塔-龙井问茶-苏提春晓,如家快捷酒店<br />
                4,飞来峰,<br />
            </p>
            <asp:TextBox TextMode="MultiLine" runat="server" ID="tbxSimple" CssClass="tbMemberSingleText"></asp:TextBox>
            <asp:Button runat="server" ID="btnSaveSimple" OnClick="btnSave_Click" OnClientClick="javascript:return confirm('原有的行程信息将清除,是否继续?');"
                Text="保存" />
            <asp:Label runat="server" ID="lblSimpleMsg" ForeColor="green"></asp:Label>
        </div>
    </div>
    <a style=" display:block;  padding:3px; margin:10px; background-color:#ddd;font-size:larger;"  href="GroupEditMember.aspx?groupid=<%=CurrentGroup.Id%>">
    去编辑成员信息</a> 
</asp:Content>
