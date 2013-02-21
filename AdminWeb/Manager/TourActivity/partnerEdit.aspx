<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="partnerEdit.aspx.cs" Inherits="Manager_TourActivity_partnerEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
供应商编辑
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                名称
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                编号
            </td>
            <td>
                <asp:TextBox ID="txtPartnerCode" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                是否使用
            </td>
            <td>
                <asp:CheckBox ID="ckEnabled" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                是否只控制总体数量
            </td>
            <td>
                <asp:CheckBox ID="ckOnlyControlTotalAmount" runat="server" />
            </td>
            
        </tr>
         <tr>
            <td>
                是否限制购票时间
            </td>
            <td>
                <asp:CheckBox ID="cbxNeedCheckTime" Checked="true" runat="server" />
            </td>
            
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

