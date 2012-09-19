<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true" CodeFile="GroupEdit.aspx.cs" Inherits="LocalTravelAgent_GroupEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    团队名称：<asp:TextBox ID="txtGroupname" runat="server" /><br />
开始时间：<asp:TextBox ID="txtBegintime" runat="server"></asp:TextBox><br />
结束时间：<asp:TextBox ID="txtEndtime" runat="server"></asp:TextBox><br />
导游信息：<asp:TextBox ID="txtGuidename" runat="server" /><asp:TextBox ID="txtGuidephone" runat="server" /><br />
司机信息：<asp:TextBox ID="txtDrivername" runat="server" /><asp:TextBox ID="txtDriverphone" runat="server" /><br />
车牌号：<asp:TextBox ID="txtCarid" runat="server" /><br />
成人总数：<asp:TextBox ID="txtAdultnum" runat="server" /><br />
儿童总数：<asp:TextBox ID="txtChildnum" runat="server" /><br />
    <asp:Button ID="btnOK" Text="确定" runat="server" onclick="btnOK_Click" />
</asp:Content>
