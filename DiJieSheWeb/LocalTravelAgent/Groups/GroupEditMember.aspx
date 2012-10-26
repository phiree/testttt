<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="GroupEditMember.aspx.cs" Inherits="LocalTravelAgent_Groups_GroupEditMember" %>

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
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-1.9.0.custom.min.js"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <!--身份证正则验证-->
    <script src="/Scripts/VeriIdCard.js" type="text/javascript"></script>
    <script src="/Scripts/json2.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        var __TEST_DATA__ =
  JSON.parse("<%=MemberJsonList %>");
        //[["youkeid","1", "成人游客", "李爽", "13282151877", "520822198010103916",""]];
        var grid_demo_id = "myGrid1";

        var dsOption = {

            fields: [
		{ name: 'tourertype' },
		{ name: 'realname' },
		{ name: 'phone' },
		{ name: 'idcardno' },
		{ name: 'othercardno' },
          { name: 'memberid' }
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
                //                       '<select id="selMemberType">',
                //                       '<option value=1 selected>成人游客</option>',
                //                       '<option value=5>导游</option>',
                //                       '<option value=6>司机</option>',
                //                       '<option value=2>儿童</option>',
                //                       '<option value=3>外宾</option>',
                //                       '<option value=4>港澳台</option>',
                //                       '</select>',
'<input type="text" id="inputte" />',
                         '<input type="button" value="OK" ',
        'onclick="Sigma.$grid(\'myGrid1\').activeDialog.confirm()"/>']

        .join(''),
                getValue: function () {

                    //   var sel = Sigma.$("selMemberType");
                    // return sel.options[sel.selectedIndex].text;
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
        {id:"",width:5},
        { id: 'tourertype', header: "游客类型", width: 80, editor: { type: "select", options: { '成人游客': '成人游客', '导游': '导游', '司机': '司机', '儿童': '儿童', '外宾': '外宾', '港澳台': '港澳台' }
     , defaultText: '成人游客'
        }
        },
	   { id: 'realname', header: "姓名", width: 80, editor: { type: "text", validRule: ['R']} },
	   { id: 'phone', header: "电话号码", width: 100, editor: { type: "text", validRule: ['R', 'F']} },
       { id: 'idcardno', header: "身份证号码", width: 140, editor: { type: "text",
           validator: function (value, record, colObj, grid) {
               var testResult = test(value);
               var result = testResult == "验证通过";

               if (result) return result;
               else return testResult;
           }
       }
       },
	   { id: 'othercardno', header: "其他证件号码", width: 120, editor: { type: "text"} },
        { id: 'memberid', hideable: true, header: "", width: 100, editor: { type: "text"} }
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
            saveURL: "GroupEditMemberHanlder.ashx",
            //  loadURL: "GroupEditMemberHanlder.ashx",
            parameters: { "groupid": "<%=CurrentGroup.Id %>" },
      
            saveResponseHandler: function (r, d) {
                //   debugger;
                window.location.href = window.location.href;
            },
                showIndexColumn : true
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
    <script type="text/javascript">
        $(function () {
            $("#btnExcel").click(function () {

                var datas = "";
                $.ajax({
                    type: "Post",
                    url: "ExcelHandler.ashx?filename=" + $("#<%=Label1.ClientID%>").html(),
                    dataType: "text",
                    data: datas,
                    success: function (data, status) {
                        alert(data);
                    }
                });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div>
        <%=CurrentGroup.Name %>游客列表</div>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">表格录入</a></li>
            <li><a href="#tabs-2">简单文本录入</a></li>
            <li><a href="#tabs-3">Excel导入</a></li>
        </ul>
        <div id="tabs-1">
            <div id="gridbox" style="border: 0px solid #cccccc; background-color: #f3f3f3;">
            </div>
        </div>
        <div id="tabs-2">
            <p>
                将游客信息按照一定的格式输入,一次性导入系统
            </p>
            <p>
                格式要求: 1)单个游客的资料用逗号分隔,按序依次为:成员类型,姓名,电话号码,身份证号,其他证件号.如果没有对应信息,请保留逗号. 2)成员类型:成人游客,儿童,外宾,港澳台,导游,司机
                不同游客用回车分隔. 比如:<br />
                成人游客,张晓华,13287839485,51332919880321639X,<br />
                外宾,Jim Green,13287839485,,CH1034123<br />
                儿童,李晓彤,,,<br />
            </p>
            <asp:TextBox TextMode="MultiLine" runat="server" ID="tbxSimple" CssClass="tbMemberSingleText"></asp:TextBox>
            <asp:Button runat="server" ID="btnSaveSimple" OnClick="btnSave_Click" OnClientClick="javascript:return confirm('原有的团队成员信息将清除,是否继续?');"
                Text="保存" />
            <asp:Label runat="server" ID="lblSimpleMsg" ForeColor="green"></asp:Label>
        </div>
        <div id="tabs-3">
            <p>
                将游客信息从的Excel文件中导进系统.请下载模板文件,按照规范填入数据.</p>
            <p>
                <a href="">Excel模板文件下载</a>
            </p>
            <asp:TextBox TextMode="MultiLine" runat="server" ID="tbxExcel" CssClass="tbMemberSingleText"></asp:TextBox>
            <p>
                <asp:FileUpload runat="server" ID="fuMemberExcel" />
                <asp:Button ID="btnUpload" runat="server" Text="上传" OnClick="btnUpload_Click" />
                <asp:Label ID="Label1" runat="server" />
            <asp:Button runat="server" ID="Button1" OnClick="btnExcel_Click" OnClientClick="javascript:return confirm('原有的团队成员信息将清除,是否继续?');"
                Text="保存" />
            </p>
        </div>
    </div>
</asp:Content>
