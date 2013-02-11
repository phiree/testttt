<%@ Page Title="" Language="C#" MasterPageFile="~/detail.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/theme/default/css/20130203/Index.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
  <!--  <div class="show_1">
        <asp:Button ID="btnQuZhou" runat="server" Text="" CssClass="btnShow_1 btnIndex" 
            onclick="btnQuZhou_Click" />
        <asp:Button ID="btnSuiChange" runat="server" Text="" 
            CssClass="btnShow_2 btnIndex" onclick="btnSuiChange_Click" />
    </div>
-->
    <a href="/SuiChangSpring/SuiChangSpring.aspx">
        <span class="show_2">
        
        </span>
    </a>
   <!-- <a href="/qzspring">
        <span class="show_3">
            
        </span>
    </a>
-->
<a href="/tickets/quzhou/"><img src="/img/quzhouspringjieshu.jpg" alt='衢州春节门票大派送活动结束' /></a>
    <a>
        <span class="show_4">
            
        </span>
    </a>
</asp:Content>

