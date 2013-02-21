<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="partnerList.aspx.cs" Inherits="Manager_TourActivity_partnerList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
合作商列表
    <asp:Repeater runat="server" ID="rptPartner">
        <HeaderTemplate>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        名称
                    </td>
                    <td>
                        编号
                    </td>
                    <td>
                        是否使用
                    </td>
                    <td>
                        是否只控制整体数量
                    </td>
                    <td>
                        编辑
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# Eval("Name") %>
                </td>
                <td>
                    <%# Eval("PartnerCode")%>
                </td>
                <td>
                    <%# (bool)Eval("Enabled")?"是":"否" %>
                </td>
                <td>
                    <%# (bool)Eval("OnlyControlTotalAmount") ? "是" : "否"%>
                </td>
                <td>
                    <a href='/manager/touractivity/partnerEdit.aspx?paId=<%# Eval("Id") %>&actId=<%= Request.QueryString["actId"] %>'>编辑</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Button ID="btnAdd" runat="server" Text="增加" OnClick="btnAdd_Click" />
</asp:Content>

