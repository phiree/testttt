<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="ProductEdit.aspx.cs" Inherits="LocalTravelAgent_ProductDetail" %>

<%@ Register src="RouteEditControl.ascx" tagname="RouteEditControl" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
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
                  路线
                </td>
                <td>
                   <uc1:RouteEditControl runat="server"  ID="ucRouteEditor" />
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
                          

        <asp:Button runat="server" ID="btnSaveProduct"     OnClick="btnSaveProduct_Click" Text="保存" />
    </div>
</asp:Content>
