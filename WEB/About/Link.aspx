<%@ Page Title="" Language="C#" MasterPageFile="~/About/MasterPage.master" AutoEventWireup="true"
    CodeFile="Link.aspx.cs" Inherits="About_Link" %>
<%@ Register TagPrefix="self" Namespace="TourControls" Assembly="TourControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <script type="text/javascript">

        var boderwidth;
        function EditHTMLInfo(obj) {
            boderwidth = $(obj).css("boder-width");
            $(obj).css("border", "1px solid #FAF707");
        }
        function CancelHTMLInfo(obj) {
            if (boderwidth == undefined) {
                $(obj).css("border-color", "");
                if ($(obj).attr("id") == "aboutus") {
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
            window.open(encodeURI('/Scenic/EditHTMLInfo.aspx?scname=' + scname + '&scfunctype=' + scfunctype + '&type=联系我们&flag=' + flag + ''), 'newwindow', 'height=600,width=740,top=' + h + ',left=' + w + ',toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cc" runat="Server">
    <div id="wenzi">
        <self:ContentReader runat="server" ID="aboutus" type="联系我们" CssClass="textareadiv"/>
    </div>
</asp:Content>
