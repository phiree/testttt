<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true" CodeFile="UpdateAdminInfo.aspx.cs" Inherits="ScenicManager_UploadAdminInfo" %>
<%@ MasterType VirtualPath="~/ScenicManager/sm.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" Runat="Server">
    <link href="/theme/default/css/smdefault.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <p class="fuctitle">
        修改信息</p>
    <hr />
    <div id="upadmininfo">
        <table border="0" cellpadding="5" cellspacing="5">
            <tr>
                <td>
                    用户名
                </td>
                <td>
                    <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    旧密码
                </td>
                <td>
                    <asp:TextBox ID="txtpwd1" TextMode="Password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    新密码
                </td>
                <td>
                    <asp:TextBox ID="txtpwd2" TextMode="Password" runat="server" 
                        style="vertical-align:middle"></asp:TextBox><asp:CompareValidator
                        ID="CompareValidator1" runat="server" ErrorMessage="两次密码不同" 
                        ControlToCompare="txtpwd1" ControlToValidate="txtpwd2" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>
                    
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" CssClass="updateadmininfo" 
                        onclick="Button1_Click"  />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

