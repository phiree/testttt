var cart = new Cart();
function AddToCart(btn, id) {
    var h;
    var randomParam = new Date().toString();
    $.get("/Scenic/CheckHandler.ashx?id=" + id + "&type=" + randomParam, function (data, status) {
        if (data != "true") {
            alert(data);
        }
        else {
            //var qty = $("#txtTicketCount").val();
            cart.AddToCart(GetTicketId(btn), 1);
            //  window.location.href = "/order/cart.aspx";
            //衢州活动 直接跳转至确认页面
            window.location.href = "/order/checkout.aspx";
        }
    });

}




function GetTicketId(btn) {
    var ticketId = 0;
    ticketId = $($(btn).parent().siblings()[0]).children("input").val()

    return ticketId;
}

function ShowPriceIntro() {
    $("#priceintrodiv").css("display", "block");
    var mubiao = $(".priceintro");
    $("#priceintrodiv").css({ left: mubiao.position().left + "px", top: mubiao.position().top - 10 + "px" });
}
function ClosePriceIntro() {
    $("#priceintrodiv").css("display", "none");
}
function btnselect(obj) {
    var that = obj;
    $(".selectinfospan span").attr("class", "");
    $(that).attr("class", "highselected");
    var f = $("#plate1").html();
    var t = $("#scdetailplate").html();
    if ($(".highselected").html().toString().trim() == "交通指南") {
        $("#changeinfo").html("<div id='plate1'>" + f + "</div>" + "<p id='plap'>" + "景区简介" + "</p>" + "<div id='scdetailplate'>" + t + "</div>");
    }
    if ($(".highselected").html().toString().trim() == "景区简介") {
        $("#changeinfo").html("<div id='scdetailplate'>" + t + "</div>" + "<p id='plap'>" + "交通指南" + "</p>" + "<div id='plate1'>" + f + "</div>");
    }
    flag = 1;
    // showMap();
}

$(window).scroll(function () {
    findDimensions();
    $(".backtop").css("right", (winWidth - 950) / 2 - 50);
    $(".backtop").click(function () {
        window.scrollTo(0, 0);
    });
    $(".backtop").css("position", "fixed");
    if (document.documentElement.scrollTop + document.body.scrollTop > 100) {
        $(".backtop").fadeIn("fast");
    }
    else {
        $(".backtop").fadeOut("fast");
    }
    if (document.body.scrollHeight - document.documentElement.scrollTop - document.body.scrollTop - winHeight < 347) {
        $(".backtop").css("position", "absolute");
    }
});

$(function () {
    $("#priceinfo table tr").each(function () {
        if ($(this).attr("class") != "tstr") {
            $(this).mouseover(function () {
                $(this).find("td").css("background-color", "#FFFCE6");
            });
            $(this).mouseout(function () {
                $(this).find("td").css("background-color", "");
            });
        }
    });
    getTicketCount();
    showMap();
});

var map;
var position;
var flag = 1;
function showMap() {
    position = $("[id$='hfposition']").val();
    if (position == null || position == undefined || position == "")
        position = "120.141175,30.303563";
    var latlng = new BMap.Point(position.split(",")[0], position.split(",")[1]);
    map = new BMap.Map("containtermap");
    map.centerAndZoom(latlng, 9);
    map.addControl(new BMap.ScaleControl());
    map.addControl(new BMap.OverviewMapControl());
    map.addControl(new BMap.NavigationControl({ offset: new BMap.Size(10, 50) }));
    if (flag == 1) {
        map.centerAndZoom(latlng, 9);
        flag++;
    }
    else {
        map.setCenter(latlng);
        map.setZoom(map.getZoom());
    }
    var txt = $("[id$='hfscname']").val();
    var overlay = new customOverlay_Large({ latlng: latlng, text: txt, id:0  });
    map.addOverlay(overlay);
}

function gotocenter() {
    var latlng = new BMap.Point(position.split(",")[0], position.split(",")[1]);
    if (flag == 1) {
        map.centerAndZoom(latlng, 9);
        flag++;
    }
    else {
        map.setCenter(latlng);
        map.setZoom(map.getZoom());
    }
}
/*创建baidu自定义覆盖物*/
function customOverlay_Large(options) {
    //初始化参数
    this._latlng = options.latlng; //设置图标位置
    this._text = options.text;
    this._id = options.id;
    this._scid = options.scid;
}
customOverlay_Large.prototype = new BMap.Overlay();
//初始化图标
customOverlay_Large.prototype.initialize = function () {
    this._map = map;
    var div = this._div = document.createElement("div");
    div.style.position = "absolute";
    div.style.zIndex = BMap.Overlay.getZIndex(this._latlng.lat);
    div.className = "divicon";
    div.style.MozUserSelect = "none";
    div.style.fontSize = "12px";
    div.id = this._div;
    div.name = this._name;


    var spanscenic = this._span = document.createElement("span");
    div.appendChild(spanscenic);
    spanscenic.height = "15px";
    spanscenic.style.position = "relative";
    spanscenic.style.top = "-2px \0";
    spanscenic.style.display = "inline-block";
    spanscenic.style.lineHeight = "15px";
    spanscenic.style.color = "White";
    spanscenic.appendChild(document.createTextNode(this._text))


    var arrow = this._arrow = document.createElement("div");
    arrow.style.background = "url('/Img/yuansu/largeicon3.gif') no-repeat";
    arrow.style.position = "absolute";
    arrow.style.width = "15px";
    arrow.style.height = "14px";
    arrow.style.top = "19px";
    arrow.style.left = "10px";
    arrow.style.overflow = "hidden";
    div.appendChild(arrow);
    map.getPanes().labelPane.appendChild(div);
    return div;
}
//绘制图标，主要用于控制图标的位置
customOverlay_Large.prototype.draw = function () {
    var map = this._map;
    var pixel = map.pointToOverlayPixel(this._latlng);
    this._div.style.left = pixel.x - parseInt(this._arrow.style.left) + "px";
    this._div.style.top = pixel.y - 30 + "px";
}
function getTicketCount() {


    $.get("/Scenic/CheckHandler.ashx?date=1", function (time, status) {
        //        $.ajax({
        //            type: "POST",
        //            contentType: "application/json",
        //            url: "/TourolService/quzhouspring/TicketService.asmx/ProductInfo",
        //            data: "{PartnerCode:'tourol.cn',productCode:'" + $("[id$='hfProductCode']").val() + "',dt:'" + time + "'}",
        //            dataType: "json",
        //            success: function (msg) {

        //            }
        //        });
        var msg = $("[id$='hfSyCount']").val();
        if (msg == "" || parseInt(msg)<=0) {
            $("[id$='qzTicketCount']").html("<span class='noTc' style=' font-size:14px;'>已抢完</span>");
            $(".btnputcart").each(function () {
                if ($(this).attr("isActivity") == "true") {
                    $(this).attr("onclick", "");
                    $(this).click(function () {
                        alert("今天的门票已抢完，请您明天来抢票！");
                        return false;
                    });
                }
            });
        }
        else {
            $("[id$='qzTicketCount']").html("<span class='tc'>余<span class='countSum' style=' font-size:24px; font-weight:bold;'>" + msg + "</span>张</span>");
        }
    });
}