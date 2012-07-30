<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true"
    CodeFile="OnlinePrice.aspx.cs" Inherits="ScenticManager_OnlineSell_OnlinePrice" %>

<%@ MasterType VirtualPath="~/ScenicManager/sm.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" runat="Server">
    <link href="/theme/default/css/smdefault.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function Pricepd() {
            var price = $("[id$='tbxPrice']").val();
            var orderprice = $("[id$='tbxPreOrder']").val();
            var payonline = $("[id$='tbxPayOnline']").val();
            if (parseInt(price) > parseInt(orderprice) && parseInt(orderprice) > parseInt(payonline)) {
                return true;
            }
            else {
                alert("填写的价格有误，请重新填写!");
                return false;
            }
        }

        function calc() {
            var tabledom = $("tbody>tr");
            tabledom.each(function () {
                var ticketname = $(this).children().children().val();
                var yuanjia = $(this).children().next().children().val();
                var mingxipianjia = $(this).children().next().next().children().val();
                var xianfujia = $(this).children().next().next().next().children().val();
                var zaixianjia = $(this).children().next().next().next().next().children().val();
                var ticketid = $(this).children().next().next().next().next().next().children().val();
                var scid = $("input[id*=hidden_scid]").val();
                Boolean result=true;
                //alert("ticketname:" + ticketname + " yuanjia:" + yuanjia + " mxp:" + mingxipianjia + " xianfujia:" + xianfujia + " zaixianjia:" + zaixianjia + " ticketid:" + ticketid + "scid:" + scid);
                $.ajax({
                    type: "Post",
                    url: "TicketPriceHandler.ashx",
                    dataType: "json",
                    data: { 'ticketname': ticketname, 'yuanjia': yuanjia, 'mingxipianjia': mingxipianjia, 'xianfujia': xianfujia, 'zaixianjia': zaixianjia, "ticketid": ticketid, "scid": scid },
                    success: function (data, status) {
                        alert("修改成功！");
                    }
                });
            });
            return false;
        }

        //删除行
        function delrow(obj) {
            $(obj).parent().parent().remove();
        }

        //添加行
        $(function () {
            $("#addrow").click(function () {
                var tbody = $(this).parent().parent().parent().next().html();
                tbody += "<tr><td><input type='text' /></td><td><input type='text' /></td><td><input type='text' />" +
                "</td><td><input type='text' /></td><td><input type='text' /></td><td><input type='hidden' /><input type='hidden' />" +
                "<input onclick='delrow(this)' class='delrow' type='button' style='width: 25px;' value='-' /></td></tr>";
                $(this).parent().parent().parent().next().html(tbody);
            });
        });
    </script>
    <style type="text/css">
        td input
        {
            width: 80px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <p class="fuctitle">
        <a style="cursor: pointer; text-decoration: none; color: #2E6391;" onclick="javascript:history.go(-1);">
            景区门票信息</a>&nbsp;>&nbsp;修改景区价格</p>
    <hr />
    <div id="updateprice">
        <div class="priceintroduction">
            门票价格介绍
            <ul>
                <li>门市价:正常销售价格</li>
                <li>景区现付价:网上预定价格,游客在进入景区时付款</li>
                <li>网上订购价:网上支付的价格</li>
            </ul>
        </div>
        <hr style="border: 0px none; border-top: 1px solid Gray; width: 95%;" />
        <table class="tableprice" id="tptable">
            <thead>
                <tr>
                    <td>
                        景区门票
                    </td>
                    <td>
                        门票原价
                    </td>
                    <td>
                        明信片优惠价
                    </td>
                    <td>
                        景区现付价
                    </td>
                    <td>
                        在线支付价
                    </td>
                    <td>
                        <input id="addrow" type="button" style="width: 25px;" value="+" />
                    </td>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptPrice" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input type="text" value='<%# Eval("Name") %>' />
                            </td>
                            <td>
                                <input type="text" value='<%# ((IList<Model.TicketPrice>)Eval("TicketPrice")).Where(x => x.PriceType == Model.PriceType.Normal).First().Price.ToString("0") %>' />
                            </td>
                            <td>
                                <input type="text" value='<%# ((IList<Model.TicketPrice>)Eval("TicketPrice")).Where(x => x.PriceType == Model.PriceType.PostCardDiscount).First().Price.ToString("0")%>' />
                            </td>
                            <td>
                                <input type="text" value='<%# ((IList<Model.TicketPrice>)Eval("TicketPrice")).Where(x => x.PriceType == Model.PriceType.PreOrder).First().Price.ToString("0") %>' />
                            </td>
                            <td>
                                <input type="text" value='<%# ((IList<Model.TicketPrice>)Eval("TicketPrice")).Where(x => x.PriceType == Model.PriceType.PayOnline).First().Price.ToString("0") %>' />
                            </td>
                            <td>
                                <input type="hidden" value='<%# Eval("Id") %>' />
                                <input type="hidden" value='<%# Eval("Scenic.Id") %>' />
                                <input type="button" style="width: 25px;" value="-" onclick="delrow(this)" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <%-- <tr>
                <td>
                    
                </td>
            </tr>--%>
        </table>
        <input type="button" name="name" class="btnokprice" onclick="calc()" />
        <input type="hidden" id="hidden_scid" runat="server" />
    </div>
</asp:Content>
