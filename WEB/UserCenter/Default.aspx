<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/uc.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="UserCenter_Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ucContent" runat="Server">
    <div id="dinfo">
        <a class="dorder" href="Order.aspx" mce_href=”#1″ hidefocus=”true”>
            我的订单
        </a>
        <div class="dorderinfo">
            <a runat="server" id="dpinfo" class="ddpcount" href="Order.aspx">有3张订票信息</a>
            <%--<a runat="server" id="notusedtp" class="dgpcount" href="Order.aspx">1张门票未使用</a>--%>
        </div>
        <a class="dorder" href="MyVisited.aspx" mce_href=”#1″ hidefocus=”true”>
            游玩记录
        </a>
        <div class="dorderinfo">
            <a runat="server" id="visitedrecord"  class="ddpcount" href="MyVisited.aspx"></a>
        </div>
    </div>
</asp:Content>
    