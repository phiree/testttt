<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="ImportMipangTicket.aspx.cs" Inherits="Manager_ImportMipangTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
<asp:TextBox runat="server" ID="tbxAddress"  Text="http://www.mipang.com/var/res/benniu/routes-1.xml"></asp:TextBox>
<asp:Button runat="server" ID="btnImport" Text="导入"  OnClick="btnImport_Click"/>
<asp:Label runat="server" ID="lblDesc"></asp:Label>

<fieldset>
<legend>获得景区信息</legend>
<asp:Button runat="server" ID="btnGetMipangList" Text="查看米胖景区列表" OnClick="btnGetMipangList_Click" />
<table><asp:Repeater runat="server" ID="rptMipangList">
<ItemTemplate>

<tr><td><%#Eval("Name") %></td><td><%#Eval("MipangId")%></td><td><%#Eval("desec") %></td></tr></li>
</ItemTemplate>
</asp:Repeater>
</table>
</fieldset>


<div style="border:solid 1px black">
 <div>将mipangticket 批量移到tourol对应的景区.</div>
 <div>格式:mipangid,seoname   表示 将 mipangid 下的门票 移到 对应seoname的景区下.</div>
 <asp:TextBox runat="server" ID="tbxMoves" TextMode="MultiLine" Width="300" Height="600">
    
 </asp:TextBox>
 <asp:Button runat="server" Text="开始对应"  ID="btnMove" OnClick="btnMove_Click" />
 <asp:Label runat="server" ID="lblMoveError"></asp:Label>
</div>
</asp:Content>

