<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="DjsEdit.aspx.cs" Inherits="LocalTravelAgent_DjsEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="detail_titlebg">
        信息维护
    </div>
    <div class="detaillist">
        <table border="0" cellpadding="0" cellspacing="0" class="comTable">
            <tr>
                <td>
                    名称:
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="80%" />
                </td>
                <td>
                    地区
                </td>
                <td>
                   <asp:DropDownList ID="ddlArea" runat="server" Width="80%">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    联系电话:
                </td>
                <td>
                    <asp:TextBox ID="txtTel" runat="server" Width="80%" />
                </td>
                <td>
                    负责人名称:
                </td>
                <td>
                    <asp:TextBox ID="txtCPN" runat="server" Width="80%" />
                </td>
            </tr>
            <tr>
                <td>
                    负责人电话:
                </td>
                <td>
                    <asp:TextBox ID="txtCPP" runat="server" Width="80%" />
                </td>
                <td>
                    电子邮箱
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Width="80%" />
                </td>
            </tr>
            <tr>
                <td>
                    地址:
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtAddress" runat="server" Width="92%" />
                </td>
            </tr>
            <tr>
                
            </tr>
        </table>
    <div style="text-align:center">
    <asp:Button ID="btnSave" Text="保存" runat="server" OnClick="btnSave_Click"  CssClass="btn"
        />
    </div>
    </div>
</asp:Content>
