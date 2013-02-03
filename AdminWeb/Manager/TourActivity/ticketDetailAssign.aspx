<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="ticketDetailAssign.aspx.cs" Inherits="Manager_TourActivity_ticketDetailAssign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
<%= DateTime.Parse(Request.QueryString["dateTime"]).ToString("yyyy-MM-dd")%>具体门票分配
    <asp:Repeater runat="server" ID="rptTicket" 
        onitemdatabound="rptTicket_ItemDataBound" 
        onitemcommand="rptTicket_ItemCommand">
        <HeaderTemplate>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        景区
                    </td>
                    <td>
                        门票名称
                    </td>
                    <td>
                        分配情况
                    </td>
                    <td>
                        操作
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# Eval("Scenic.Name")%>
                </td>
                <td>
                    <%# Eval("Name")%>
                </td>
                <td>
                    <asp:Repeater runat="server" ID="rptAssign">
                        <ItemTemplate>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtPaName" runat="server" Text='<%# Eval("Partner.Name")%>'></asp:TextBox> 
                                        <asp:HiddenField ID="hfPaId" runat="server" Value='<%# Eval("Partner.Id") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAmount" runat="server" Text='<%# Eval("AssignedAmount")%>'></asp:TextBox> 
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="保存" CommandName="Save" CommandArgument='<%# Eval("Id") %>' />
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

