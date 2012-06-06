<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Map.aspx.cs" Inherits="BaiduMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript" src="http://api.map.baidu.com/api?v=1.3"></script>
<script  type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=true"></script>
    <script src="/Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="../Scripts/baidumap.js" type="text/javascript"></script>
    <script type="text/javascript">
        var count = 0;
        function qiehuan() {
            if (count % 2 == 0) {
                $.cookie("maptype", "1");
                $("#change").html("切换至google版地图");
            }
            else {
                $.cookie("maptype", "2");
                $("#change").html("切换至百度版地图");
            }
            count++;
           check();
        }
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
<div>
   <div style=" margin:0px; padding:0px; float:left;width: 79%; height: 550px; border: 1px solid gray" id="container">
    </div>
    <div style=" margin:0px; padding:0px; float:left;width:20%">
        景区名:<asp:TextBox ID="txtPosition" style=" margin:0px; padding:0px;" runat="server"></asp:TextBox><br />
        景区级别
        <asp:DropDownList ID="Level" runat="server">
            <asp:ListItem>全部</asp:ListItem>
            <asp:ListItem>1A</asp:ListItem>
            <asp:ListItem>2A</asp:ListItem>
            <asp:ListItem>3A</asp:ListItem>
            <asp:ListItem>4A</asp:ListItem>
            <asp:ListItem>5A</asp:ListItem>
        </asp:DropDownList>
        <input id="Button2" type="button" value="搜索" onclick="check2();" />
        <br />
        <div id="showscenic">
            
        </div>
    <a id="change"  onclick="qiehuan()" style=" cursor:pointer;">切换至google版地图</a>
    </div>
    </div>
</asp:Content>

