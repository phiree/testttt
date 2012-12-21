<%@ Page Title="" Language="C#" MasterPageFile="~/TourManagerDpt/manager.master" AutoEventWireup="true" CodeFile="RePolicyManager.aspx.cs" Inherits="TourManagerDpt_RePolicyManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" Runat="Server">
<div class="detail_titlebg">
        奖励政策编辑
    </div>
    <div class="detaillist">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    奖励政策
                </td>
                <td>
                    <asp:TextBox ID="txtPolicy" runat="server" Width="500px" TextMode="MultiLine" Height="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    相关文件上传
                </td>
                <td>
                    <asp:FileUpload ID="fuFile" runat="server" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn2" 
                        style="margin-top:15px" onclick="btnSave_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

