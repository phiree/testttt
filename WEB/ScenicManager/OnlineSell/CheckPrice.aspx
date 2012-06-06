<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true" CodeFile="CheckPrice.aspx.cs" Inherits="ScenicManager_OnlineSell_CheckPrice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
<p style="color:Red">景区价格审核：请按以下步骤操作，最后把景区资料以文件的形式上传或发传真给我们审核，我们网站后台管理员审核通过后会第一时间通知你们，并更改景区价格
</p>
<a href="OnlinePrice.aspx">1.填写售票价格:</a><br />
<a href="PrintScenicPrice.aspx">2.打印,盖公章,拍照</a><br />
<a href="Uploadscenicprice.aspx">3.上传更改景区价格文件</a><br />
</asp:Content>

