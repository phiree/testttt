<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="AccountDetail.aspx.cs" Inherits="Manager_AccountDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" Runat="Server">
<div>
 用户帐号:
</div>
<div>
角色:<asp:CheckBoxList runat="server" ID="cbxRoles"></asp:CheckBoxList>
</div>
<div><a href='ScenicAdminDetail.aspx?userid=<%=userId%>'>设为景区管理员</a></div>
<div>
<asp:Button runat="server" ID="btnOK" OnClick="btnOK_Click" Text="确定" />
</div>
</asp:Content>

