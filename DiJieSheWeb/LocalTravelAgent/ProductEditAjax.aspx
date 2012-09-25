<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true"
    CodeFile="ProductEditAjax.aspx.cs" Inherits="LocalTravelAgent_ProductEditAjax" %>

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
                    <input type="text" name="txtProductName" />
                </td>
            </tr>
            <tr>
                <td>
                    备注
                </td>
                <td>
                    <input type="text" name="txtMemo" />
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:Button runat="server" ID="btnSave" Text="保存" />
    </div>
</asp:Content>
