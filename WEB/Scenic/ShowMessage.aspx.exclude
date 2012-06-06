<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowMessage.aspx.cs" Inherits="ShowMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
    #message
    {
        margin:50px auto;
        width:750px;
        height:600px;
        font-size:17px;
        font-style:normal;
        font-weight:500;
    }
</style>
<script type="text/javascript">
    var x = 5; 
    function timedCount() {
        // alert(document.getElementById("count"));
        $("[id$='count']").html(x);
        x = x - 1;
        if(x>=0)
            t = setTimeout("timedCount()", 1000);
        else
            window.location="Account/Login.aspx"
    }
    window.onload = timedCount();
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <div id="message">
        <asp:Label ID="messtitle" runat="server" Text="Label"></asp:Label>
        <h2 id="count" style="text-align:center">5</h2>
    </div>
    
</asp:Content>

