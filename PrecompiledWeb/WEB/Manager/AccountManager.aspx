<%@ page title="" language="C#" masterpagefile="~/Manager/manager.master" autoeventwireup="true" inherits="Manager_AccountManager, App_Web_yhjf3wuk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Repeater runat="server" ID="rpt" OnItemDataBound="rpt_DataBound">
        <HeaderTemplate>
            <table>
                <tr>
                    <td>
                        帐号名称
                    </td>
                    <td>
                        目前角色
                    </td>
                    <td></td>
                </tr>
        </HeaderTemplate>
        <FooterTemplate>
            </table></FooterTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("Name")%>
                </td>
                <td>
                <%#  Eval("UserTypeNameString")%>
                </td>
                <td><a href='AccountDetail.aspx?userid=<%#Eval("Id") %>'>修改</a></td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
