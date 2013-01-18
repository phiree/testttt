<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="DateTicketAsign.aspx.cs" Inherits="Manager_QuZhouSpring_DateTicketAsign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <div class="detail_titlebg">
        <asp:Literal Text="" ID="laDate" runat="server" />
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            分配列表
        </div>
        <asp:Repeater runat="server" ID="rptAsignList" 
            onitemdatabound="rptAsignList_ItemDataBound" 
            onitemcommand="rptAsignList_ItemCommand">
            <HeaderTemplate>
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            门票名称
                        </td>
                        <td>
                            总票数
                        </td>
                        <td>
                            分配情况
                        </td>
                        <td>
                            已售总数
                        </td>
                        <td>
                            操作
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("Ticket.Scenic.Name")%> <%# Eval("Ticket.Name")%>
                    <asp:HiddenField runat="server" ID="hfTaId" Value='<%# Eval("Id") %>' />
                    </td>
                    <td><%# Eval("Amount")%></td>
                    <td>
                        <asp:Repeater runat="server" ID="rptPartnerList">
                            <HeaderTemplate>
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            合作商名字
                                        </td>
                                        <td>
                                            分配票数
                                        </td>
                                        <td>
                                            已售票数
                                        </td>
                                        
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Eval("Partner.Name")%>
                                            <asp:HiddenField runat="server" ID="hfid" Value='<%# Eval("Id") %>' />
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="tbxAsignAmount"  Text='<%# Eval("AsignedAmount") %>'/>
                                        </td>
                                        <td>
                                            <%# Eval("SoldAmount")%>
                                        </td>
                                    </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </td>
                    <td>
                        <%# Eval("SoldAmount")%>
                    </td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="保存" CommandName="save" CommandArgument='<%# Eval("Id") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

