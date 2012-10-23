<%@ Page Title="" Language="C#" MasterPageFile="~/TourManagerDpt/manager.master" AutoEventWireup="true" CodeFile="EnterEdit.aspx.cs" Inherits="TourManagerDpt_EnterEdit" %>

<%@ Register TagPrefix="uc"  Src="~/UC/CityCode.ascx" TagName="dllcitycode"%>
<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">

    <div class="detail_titlebg">
        企业编辑
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            编辑详情
        </div>
        <table>
            <tr>
                <td>
                    企业名称
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    类型
                </td>
                <td>
                    <asp:DropDownList ID="ddltype" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    所属区域
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
                    负责人姓名
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxChargePerson"></asp:TextBox>
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
            <tr>
                <td>
                    办公室电话
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxOfficePhone"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button runat="server" ID="btnSave" OnClick="btnSave_Click" Text="保存" CssClass="btn" style="margin-left:350px;" />
    </div>
</asp:Content>

