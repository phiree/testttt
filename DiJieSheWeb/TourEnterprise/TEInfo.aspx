<%@ Page Title="" Language="C#" MasterPageFile="~/TourEnterprise/TE.master" AutoEventWireup="true" CodeFile="TEInfo.aspx.cs" Inherits="TourEnterprise_TEInfo" %>
<%@ MasterType VirtualPath="~/TourEnterprise/TE.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
<div class="detail_titlebg">
        单位信息
    </div>
    <div class="detaillist">
        <table border="0" cellpadding="0" cellspacing="0" class="comTable">
            <tr>
                <td>
                    单位名称:
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="80%" Enabled="false" />
                </td>
                <td>
                    行政辖区
                </td>
                <td>
                <asp:Label runat="server" ID="lblArea"></asp:Label>
                   <asp:DropDownList ID="ddlArea" Visible=false runat="server" Width="80%">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    单位电话:
                </td>
                <td>
                    <asp:TextBox ID="txtTel" runat="server" Width="80%" />
                </td>
                <td>
                    负责人姓名:
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
                    负责人邮箱
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Width="80%" />
                </td>
            </tr>
            <tr>
                <td>
                    邮寄地址:
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtAddress" runat="server" Width="92%" CssClass="required" />
                </td>
            </tr>
            <tr>
                
            </tr>
        </table>
    <div style="text-align:center">
    <asp:Button ID="btnSave" Text="保存" runat="server" ValidationGroup="vgGroup" OnClick="btnSave_Click"  CssClass="btn2 submit"
        />
    </div>
    </div>
</asp:Content>

