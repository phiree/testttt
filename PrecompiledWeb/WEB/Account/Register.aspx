<%@ page title="注册" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Account_Register, App_Web_pswm0j0h" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div>
    
        登陆名称:<asp:TextBox ID="txtBoxLoginname" runat="server"></asp:TextBox>
        <br />
        密&nbsp; 码:<asp:TextBox ID="txtBoxPwd" runat="server"></asp:TextBox>
        <br />
        
        真实名称:<asp:TextBox ID="txtBoxName" runat="server"></asp:TextBox>
        <br />
        身份证号:<asp:TextBox ID="txtBoxIdcard" runat="server"></asp:TextBox>
        <br />
        联系电话:<asp:TextBox ID="txtBoxPhone" runat="server"></asp:TextBox>
        <br />
        联系地址:<asp:TextBox ID="txtBoxAddress" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnRegist" runat="server" Text="注册" Height="21px" 
            onclick="btnRegist_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="取消" />
    
    </div>
</asp:Content>