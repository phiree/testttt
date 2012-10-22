<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true" CodeFile="GroupEditBasicInfo.aspx.cs" Inherits="LocalTravelAgent_Groups_GroupEditBasicInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
 <div>
        <table>
            <tr>
                <td>
                    团队名称
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    团队编号
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxGroupNo"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                   开始时间
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxMemo"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                   结束时间
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                </td>
            </tr>
        </table>
                          

        <asp:Button runat="server" ID="btnSaveProduct" OnClick="btnSaeProduct_Click" Text="保存" />
    </div>
</asp:Content>

