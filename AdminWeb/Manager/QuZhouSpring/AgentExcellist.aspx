<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AgentExcellist.aspx.cs" Inherits="Manager_QuZhouSpring_AgentExcellist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Button Text="按一下" runat="server" OnClick="btnInput_Click" /><br />
    <asp:Label ID="lblresult" Text="text" runat="server" />
    <hr />
    <asp:Repeater runat="server" ID="rptTaList" OnItemCommand="rptTaList_ItemCommand">
        <HeaderTemplate>
            <table>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <td>
                        <asp:Button runat="server" ID="btn" CommandName="add" Text="分配门票" />
                    </td>
                    <td>
                        <%#DataBinder.Eval(Container, "DataItem.景区名称")%>
                    </td>
                    c
                    <td>
                        <asp:Label runat="server" ID="lblName" Text='<%#DataBinder.Eval(Container, "DataItem.姓名")%>' />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblIdCardNo" Text='<%#DataBinder.Eval(Container, "DataItem.身份证号码")%>' />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblProductCode" Text='<%#DataBinder.Eval(Container, "DataItem.ticketcode")%>' />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblPhone" Text='<%#DataBinder.Eval(Container, "DataItem.手机号码")%>' />
                    </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    </form>
</body>
</html>
