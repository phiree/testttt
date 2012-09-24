<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true"
    CodeFile="ProductEdit.aspx.cs" Inherits="LocalTravelAgent_ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <div>
        <table>
            <tr>
                <td>
                    产品名称
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    备注
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxMemo"></asp:TextBox>
                </td>
            </tr>
           
        </table>
        <asp:Button runat="server" ID="btnSave" Text="保存" />
    </div>
</asp:Content>
