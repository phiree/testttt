<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="ManageDptEdit.aspx.cs" Inherits="Admin_ManageDptEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">
 <table>
        <tr>
            <td>
                部门名称
            </td>
            <td>
                <asp:TextBox runat="server" ID="tbxName"></asp:TextBox>
            </td>
        </tr>
       
           <tr>
            <td>
               区域编码:
            </td>
            <td>
              
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
                负责人电话
            </td>
            <td>
              
               <asp:TextBox runat="server" ID="tbxPhone"></asp:TextBox>
            </td>
        </tr>
         
    </table>
    <asp:Button runat="server" ID="btnSave"  OnClick="btnSave_Click" Text="保存"/>
</asp:Content>

