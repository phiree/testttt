<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true"
    CodeFile="EnterpriseEdit.aspx.cs" Inherits="Admin_EnterpriseEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="Server">

    <table>
        <tr>
            <td>
                企业名称
            </td>
            <td>
                <asp:TextBox runat="server" ID="tbxName"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                类型
            </td>
            <td>
                <asp:RadioButtonList runat="server" ID="rblType">
                    <asp:ListItem Value="5" Selected="True">旅行社</asp:ListItem>
                    <asp:ListItem Value="1">景点</asp:ListItem>
                    <asp:ListItem Value="2">饭店</asp:ListItem>
                    <asp:ListItem Value="3">宾馆</asp:ListItem>
                     <asp:ListItem Value="4">购物点</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
           <tr>
            <td>
                所属区域
            </td>
            <td>
               <asp:DropDownList runat="server" ID="ddlArea"></asp:DropDownList>
               <asp:TextBox runat="server" ID="tbxAreaCode"></asp:TextBox>
            </td>
        </tr>
             
           <tr>
            <td>
                地址
            </td>
            <td>
              
               <asp:TextBox runat="server" ID="tbxAdress"></asp:TextBox>
            </td>
        </tr>
           <tr>
            <td>
                负责人姓名
            </td>
            <td>
              
               <asp:TextBox runat="server" ID="tbxChargePerson"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td>
                负责人电话
            </td>
            <td>
              
               <asp:TextBox runat="server" ID="tbxPhone"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
                办公室电话
            </td>
            <td>
              
               <asp:TextBox runat="server" ID="tbxOfficePhone"></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:Button runat="server" ID="btnSave"  OnClick="btnSave_Click" Text="保存"/>
</asp:Content>
