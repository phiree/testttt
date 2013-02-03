<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="TicketEdit2.aspx.cs" Inherits="Manager_ScenicManage_TicketManage_TicketEdit2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <table>
        <tr>
            <td>
                门票类别
            </td>
            <td>
                <asp:RadioButtonList runat="server" ID="rblTicketType">
                    <asp:ListItem Value="1">普通门票</asp:ListItem>
                    <asp:ListItem Value="2">套票(联票)</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                名称
            </td>
            <td>
                <asp:TextBox runat="server" ID="tbxName"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                所属单位
            </td>
            <td>
                <asp:TextBox runat="server" ID="tbxOwner"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                门票代码
            </td>
            <td>
                <asp:TextBox runat="server" ID="tbxProductCode"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                是否是主票
            </td>
            <td>
                <asp:CheckBox runat="server" ID="cbxIsMain" />
            </td>
        </tr>
        <tr>
            <td>
                是否锁住
            </td>
            <td>
                <asp:CheckBox runat="server" ID="cbxLock" />
            </td>
        </tr>
        <tr>
            <td>
                验票有效期限
            </td>
            <td>
                从
                <asp:TextBox runat="server" ID="tbxBeginDate">至</asp:TextBox>
                <asp:TextBox runat="server" ID="tbxEndDate"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                价格列表
            </td>
            <td>
                <ul>
                    <li>原价:<asp:TextBox runat="server" ID="tbxPriceNormal"></asp:TextBox>
                    </li>
                    <li>在线支付价:<asp:TextBox runat="server" ID="tbxPricePayOnline"></asp:TextBox>
                    </li>
                    <li>景区现付价:<asp:TextBox runat="server" ID="tbxPricePreOrder"></asp:TextBox>
                    </li>
                </ul>
            </td>
        </tr>
        <tr>
            <td>
                序号
            </td>
            <td>
                <asp:TextBox runat="server" ID="tbxOrder"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                备注
            </td>
            <td>
                <asp:TextBox runat="server" ID="tbxRemark"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                参与的活动
            </td>
            <td>
                <asp:HyperLink ID="hlActivity" runat="server"></asp:HyperLink>
            </td>
        </tr>
    </table>
    <!--联票属性-->
    <table runat="server" id="tblUnion">
        <tr>
            <td>
                包含的门票
            </td>
            <td>
                <a href="UnionTicketEdit.aspx?ticketid=<%=ticketId %>">管理门票</a>
                <asp:Repeater runat="server" ID="rptTicket">
                </asp:Repeater>
            </td>
        </tr>
    </table>
    <table runat="server" id="tblNormal">
        <tr>
            <td>
                所属联票
            </td>
            <td>
                <!--联票名称-->
                <asp:HyperLink runat="server" ID="hlUnionTicket"></asp:HyperLink>
            </td>
        </tr>
    </table>
    <div>
        <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" />
    </div>
</asp:Content>
