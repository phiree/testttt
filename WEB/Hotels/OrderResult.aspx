<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="OrderResult.aspx.cs" Inherits="Hotels_OrderResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="yct clearfix">
        <div class="yctl">
            <img src="/Img/suc.gif" width="33" height="33" alt="" border="0" style="float: left"></div>
        <div class="yctr">
            <h3 class="title">
                订单号：&nbsp;<span><asp:Label Text="text" runat="server" ID="lblorderid" /></span>&nbsp;订单已提交，目前状态正在处理中，您将收到艺龙(酒店提供商)的确认短信。</h3>
            <ul class="ycu">
                <li><b>尊敬的&nbsp;<asp:Label Text="text" runat="server" ID="lblname" />&nbsp;先生/女士</b></li>
                <li>您可以在右上角“我的订单”中查到此订单详细信息以及处理状态</li>
                <li>如果您所填写的手机号码或入住人信息有误，此订单将被自动取消</li>
                <li>因订单是否预订成功是通过短信或者电话的形式告知您的，请保持手机畅通或者关注下表中订单状态</li>
            </ul>
        </div>
    </div>
    <div class="ycta">
        <table>
            <tbody>
                <tr>
                    <td>
                        订单号：
                    </td>
                    <td colspan="3">
                        <b><asp:Label ID="lblorderid2" Text="text" runat="server" /></b> &nbsp; (该酒店由艺龙提供，对应的艺龙订单号为<asp:Label ID="lblelongorderid" Text="text" runat="server" />)
                    </td>
                </tr>
                <tr>
                    <td>
                        订单状态：
                    </td>
                    <td>
                        <span class="b">
                            <asp:Label Text="lblorderstatus" runat="server" ID="lblorderstatus" /></span>
                    </td>
                    <td>
                        酒店名称：
                    </td>
                    <td>
                        <asp:Label Text="hotelname" runat="server" ID="hotelname" />
                    </td>
                </tr>
                <tr>
                    <td>
                        入住日期：
                    </td>
                    <td>
                        <asp:Label ID="lblcindate" Text="text" runat="server" />
                    </td>
                    <td>
                        客房类型：
                    </td>
                    <td>
                        <asp:Label ID="lblroomtype" Text="text" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        离店日期：
                    </td>
                    <td>
                        <asp:Label ID="lblcoutdate" Text="text" runat="server" />
                    </td>
                    <td>
                        房间数量：
                    </td>
                    <td>
                        <asp:Label ID="lblroomnum" Text="text" runat="server" />间
                    </td>
                </tr>
                <tr>
                    <td>
                        到店时间：
                    </td>
                    <td>
                        <asp:Label ID="lblarrive" Text="text" runat="server" />
                    </td>
                    <td>
                        费用总计：
                    </td>
                    <td>
                        <span class="num">¥<asp:Label ID="lblfeetotal" Text="text" runat="server" /></span>
                    </td>
                </tr>
                <tr>
                    <td>
                        酒店地址：<asp:Label ID="lbladdress" Text="text" runat="server" />
                    </td>
                    <td>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>
