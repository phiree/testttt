<%@ Page Title="" Language="C#" MasterPageFile="~/TourManagerDpt/manager.master" AutoEventWireup="true" CodeFile="UserManager.aspx.cs" Inherits="TourManagerDpt_UserManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" Runat="Server">
<div class="detail_titlebg">
        用户管理
    </div>
<div class="detaillist">
    <asp:Repeater ID="rptUser" runat="server" 
        onitemdatabound="rptUser_ItemDataBound" 
        onitemcommand="rptUser_ItemCommand">
        <HeaderTemplate>
        <table>
            <tr>
                <td>
                    序号
                </td>
                <td>
                    用户名
                </td>
                <td>
                    权限
                </td>
                <td>
                    操作
                </td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%= Index++ %>
                </td>
                <td>
                    <%# Eval("Name")%>
                </td>
                <td>
                    <asp:Literal ID="laPermis" runat="server"></asp:Literal>
                </td>
                <td>
                    <a runat="server" id="aedit" href="">编辑</a>
                    <asp:Button ID="btndelete" runat="server" Text="删除" CommandArgument='<%# Eval("Id") %>' CommandName="delete" style="margin-left:15px;border:none; background:none; cursor:pointer;"  />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <div>
        <asp:Button ID="BtnAdd" runat="server" Text="新增" CssClass="btn" 
            onclick="BtnAdd_Click" />
    </div>
</div>
</asp:Content>

