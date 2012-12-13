<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="ScenicAdminSetting.aspx.cs" Inherits="Manager_ScenicAdminSetting" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <link href="/theme/default/css/Managerdefault.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
    <div id="selectdiv">
        <span>筛选:&nbsp;&nbsp;</span>
        <asp:DropDownList runat="server" ID="ddlArea">
        </asp:DropDownList>&nbsp;
        <asp:Button runat="server" ID="btnSearch" CssClass="btnok" 
            onclick="btnSearch_Click" />
    </div>
    <asp:Repeater ID="rptScenicAdmin" runat="server" 
        onitemcommand="rptScenicAdmin_ItemCommand" 
        onitemdatabound="rptScenicAdmin_ItemDataBound">
        <HeaderTemplate>
            <table class="tblist" cellpadding="0" cellspacing="1" border="1px">
                <tr class="thead">
                    <td style="width:300px;">
                        所属景区
                    </td>
                    <td style="width:400px;">
                        生成账号
                    </td>
                    <td style="width:100px;">
                        账号操作
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td style="text-align:center">
                    <%#Eval("Name")%>
                </td>
                <td style="text-align:center">
                    &nbsp;<asp:Button ID="btnmake" runat="server" Text="生成" CommandName="make" CommandArgument='<%#Eval("Id") %>' />
                    <asp:Label ID="lblaccount" runat="server"></asp:Label>
                </td>
                <td style="text-align:center">
                   &nbsp; <asp:Button ID="btncz" runat="server" Text="重置密码" CommandName="reset" CommandArgument='<%#Eval("Id") %>' />
                </td>
                
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <uc:AspNetPager runat="server" ID="pager" UrlPaging="true">
    </uc:AspNetPager>
</asp:Content>
