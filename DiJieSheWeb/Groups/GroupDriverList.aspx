<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true" CodeFile="GroupDriverList.aspx.cs" Inherits="Groups_GroupDriver" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:DropDownList ID="ddlDJS" runat="server" ontextchanged="ddlDJS_TextChanged" 
        AutoPostBack="True">
    </asp:DropDownList>
    <asp:Repeater ID="rptGuide" runat="server">
        <HeaderTemplate>
            <table border="1" cellpadding="1" cellspacing="1">
            <tr>
                <td>姓名
                </td>
                <td>身份证号
                </td>
                <td>手机号码
                </td>
                <td>性别
                </td>
                <td>车牌号
                </td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><a href='/Groups/GroupDriverDetail.aspx?id=<%# Eval("Id")%>'><%# Eval("Name")%></a>
                </td>
                <td><%# Eval("Idcard")%>
                </td>
                <td><%# Eval("Phone")%>
                </td>
                <td><%# Eval("Gender")%>
                </td>
                <td><%# Eval("Carno")%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

