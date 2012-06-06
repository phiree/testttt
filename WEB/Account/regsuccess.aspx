<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="regsuccess.aspx.cs" Inherits="Account_regsuccess" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <script src="/Scripts/jqueryplugin/jquery.autoRedirect.js" type="text/javascript"></script>
    <script language="javascript" type="text/jscript">
        $(function () {
            $("#spTimer").AutoRedirect();
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphmain" Runat="Server">
<div class="logout" style=" height:200px; padding-top:80px; text-align:center">
您已<span style="font-size:large; color:Green;">成功注册</span>,系统将在<span style=" font-size:large;font-weight:700;" id="spTimer"></span>秒之后返回首页,您也可以<a href="/">立即跳转</a>.
</div>
</asp:Content>

