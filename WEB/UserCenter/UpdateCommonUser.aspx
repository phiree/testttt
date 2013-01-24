<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/uc.master" AutoEventWireup="true" CodeFile="UpdateCommonUser.aspx.cs" Inherits="UserCenter_UpdateCommonUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="/theme/default/css/ucdefault.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ucContent" Runat="Server">
    
    <div id="cuuinfo">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    联系人姓名
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    身份证号
                </td>
                <td>
                    <asp:TextBox ID="txtIdcard" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnsave" runat="server" onclick="btnsave_Click" CssClass="btnsave" Text="修改" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

