<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="SeoInit.aspx.cs" Inherits="Manager_SeoInit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
    <asp:DropDownList runat="server" ID="ddlCity" AutoPostBack="True" OnTextChanged="ddlCity_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:Repeater runat="server" ID="rptScenic" OnItemCommand="rptScenic_ItemCommand">
        <HeaderTemplate>
            <table class="tblist" cellpadding="0" cellspacing="0" border="0">
                <thead>
                    <tr>
                        <td style="width: 35%">
                            名称
                        </td>
                        <td style="width: 35%">
                            SEO名称
                        </td>
                        <td>
                        </td>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <FooterTemplate>
            </tbody> </table></FooterTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("Name") %>
                </td>
                <td>
                    <asp:TextBox Text='<%#Eval("SeoName") %>' ID="txtSeoname" runat="server" />
                </td>
                <td>
                    <asp:LinkButton ID="lbtnSubmit" runat="server" CommandName="Edit" CommandArgument='<%#Eval("Id") %>'>修改</asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
