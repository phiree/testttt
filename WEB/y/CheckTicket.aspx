<%@ Page Title="" Language="C#" MasterPageFile="~/y/MasterPage.master" AutoEventWireup="true" CodeFile="CheckTicket.aspx.cs" Inherits="qumobile_CheckTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
    <meta   http-equiv= "expires "   content= "0 ">   
    <meta   http-equiv= "cache-control "   content= "no-cache ">   
    <meta   http-equiv= "pragma "   content= "no-cache ">  
    <meta http-equiv="x-ua-compatible" content="ie=8" />
    <script src="/Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <link href="/Scripts/jqueryplugin/jqueryui/css/ui-lightness/jquery-ui-1.9.1.custom.min.css"
        rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-1.9.1.custom.min.js" type="text/javascript"></script>
    <link href="/Styles/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/InlineTip.js" type="text/javascript"></script>
    <script src="/Scripts/pages/yCheckTicket.js" type="text/javascript"></script>
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
        #spCheckProgress
        {
             display:block;
            }
        .tbx
       {
           -moz-border-radius:5px; -webkit-border-radius:5px; border-radius:5px;
           
           height:30px;
           width:190px;
           padding-left:10px;
       }
       .detailinfo
       {
           margin-top:10px !important;
           -moz-border-radius:5px; -webkit-border-radius:5px; border-radius:5px;
           width: 85%;
       }
    </style>
    <script language="javascript" type="text/javascript">
        function ShowCheckProgress() {
            $("#spCheckProgress").text("正在查询...");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <asp:HiddenField ID="hfscid" runat="server" />
    <div id="checkTicket">

        <p style="margin-top:0px">请输入姓名/身份证号</p>
        <asp:TextBox runat="server" ID="txtinfo" CssClass="txtInfo tbx"></asp:TextBox><asp:Button ID="btnSearch" runat="server" CssClass="btn" style="margin-left:5px"

            Text="查询" OnClick="btnSearch_Click" OnClientClick="ShowCheckProgress()" />
         <span id="spCheckProgress" style="color:#EA693F;"></span>
        <p runat="server" id="Msg" style="color:#EA693F;"></p>
        <div runat="server" id="detailinfo" class="detailinfo">
            <h3 id="username" runat="server">金俊杰
                </h3>
            <p id="useridcard" runat="server" class="idcard">
                身份证号码:&nbsp;</p>
              
            <%--在线支付--%>
            <asp:Repeater ID="rptpayonline" runat="server" 
                onitemdatabound="rptpayonline_ItemDataBound">
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
                onitemdatabound="rptpayyd_ItemDataBound">
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
            <%--导游预定--%>
            <asp:Repeater ID="rptguiderinfo" runat="server" 
                onitemdatabound="rptguiderinfo_ItemDataBound">
                <HeaderTemplate>
                    <table class="guidertable" border="0" cellpadding="0" cellspacing="0">
                        <%--<tr>
                            <td>
                                选择
                            </td>
                            <td>
                                导游信息
                            </td>
                            <td>
                                验证情况
                            </td>
                        </tr>--%>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:CheckBox ID="selectItem" runat="server" />
                        </td>
                        <td>
                            <asp:HiddenField ID="hfrouteId" runat="server" />
                            <h5>团队信息：</h5>
                            <p>导游:<asp:Literal ID="laGuideName" runat="server"></asp:Literal></p>
                            <p>团队名称:<%# Eval("Name") %></p>
                            <p>人数:成人<%# Eval("AdultsAmount")%>人&nbsp;儿童<%# Eval("ChildrenAmount")%>人</p>
                            <h5>
                            实际信息：</h5>
                            实到人数:成人<asp:TextBox ID="txtAdultsAmount" runat="server"></asp:TextBox>&nbsp;儿童<asp:TextBox
                            ID="txtChildrenAmount" runat="server"></asp:TextBox>人
                        </td>
                        <td>
                            <asp:Literal ID="laIsChecked" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <div class="yptg">
                <asp:Button ID="Btnckpass" runat="server" OnClick="Btnckpass_Click" Text="验票" CssClass="btn" style=" margin-top:10px; display:block;float:left" />
                <a runat="server" target="_blank" style="display:none;float:left" id="BtnPrint"></a>
                <div style="clear:both"></div>
            </div>
          
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hfdata" />
</asp:Content>

