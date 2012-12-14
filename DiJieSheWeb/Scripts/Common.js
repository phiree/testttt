function getParameterByName(name, query) {
    query = query.replace("#m", "");
    var match = RegExp('[?&]' + name + '=([^&]*)')
                    .exec(query);
    return match && decodeURIComponent(match[1].replace(/\+/g, ' '));
}
function removeURLParam(url, param) {
    var urlparts = url.split('?');
    if (urlparts.length >= 2) {
        var prefix = encodeURIComponent(param) + '=';
        var pars = urlparts[1].split(/[&;]/g);
        for (var i = pars.length; i-- > 0; )
            if (pars[i].indexOf(prefix, 0) == 0)
                pars.splice(i, 1);
        if (pars.length > 0)
            return urlparts[0] + '?' + pars.join('&');
        else
            return urlparts[0];
    }
    else
        return url;
}     
function trim(input) {
    return input.replace(/(^\s*)|(\s*$)/g, "");
}
String.prototype.trim = function () {
    return this.replace(/(^\s*)|(\s*$)/g, "");
}
Array.prototype.Remove = function (b) {
    var a = this.indexOf(b);
    if (a >= 0) {
        this.splice(a, 1);
        return true;
    }
    return false;
}; 