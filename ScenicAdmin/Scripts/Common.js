function getParameterByName(name, query) {
    query = query.replace("#m", "");
    var match = RegExp('[?&]' + name + '=([^&]*)')
                    .exec(query);
    return match && decodeURIComponent(match[1].replace(/\+/g, ' '));
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