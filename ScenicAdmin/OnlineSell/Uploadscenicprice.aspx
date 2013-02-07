<%@ Page Title="" Language="C#" MasterPageFile="~/sm.master" AutoEventWireup="true"
    CodeFile="Uploadscenicprice.aspx.cs" Inherits="ScenicManager_OnlineSell_Uploadscenicprice" %>
<%@ MasterType VirtualPath="~/sm.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" runat="Server">
    <link href="/theme/default/css/smdefault.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function btnchange() {
            $("[id$='btnchange22']").click();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <p class="fuctitle">
        <a style="cursor: pointer; text-decoration: none; color: #2E6391;" onclick="javascript:history.go(-1);">
            景区门票信息</a>&nbsp;>&nbsp;上传景区资料</p>
    <hr />
    <div id="uploadscinfo">
        <div class="paystate">
        <a href="/scenicmanager/onlinesell/OnlinePrice.aspx">填写景区价格</a>><a href="/scenicmanager/onlinesell/PrintScenicPrice.aspx">打印价格表</a>><a href="/scenicmanager/onlinesell/Uploadscenicprice.aspx" class="nowstate">上传盖章后价格表</a>><a onclick="btnchange()" style="cursor:pointer;"" >申请</a>
        </div>
        <p class="udtitle">
            请把盖好公章的更改价格文件上传至网站，如果已经发传真给我们则可以跳过此步骤</p>
        <div class="udinfo">
            请选择上传的文件：<asp:FileUpload ID="fuwj" runat="server" />
        </div>
        <div class="udinfo" style="margin-bottom: 20px">
            <asp:Button ID="btnok" runat="server" OnClick="btnok_Click" CssClass="btnudok" style="vertical-align:middle" /><a runat="server" id="gopay" style="margin-left:400px; vertical-align:middle; cursor:pointer;" onclick="btnchange()">去申请</a>
        </div>
    </div>
    <div style="display:none">
        <asp:Button ID="btnchange22" runat="server" Text="Button" 
            onclick="btnchange_Click" />
    </div>
</asp:Content>
