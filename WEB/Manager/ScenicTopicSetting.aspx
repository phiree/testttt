<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="ScenicTopicSetting.aspx.cs" Inherits="Manager_ScenicTopicSetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="/theme/default/css/Managerdefault.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <div id="selectdiv">
        <span>筛选:&nbsp;&nbsp;</span>
        <asp:DropDownList runat="server" ID="ddlArea">
        </asp:DropDownList>&nbsp;
        <asp:Button runat="server" ID="btnSearch" CssClass="btnok"  />
    </div>
    <asp:Repeater ID="rptScenicAdmin" runat="server" >
        <HeaderTemplate>
            <table class="tblist" cellpadding="0" cellspacing="1" border="1px">
                <tr class="thead">
                    <td style="width:300px;">
                        所属景区
                    </td>
                    <td style="width:400px;">
                        旅游主题
                    </td>
                    <td style="width:100px;">
                        操作
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td style="text-align:center">
                    <%#Eval("Scenic.Name")%>
                </td>
                <td style="text-align:center">
                    <asp:Label ID="lblaccount" runat="server">
                        <asp:repeater runat="server">
    <itemtemplate><%# Eval("Topic")%></itemtemplate>
</asp:repeater>
                    </asp:Label>
                </td>
                <td style="text-align:center">
                   &nbsp; <asp:Button ID="btncz" runat="server" Text="修改" CommandName="reset" CommandArgument='<%#Eval("Id") %>' />
                </td>
                
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

