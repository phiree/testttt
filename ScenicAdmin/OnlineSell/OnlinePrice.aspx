<%@ Page Title="" Language="C#" MasterPageFile="~/sm.master" AutoEventWireup="true"
    CodeFile="OnlinePrice.aspx.cs" Inherits="ScenticManager_OnlineSell_OnlinePrice" %>

<%@ MasterType VirtualPath="~/sm.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" runat="Server">
    <link href="/theme/default/css/smdefault.css" rel="stylesheet" type="text/css" />
    <link href="/Scripts/jqueryplugin/jqueryui/css/ui-lightness/jquery-ui-1.9.1.custom.min.css"
        rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-datepicker-zh.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-1.9.1.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".sxjsj").datepicker();

            //添加行
            $("#addrow").click(function () {
                var tbody = $(this).parent().parent().parent().next();
                var a = $("<tr><td><input type='text' style='width:100px' /></td><td><input type='text' style='width: 60px' /></td><td><input type='text' style='width: 60px' />" +
                                                "</td><td><input type='text' style='width: 60px' /></td><td><input class='sxjsj' type='text' style='width: 70px' name='name' value=' ' /></td>" +
                                                "<td><input class='sxjsj' type='text' style='width: 70px' name='name' value=' ' /></td><td><input type='hidden' /><input type='hidden' />" +
                                                "<a onclick='delrow(this)' style='cursor:pointer'>删除</a></td></tr>");
                a.appendTo(tbody);
                calldatepicker();
            });
        });
        function calldatepicker() {
            $(".sxjsj").datepicker();
        }
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
            var result = true;
            var datas = '';
            tabledom.each(function () {
                var ticketname = $(this).children().children().val();
                var yuanjia = $(this).children().next().children().val();
                var xianfujia = $(this).children().next().next().children().val();
                var zaixianjia = $(this).children().next().next().next().children().val();
                var update = $(this).children().next().next().next().next().children().val();
                var downdate = $(this).children().next().next().next().next().next().children().val();
                var ticketid = $(this).children().next().next().next().next().next().next().children().val();
                var scid = $("input[id*=hidden_scid]").val();
//                alert('名称:' + ticketname + ' 价格：' + yuanjia + '-' + xianfujia + '-' + zaixianjia
//                    + ' ticketid:' + ticketid + ' scid:' + scid+ '上下架时间：' + update + '--' + downdate);
                datas += '{' + ticketname + ',' + yuanjia + ',' + xianfujia + ',' + zaixianjia + ',' + ticketid + ',' + scid + ',' + update + ',' + downdate;
            });
            $.ajax({
                type: "Post",
                url: "TicketPriceHandler.ashx",
                dataType: "json",
                data: datas,
                success: function (data, status) {
                    result = status == "success";
                }
            });
            if (result)
                alert("修改成功！");
            else
                alert("修改失败！");
            //return false;
        }

        //删除行
        function delrow(obj) {
            $(obj).parent().parent().remove();
        }

        function btnchange() {
            $("[id$='btnchange22']").click();
        }
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
        <%--<div class="paystate">
            <a href="/onlinesell/OnlinePrice.aspx" class="nowstate">填写景区价格</a>><a>打印价格表</a>><a>上传盖章后价格表</a>><a>申请</a>
        </div>--%>
        <div class="priceintroduction">
            门票价格介绍
            <ul>
                <li>门市价:正常销售价格</li>
                <li>景区现付价:网上预定价格,游客在进入景区时付款</li>
                <li>在线支付价:网上支付的价格</li>
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
                        景区现付价
                    </td>
                    <td>
                        在线支付价
                    </td>
                    <td>
                        上架时间
                    </td>
                    <td>
                        下架时间
                    </td>
                    <td>
                        <a id="addrow" style="cursor:pointer">添加</a>
                    </td>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptPrice" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input type="text" value='<%# Eval("Name") %>' style="width: 100px" />
                            </td>
                            <td>
                                <input type="text" style="width: 60px" value='<%# ((IList<Model.TicketPrice>)Eval("TicketPrice")).Where(x => x.PriceType == Model.PriceType.Normal).First().Price.ToString("0") %>' />
                            </td>
                            <td>
                                <input type="text" style="width: 60px" value='<%# ((IList<Model.TicketPrice>)Eval("TicketPrice")).Where(x => x.PriceType == Model.PriceType.PreOrder).First().Price.ToString("0") %>' />
                            </td>
                            <td>
                                <input type="text" style="width: 60px" value='<%# ((IList<Model.TicketPrice>)Eval("TicketPrice")).Where(x => x.PriceType == Model.PriceType.PayOnline).First().Price.ToString("0") %>' />
                            </td>
                            <td>
                                <input class="sxjsj" type="text" style="width: 70px" name="name" value='<%# DateTime.Parse(Eval("BeginDate").ToString()).ToString("yyyy-MM-dd") %>'  id="txtbegin" />
                            </td>
                            <td>
                                <input class="sxjsj" type="text" style="width: 70px" name="name" value='<%# DateTime.Parse(Eval("EndDate").ToString()).ToString("yyyy-MM-dd") %>'  id="txtend" />
                            </td>
                            <td>
                                <input type="hidden" value='<%# Eval("Id") %>' />
                                <input type="hidden" value='<%# Eval("Scenic.Id") %>' />
                                <a onclick='delrow(this)' style="cursor:pointer">删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <input type="button" name="name" class="btnokprice" onclick="calc()" style="margin-left: 30px;
            vertical-align: middle;" /><a style="vertical-align: middle;
                margin-left: 430px; cursor:pointer" onclick="btnchange()">进入下一步</a>
        <input type="hidden" id="hidden_scid" runat="server" />
    </div>
    <div style="display:none">
        <asp:Button ID="btnchange22" runat="server" Text="Button" 
            onclick="btnchange_Click" />
    </div>
</asp:Content>
