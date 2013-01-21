<%@ Page Title="" Language="C#" MasterPageFile="~/qumobile/MasterPage.master" AutoEventWireup="true" CodeFile="CheckTicket.aspx.cs" Inherits="qumobile_CheckTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
    <meta   http-equiv= "expires "   content= "0 ">   
    <meta   http-equiv= "cache-control "   content= "no-cache ">   
    <meta   http-equiv= "pragma "   content= "no-cache ">  
    <meta http-equiv="x-ua-compatible" content="ie=8" />
    <script src="/Scripts/jquery.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.autocomplete.js" type="text/javascript"></script>
    <link href="/Styles/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/InlineTip.js" type="text/javascript"></script>
    <script src="/Scripts/quCheckTicket.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/HighLightLink.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <style type="text/css"> 
        #checkTicket
        {
            width:300px;
            margin:0px auto;
            font-size:12px;
        }
        .txtInfo
        {
            width:200px;
        }
        .detailinfo
        {
            width:80%;
            padding:10px;
            border:1px solid #CDCDCD;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <asp:HiddenField ID="hfscid" runat="server" />
    <div id="checkTicket">
        <p>请输入姓名/身份证号<br />如:张三/330203197804255874</p>
        <asp:TextBox runat="server" ID="txtinfo" CssClass="txtInfo"></asp:TextBox><asp:Button ID="btnSearch" runat="server"
            Text="查询" OnClick="btnSearch_Click" />
        <p runat="server" id="Msg"></p>
        <div runat="server" id="detailinfo" class="detailinfo">
            <h3 id="username" runat="server">金俊杰
                </h3>
            <p id="useridcard" runat="server" class="idcard">
                身份证号码:&nbsp;</p>
            <%--在线支付--%>
            <asp:Repeater ID="rptpayonline" runat="server" 
                >
                <ItemTemplate>
                    <div class="onlinebuy" runat="server" id="idcardol">
                        <asp:HiddenField ID="hfticketid" runat="server" Value='<%# Eval("Id") %>' />
                        在线支付&nbsp;<span style="font-weight:bold"><%# Eval("Name") %></span>&nbsp;购票&nbsp;<span id="olgpcount" runat="server" class="num"></span>&nbsp;张&nbsp;&nbsp;已使用了&nbsp;<span
                            class="num" id="olgpusedcount" runat="server"></span>&nbsp;张&nbsp;&nbsp;现用
                        <asp:TextBox ID="txtolusecount" runat="server" CssClass="bottom" Width="60px" onkeyup="return changeolcount(this)"></asp:TextBox>&nbsp;张
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <%--在线预定--%>
            <asp:Repeater ID="rptpayyd" runat="server" 
                >
                <ItemTemplate>
                    <asp:HiddenField ID="hfticketid" runat="server" Value='<%# Eval("Id") %>' />
                    <div class="ydbuy" runat="server" id="idcardyuding">
                预定&nbsp;<span id="ticketname" style="font-weight:bold"><%# Eval("Name") %></span>&nbsp;门票&nbsp;<span id="ydmpcount" class="num" runat="server"></span>&nbsp;张&nbsp;&nbsp;已使用了&nbsp;<span
                    class="num" id="ydmpusedcount" runat="server"></span>&nbsp;张&nbsp;&nbsp;现用
                <asp:TextBox ID="txtUseCount" runat="server" Width="60px" CssClass="bottom" onkeyup="changesumprice(this)"></asp:TextBox>&nbsp;张&nbsp;&nbsp;预订单价为&nbsp;<span
                    id="yddj" runat="server" class="num"></span>
                <img src="/theme/default/image/moneyicon.png" width="15px" height="20px" style="position: relative;
                    top: 4px;">需要支付&nbsp;<span id="sumprice" class="num">0元</span>
            </div>
            <div class="jxyd">
            </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hfdata" />
</asp:Content>

