var tip = "输入景区或景点名称";
$(function () {

    $("#tbxKeywords").InlineTip({ "tip": tip });

    $("#btnSearch").click(
            function () {
                var that = this;
                var keyword = $("#tbxKeywords").val();
                if (keyword == "" || keyword == tip) {
                    return false;
                }
            }
            );
    $("#cart").hover(function () {
        $("#popcart").toggle();
    });



    var cart = new Cart();
    $(".cartdelete").click(function () {
        cart.Delete($(this).attr("tid"));
        $(this).parent().parent().addClass("deleted");
    });
    //每张门票数量.
    $("#pcbody .pcqty").each(function () {
        var that = this;
        var pid = $($($(that).parent().siblings()[0]).children()[0]).attr("tid");
        var qty = cart.GetQty(pid);
        $(that).text(qty);
    });
    //购物车内的统计数据
    $("#ticketsSum").text(cart.TotalQty);
    $("#scenicSum").text(cart.CartItems.length);
});