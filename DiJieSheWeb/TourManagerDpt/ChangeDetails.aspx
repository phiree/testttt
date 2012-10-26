<%@ Page Title="" Language="C#" MasterPageFile="~/TourManagerDpt/manager.master" AutoEventWireup="true" CodeFile="ChangeDetails.aspx.cs" Inherits="TourManagerDpt_ChangeDetails" %>

<%@ Register TagPrefix="uc"  Src="~/UC/CityCode.ascx" TagName="dllcitycode"%>

<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">

    <div class="detail_titlebg">
        增加旅游管理部门
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            增加旅游管理部门
        </div>
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
                    <uc:dllcitycode ID="ddlarea" runat="server" />
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
        <asp:Button runat="server" ID="btnSave" OnClick="btnSave_Click" Text="保存" CssClass="btn"
            Style="margin-left: 360px" />
    </div>
</asp:Content>

