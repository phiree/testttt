<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="GroupDetail.aspx.cs" Inherits="Groups_GroupDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="detail_titlebg">
        团队详细信息
    </div>
    <div class="detaillist">
    <!-- 基本信息begin -->
    <div class="detailtitle">
            基本信息
        </div>
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
                <%#Eval("RouteDate")%>
                </td>
                <td>
                <%#Eval("Breakfast")%>
                </td>
                <td>
                <%#Eval("Lunch")%>
                </td>
                <td>
                <%#Eval("Dinner")%>
                </td>
                <td>
                <%#Eval("Hotel1") + (string.IsNullOrWhiteSpace(Eval("Hotel2").ToString()) ? "" : "-"+Eval("Hotel2").ToString())%>
                </td>
                <td>
                <%#Eval("Scenic1")
                            + (string.IsNullOrWhiteSpace(Eval("Scenic2").ToString()) ? "" : "-" + Eval("Scenic2").ToString())
                            + (string.IsNullOrWhiteSpace(Eval("Scenic3").ToString()) ? "" : "-" + Eval("Scenic3").ToString())
                            + (string.IsNullOrWhiteSpace(Eval("Scenic4").ToString()) ? "" : "-" + Eval("Scenic4").ToString())
                            + (string.IsNullOrWhiteSpace(Eval("Scenic5").ToString()) ? "" : "-" + Eval("Scenic5").ToString())%>
                </td>
                <td>
                <%#Eval("ShoppingPoint1")
                            + (string.IsNullOrWhiteSpace(Eval("ShoppingPoint2").ToString()) ? "" : "-" + Eval("ShoppingPoint2").ToString())
                            + (string.IsNullOrWhiteSpace(Eval("ShoppingPoint3").ToString()) ? "" : "-" + Eval("ShoppingPoint3").ToString())
                            + (string.IsNullOrWhiteSpace(Eval("ShoppingPoint4").ToString()) ? "" : "-" + Eval("ShoppingPoint4").ToString())
                            + (string.IsNullOrWhiteSpace(Eval("ShoppingPoint5").ToString()) ? "" : "-" + Eval("ShoppingPoint5").ToString())%>
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
