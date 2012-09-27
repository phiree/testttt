<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true"
    CodeFile="ProductEdit.aspx.cs" Inherits="LocalTravelAgent_ProductDetail" %>

<%@ Register src="RouteEditControl.ascx" tagname="RouteEditControl" tagprefix="uc1" %>

<%@ Register src="RouteListControl.ascx" tagname="RouteListControl" tagprefix="uc2" %>

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
                    天数
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxDayAmount"></asp:TextBox>
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
                          

        <asp:Button runat="server" ID="btnSaveProduct" OnClick="btnSaeProduct_Click" Text="保存" />
    </div>
</asp:Content>
