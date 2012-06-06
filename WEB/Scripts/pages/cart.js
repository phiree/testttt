$(function () {
    //init qty
    var theCart = new Cart();
    for (var i in theCart.CartItems) {
        var item = theCart.CartItems[i];
        var ticketId = item.TicketId;
        var qty = item.Qty;
        $("input.hdId[value='" + ticketId + "']").parent().parent().find("input.qtyModify").val(qty);
    }
    //modify qty
    function ModifyQty(that, type) {

        var ticketId = $($(that).parent().parent().children()[0]).children("input:hidden").val();
        var qtyModify = $(that).parent().children(".qtyModify");
        var qty = parseInt($(qtyModify).val());
        var nowQty;
        if (type == "add")
        { nowQty = qty + 1; }
        else if (type == "cut")
        { nowQty =  qty - 1; }
        else if (type == "modify") {
            nowQty =  qty;
        }
        else if (type = "delete") {


            theCart.Delete(ticketId);
            $(that).parent().parent().remove();
            TicketSum();
            return;

        }
        //change the value
        nowQty = EnsureCartQty(nowQty)
        $(qtyModify).val(nowQty);
        theCart.ModifyQty(ticketId, nowQty);
        TicketSum();
    }
    $(".qtyAdd").click(function () {
        ModifyQty(this, "add");

    });
    $(".qtyCut").click(function () {
        ModifyQty(this, "cut");

    });
    $(".qtyModify").change(function () {
        ModifyQty(this, "modify");

    });
    $(".delete").click(function () {
        ModifyQty(this, "delete");

    });
    //ticketsSum
    function TicketSum() {
        var totalQty = 0;
        $("input.qtyModify").each(function () {
            var qty = parseInt($(this).val());
            totalQty += qty;

        });
        $("#ticketsSum").text(totalQty);
    };
    TicketSum();


});