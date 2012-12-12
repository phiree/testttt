<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="GroupEditBasicInfo.aspx.cs" Inherits="LocalTravelAgent_Groups_GroupEditBasicInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    ///<reference path="/Scripts/jquery-1.6.4-vsdoc.js" />
    <link href="/Content/themes/base/minified/jquery-ui.min.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/json2.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Scripts/jquery-ui-1.9.2.min.js"></script>
    <script src="/Scripts/jqueryplugin/ContainerToJson.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(function () {
            //限制日期选择范围
            $("#<%=tbxDateBegin.ClientID %>").datepicker({ minDate: new Date() });
            //
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="navlist">
        <a runat="server" id="a_link_1" href="/LocalTravelAgent/Groups/GroupEditBasicInfo.aspx"
            class="selectstate">录入团队基本信息</a> <a runat="server" id="a_link_2" href="/LocalTravelAgent/Groups/GroupEditMember.aspx">
                录入游客信息</a> <a runat="server" id="a_link_3" href="/LocalTravelAgent/Groups/GroupEditRoute.aspx">
                    录入行程信息</a>
    </div>
    <%--<div class="detail_titlebg">
        新增团队
    </div>--%>
    <div class="navstate">
    </div>
    <div class="detaillist">
        <table class="comTable">
            <tr>
                <td>
                    团队名称
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxName"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" ControlToValidate="tbxName" Display="Dynamic" runat="server"
                        ErrorMessage="请填写团队名称"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    开始时间
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxDateBegin"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server"
                        ControlToValidate="tbxDateBegin" ErrorMessage="请输入开始时间"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    总天数
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxDateAmount"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic"
                        ControlToValidate="tbxDateAmount" runat="server" ValidationExpression="\d+" ErrorMessage="请输入数字"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="tbxDateAmount"
                        runat="server" ErrorMessage="请输入游玩天数"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    导游
                </td>
                <td>
                    <asp:CheckBoxList runat="server" ID="cbxGuides" CssClass="rbl" Style="margin: 0px 0px 5px 0px">
                    </asp:CheckBoxList>
                    <input type="button" name="showDiag_AddGuide" class="showAddDiag" value="增加导游" />
                    <span><a target="_blank" href="/LocalTravelAgent/GuideList.aspx">导游列表</a></span>
                </td>
            </tr>
            <tr>
                <td>
                    司机
                </td>
                <td>
                    <asp:CheckBoxList runat="server" ID="cbxDrivers">
                    </asp:CheckBoxList>
                    <span>
                        <input type="button" name="showDiag_AddDriver" class="showAddDiag" value="增加车辆司机" />
                        <a target="_blank" href="/LocalTravelAgent/DriverList.aspx">车辆司机列表</a></span>
                </td>
            </tr>
        </table>
        <asp:Button runat="server" ID="btnSaveBasicInfo" OnClick="btnBasicInfo_Click" Text="保存"
            CssClass="btn" Style="margin-left: 350px" />
        <asp:Label runat="server" ID="lblMsg"></asp:Label>
        <%--<asp:Panel runat="server" ID="pnlLinks">
            <a href="GroupEditMember.aspx?groupid=<%=groupId %>">编辑成员信息</a>
             <a href="GroupEditRoute.aspx?groupid=<%=groupId %>">
                编辑行程信息</a>
        </asp:Panel>--%>
    </div>
    <div id="DvAddWorker">
        <div class="searchdiv">
            <div>
                姓名:<input type="text" name="Name" style="margin-right: 100px; margin-left: 50px;
                    width: 150px;" /></div>
            <div>
                手机:<input type="text" name="Phone" style="margin-left: 50px; width: 150px;" /></div>
            <div>
                身份证号:<input type="text" name="IDCard" style="margin-right: 100px; margin-left: 27px;
                    width: 150px;" /></div>
            <div>
                <span id="spcardno">导游证号:</span>
                <input type="text" name="SpecificIdCard" style="margin-left: 27px; width: 150px;" /></div>
            <div id="dvbelong">
                所属公司:<input type="text" name="CompanyBelong" style="margin-left: 27px; width: 150px;" /></div>
            <input id="btnAddWorker" type="button" value="添加" />
            <input type="hidden" id="hiWorkType" name="WorkerType" value="1" />
        </div>
    </div>
    <script type="text/javascript" language="javascript">
        $(function () {
                
                 $("#DvAddWorker" ).dialog({
            autoOpen: false,
            height: 300,
            width: 350,
            modal: true
           });

             $(".showAddDiag").click(function(){
             $("#DvAddWorker" ).dialog("open");
                if(this.name=="showDiag_AddDriver")
                {
                    $("#hiWorkType").val("2");
                     $("#spcardno").text("车牌证号");
                     $("#dvbelong").hide();
                }
                else{
                     $("#hiWorkType").val("1");
                       $("#spcardno").text("导游证号");
                     $("#dvbelong").show();
                }
             });
            $("#btnAddWorker").click(function () {
                
                var json = $("#DvAddWorker").ContainerToJson();
                var jsonString = JSON.stringify(json);
                $.get("AddGuide.ashx?entId="+<%=CurrentDJS.Id %>+"&jr=" + jsonString,
                function (data) {
                window.location.href=window.location.href;
                  /*  alert(data);
                    var addedItem=" <tr><td><input id='main_ContentPlaceHolder2_cbxGuides_4'"
                    +" type='checkbox' name='ctl00$ctl00$main$ContentPlaceHolder2$cbxGuides$4'"
                    +" value='"+data+"'>"
                    +"<label for='main_ContentPlaceHolder2_cbxGuides_4'>"+json.Name+"</label></td>"
	                +"</tr>";

                    $("#<%=cbxGuides.ClientID %>").append(addedItem);

                    $( "#DvAddWorker" ).dialog("close");
                   */
                    

                });
            });
        });
    </script>
</asp:Content>
