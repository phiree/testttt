/*比较当前url和本链接的href  高亮当前页面,并取消其他链接的高亮
目标对象: 链接列表
UI结构要求:<a href="/pagename.aspx"> 
  
*/


$.fn.HighLightLink = function (param) {
    var options = $.extend(
        {
            highLightClass: "highLightLink"

        },
         param
    );
    $(this).parent("li").removeClass(options.highLightClass);
    var href = EnsureUrl(window.location.href);


    for (var i = 0; i < this.length; i++) {
        var thishref = EnsureUrl($(this[i]).attr("href"));
        if (href.indexOf(thishref) >= 0) {
            $(this[i]).parent("li").attr("class", options.highLightClass);
            break;
        }
    }

}

    function EnsureUrl(href) {

        if (href.indexOf(".aspx") < 0) {
            if (href.lastIndexOf("/") >= 0) {
                href = href.substr(0, href.length - 1);
            }
            href += "/default.aspx";
        }
        return href;

    }