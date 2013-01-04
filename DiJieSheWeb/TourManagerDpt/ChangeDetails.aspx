<%@ Page Title="" Language="C#" MasterPageFile="~/TourManagerDpt/manager.master" AutoEventWireup="true" CodeFile="ChangeDetails.aspx.cs" Inherits="TourManagerDpt_ChangeDetails" %>

<%@ Register TagPrefix="uc"  Src="~/UC/CityCode.ascx" TagName="dllcitycode"%>

<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">

    <div class="detail_titlebg">
        修改旅游管理单位
    </div>
    <div class="detaillist">
        <table>
            <tr>
                <td>
                    单位名称
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    行政辖区:
                </td>
                <td>
                    <uc:dllcitycode ID="ddlarea" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    邮寄地址
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxAdress"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    单位电话
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxPhone"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    联系人名字
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxUserName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    联系人电话
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxUserTel"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    负责人邮箱
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxUserEmail"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button runat="server" ID="btnSave" OnClick="btnSave_Click" Text="保存" CssClass="btn2"
            Style="margin-left: 360px" />
    </div>
</asp:Content>

