<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="ScenicTopicSetting.aspx.cs" Inherits="Manager_ScenicTopicSetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="/theme/default/css/Managerdefault.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <div id="selectdiv">
        <span>筛选:&nbsp;&nbsp;</span>
        <asp:DropDownList runat="server" ID="ddlArea">
        </asp:DropDownList>&nbsp;
        <asp:Button runat="server" ID="btnSearch" CssClass="btnok" OnClick="btnSearch_Click" />
    </div>
    <asp:Repeater ID="rptScenic" runat="server" OnItemDataBound="rptScenic_ItemDataBound" >
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
                    <%#Eval("Name")%>
                </td>
                <td style="text-align:center">
                    <asp:Label ID="lblaccount" runat="server">
                        <asp:repeater ID="rptTopic" runat="server">
    <itemtemplate><%# Eval("Name")%>  </itemtemplate>
</asp:repeater>
                    </asp:Label>
                </td>
                <td style="text-align:center">
                   &nbsp; 
                    <a href='/manager/scenictopicsetting2.aspx?scid=<%#Eval("Id") %>'>修改</a>
                </td>
                
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

