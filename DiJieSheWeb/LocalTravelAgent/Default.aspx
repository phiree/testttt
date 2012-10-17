<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="LocalTravelAgent_Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server" >
<asp:Panel runat="server"  Visible="false">
地区: 
<asp:DropDownList ID="ddlArea" runat="server">
</asp:DropDownList>

类别: 
<asp:DropDownList ID="ddlType" runat="server">
</asp:DropDownList>

名称:<asp:TextBox ID="txtName" runat="server" />

    <asp:Button ID="btnSearch" Text="查看" runat="server" onclick="btnSearch_Click" />

    <asp:Repeater ID="rptDjs" runat="server">
        <HeaderTemplate>
        <table>
            <tr>
                <td>
                    名称
                </td>
                <td>
                    查看
                </td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            
        </ItemTemplate>
        <FooterTemplate>
        </table>
        </FooterTemplate>
    </asp:Repeater>
    </asp:Panel>

   <div class="welcome">
   
   </div>
</asp:Content>

