<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="DateStatist.aspx.cs" Inherits="Manager_DateStatist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <asp:Repeater ID="rptStatis" runat="server" 
    onitemdatabound="rptStatis_ItemDataBound">
        <HeaderTemplate>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        时间
                    </td>
                    <td>
                        景区
                    </td>
                    <td>
                        验票人数
                    </td>
                </tr>
            
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# Eval("date","{0:yyyy-MM-dd}")%>
                </td>
                <td>
                    <%# Eval("ticket.Scenic.Name")%>
                </td>
                <td>
                    <%# Eval("Amount") %>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

