<%@ Page Title="" Language="C#" MasterPageFile="~/TourEnterprise/TE.master" AutoEventWireup="true" CodeFile="GroupDetail.aspx.cs" Inherits="TourEnterprise_GroupDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
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
</asp:Content>

