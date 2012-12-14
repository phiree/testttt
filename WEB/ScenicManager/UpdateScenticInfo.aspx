<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true"
    CodeFile="UpdateScenticInfo.aspx.cs" Inherits="ScenticManager_UpdateScenticInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" runat="Server">
    <title>景区管理员</title>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.2&amp;services=true"> </script>
    <script type="text/javascript"
    src="https://maps.google.com/maps/api/js?sensor=true">
</script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/Verification.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.uploadify.min.js" type="text/javascript"></script>
    <link href="/Styles/uploadify.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/swfobject.js" type="text/javascript"></script>
    <script src="/Scripts/pages/Brower.js" type="text/javascript"></script>
    <link href="/theme/default/css/smdefault.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/UpdateScInfo.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <p class="fuctitle">
        景区资料管理</p>
    <hr />
    <div id="scinfo">
        <table class="scinfolist" cellspacing="5" cellpadding="10">
            <tr>
                <td>
                    景区名称
                </td>
                <td>
                    <asp:TextBox ID="ScenicName" runat="server"></asp:TextBox><font style="color: Red">*</font>
                </td>
            </tr>
            <tr>
                <td>
                    等级
                </td>
                <td>
                    <asp:TextBox ID="ScenicLevel" runat="server"></asp:TextBox><font style="color: Red">*</font>
                </td>
            </tr>
            <tr>
                <td>
                    所在区域
                </td>
                <td>
                    <asp:Label ID="ScenicArea" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    地址
                </td>
                <td>
                    <asp:TextBox ID="Address" runat="server" Width="245px"></asp:TextBox><font style="color: Red">*</font>
                </td>
            </tr>
            <tr>
                <td>
                    E-mail
                </td>
                <td>
                    <asp:TextBox ID="Email" runat="server" Width="245px"></asp:TextBox><font style="color: Red">*</font>
                </td>
            </tr>
        </table>
        <p class="scintrotitle">
            交通指南</p>
        <asp:TextBox ID="Desc" TextMode="MultiLine" runat="server" Height="100px" CssClass="jjtext"
            Width="400px"></asp:TextBox>
        <p class="scintrotitle">
            景区图片</p>
        <asp:Image ID="ScenicImg" runat="server" Width="400px" Height="250px" CssClass="jjtext" />
        <p class="scintrotitle">
            景区图片修改</p>
        <div style="margin-left: 60px;">
            <asp:Button ID="btnupdatescpic" runat="server" CssClass="btnupdatescpicto" OnClick="btnupdatescpic_Click" />
        </div>
        <asp:HiddenField ID="hfimgurl" runat="server" />
        <p class="scintrotitle">
            景区位置</p>
        <asp:HiddenField ID="hfposition" runat="server" />
        <p style="margin-left: 60px;">
            点击右键选择景区地址（必选）<a onclick="showbigmap()" style="text-decoration: none; cursor: pointer;">放大查看</a></p>
        <div style="width: 400px; height: 250px; margin-left: 60px;" id="container">
        </div>
        
        <div style="margin-left: 60px; margin-top: 20px; margin-bottom: 20px;">
            <asp:Button ID="BtnUpdateScenicInfo" CssClass="btnsaveimg" runat="server" OnClientClick="return BtnUpdateScenicInfo();"
                OnClick="btnOK_Click" /></div>
    </div>
    <div id="divbigmap" style="display: none; position:fixed !important">
        <p style="width: 100%; height: 15px; color: Red; text-align: right; margin: 0px;
            padding: 0px; background-color: #E5E5E5; line-height: 15px; z-index:9999">
            <a style="text-decoration: none; cursor: pointer; color: Red" onclick="closebigmap()">
                关闭</a></p>
        <div id="bigmap" style="width: 100%; height: 435px; display: block;">
        </div>
    </div>
</asp:Content>
