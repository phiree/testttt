<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="CancelTa.aspx.cs" Inherits="Manager_QuZhouSpring_CancelTa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <asp:TextBox ID="txtIdCard" runat="server"></asp:TextBox><asp:Button ID="btnSearch" runat="server" Text="查询" />
    <asp:Repeater ID="rptTa" runat="server" onitemcommand="rptTa_ItemCommand">
        <HeaderTemplate>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        姓名
                    </td>
                    <td>
                        省份证号
                    </td>
                    <td>
                        是否已使用
                    </td>
                    <td>
                        取消验票
                    </td>
                </tr>
            
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# Eval("Name") %>
                </td>
                <td>
                    <%# Eval("IdCard") %>
                </td>
                <td>
                    <%# Eval("IsUsed") %>
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Text="取消验票" CommandName="cancel" CommandArgument='<%# Eval("Id") %>' />
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>

