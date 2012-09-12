<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ScenicPay.aspx.cs" Inherits="Scenic_ScenicPay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Styles/PayScenic.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        //        function add() {
        //            var count = $("[id$='txtcount']").val();
        //            if (count > 0) {
        //                count = parseInt(count) + 1;
        //            }
        //            else {
        //                count = 1;
        //            }
        //            $("[id$='txtcount']").val(count);
        //            var goupiaojia = $("[id$='goumaijia']").html().toString().substring(0, $("[id$='goumaijia']").text().length - 1);
        //            var total = parseFloat(goupiaojia) * parseInt(count);
        //            $("[id$='total']").html(parseInt(total) + "元");
        //            $("[id$='ptotal']").html("总计:" + parseInt(total) + "元");
        //            $("[id$='fonttotal']").html(parseInt(total));
        //        }

        //        function jian() {
        //            var count = $("[id$='txtcount']").val();
        //            if (count > 1) {
        //                count = parseInt(count) - 1;
        //            }
        //            else {
        //                count = 1;
        //            }
        //            $("[id$='txtcount']").val(count);
        //            var goupiaojia = $("[id$='goumaijia']").html().toString().substring(0, $("[id$='goumaijia']").text().length - 1);
        //            var total = parseFloat(goupiaojia) * parseInt(count);
        //            $("[id$='total']").html(parseInt(total) + "元");
        //            $("[id$='ptotal']").html("总计:" + parseInt(total) + "元");
        //            $("[id$='fonttotal']").html(parseInt(total));
        //        }

        function add(obj) {
            var flagdivindex = $(obj).parent().parent().index();
            var t = "cphmain_rptscenic_goumaijia_" + flagdivindex;
            var goupiaojia = $("#" + t).html().toString().substring(0, $("#" + t).text().length - 1);
            var tcount = "cphmain_rptscenic_txtcount_" + flagdivindex;
            var count = $("#" + tcount).val();
            if (count < 1) {
                count = 1;
            }
            else {
                count = parseInt(count) + 1;
            }
            $("#" + tcount).val(count);
            var total = parseFloat(goupiaojia) * parseInt(count);
            var ttotal = "cphmain_rptscenic_total_" + flagdivindex;
            $("#" + ttotal).html(parseInt(total) + "元");
            var totalprice = 0;
            for (var i = 0; i < $("#flagdiv").size(); i++) {
                var x = "cphmain_rptscenic_total_" + i;
                var ttt = $("#" + x).html().toString().substring(0, $("#" + x).text().length - 1);
                totalprice = parseInt(totalprice + parseInt(ttt));
            }
            $("[id$='ptotal']").html("总计:" + parseInt(totalprice) + "元");
            $("[id$='fonttotal']").html(parseInt(totalprice));
        }

        function jian(obj) {
            var flagdivindex = $(obj).parent().parent().index();
            var t = "cphmain_rptscenic_goumaijia_" + flagdivindex;
            var goupiaojia = $("#" + t).html().toString().substring(0, $("#" + t).text().length - 1);
            var tcount = "cphmain_rptscenic_txtcount_" + flagdivindex;
            var count = $("#" + tcount).val();
            if (count < 2) {
                count = 1;
            }
            else {
                count = parseInt(count) - 1;
            }
            $("#" + tcount).val(count);
            var total = parseFloat(goupiaojia) * parseInt(count);
            var ttotal = "cphmain_rptscenic_total_" + flagdivindex;
            $("#" + ttotal).html(parseInt(total) + "元");
            var totalprice = 0;
            for (var i = 0; i < $("#flagdiv").size(); i++) {
                var x = "cphmain_rptscenic_total_" + i;
                var ttt = $("#" + x).html().toString().substring(0, $("#" + x).text().length - 1);
                totalprice = parseInt(totalprice + parseInt(ttt));
            }
            $("[id$='ptotal']").html("总计:" + parseInt(totalprice) + "元");
            $("[id$='fonttotal']").html(parseInt(totalprice));
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <div id="paymain">
        <%--<p class="ddinfo" runat="server">
            请输入游客信息</p>
            <asp:Repeater ID="rptidcard" runat="server">
                        <HeaderTemplate>
                            <div class="idcarddiv"><span class="spanname">姓名</span><span class="spanidcard">身份证号</span></div>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="idcarddiv">
                                <asp:HiddenField ID="hfisued" runat="server" Value='<%# Eval("IsUsed") %>' />
                                <asp:TextBox ID="txtName" runat="server" CssClass="UserName" Text='<%# Eval("Name") %>' style="border:1px solid #EEEEEE;"></asp:TextBox>
                                <asp:TextBox ID="txtidCard" runat="server" CssClass="idcard" Text='<%# Eval("IdCard") %>' style="border:1px solid #EEEEEE;"></asp:TextBox>
                            </div>
                        </ItemTemplate>
             </asp:Repeater>--%>


        <p class="ddinfo" id="typeinfo" runat="server">
            你的订单信息</p>
        <div id="paylist">
            <span class="areaname" style="width: 200px">景区名称</span> <span class="yuanjia">原价</span>
            <span class="yuanjia" id="typeprice" runat="server">购票价格</span> <span class="yuanjia">
                数量</span> <span class="yuanjia">小计</span>
        </div>
        <div id="payinfo">
            <asp:Repeater ID="rptscenic" runat="server" OnItemDataBound="rptscenic_ItemDataBound">
                <ItemTemplate>
                    <div id="flagdiv">
                        <asp:HiddenField ID="hfscid" runat="server" Value='<%# Eval("Scenic.Id") %>' />
                        <span class="areaname2" style="width: 200px" id="areaname" runat="server">
                        <a href='/scenic/?id=<%#Eval("Scenic.Id") %>'>
                            <%# Eval("Scenic.Name")%>
                        </a></span><span class="yuanjia" id="yuanjia" runat="server">100元</span> <span class="yuanjia"
                            id="goumaijia" runat="server">70元</span> <span class="yuanjia">
                                <input type="button" class="btnjian2"  style="cursor: pointer" onclick="jian(this)" />
                                <asp:TextBox ID="txtcount" CssClass="count" runat="server" Text="1"></asp:TextBox>
                                <input type="button" class="btnadd2"  style="cursor: pointer" onclick="add(this)" />
                            </span><span class="yuanjia" id="total" runat="server">70元</span>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <hr noshade="noshade" />
        <div id="totalnum">
            <p runat="server" id="ptotal">
                总计:70元</p>
        </div>
        <div id="totalpay">
            总共支付:<font runat="server" id="fonttotal" style="font-size: 26px; color: #CB1F2D">70</font>元</div>
        <div id="btnpay">
            <asp:Button ID="btnPay" runat="server" Text="确认订单" CssClass="btngopay" OnClick="btnPay_Click" /></div>
    </div>
</asp:Content>
