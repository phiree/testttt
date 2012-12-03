$(function () {
    var postion = null;
    var hfposi = $("[id$='hfposition']").val();
    if (hfposi != "" && hfposi != null && hfposi != undefined) {
        postion = hfposi;
    }
    showSmallMap(postion);
});

function showSmallMap(position) {
    var latlng;
    var Zoom;
    var marker;
    if (position == null) {
        latlng = new google.maps.LatLng(30.303563, 120.141175);
        Zoom = 8;
    }
    else {
        latlng = new google.maps.LatLng(position.split(',')[1], position.split(',')[0]);
        Zoom = 15;
        $("[id$='hfposition']").val(position);
    }
    var myOptions = {
        zoom: Zoom,
        center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("container"), myOptions);
    if(position!=null){
            marker = new google.maps.Marker({
            position:latlng,
            map:map
        });
    }
    var contextMenuOptions = {};
    contextMenuOptions.classNames = { menu: 'context_menu', menuSeparator: 'context_menu_separator' };
    var menuItems = [];
    menuItems.push({ className: 'context_menu_item', eventName: 'click_showInfo', label: '在此添加景区位置' });
    contextMenuOptions.menuItems = menuItems;
    var contextMenu = new ContextMenu(map, contextMenuOptions);
    google.maps.event.addListener(map, 'rightclick', function (mouseEvent) {
        contextMenu.show(mouseEvent.latLng);
    });
    google.maps.event.addListener(contextMenu, 'menu_item_selected', function (latLng, eventName) {
        $("[id$='hfposition']").val(latLng.lng() + "," + latLng.lat());
        switch (eventName) {
            case 'click_showInfo':
                {
                    if (marker != undefined) {
                        marker.setPosition(latLng);
                    }
                    else {
                        marker = new google.maps.Marker({
                            position: latLng,
                            map: map
                        });
                    }
                }
        }
    });
}
function showbigmap() {
    var postion = null;
    var hfposi = $("[id$='hfposition']").val();
    if (hfposi != "" && hfposi != null && hfposi != undefined) {
        postion = hfposi;
    }
    showLargeMap(postion);
}
function showLargeMap(position) {
    $("#divbigmap").css("display", "block");
    findDimensions();
    var t = (winHeight - 450) / 2;
    var w = (winWidth - 750) / 2;
    $("#divbigmap").css({ left: w + "px", top: t + "px" });
    var latlng;
    var Zoom;
    var marker;
    if (position == null) {
        latlng = new google.maps.LatLng(30.303563, 120.141175);
        Zoom = 8;
    }
    else {
        latlng = new google.maps.LatLng(position.split(',')[1], position.split(',')[0]);
        Zoom = 15;
        $("[id$='hfposition']").val(position);
    }
    var myOptions = {
        zoom: Zoom,
        center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("bigmap"), myOptions);
    if (position != null) {
        marker = new google.maps.Marker({
            position: latlng,
            map: map
        });
    }
    var contextMenuOptions = {};
    contextMenuOptions.classNames = { menu: 'context_menu', menuSeparator: 'context_menu_separator' };
    var menuItems = [];
    menuItems.push({ className: 'context_menu_item', eventName: 'click_showInfo', label: '在此添加景区位置' });
    contextMenuOptions.menuItems = menuItems;
    var contextMenu = new ContextMenu(map, contextMenuOptions);
    google.maps.event.addListener(map, 'rightclick', function (mouseEvent) {
        contextMenu.show(mouseEvent.latLng);
    });
    google.maps.event.addListener(contextMenu, 'menu_item_selected', function (latLng, eventName) {
        $("[id$='hfposition']").val(latLng.lng() + "," + latLng.lat());
        switch (eventName) {
            case 'click_showInfo':
                {
                    if (marker != undefined) {
                        marker.setPosition(latLng);
                    }
                    else {
                        marker = new google.maps.Marker({
                            position: latLng,
                            map: map
                        });
                    }
                }
        }
    });
}
function closebigmap() {
    $("#divbigmap").css("display", "none");
    var postion = null;
    var hfposi = $("[id$='hfposition']").val();
    if (hfposi != "" && hfposi != null && hfposi != undefined) {
        postion = hfposi;
    }
    showSmallMap(postion);
}
window.onresize = function () {
    var postion = null;
    var hfposi = $("[id$='hfposition']").val();
    if (hfposi != "" && hfposi != null && hfposi != undefined) {
        postion = hfposi;
    }
    showSmallMap(postion);
}
/*
谷歌地图右键菜单
*/

