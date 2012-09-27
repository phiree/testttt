<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="GroupDriverDetail.aspx.cs" Inherits="Groups_GroupDriverDetail" %>

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
    车牌号:<asp:TextBox ID="txtCarno" runat="server" /><br />
    <asp:Button ID="btnSave" Text="保存" runat="server" OnClick="btnSave_Click" />
</asp:Content>
