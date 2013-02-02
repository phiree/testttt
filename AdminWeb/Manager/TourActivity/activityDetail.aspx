<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="activityDetail.aspx.cs" Inherits="Manager_TourActivity_activityDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    活动详情
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                活动名称
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                活动编号
            </td>
            <td>
                <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                起始时间
            </td>
            <td>
                <asp:TextBox ID="txtBeginDate" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                结束时间
            </td>
            <td>
                <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                每日开始时间
            </td>
            <td>
                <asp:TextBox ID="txtBeginHour" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                每日结束时间
            </td>
            <td>
                <asp:TextBox ID="txtEndHour" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                每张身份证每个景区购买的最大数量
            </td>
            <td>
                <asp:TextBox ID="txtAmountPerIdcardTicket" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                身份证号在本次活动中能购买的最大数量
            </td>
            <td>
                <asp:TextBox ID="txtAmountPerIdcardInActivity" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                是否限制购买者的地理位置
            </td>
            <td>
                <asp:CheckBox ID="ckIsBuy" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                黑名单
            </td>
            <td>
                <asp:TextBox ID="txtBlack" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                白名单
            </td>
            <td>
                <asp:TextBox ID="txtWhite" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                合作分票者列表
            </td>
            <td>
                <a href='/manager/touractivity/partnerList.aspx?actId=<%= Request.QueryString["actId"]  %>'>合作分票者列表</a>
            </td>
        </tr>
        <tr>
            <td>
                参与活动门票列表
            </td>
            <td>
                <a href='/manager/touractivity/ticketlist.aspx?actId=<%= Request.QueryString["actId"]  %>'>参与活动门票列表</a>
            </td>
        </tr>
        <tr>
            <td>
                门票分票情况
            </td>
            <td>
                <a href='/manager/touractivity/ticketAssign.aspx?actId=<%= Request.QueryString["actId"]  %>'>门票分票情况</a>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnUpdate" runat="server" Text="修改" OnClick="btnUpdate_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

