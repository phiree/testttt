<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true" CodeFile="ScenicImg.aspx.cs" Inherits="Manager_ScenicImg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    景区名称<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><asp:Button ID="Button1"
        runat="server" Text="搜索" />
    <asp:Repeater ID="rptScenic" runat="server" 
        onitemdatabound="rptScenic_ItemDataBound">
        <HeaderTemplate>
            <table border="0" cellpadding="0" cellspacing="0">
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# Eval("Name") %>
                </td>
                <asp:Repeater ID="rptImg" runat="server">
                    <ItemTemplate>
                        <td>
                            <asp:CheckBox ID="cbSelect" runat="server"  Enabled="false"/><img width="120px" height="70px" src='/ScenicImg/mainimg/<%# Eval("Name") %>' />
                            <span><%# Eval("Name") %></span>
                            <%# Eval("Name") %>&nbsp;&nbsp;<asp:Button ID="btnSetMain" runat="server" Text="设置主图" CommandName="setMain" CommandArgument='<%# Eval("Id") %>' />
                        </td>
                    </ItemTemplate>
                </asp:Repeater>
            </tr>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>

