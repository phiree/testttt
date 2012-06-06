<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="EarnVoteWay.aspx.cs" Inherits="Manager_EarnVoteWay" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
<asp:Repeater runat="server" ID="rpt">
<ItemTemplate>
<div>类型:<%#Eval("EarnWay")%>  获得数量<asp:TextBox runat="server" ID="tbxAmount"></asp:TextBox><asp:Button runat="server" ID="btnSave"  Text="保存"/> </div>
</ItemTemplate>
</asp:Repeater>

<div>类型:<asp:DropDownList  runat="server" ID="ddlWays"></asp:DropDownList>
  获得数量<asp:TextBox runat="server" ID="tbxAmount"></asp:TextBox><asp:Button runat="server" ID="btnSave"  Text="增加"/> </div>

</asp:Content>


