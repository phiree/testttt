<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="DriverDetail.aspx.cs" Inherits="LocalTravelAgent_DriverDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="detail_titlebg">
        司机编辑
    </div>
    <div class="detaillist">
    <table border="0" cellpadding="0" cellspacing="0" class="comTable">
        <tr>
            <td>
                姓名:
            </td>
            <td>
                <asp:Label ID="lblname" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                手机:
            </td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                身份证号:
            </td>
            <td>
                <asp:TextBox ID="txtidcard" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                驾驶证号:
            </td>
            <td>
                <asp:TextBox ID="txtdriverid" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                归属部门:
            </td>
            <td>
                <asp:Label ID="lbldjs" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style=" text-align:center">
                <asp:Button ID="btnSave" Text="保存" runat="server" OnClick="btnSave_Click" CssClass="btn"/>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
