<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true" CodeFile="LTAUserEdit.aspx.cs" Inherits="LocalTravelAgent_LTAUserEdit" %>
<%@ MasterType  VirtualPath="~/LocalTravelAgent/LTA.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
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
                        <asp:ListItem Value="1" >信息编辑员(修改、编辑本地接社基本信息)</asp:ListItem>
                        <asp:ListItem Value="2" >报表查看员(查看旅游企业和管理部门相关报表)</asp:ListItem>
                        <asp:ListItem Value="3">用户管理员(管理各类用户权限)</asp:ListItem>
                        <asp:ListItem Value="4">团队录入员(新建、修改团队包括人员、行程等信息)</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td colspan="2" style=" text-align:center">
                    <asp:Button ID="BtnSave" runat="server" Text="保存" CssClass="btn" 
                        onclick="BtnSave_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

