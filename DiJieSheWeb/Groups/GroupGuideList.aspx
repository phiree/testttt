<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="GroupGuideList.aspx.cs" Inherits="Groups_GroupGuide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:DropDownList ID="ddlDJS" runat="server">
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
                <td>导游号
                </td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("Name")%>
                </td>
                <td><%# Eval("Idcard")%>
                </td>
                <td><%# Eval("Phone")%>
                </td>
                <td><%# Eval("Gender")%>
                </td>
                <td><%# Eval("GuideNo")%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
