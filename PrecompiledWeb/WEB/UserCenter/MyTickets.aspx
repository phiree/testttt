<%@ page title="" language="C#" masterpagefile="~/UserCenter/uc.master" autoeventwireup="true" inherits="UserCenter_MyTickets, App_Web_ze50iwky" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ucContent" runat="Server">
 
    <asp:Repeater runat="server" ID="rpt">
        <HeaderTemplate>
            <table>
                <tr>
                    <td>
                        所属景点
                    </td>
                    <td>
                        购买价
                    </td>
                    <td>
                        购入张数
                    </td>
                      <td>
                        购买时间
                    </td>
                    <td>
                        已用张数
                    </td>
                </tr>
        </HeaderTemplate>
        <FooterTemplate>
            </table></FooterTemplate>
        <ItemTemplate>
            <tr>
                <td>
                   
                        <%#Eval("Ticket.Scenic.Name")%></a>
                </td>
                <td>
                    <%#DataBinder.Eval(Container.DataItem,"Price","{0:c}")%>
                </td>
                <td>
                    <%#Eval("TotalNum")%>
                </td>
                <td>
                    <%#Eval("BuyTime")%>
                </td>
                <td>
                    <%#Eval("UsedNum")%>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
