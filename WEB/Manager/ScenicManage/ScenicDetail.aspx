<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Manager/manager.master"
    CodeFile="ScenicDetail.aspx.cs" EnableEventValidation="false" Inherits="Manager_ScenicDetail" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link href="/theme/default/css/Managerdefault.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="cphmain">
    <!--景区详细信息-->
    <table class="tdetailtable">
        <tr>
            <th>
                名称
            </th>
            <td>
                <%=scenic.Name %>
            </td>
        </tr>
        <tr>
            <th>
                级别
            </th>
            <td>
                <%=scenic.Level %>
            </td>
        </tr>
        <tr>
            <th>
                单位地址
            </th>
            <td>
                <%=scenic.Address %>
            </td>
        </tr>
        <asp:Repeater ID="rptprice" runat="server">
            <ItemTemplate>
                <tr>
                    <th>门票: <%#Eval("Name") %></th>
                    <td>
                        <ul>
                            <li>原价: <%# ((IList<Model.TicketPrice>)Eval("TicketPrice")).Where(x => x.PriceType == Model.PriceType.Normal).First().Price.ToString("0") %></li>
                            <li>明信片优惠价: <%# ((IList<Model.TicketPrice>)Eval("TicketPrice")).Where(x => x.PriceType == Model.PriceType.PostCardDiscount).First().Price.ToString("0")%></li>
                            <li>景区现付价: <%# ((IList<Model.TicketPrice>)Eval("TicketPrice")).Where(x => x.PriceType == Model.PriceType.PreOrder).First().Price.ToString("0")%></li>
                            <li>在线支付价: <%# ((IList<Model.TicketPrice>)Eval("TicketPrice")).Where(x => x.PriceType == Model.PriceType.PayOnline).First().Price.ToString("0")%></li>
                        </ul>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <th>
                传真图片
            </th>
            <td>
                <asp:Image ID="ContractImg" runat="server" Height="200px" Width="250px"/>
            </td>
        </tr>
        <tr>
            <th>
                网上售票
            </th>
            <td>
                <asp:Panel runat="server" ID="pnlApplied">
                    备忘:<asp:TextBox runat="server" ID="tbxMsg"></asp:TextBox>
                    <asp:Button runat="server" ID="btnPass" Text="通过" OnClick="btnPass_Click" />
                    <asp:Button runat="server" ID="btnNoPass" Text="拒绝" onclick="btnNoPass_Click" />
                </asp:Panel>
                <asp:Panel runat="server" ID="pnlPassed">
                    已经通过审核
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
