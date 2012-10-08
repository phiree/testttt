<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true"
    CodeFile="CheckTicket.aspx.cs" Inherits="ScenicManager_CheckTicket" %>

<%@ MasterType VirtualPath="~/ScenicManager/sm.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" runat="Server">
    <meta   http-equiv= "expires "   content= "0 ">   
    <meta   http-equiv= "cache-control "   content= "no-cache ">   
    <meta   http-equiv= "pragma "   content= "no-cache ">  

    <%--<script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../Scripts/jqueryplugin/InlineTip.js" type="text/javascript"></script>
    <script src="../Scripts/jqueryplugin/jquery.autoRedirect.js" type="text/javascript"></script>--%>
    <script src="/Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.autocomplete.js" type="text/javascript"></script>
    <link href="../theme/default/css/smdefault.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jqueryplugin/InlineTip.js" type="text/javascript"></script>
    <script src="../Scripts/CheckTicket.js" type="text/javascript"></script>
    <script src="../Scripts/jqueryplugin/HighLightLink.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.cookie.js" type="text/javascript"></script>
    <object id="aaa" classid="clsid:6c78bcd1-ac43-4fb9-8d89-d9f7b717d021" style=" height:0px;">
    </object>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <asp:HiddenField ID="hfscid" runat="server" />
    <p class="fuctitle">
        景区验票</p>
    <hr />
    <p class="wkintr">
        身份证读卡器的驱动下载地址:<a href="http://productbbs.it168.com/thread-67620-1-1.html">下载地址</a>
    </p>
    <p class="wkintr">
        首次进入该页面，请先下载身份证读卡器程序，安装到本地电脑后，打开IE浏览器，进入该页面后浏览器会提示是否运行该加载项，点击允许，即可使用：
        <a href="/ScenicManager/setup.exe">身份证读卡器程序下载</a>
    </p>
    <div id="tpmain">
        <div runat="server" id="tp_nav" class="tp_nav">
            <div id="txinfo" runat="server" class="centerbig">
                <div class="divtxtinfo">
                    <asp:TextBox ID="txtinfo" CssClass="txtinfo" runat="server" Style="border: 0px none White;"></asp:TextBox></div>
            </div>
            <span id="yklistt"><span style="margin-left: 0px; padding-left: 0px; float: left; cursor:pointer" onmouseover="showyklist()">游客列表&nbsp;&nbsp;</span><img
                onmouseover="showyklist()" height="15px" width="10px" src="../theme/default/image/downicon.png"
                style="margin-top: 7px; display: block; float: left; cursor: pointer;" /></span>
            <%--<asp:Button ID="btnsearch" runat="server" Text="查询全部信息" OnClick="btnsearch_Click" />--%>
        </div>
        <div runat="server" id="detailinfo" class="detailinfo">
            <h3 id="username" runat="server">
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
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                选择
                            </td>
                            <td>
                                导游信息
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <input name="selectTour" runat="server" type="checkbox" />
                        </td>
                        <td>
                            <h5>团队信息：</h5>
                            导游:<asp:Literal ID="laGuideName" runat="server"></asp:Literal><br />
                            <asp:Literal ID="laGroupName" runat="server"></asp:Literal><br />
                            人数:成人<%# Eval("AdultsAmount")%>人&nbsp;儿童<%# Eval("ChildrenAmount")%>人<br />
                            <h5>
                            实际信息：</h5>
                            实到人数:成人<asp:TextBox ID="txtAdultsAmount" runat="server"></asp:TextBox>儿童<asp:TextBox
                            ID="txtChildrenAmount" runat="server"></asp:TextBox>人
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <div class="yptg">
                <asp:Button ID="Btnckpass" runat="server" CssClass="btnckpass" OnClick="Btnckpass_Click" />
            </div>
            
        </div>
        <div runat="server" id="ywdiv" class="ywdiv">
            <span id="ywspan"><span style="display: block; float: left; padding: 0px; margin: 0px;cursor:pointer;" onmouseover="showywrecord()">
                游玩记录&nbsp;&nbsp;</span><img onmouseover="showywrecord()" height="15px" width="10px" src="../theme/default/image/downicon.png"
                    style="display: block; float: left; margin-top: 3px; cursor: pointer;" />
            </span>
        </div>
        <div style="display: none">
            <asp:Button ID="btnbind" runat="server" Text="Button" OnClick="btnbind_Click" />
            <asp:HiddenField ID="hfdata" runat="server" />
            <asp:Button ID="btnselect" runat="server" Text="Button" OnClick="btnselect_Click" />
            <asp:HiddenField ID="hfselectname" runat="server" />
            <asp:HiddenField ID="hfselectidcard" runat="server" />
            <asp:Button ID="btnauto" runat="server" Text="Button" OnClick="btnauto_Click" />
            <asp:HiddenField ID="hfautoidcard" runat="server" />
        </div>
    </div>
    <div id="listname" class="yklist" style="display: none;">
        <table cellpadding="0" cellspacing="0" style="margin: 15px auto; margin-bottom: 0px;
            width: 200px; table-layout: fixed">
            <tr style="width: 150px; background-color: #E9E9E9">
                <td style="width:60px;padding: 0px; padding-right: 0px; padding-left: 0px; padding-right: 0px;">
                    <span style="display: block; width: 60px; margin: 0px; margin-left: 0px; margin-right: 0px;">
                        姓名</span>
                </td>
                <td style="width: 135px; padding-left: 0px; padding-right: 0px;">
                    <span style="display: block; width: 135px">身份证号</span>
                </td>
            </tr>
        </table>
        <div style="margin-right: 10px; padding: 0px; height: 250px; width: 215px; overflow-x: hidden;
            overflow-y: auto;">
            <asp:Repeater ID="rptpeopleinfo" runat="server">
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0" style="display: block; margin-bottom: 0px;
                        border-top: 0px none; width: 200px; table-layout: fixed">
            </HeaderTemplate>
            <ItemTemplate>
                <tr  onmouseover="cgbg(this)" onmouseout="cgbg2(this)" style="cursor:pointer;">
                    <td style="width: 60px; background-color: #F7F7F7; padding-left: 0px; padding-right: 0px;
                            margin-left: 0px; margin-right: 0px;" onclick="btnselectname(this)">
                        <span style="display: block; width: 60px;">
                            <%# Eval("Name") %></span>
                    </td>
                    <td style="width: 135px; background-color: #F7F7F7; padding: 0px;" onclick="btnselectname(this)">
                        <span style="display: block; width: 125px">
                            <%# Eval("IdCard") %></span>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        </div>

        
    </div>
    <div id="listyw" class="ywrecord" style="display: none;">
        <table cellpadding="0" cellspacing="0" style="margin: 15px auto; margin-bottom: 0px;
            width: 200px; table-layout: fixed">
            <tr style="width: 150px; background-color: #E9E9E9">
                <td style="padding: 0px; padding-right: 0px; padding-left: 0px; padding-right: 0px;">
                    <span style="display: block; width: 140px; margin: 0px; margin-left: 0px; margin-right: 0px;">
                        游玩时间</span>
                </td>
                <td style="width: 60px; padding-left: 0px; padding-right: 0px;">
                    <span style="display: block; width: 60px">游玩人数</span>
                </td>
            </tr>
        </table>
        <div style="margin-right: 10px; padding: 0px; height: 150px; width: 215px; overflow-x: hidden;
            overflow-y: auto;">
            <asp:Repeater ID="rptywrecord" runat="server" OnItemDataBound="rptywrecord_ItemDataBound">
                <HeaderTemplate>
                    <table cellpadding="0" cellspacing="0" style="display: block; margin-bottom: 0px;
                        border-top: 0px none; width: 200px; table-layout: fixed">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td style="width: 135px; background-color: #F7F7F7; padding-left: 0px; padding-right: 0px;
                            margin-left: 0px; margin-right: 0px;">
                            <span style="display: block; width: 125px; margin-left: 0px; padding-left: 0px; padding-right: 0px;
                                margin-right: 0px;">
                                <%# Eval("UsedTime","{0:yyyy-MM-dd}") %></span>
                        </td>
                        <td style="width: 60px; background-color: #F7F7F7; padding: 0px;">
                            <span runat="server" id="ywtime" style="display: block; width: 60px">
                                <%# Eval("UsedTime") %></span>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
    <%--<input type="button" onclick="sss();" value="ceshi" />
    <script type="text/javascript">
        function sss() {
            $("[id$='hfautoidcard']").val("1232143243453");
            $("[id$='btnauto']").click();
        }
    </script>--%>
</asp:Content>
