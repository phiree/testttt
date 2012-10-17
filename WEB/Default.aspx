<%@ Page Title="" Language="C#" MasterPageFile="~/detail.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="self" Namespace="TourControls" Assembly="TourControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>中国旅游在线_浙江旅游景点门票预订官网</title>
    <script src="/Scripts/slide.js" type="text/javascript"></script>
    <script src="/Scripts/pages/default.js" type="text/javascript"></script>
    <link href="/theme/default/css/default.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/pager.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/Show.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            startscrolltime();
            $(".navlistnb a").attr("class", "");
            $(".navlistnb a:eq(0)").attr("class", "navhight");
            $(".navhight").next().attr("class", "");
            $(".navlistnb a").each(function () {
                if ($(this).attr("class") == "navhight") {
                    $(this).next().css("display", "none");
                    $(".chartdiv").css("display", "block");
                }
                else {
                    $(this).next().css("display", "");
                    $(".chartdiv").css("display", "block");
                    $(this).click(function () {
                        $(this).next().css("display", "none");
                        $(".chartdiv").css("display", "block");
                    });
                    $(this).mouseover(function () {
                        $(this).next().css("display", "none");
                        $(".chartdiv").css("display", "block");
                    });
                    $(this).mouseout(function () {
                        $(this).next().css("display", "");
                        $(".chartdiv").css("display", "block");
                    });
                }
            });
        });
        function startscrolltime() {
            scrollimg();
            t = setTimeout("startscrolltime()", 50);
        }

        function scrollimg() {
            var imgtop = $(".adcolum img").css("top");
            imgtop=imgtop.replace("px", "");
            if (imgtop >= 0) {
                $(".adcolum img").css("top", "-160px");
            }
            else {
                imgtop = parseInt(imgtop) + parseInt(1);
                $(".adcolum img").css("top", imgtop+"px");
            }
        }
        var boderwidth;
        function EditHTMLInfo(obj) {
            boderwidth = $(obj).css("boder-width");
            $(obj).css("border", "1px solid #FAF707");
        }
        function CancelHTMLInfo(obj) {
            if (boderwidth == undefined) {
                $(obj).css("border-color", "");
                if ($(obj).attr("id") == "default") {
                    $(obj).css("border-width", "0px");
                }
            }
        }
        function EditHTMLInfoBtn(obj, scname, scfunctype) {
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
            window.open(encodeURI('/Scenic/EditHTMLInfo.aspx?scname=' + scname + '&scfunctype=' + scfunctype + '&type=首页&flag=' + flag + ''), 'newwindow', 'height=600,width=740,top=' + h + ',left=' + w + ',toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <self:ContentReader runat="server" ID="default" CanEdit="true" type="首页" CssClass="editdiv"/>

</asp:Content>
