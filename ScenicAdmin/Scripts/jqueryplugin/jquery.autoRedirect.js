$.fn.AutoRedirect = function (param) {
    var option = $.extend(
     {
         TargetUrl: "/"
     , Delay: 5
     },
     param
    );
    var that = this;
    var timeLeft = option.Delay;
    that.text(timeLeft);
    var timer = setInterval(Redirect, 1000);
    function Redirect() {
        if (timeLeft == 0) {
            timer = null;
            window.location.href = option.TargetUrl;
        }
        else {
            timeLeft--;
            that.text(timeLeft);
        }
    }

}