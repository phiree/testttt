<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="Order.aspx.cs" Inherits="Hotels_Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-1.8.2.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-1.9.1.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jquery.validate.min.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jquery.validate.messages_zh.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jquery.validation.net.webforms.js" type="text/javascript"></script>
    <link href="/Scripts/jqueryplugin/jqueryui/css/ui-lightness/jquery-ui-1.9.1.custom.min.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("#<%=tbxDateBegin.ClientID %>").datepicker({ minDate: new Date() });
            $("#<%=tbxDateEnd.ClientID %>").datepicker({ minDate: new Date() });
            $("#copylxr").click(function () {
                $("#<%=txtrzr.ClientID %>").val($("#<%=txtlxr.ClientID %>").val());
            });
            $("#btnsubmit").click(function () {

            });
            $("#<%=ddlroomnum.ClientID %>").change(function () {
                var num = $("#<%=ddlroomnum.ClientID %> option:selected").text();
                var price = $("#<%=hide_Price.ClientID %>").val();
                $("#<%=lblprice.ClientID %>").text(num * price).toString("C2");
                if (num == "1") {
                    $("#row2").attr("style", "display:none");
                    $("#row3").attr("style", "display:none");
                    $("#row4").attr("style", "display:none");
                    $("#row5").attr("style", "display:none");
                }
                if (num == "2") {
                    $("#row2").removeAttr("style");
                    $("#row3").attr("style", "display:none");
                    $("#row4").attr("style", "display:none");
                    $("#row5").attr("style", "display:none");
                }
                if (num == "3") {
                    $("#row2").removeAttr("style");
                    $("#row3").removeAttr("style");
                    $("#row4").attr("style", "display:none");
                    $("#row5").attr("style", "display:none");
                }
                if (num == "4") {
                    $("#row2").removeAttr("style");
                    $("#row3").removeAttr("style");
                    $("#row4").removeAttr("style");
                    $("#row5").attr("style", "display:none");
                }
                if (num == "5") {
                    $("#row2").removeAttr("style");
                    $("#row3").removeAttr("style");
                    $("#row4").removeAttr("style");
                    $("#row5").removeAttr("style");
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    您预订的是：<asp:Label ID="lblhotelname1" Text="text" runat="server" />
    <hr />
    预订详情：房型信息<br />
    <div class="hotel_info" style="float: left;width:230px;">
        <div class="l">
            <asp:Image ID="imghotel" ImageUrl="" runat="server" /></div>
        <div class="r">
            <a title="" href="" target="_blank" runat="server">
                <asp:Label Text="text" runat="server" ID="lblhotelname2" /></a><br>
            <p class="dizhi">
                <asp:Label ID="lblhoteladdress" Text="text" runat="server" />
            </p>
        </div>
        <div class="clear">
        </div>
        <!--促销信息-->
        <div class="rm_type">
            <ul>
                <li><span>房&nbsp;&nbsp;&nbsp;型：</span><asp:Label Text="text" runat="server" ID="lblroomtype"/></li>
                <li><span>床&nbsp;&nbsp;&nbsp;型：</span><asp:Label Text="text" runat="server" ID="lblbedtype"/></li>
                <li><span>早&nbsp;&nbsp;&nbsp;餐：</span><asp:Label Text="text" runat="server" ID="lblbreakfast"/></li>
                <li><span>宽&nbsp;&nbsp;&nbsp;带：</span><asp:Label Text="text" runat="server" ID="lblnet"/></li>
            </ul>
        </div>
        <!--促销信息 end-->
    </div>
    <div>
        <table border="1" cellpadding="1" cellspacing="1">
            <tr>
                <td>
                    房型数量：
                </td>
                <td>
                    <asp:DropDownList ID="ddlroomnum" runat="server">
                        <asp:ListItem Value="1" Text="1" />
                        <asp:ListItem Value="2" Text="2" />
                        <asp:ListItem Value="3" Text="3" />
                        <asp:ListItem Value="4" Text="4" />
                        <asp:ListItem Value="5" Text="5" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    单价：
                </td>
                <td>
                    <asp:Label Text="text" runat="server" ID="lblprice" />
                </td>
            </tr>
            <tr>
                <td>
                    入住时间：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxDateBegin"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    离店时间：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxDateEnd"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    付款方式：
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    附加服务：
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table border="1" cellpadding="1" cellspacing="1">
            <tr>
                <td>
                    联系人：
                </td>
                <td>
                    <input id="txtlxr" type="text" name="name" value=" " runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    手机号码：
                </td>
                <td>
                    <input id="txtphone" type="text" name="name" value=" " runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    邮箱：
                </td>
                <td>
                    <input id="txtemail" type="text" name="name" value=" " runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    固定电话：
                </td>
                <td>
                    <input id="txttel" type="text" name="name" value=" " runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    入住人姓名：
                </td>
                <td>
                    <input id="txtrzr" type="text" name="name" value=" " runat="server" /><a id="copylxr">复制联系人</a>
                </td>
            </tr>
            <tr id="row2" style="display:none" >
                <td>客人2
                </td>
                <td>
                    <input id="txtrzr2" type="text" name="name" value=" " runat="server" />
                </td>
            </tr>
            <tr id="row3" style="display:none" >
                <td>客人3
                </td>
                <td>
                    <input id="txtrzr3" type="text" name="name" value=" " runat="server"/>
                </td>
            </tr>
            <tr id="row4" style="display:none" >
                <td>客人4
                </td>
                <td>
                    <input id="txtrzr4" type="text" name="name" value=" " runat="server"/>
                </td>
            </tr>
            <tr id="row5" style="display:none" >
                <td>客人5
                </td>
                <td>
                    <input id="txtrzr5" type="text" name="name" value=" " runat="server"/>
                </td>
            </tr>
            <tr>
                <td>
                    最早到达：
                </td>
                <td>
                    <asp:DropDownList ID="ddlearly" runat="server">
                        <asp:ListItem Text="10:00" />
                        <asp:ListItem Text="11:00" />
                        <asp:ListItem Text="12:00" />
                        <asp:ListItem Text="13:00" />
                        <asp:ListItem Text="14:00" />
                        <asp:ListItem Text="15:00" />
                        <asp:ListItem Text="16:00" />
                        <asp:ListItem Text="17:00" />
                        <asp:ListItem Text="18:00" />
                        <asp:ListItem Text="19:00" />
                        <asp:ListItem Text="20:00" />
                        <asp:ListItem Text="21:00" />
                        <asp:ListItem Text="22:00" />
                        <asp:ListItem Text="23:00" />
                        <asp:ListItem Text="23:59" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    最晚到达：
                </td>
                <td>
                    <asp:DropDownList ID="ddllate" runat="server">
                        <asp:ListItem Text="10:00" />
                        <asp:ListItem Text="11:00" />
                        <asp:ListItem Text="12:00" />
                        <asp:ListItem Text="13:00" />
                        <asp:ListItem Text="14:00" />
                        <asp:ListItem Text="15:00" />
                        <asp:ListItem Text="16:00" />
                        <asp:ListItem Text="17:00" />
                        <asp:ListItem Text="18:00" />
                        <asp:ListItem Text="19:00" />
                        <asp:ListItem Text="20:00" />
                        <asp:ListItem Text="21:00" />
                        <asp:ListItem Text="22:00" />
                        <asp:ListItem Text="23:00" />
                        <asp:ListItem Text="23:59" />
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnsubmit" Text="提交订单" runat="server" OnClick="btnsubmit_Click" />
    </div>
    <asp:HiddenField ID="hide_CurrencyCode" runat="server" />
    <asp:HiddenField ID="hide_RoomTypeId" runat="server" />
    <asp:HiddenField ID="hide_GuestTypeCode" runat="server" />
    <asp:HiddenField ID="hide_Price" runat="server" />
</asp:Content>
