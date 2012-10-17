<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="GroupDetail.aspx.cs" Inherits="Groups_GroupDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $(function () {
            var tbody = $("#tbRoute>tbody>tr>td>span");
            tbody.each(function () {
                //lert($.trim($(this).html()));//显示各个单元格内容
                var datas = "{\"enterpid\":\"" + $.trim($(this).html()) + "\"}";
                $.Post({
                    type: "Post",
                    url: "RouteHandler.ashx",
                    dataType: "json",
                    data: datas,
                    success: function (data, status) {
                        alert(data);
                        if (data == 'False') {
                            alert('aaa');
                            $(this).parent().css("background-color", "Aqua");
                        }
                        else {
                            alert('ttt');
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
        <!-- 基本信息begin -->
        <div>
            <p>
                团队名称：<asp:Label ID="lblName" runat="server" /></p>
            <p>
                起止时间：<asp:Label ID="lblDate" runat="server" /></p>
            <p>
                天数：<asp:Label ID="lblDays" runat="server" /></p>
            <p>
                人数：<asp:Label ID="lblPnum" runat="server" /></p>
            <p>
                成人：<asp:Label ID="lblPadult" runat="server" /></p>
            <p>
                儿童：<asp:Label ID="lblPchild" runat="server" /></p>
            <p>
                上车集合点：<asp:Label ID="lblGether" runat="server" /></p>
            <p>
                返程点：<asp:Label ID="lblBack" runat="server" /></p>
        </div>
        <!-- 基本信息end -->
        <!-- 工作人员begin -->
        <asp:Repeater ID="rptWorkers" runat="server">
            <HeaderTemplate>
                <div>
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
                </tbody> </table> </div>
            </FooterTemplate>
        </asp:Repeater>
        <!-- 人员end -->
        <!-- 行程begin -->
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
