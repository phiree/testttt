<%@ page title="" language="C#" masterpagefile="~/Manager/manager.master" autoeventwireup="true" inherits="Manager_AccountDetail, App_Web_yhjf3wuk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
 用户帐号:<%=User.UserType %>
</div>
<div>
权限分配:<asp:CheckBoxList runat="server" ID="cbxPermissions"></asp:CheckBoxList>
</div>
<div>
<asp:Button runat="server" ID="btnOK" OnClick="btnOK_Click" Text="确定" />
</div>
</asp:Content>

