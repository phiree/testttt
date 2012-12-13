/// <reference path="/Scripts/jquery-1.6.4-vsdoc.js" />

$.fn.ContainerToJson = function (option) {
    var that = this;
    var jsonResult = {};
    var formTags = $(that).find("input:text,input:hidden");
    for (var i = 0; i < formTags.length;i++ ) {
        var tag = formTags[i];
        var name = tag.name;
        var val = tag.value;
        jsonResult[name] = val;
    }
    return jsonResult;

};