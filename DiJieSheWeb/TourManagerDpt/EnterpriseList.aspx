<%@ Page Title="" Language="C#" MasterPageFile="~/TourManagerDpt/manager.master"
    AutoEventWireup="true" CodeFile="EnterpriseList.aspx.cs" Inherits="TourManagerDpt_EnterpriseList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="Server">
    <div class="detail_titlebg">
        企业列表
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            企业列表
        </div>
        <asp:Repeater runat="server" ID="rpt" OnItemCommand="rpt_ItemCommand" OnItemDataBound="rpt_ItemDataBound">
            <HeaderTemplate>
                <table>
                    <tr>
                        <td>
                            企业类型
                        </td>
                        <td>
                            名称
                        </td>
                        <td>
                            查看
                        </td>
                        <%--<td>
                            奖励情况
                        </td>--%>
                        <td>
                            认证状态
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("Type").ToString()%>
                    </td>
                    <td>
                        <%#Eval("Name") %>
                    </td>
                    <td>
                        <a href='EnterpriseDetail.aspx?entid=<%#Eval("Id") %>'>查看企业信息</a>
                    </td>
                    <%--<td>
                        <a href='RewordEnt.aspx?entid=<%#Eval("Id") %>'>查看奖励情况</a>
                    </td>--%>
                    <td>
                        <asp:Button runat="server" ID="btnSetVerify" CommandArgument='<%#Eval("Id") %>' CssClass="btn"
                            CommandName="SetVerify" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
