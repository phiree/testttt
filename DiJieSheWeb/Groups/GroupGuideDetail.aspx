<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="GroupGuideDetail.aspx.cs" Inherits="Groups_GroupGuideDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    姓名:<asp:Label ID="lblName" Text="" runat="server" /><br />
    身份证号:<asp:TextBox ID="txtIDcard" runat="server" /><br />
    手机号码:<asp:TextBox ID="txtPhone" runat="server" /><br />
    性别:<asp:DropDownList ID="ddlGender" runat="server">
        <asp:ListItem Text="男" />
        <asp:ListItem Text="女" />
    </asp:DropDownList>
    <br />
    导游号:<asp:TextBox ID="txtGuideno" runat="server" /><br />
    <asp:Button ID="btnSave" Text="保存" runat="server" onclick="btnSave_Click" />
</asp:Content>
