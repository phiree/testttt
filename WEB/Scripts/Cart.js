var cartcookiename = "_cart";

var Cart = function () {
    var items = [];
    var cartCookie = $.cookie(cartcookiename);
    if (cartCookie == null || cartCookie == undefined) {
        cartCookie = $.cookie(cartcookiename, JSON.stringify(items));
    }
    else {
        items = JSON.parse(cartCookie);
    }
    this.CartItems = items;
    this.Sum();
  
}

Cart.prototype.Save = function () {
    var strCartItems = JSON.stringify(this.CartItems);
    $.cookie(cartcookiename, strCartItems);
    this.Sum();
}
   


Cart.prototype.IsInCart = function (ticketId) {
    for (var i = 0; i < this.CartItems.length; i++) {
        if (this.CartItems[i].TicketId + "" == ticketId + "") {
            return this.CartItems[i];
        }
    }
}
Cart.prototype.AddToCart = function (ticketId, qty) {
    var item = this.IsInCart(ticketId);
    qty = EnsureCartQty(qty);
    if (item) {
        item.Qty = qty;
    }
    else {
        item = { TicketId: ticketId, Qty: qty };
        this.CartItems.push(item);
    }
    this.Save();
}
Cart.prototype.ModifyQty = function (ticketId, qty) {
    var item = this.IsInCart(ticketId);
    if (item != null) {

        item.Qty = EnsureCartQty(qty);
        this.Save();
    }
    else {
        this.AddToCart(ticketId, qty);
       
    }
}
Cart.prototype.GetQty = function (ticketId) {

    var item = this.IsInCart(ticketId);
    if (item != null) return item.Qty;
    else return null;
}
Cart.prototype.Delete = function (ticketId) {
    var item = this.IsInCart(ticketId);
    this.CartItems.Remove(item);
    this.Save();
}

Cart.prototype.Sum = function () {
    var totalQty = 0;
    for (var i = 0; i < this.CartItems.length; i++) {
        var qty = parseInt(this.CartItems[i].Qty);
        totalQty += qty;
    }
    this.TotalQty = totalQty;
    $("#cartsum").text(totalQty);
    
}


function EnsureCartQty(qty) {
    qty = parseInt(qty.toString());
    if (isNaN(qty)) qty = 1;
    if (qty <= 0) {
        qty = 1;
        alert("数量至少为1");
    };
    if (qty > 999) {

        qty = 999;
        alert("同一景区的最大购票数量为999");
    };
    return qty;
}

