<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true" CodeFile="GroupMemberid.aspx.cs" Inherits="LocalTravelAgent_GroupMemberid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
        var result = true;
        var datas = '';
        tabledom.each(function () {
            var ticketname = $(this).children().children().val();
            var yuanjia = $(this).children().next().children().val();
            var xianfujia = $(this).children().next().next().children().val();
            var zaixianjia = $(this).children().next().next().next().children().val();
            var ticketid = $(this).children().next().next().next().next().children().val();
            var scid = $("input[id*=hidden_scid]").val();
            datas += '{' + ticketname + ',' + yuanjia + ',' + xianfujia + ',' + zaixianjia + ',' + ticketid + ',' + scid;
        });
        $.ajax({
            type: "Post",
            url: "TicketPriceHandler.ashx",
            dataType: "json",
            data: datas,
            success: function (data, status) {
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

    //添加行
    $(function () {
        $("#addrow").click(function () {
            var tbody = $(this).parent().parent().parent().next().html();
            tbody += "<tr><td><input type='text' style='width:150px' /></td><td><input type='text' /></td><td><input type='text' />" +
                "</td><td><input type='text' /></td><td><input type='hidden' /><input type='hidden' />" +
                "<input onclick='delrow(this)' class='delrow' type='button' style='width: 25px;' value='-' /></td></tr>";
            $(this).parent().parent().parent().next().html(tbody);
        });
    });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

        <table class="tableMemberid" id="tptable">
            <thead>
                <tr>
                    <td>
                        类型
                    </td>
                    <td>
                        姓名
                    </td>
                    <td>
                        身份证号
                    </td>
                    <td>
                        联系方式
                    </td>
                    <td>
                        <input id="addrow" type="button" style="width: 25px;" value="+" />
                    </td>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptMember" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input type="text" value='<%# Eval("Name") %>' style="width:150px" />
                            </td>
                            <td>
                                <input type="text" value='<%# ((IList<Model.TicketPrice>)Eval("TicketPrice")).Where(x => x.PriceType == Model.PriceType.Normal).First().Price.ToString("0") %>' />
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
        </table>
        <input type="button" name="name" class="btnokprice" onclick="calc()" style="margin-left:30px; vertical-align:middle;" />
        <a href="/scenicmanager/onlinesell/PrintScenicPrice.aspx" style=" vertical-align:middle;margin-left:430px">进入下一步</a>
        <input type="hidden" id="hidden_scid" runat="server" />
</asp:Content>

