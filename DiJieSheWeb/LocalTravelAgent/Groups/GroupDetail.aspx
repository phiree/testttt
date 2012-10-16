<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="GroupDetail.aspx.cs" Inherits="Groups_GroupDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $(function () {
            var tbody = $("#tbRoute>tbody>tr>td>span");
            tbody.each(function () {
                //lert($.trim($(this).html()));//显示各个单元格内容
                //var datas = "{\"enterpid\":\"" +  + "\"}";
                $.ajax({
                    type: "get",
                    url: "RouteHandler.ashx?enterpid="+$.trim($(this).html()),
                    dataType: "json",
                    success: function (data, status) {
                        if (data == 'False') {
                            $(this).parent().css("background-color", "Aqua");
                        }
                        else {
                            $(this).parent().css("background-color", "Yellow");
                        }
                    }
                });
            });
        });
    </script>
    <style type="text/css">
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
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
                <td style="width:15%">
                    团队名称：
                </td>
                <td>
                    <asp:Label ID="lblName" runat="server" />
                </td>
                <td style="width:15%">
                   起止时间：
                </td>
                <td>
                    <asp:Label ID="lblDate" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    游玩天数：
                </td>
                <td>
                    <asp:Label ID="lblDays" runat="server" />
                </td>
                <td>
                    游玩人数：
                </td>
                <td>
                    <asp:Label ID="lblPnum" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    成人人数：
                </td>
                <td>
                    <asp:Label ID="lblPadult" runat="server" />
                </td>
                <td>
                    儿童人数：
                </td>
                <td>
                    <asp:Label ID="lblPchild" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    上车集合点：
                </td>
                <td>
                    <asp:Label ID="lblGether" runat="server" />
                </td>
                <td>
                    返程点：
                </td>
                <td>
                    <asp:Label ID="lblBack" runat="server" />
                </td>
            </tr>
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
            行程信息
        </div>
        <asp:Repeater ID="rptRoute" runat="server">
            <HeaderTemplate>
                <table id="tbRoute">
                    <thead>
                        <tr>
                            <td>
                                日期
                            </td>
                            <%--<td>
                            地点
                        </td>--%>
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
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <span><%#Eval("RouteDate")%></span>
                    </td>
                    <td>
                        <span><%#Eval("Breakfast")%></span>
                    </td>
                    <td>
                        <span><%#Eval("Lunch")%></span>
                    </td>
                    <td>
                        <span><%#Eval("Dinner")%></span>
                    </td>
                    <td>
                        <span><%#Eval("Hotel1")%></span>
                        <%#(string.IsNullOrWhiteSpace(Eval("Hotel2").ToString()) ? "" : "-<span>" + Eval("Hotel2").ToString()) + "</span>"%>
                    </td>
                    <td>
                        <span>
                            <%#Eval("Scenic1")%></span> 
                                <%# (string.IsNullOrWhiteSpace(Eval("Scenic2").ToString()) ? "" : "-<span>" + Eval("Scenic2").ToString()) + "</span>"%>
                        
                            <%# (string.IsNullOrWhiteSpace(Eval("Scenic3").ToString()) ? "" : "-<span>" + Eval("Scenic3").ToString()) + "</span>"%>
                        
                            <%# (string.IsNullOrWhiteSpace(Eval("Scenic4").ToString()) ? "" : "-<span>" + Eval("Scenic4").ToString()) + "</span>"%>
                       
                            <%# (string.IsNullOrWhiteSpace(Eval("Scenic5").ToString()) ? "" : "-<span>" + Eval("Scenic5").ToString()) + "</span>"%>
                        
                            <%# (string.IsNullOrWhiteSpace(Eval("Scenic6").ToString()) ? "" : "-<span>" + Eval("Scenic6").ToString()) + "</span>"%>
                        
                            <%# (string.IsNullOrWhiteSpace(Eval("Scenic7").ToString()) ? "" : "-<span>" + Eval("Scenic7").ToString()) + "</span>"%>
                        
                            <%# (string.IsNullOrWhiteSpace(Eval("Scenic8").ToString()) ? "" : "-<span>" + Eval("Scenic8").ToString()) + "</span>"%>
                        
                            <%# (string.IsNullOrWhiteSpace(Eval("Scenic9").ToString()) ? "" : "-<span>" + Eval("Scenic9").ToString()) + "</span>"%>
                        
                            <%# (string.IsNullOrWhiteSpace(Eval("Scenic10").ToString()) ? "" : "-<span>" + Eval("Scenic10").ToString()) + "</span>"%>
                    </td>
                    <td>
                        <%#Eval("ShoppingPoint1")%></span>
                            <%# (string.IsNullOrWhiteSpace(Eval("ShoppingPoint2").ToString()) ? "" : "-<span>" + Eval("ShoppingPoint2").ToString())+ "</span>"%>
                        
                            <%# (string.IsNullOrWhiteSpace(Eval("ShoppingPoint3").ToString()) ? "" : "-<span>" + Eval("ShoppingPoint3").ToString())+ "</span>"%>
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
