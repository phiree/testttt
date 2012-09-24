<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="DjsEdit.aspx.cs" Inherits="LocalTravelAgent_DjsEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    名称:<asp:TextBox ID="txtName" runat="server" /><br />
    类型:<asp:DropDownList ID="ddlType" runat="server">
    </asp:DropDownList>
    <br />
    地区:<asp:DropDownList ID="ddlArea" runat="server">
    </asp:DropDownList>
    <br />
    地址:<asp:TextBox ID="txtAddress" runat="server" /><br />
    负责人名称:<asp:TextBox ID="txtCPN" runat="server" /><br />
    负责人电话:<asp:TextBox ID="txtCPP" runat="server" /><br />
    联系电话:<asp:TextBox ID="txtTel" runat="server" /><br />
    <asp:Button ID="btnSave" Text="保存" runat="server" OnClick="btnSave_Click" 
        style="height: 21px" />
</asp:Content>
