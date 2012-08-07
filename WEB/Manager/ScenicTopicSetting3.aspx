<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="ScenicTopicSetting3.aspx.cs" Inherits="Manager_ScenicTopicSetting3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <asp:Repeater runat="server" ID="rptTopic" OnItemCommand="rptTopic_ItemCommand">
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
                    <asp:LinkButton ID="lbtnSubmit" runat="server" CommandName="Edit" CommandArgument='<%#Eval("Name") %>'>修改</asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

