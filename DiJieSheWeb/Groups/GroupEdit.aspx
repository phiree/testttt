<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true" CodeFile="GroupEdit.aspx.cs" Inherits="LocalTravelAgent_GroupEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    地接社：<asp:DropDownList ID="ddlDJS" runat="server"></asp:DropDownList><br />
    团队名称：<asp:TextBox ID="txtGroupname" runat="server" /><br />
开始时间：<asp:TextBox ID="txtBegintime" runat="server" ReadOnly="True"></asp:TextBox>
    <asp:Calendar ID="Calendar1" runat="server" 
        onselectionchanged="Calendar1_SelectionChanged"></asp:Calendar>
    <br />
结束时间：<asp:TextBox ID="txtEndtime" runat="server"></asp:TextBox>
    <asp:Calendar ID="Calendar2" runat="server" 
        onselectionchanged="Calendar2_SelectionChanged"></asp:Calendar>
    <br />
游玩天数：<asp:TextBox ID="txtDays" runat="server"></asp:TextBox><br />
<%--导游信息：<asp:TextBox ID="txtGuidename" runat="server" /><asp:TextBox ID="txtGuidephone" runat="server" /><br />
司机信息：<asp:TextBox ID="txtDrivername" runat="server" /><asp:TextBox ID="txtDriverphone" runat="server" /><br />
车牌号：<asp:TextBox ID="txtCarid" runat="server" /><br />--%>
成人总数：<asp:TextBox ID="txtAdultnum" runat="server" /><br />
儿童总数：<asp:TextBox ID="txtChildnum" runat="server" /><br />
    <asp:Button ID="btnOK" Text="保存" runat="server" onclick="btnOK_Click" />
    <asp:Button ID="btnNext" Text="下一步" runat="server" onclick="btnNext_Click" />
</asp:Content>
