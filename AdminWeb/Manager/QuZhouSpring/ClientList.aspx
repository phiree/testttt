<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="ClientList.aspx.cs" Inherits="Manager_QuZhouSpring_ClientManger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
<div class="detail_titlebg">
        企业列表
    </div>
    <div class="searchdiv">
        名称<asp:TextBox runat="server" ID="txtName" />&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSearch" Text="查询" runat="server" CssClass="btn2" OnClick="btnSearch_Click" />
        <asp:Button ID="btnAdd" Text="新增" runat="server" CssClass="btn2" OnClick="btnAdd_Click" />
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            客户网站列表
        </div>
        <asp:Repeater runat="server" ID="rpt" >
            <HeaderTemplate>
                <table>
                    <tr>
                        <td>
                            ID
                        </td>
                        <td>
                            网站名称
                        </td>
                        <td>
                            网站IP
                        </td>
                        <td>
                            是否启用
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("FriendlyId")%>
                    </td>
                    <td>
                        <a href='/Manager/QuZhouSpring/ClientEditor.aspx?Id=<%# Eval("Id") %>'><%#Eval("Name") %></a>
                    </td>
                    <td>
                        <%# Eval("RequestSource")%>
                    </td>
                    <td>
                        <%# (bool)Eval("Enable")?"是":"否" %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