function ContextMenu(map, options) {
    options = options || {};

    this.setMap(map);

    this.classNames_ = options.classNames || {};
    this.map_ = map;
    this.mapDiv_ = map.getDiv();
    this.menuItems_ = options.menuItems || [];
    this.pixelOffset = options.pixelOffset || new google.maps.Point(10, -5);
}

ContextMenu.prototype = new google.maps.OverlayView();

ContextMenu.prototype.draw = function () {
    if (this.isVisible_) {
        var mapSize = new google.maps.Size(this.mapDiv_.offsetWidth, this.mapDiv_.offsetHeight);
        var menuSize = new google.maps.Size(this.menu_.offsetWidth, this.menu_.offsetHeight);
        var mousePosition = this.getProjection().fromLatLngToDivPixel(this.position_);

        var left = mousePosition.x;
        var top = mousePosition.y;

        if (mousePosition.x > mapSize.width - menuSize.width - this.pixelOffset.x) {
            left = left - menuSize.width - this.pixelOffset.x;
        } else {
            left += this.pixelOffset.x;
        }

        if (mousePosition.y > mapSize.height - menuSize.height - this.pixelOffset.y) {
            top = top - menuSize.height - this.pixelOffset.y;
        } else {
            top += this.pixelOffset.y;
        }

        this.menu_.style.left = left + 'px';
        this.menu_.style.top = top + 'px';
    }
};

ContextMenu.prototype.getVisible = function () {
    return this.isVisible_;
};

ContextMenu.prototype.hide = function () {
    if (this.isVisible_) {
        this.menu_.style.display = 'none';
        this.isVisible_ = false;
    }
};

ContextMenu.prototype.onAdd = function () {
    function createMenuItem(values) {
        var menuItem = document.createElement('div');
        menuItem.innerHTML = values.label;
        if (values.className) {
            menuItem.className = values.className;
        }
        if (values.id) {
            menuItem.id = values.id;
        }
        menuItem.style.cssText = 'cursor:pointer; white-space:nowrap;background-color:White;padding:3px';
        menuItem.onclick = function () {
            google.maps.event.trigger($this, 'menu_item_selected', $this.position_, values.eventName);
        };
        return menuItem;
    }
    function createMenuSeparator() {
        var menuSeparator = document.createElement('div');
        if ($this.classNames_.menuSeparator) {
            menuSeparator.className = $this.classNames_.menuSeparator;
        }
        return menuSeparator;
    }
    var $this = this; //    used for closures

    var menu = document.createElement('div');
    if (this.classNames_.menu) {
        menu.className = this.classNames_.menu;
    }
    menu.style.cssText = 'display:none; position:absolute';

    for (var i = 0, j = this.menuItems_.length; i < j; i++) {
        if (this.menuItems_[i].label && this.menuItems_[i].eventName) {
            menu.appendChild(createMenuItem(this.menuItems_[i]));
        } else {
            menu.appendChild(createMenuSeparator());
        }
    }

    delete this.classNames_;
    delete this.menuItems_;

    this.isVisible_ = false;
    this.menu_ = menu;
    this.position_ = new google.maps.LatLng(0, 0);

    google.maps.event.addListener(this.map_, 'click', function (mouseEvent) {
        $this.hide();
    });

    this.getPanes().floatPane.appendChild(menu);
};

ContextMenu.prototype.onRemove = function () {
    this.menu_.parentNode.removeChild(this.menu_);
    delete this.mapDiv_;
    delete this.menu_;
    delete this.position_;
};

ContextMenu.prototype.show = function (latLng) {
    if (!this.isVisible_) {
        this.menu_.style.display = 'block';
        this.isVisible_ = true;
    }
    this.position_ = latLng;
    this.draw();
};