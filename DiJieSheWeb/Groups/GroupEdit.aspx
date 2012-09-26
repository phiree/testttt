<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="GroupEdit.aspx.cs" Inherits="LocalTravelAgent_GroupEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    地接社：
    <asp:DropDownList ID="ddlDJS" runat="server">
    </asp:DropDownList>
    <br />
    团队名称：<asp:TextBox ID="txtGroupname" runat="server" /><br />
    开始时间：<asp:TextBox ID="txtBegintime" runat="server" ReadOnly="True"></asp:TextBox>
    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged">
    </asp:Calendar>
    <br />
    结束时间：<asp:TextBox ID="txtEndtime" runat="server"></asp:TextBox>
    <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged">
    </asp:Calendar>
    <br />
    游玩天数：<asp:TextBox ID="txtDays" runat="server"></asp:TextBox><br />
    成人总数：<asp:TextBox ID="txtAdultnum" runat="server" /><br />
    儿童总数：<asp:TextBox ID="txtChildnum" runat="server" /><br />
    <asp:Button ID="btnOK" Text="保存" runat="server" OnClick="btnOK_Click" />
    <asp:Button ID="btnNext" Text="下一步" runat="server" OnClick="btnNext_Click" />
</asp:Content>
