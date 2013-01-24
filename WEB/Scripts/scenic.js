var cart = new Cart();
        function AddToCart(btn) {
            var h;
            var randomParam = new Date().toString();
            $.get("/Scenic/TimeHandler.ashx?type=" + randomParam, function (timeHour, status) {
                h = timeHour;
                if (parseInt(h) < 10) {
                    alert("今日抢票未开始,请在10点之后进行抢票!");
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
    showMap();
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
    if (document.body.scrollHeight - document.documentElement.scrollTop - document.body.scrollTop - winHeight < 135) {
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
    showMap();
    getTicketCount();
});

var map;
var position;
var flag = 1;
function showMap() {
    position = $("[id$='hfposition']").val();
    if (position == null || position == undefined || position == "")
        position = "120.141175,30.303563";
    var latlng = new google.maps.LatLng(position.split(",")[1], position.split(",")[0]);
    var myOptions = {
        zoom: 8,
        center: latlng,
        scrollwheel:false,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById("containtermap"), myOptions);
    if (flag == 1) {
        map.setCenter(latlng);
        map.setZoom(8);
        flag++;
    }
    else {
        map.setCenter(latlng);
        map.setZoom(map.getZoom());
    }
    var txt = $("[id$='hfscname']").val();
    var overlay = new customOverlay_Large(map, { latlng: latlng, text: txt, id: 0 });
}

function gotocenter() {
    var latlng = new google.maps.LatLng(position.split(",")[1], position.split(",")[0]);
    if (flag == 1) {
        map.setCenter(latlng);
        map.setZoom(8);
        flag++;
    }
    else {
        map.setCenter(latlng);
        map.setZoom(map.getZoom());
    }                   
}

/*创建google自定义覆盖物*/
function customOverlay_Large(map, options) {
    //初始化参数
    this._latlng = options.latlng; //设置图标位置
    this._text = options.text;
    this._id = options.id;
    this._map = map;
    this._div = null;
    this.setMap(map);
}
customOverlay_Large.prototype = new google.maps.OverlayView();
//初始化图标
customOverlay_Large.prototype.onAdd = function () {
    var that = this;
    var div = document.createElement("div"); //创建存放文字的div
    div.style.position = "absolute";
    div.style.zIndex = '1';
    div.className = "divicon";
    div.style.MozUserSelect = "none";
    div.style.fontSize = "12px";
    var span = document.createElement("span"); //创建序号span
    //div.appendChild(span);
    span.style.height = "15px";
    div.style.cursor = "pointer";
    span.style.display = "inline-block";
    span.style.color = "Black";
    span.style.margin = "0px 5px 2px 3px";
    span.appendChild(document.createTextNode(this._id));
    var spanscenic = document.createElement("span"); //创建文字标题
    div.appendChild(spanscenic);
    spanscenic.height = "15px";
    spanscenic.style.position = "relative";
    spanscenic.style.top = "-2px \0";
    spanscenic.style.display = "inline-block";
    spanscenic.style.lineHeight = "15px";
    spanscenic.style.color = "White";
    spanscenic.appendChild(document.createTextNode(this._text));
    var arrow = document.createElement("div"); //三角形图标
    arrow.style.background = "url('/Img/yuansu/largeicon2.gif') no-repeat";
    arrow.style.position = "absolute";
    arrow.style.width = "15px";
    arrow.style.height = "14px";
    arrow.style.top = "19px";
    arrow.style.left = "10px";
    arrow.style.overflow = "hidden";
    div.appendChild(arrow);
    this._div = div;
    var panes = this.getPanes();
    panes.overlayLayer.appendChild(div);
}
//绘制图标，主要用于控制图标的位置
customOverlay_Large.prototype.draw = function () {
    var overlayProjection = this.getProjection();
    var position = overlayProjection.fromLatLngToDivPixel(this._latlng); //将地图坐标转换成屏幕坐标
    var div = this._div;
    div.style.left = position.x - 5 + 'px';
    div.style.top = position.y - 5 + 'px';
}
//增加一个删除图标属性
customOverlay_Large.prototype.onRemove = function () {
    this._div.parentNode.removeChild(this._div);
    this._div = null;
}

function getTicketCount() {


    $.get("/Scenic/TimeHandler.ashx?now=1", function (time, status) {
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "/TourolService/quzhouspring/TicketService.asmx/ProductInfo",
            data: "{PartnerCode:'tourol.cn',productCode:'" + $("[id$='hfProductCode']").val() + "',dt:'" + time + "'}",
            dataType: "json",
            success: function (msg) {
                if (msg.d != "-1") {
                    $("#qzTicketCount").html("<span class='tc'>余<span class='countSum' style=' font-size:24px; font-weight:bold;'>" + msg.d + "</span>张</span>");
                }
                else {
                    $("#qzTicketCount").html("<span class='noTc' style=' font-size:14px;'>已抢完</span>");
                }
            }
        });
    });
}