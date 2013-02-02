<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="ticketList.aspx.cs" Inherits="Manager_TourActivity_ticketList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
门票列表<br />

门票id：<asp:TextBox ID="txtTicketId" runat="server"></asp:TextBox><asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="btnAdd_Click" />
    <asp:Repeater runat="server" ID="rptTicket" 
        onitemcommand="rptTicket_ItemCommand">
        <HeaderTemplate>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        门票所属单位
                    </td>
                    <td>
                        门票名称
                    </td>
                    <td>
                        门票编号
                    </td>
                    <td>
                        门票起始时间
                    </td>
                    <td>
                        门票结束时间
                    </td>
                    <td>
                        操作
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# Eval("Scenic.Name") %>
                </td>
                <td>
                    <%# Eval("Name") %>              
                </td>
                <td>
                    <asp:TextBox ID="txtProductCode" runat="server" Text='<%# Eval("ProductCode")%>'></asp:TextBox>                        
                </td>
                <td>
                    <asp:TextBox ID="txtBeginDate" runat="server" Text=' <%# Eval("BeginDate","{0:yyyy-MM-dd}")%>'></asp:TextBox>                                              
                </td>
                <td>
                     <asp:TextBox ID="txtEndDate" runat="server" Text='<%# Eval("EndDate", "{0:yyyy-MM-dd}")%>'></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="更新" CommandName="save" CommandArgument='<%# Eval("Id") %>' />
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

