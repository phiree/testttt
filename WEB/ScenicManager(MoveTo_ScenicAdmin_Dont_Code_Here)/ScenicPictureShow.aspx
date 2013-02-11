<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true" CodeFile="ScenicPictureShow.aspx.cs" Inherits="ScenicManager_ScenicPictureShow" %>
<%@ MasterType VirtualPath="~/ScenicManager/sm.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" Runat="Server">
    <link href="/theme/default/css/smdefault.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <p class="fuctitle">
        景区图片管理</p>
    <hr />
    <p class="wkintr">
        景区主图:显示在网站首页及与景区相关区域，一般只显示主图中的第一张
    </p>
    <p class="wkintr">
        景区辅图:显示在景区详情页面的景区相关景点介绍区域，为了丰富景区相关景点，一般只显示辅图中的前六张
    </p>
    <p class="wkintr">
        景区备图:用于景区储备图片，不做显示
    </p>
    <div id="picshow">
        <div class="picshowmain">
        <p class="picshowtitle">主图</p>
        <asp:Repeater ID="rptPicShow1" runat="server">
            <ItemTemplate>
                <div class="picshowinfo">
                    <a href='<%# Eval("Id","/ScenicManager/UpdateScenicImg.aspx?siid={0}") %>'><img src='<%# Eval("Name","/ScenicImg/mainimg/{0}") %>' /></a>
                    <a class="aa" href='<%# Eval("Id","/ScenicManager/UpdateScenicImg.aspx?siid={0}") %>'><%# Eval("Title") %></a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <p class="picshowtitle">辅图</p>
          <asp:Repeater ID="rptPicShow2" runat="server" 
                onitemdatabound="rptPicShow2_ItemDataBound">
            <ItemTemplate>
                <div class="picshowinfo">
                    <a href='<%# Eval("Id","/ScenicManager/UpdateScenicImg.aspx?siid={0}") %>'><img runat="server" id="smallimg" src='' /></a>
                    <a class="aa" href='<%# Eval("Id","/ScenicManager/UpdateScenicImg.aspx?siid={0}") %>'><%# Eval("Title") %></a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <p class="picshowtitle">备图</p>
          <asp:Repeater ID="rptPicShow3" runat="server">
            <ItemTemplate>
                <div class="picshowinfo">
                    <a href='<%# Eval("Id","/ScenicManager/UpdateScenicImg.aspx?siid={0}") %>'><img src='<%# Eval("Name","/ScenicImg/detailimg/{0}") %>' /></a>
                    <a class="aa" href='<%# Eval("Id","/ScenicManager/UpdateScenicImg.aspx?siid={0}") %>'><%# Eval("Title") %></a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="addscenicimg">
            <input id="Button1" type="button" class="btnaddscenicimg enable" />
            <%--<input id="Button1" type="button" class="btnaddscenicimg enable" onclick="javascript:window.location='/ScenicManager/UpdateScenicImg.aspx'"/>--%>
        </div>
        </div>
    </div>
    
</asp:Content>


