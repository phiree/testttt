<%@ Page Title="" Language="C#" MasterPageFile="~/TourManagerDpt/manager.master" AutoEventWireup="true" CodeFile="GroupDetail.aspx.cs" Inherits="TourManagerDpt_GroupDetail" %>

<asp:Content ID="Content0" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">

    $(function () {
        var tbody = $("#tbRoute>tbody");
        var count = tbody.html().split("★");
        $("#veriEnt").html(count.length - 1);
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
    </script>
    <style type="text/css">
        .colorpicker
        {
            display: block;
            margin-left: 10px;
            width: 12px;
            height: 12px;
            float: right;
            border: 1px solid #000;
            margin-right: 2px;
            margin-top: 4px;
            cursor: pointer;
        }
        .colorWord
        {
            display: block;
            margin-left: 2px;
            float: right;
            margin-right: 5px;
            cursor: pointer;
        }
        #colorpicker1
        {
            background-color: Aqua;
        }
        #colorpicker3
        {
            background-color: Yellow;
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">
<div class="detail_titlebg">
        团队详细信息
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            基本信息
        </div>
        <!-- 基本信息begin -->
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 15%">
                    团队编号：
                </td>
                <td>
                    <asp:Label ID="lblGroupno" runat="server" />
                </td>
                <td style="width: 15%">
                    团队名称：
                </td>
                <td>
                    <asp:Label ID="lblName" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 15%">
                    起止时间：
                </td>
                <td>
                    <asp:Label ID="lblDate" runat="server" />
                </td>
                <td>
                    游玩天数：
                </td>
                <td>
                    <asp:Label ID="lblDays" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    游玩人数：
                </td>
                <td>
                    <asp:Label ID="lblPnum" runat="server" />
                </td>
                <td>
                    成人人数：
                </td>
                <td>
                    <asp:Label ID="lblPadult" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    儿童人数：
                </td>
                <td>
                    <asp:Label ID="lblPchild" runat="server" />
                </td>
                <td>
                    外宾人数：
                </td>
                <td>
                    <asp:Label ID="lblForeigners" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    外宾人数：
                </td>
                <td>
                    <asp:Label ID="lblGangaotais" runat="server" />
                </td>
                <td>
                    上车集合点：
                </td>
                <td>
                    <asp:Label ID="lblGether" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    返程点：
                </td>
                <td>
                    <asp:Label ID="lblBack" runat="server" />
                </td></tr>
        </table>
        <!-- 基本信息end -->
        <!-- 工作人员begin -->
        <div class="detailtitle">
            人员信息
        </div>
        <asp:Repeater ID="rptWorkers" runat="server">
            <HeaderTemplate>
                <table class="tableMemberid" id="tbMember">
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
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("WorkerType").ToString()%>
                    </td>
                    <td>
                        <%#Eval("Name")%>
                    </td>
                    <td>
                        <%#Eval("IDCard")%>
                    </td>
                    <td>
                        <%#Eval("Phone")%>
                    </td>
                    <td>
                        <%#Eval("SpecificIdCard")%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <!-- 工作人员end -->
        <!-- 人员begin -->
        <asp:Repeater ID="rptMem" runat="server">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        游客
                    </td>
                    <td>
                        <%#Eval("RealName")%>
                    </td>
                    <td>
                        <%#Eval("IdCardNo")%>
                    </td>
                    <td>
                        <%#Eval("PhoneNum")%>
                    </td>
                    <td>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
        <!-- 人员end -->
        <!-- 行程begin -->
        <div class="detailtitle">
            行程信息 <span class="colorWord">未开始的行程</span><span class="colorpicker" id="colorpicker3"></span>
            <span class="colorWord">完成的行程</span><span class="colorpicker" id="colorpicker1"></span>
            【★企业共<span id="veriEnt"></span>个】
        </div>
        <asp:Repeater ID="rptRoute" runat="server" OnItemDataBound="rptRoute_ItemDataBound">
            <HeaderTemplate>
                <table id="tbRoute">
                    <thead>
                        <tr>
                            <td>
                                日期
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
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <span>
                            <%#Eval("RouteDate")%></span>
                    </td>
                    <td>
                        <asp:Repeater ID="rptRouteScenic" runat="server" OnItemDataBound="rptRouteSub_ItemDataBound">
                            <ItemTemplate>
                                <asp:Label ID="lblName" Text='<%#Eval("Enterprise")!=null?
                                (((Model.DJ_TourEnterprise)Eval("Enterprise")).IsVeryfied.ToString()=="True"?
                                ("★"+Eval("Enterprise.Name")):Eval("Enterprise.Name")):""%>'
                                    runat="server" />
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                    <td>
                        <asp:Repeater ID="rptRouteHotel" runat="server" OnItemDataBound="rptRouteSub_ItemDataBound">
                            <ItemTemplate>
                                <asp:Label ID="lblName" Text='<%#Eval("Enterprise")!=null?
                                (((Model.DJ_TourEnterprise)Eval("Enterprise")).IsVeryfied.ToString()=="True"?
                                ("★"+Eval("Enterprise.Name")):Eval("Enterprise.Name")):""%>'
                                    runat="server" />
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table> </div>
            </FooterTemplate>
        </asp:Repeater>
        <!-- 行程end -->
    </div>
</asp:Content>

