<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true"
    CodeFile="Pricesetting.aspx.cs" Inherits="ScenicManager_OnlineSell_Pricesetting" %>

<%@ MasterType VirtualPath="~/ScenicManager/sm.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" runat="Server">
    <link href="/theme/default/css/smdefault.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <p class="fuctitle">
        景区门票信息</p>
    <hr />
    <div id="shprice">
        <asp:Panel ID="panelpassstate" runat="server">
            <div class="passsh">
                您的上次价格更改，已经通过审核,修改后的价格如下所示，还想修改,请选择<a href="Pricesetting.aspx?update=1">修改</a>
            </div>
            <p class="priceinfo">
                门市价:<asp:Label ID="lblyj" CssClass="jtpriceinfo" runat="server"></asp:Label></p>
            <p class="priceinfo">
                预订价:<asp:Label ID="lblydj" CssClass="jtpriceinfo" runat="server"></asp:Label></p>
            <p class="priceinfo">
                优惠价:<asp:Label ID="lblyhj" CssClass="jtpriceinfo" runat="server"></asp:Label></p>
        </asp:Panel>
        <asp:Panel ID="panelshing" runat="server">
            <div class="passsh">
                正在审核中...</div>
        </asp:Panel>
        <asp:Panel ID="panelnotpass" runat="server">
            <div class="passsh">
                审核失败,请重新修改价格,请选择<a class="update" href="Pricesetting.aspx?update=1">修改</a></div>
        </asp:Panel>
        <asp:Panel ID="panelchangeprice" runat="server" CssClass="daohang">
            <p class="priceintro">
                景区价格审核：请按以下步骤操作，最后把景区资料以文件的形式上传或发传真给我们审核，审核期间景区暂时无法上架<br />
                审核后，我们网站后台管理员会第一时间通知你们审核结果，如果审核通过会立即更改景区价格
            </p>
            <a class="step" href="OnlinePrice.aspx">1.&nbsp;填写售票价格:</a> <a class="step" href="PrintScenicPrice.aspx">
                2.&nbsp;打印,盖公章,拍照</a> <a class="step" href="Uploadscenicprice.aspx">3.&nbsp;上传更改景区价格文件</a>
            <div style="margin: 20px 0px 20px 23px">
                <asp:Button ID="btnApply" runat="server" CssClass="btnapply" OnClick="btnApply_Click" /></div>
        </asp:Panel>
    </div>
</asp:Content>
