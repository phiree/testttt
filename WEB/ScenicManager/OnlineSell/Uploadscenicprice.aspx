<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true" CodeFile="Uploadscenicprice.aspx.cs" Inherits="ScenicManager_OnlineSell_Uploadscenicprice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" Runat="Server">
    <link href="/theme/default/css/smdefault.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <p class="fuctitle">
        <a style="cursor: pointer; text-decoration: none; color: #2E6391;" onclick="javascript:history.go(-1);">
            景区门票信息</a>&nbsp;>&nbsp;上传景区资料</p>
    <hr />
    <div id="uploadscinfo">
        <p class="udtitle">请把盖好公章的更改价格文件上传至网站，如果已经发传真给我们则可以跳过此步骤</p>
        <div class="udinfo">
            请选择上传的文件：<asp:FileUpload ID="fuwj" runat="server" />
        </div>
        <div class="udinfo" style="margin-bottom:20px">
            <asp:Button ID="btnok" runat="server" onclick="btnok_Click" CssClass="btnudok" />
        </div>
    </div>
    

    
</asp:Content>

