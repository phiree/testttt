<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true" CodeFile="GuideDetail.aspx.cs" Inherits="LocalTravelAgent_GuideDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div class="detail_titlebg">
        导游管理
    </div>
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
                导游证号:
            </td>
            <td>
                <asp:TextBox ID="txtGuideid" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                所属公司:
            </td>
            <td>
              <asp:TextBox ID="tbxBelong" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <asp:Button ID="btnSave" Text="保存" runat="server" OnClick="btnSave_Click" CssClass="btn"/>
            </td>
        </tr>
    </table>
</asp:Content>

