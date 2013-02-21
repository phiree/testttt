var boderwidth;
function EditHTMLInfo(obj) {
    boderwidth = $(obj).css("boder-width");
    $(obj).css("border", "1px solid #FAF707");
}
function CancelHTMLInfo(obj,hasborder) {
    if (boderwidth == undefined) {
        $(obj).css("border-color", "");
        if (hasborder.toLowerCase() == "false") {
            $(obj).css("border-width", "0px");
        }
    }
}

function EditHTMLInfoBtn(obj,type, scname, scfunctype) {
    var flag = $(obj).attr("class");
    if (flag == "" || flag == undefined || flag == null) {
        flag = $(obj).attr("id");
        flag = "#" + flag;
    }
    else {
        flag = "." + flag;
    }
    findDimensions();
    var w = (winWidth - 740) / 2;
    var h = (winHeight - 600) / 2;
    window.open(encodeURI('/Scenic/EditHTMLInfo.aspx?scname=' + scname + '&scfunctype=' + scfunctype + '&type='+type+'&flag=' + flag + ''), 'newwindow', 'height=600,width=740,top=' + h + ',left=' + w + ',toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no');
}