<%@ Page Title="" Language="C#" MasterPageFile="~/sm.master" AutoEventWireup="true" CodeFile="canelTa.aspx.cs" Inherits="ScenicManager_canelTa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" Runat="Server">
    <link href="/theme/default/css/smdefault.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <p class="fuctitle">
        取消验票</p>
    <hr />
    
    <div id="upadmininfo">
        <div class="searchtime">
        身份证号码：<asp:TextBox ID="txtIdCard" runat="server"></asp:TextBox><asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
    </div>
        <asp:Repeater ID="rptTa" runat="server" onitemcommand="rptTa_ItemCommand" 
        onitemdatabound="rptTa_ItemDataBound">
        <HeaderTemplate>
            <table border="0" cellpadding="0" cellspacing="0" style="width:600px !important">
                <tr>
                    <td>
                        票名
                    </td>
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
                    <%# Eval("OrderDetail.TicketPrice.Ticket.Name") %>
                </td>
                <td>
                    <%# Eval("Name") %>
                </td>
                <td>
                    <%# Eval("IdCard") %>
                </td>
                <td>
                    <%# (bool)Eval("IsUsed")?"是":"否" %>
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Text="取消验票" CommandName="cancel" CommandArgument='<%# Eval("Id") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    </div>
</asp:Content>

