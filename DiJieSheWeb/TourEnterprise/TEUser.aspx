<%@ Page Title="" Language="C#" MasterPageFile="~/TourEnterprise/TE.master" AutoEventWireup="true" CodeFile="TEUser.aspx.cs" Inherits="TourEnterprise_TEUser" %>
<%@ MasterType VirtualPath="~/TourEnterprise/TE.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
<div class="detail_titlebg">
        用户编辑
    </div>
    <div class="detaillist">
        <table border="0" cellpadding="0" cellspacing="0" width="40%" class="comTable">
            <tr>
                <td>
                    用户名
                </td>
                <td style="text-align:center">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    权限
                </td>
                <td >
                    <asp:CheckBoxList ID="cbList" runat="server" CssClass="rbl" style="border:none !important; text-align:left">
                        <asp:ListItem Value="1" >信息统计员(查看预订信息和已入住统计报表)</asp:ListItem>
                        <asp:ListItem Value="2">信息验证员(验证团队信息)</asp:ListItem>
                        <asp:ListItem Value="3">用户管理员(管理各类用户权限)</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td colspan="2" style=" text-align:center">
                    <asp:Button ID="BtnSave" runat="server" Text="保存" CssClass="btn2" 
                        onclick="BtnSave_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

