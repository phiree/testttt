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
            //startscrolltime();
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
            $("#quzhouticket").animate({ bottom: "0px" }, 1500);
            $("#closeWin").click(function () {
                $("#quzhouticket").animate({ bottom: "-201px" }, 1500);
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
        


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <self:ContentReader runat="server" ID="default" CanEdit="true" type="首页" CssClass="editdiv"/>
    <div id="quzhouticket">
        <a href="/Tickets/quzhou" style=" display:block; width:100%;height:100%; position:absolute; z-index:9990">
        </a>
        <a id="closeWin" style="width:20px; height:20px; display:block; position:absolute;top:0px; right:0px; z-index:9991;cursor:pointer">
        </a>
    </div>
</asp:Content>
