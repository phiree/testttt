<%@ Page Title="" Language="C#" MasterPageFile="~/TourManagerDpt/manager.master"
    AutoEventWireup="true" CodeFile="EnterpriseList.aspx.cs" Inherits="TourManagerDpt_EnterpriseList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="Server">
    <div class="detail_titlebg">
        企业列表
    </div>
    <div class="detaillist">
        <div class="searchdiv">
            名称:<asp:TextBox ID="txtName" runat="server" />
            是否奖励:
            <asp:DropDownList ID="ddlStar" runat="server">
                <asp:ListItem Text="所有" />
                <asp:ListItem Text="是" />
                <asp:ListItem Text="否" />
            </asp:DropDownList>
            类型:
            <asp:DropDownList ID="ddlType" runat="server">
                <asp:ListItem Text="所有" />
                <asp:ListItem Text="饭店" />
                <asp:ListItem Text="宾馆" />
                <asp:ListItem Text="购物点" />
            </asp:DropDownList>
            <asp:Button ID="btnSearch" Text="查询" runat="server" OnClick="btnSearch_Click" />
        </div>
        <div class="detailtitle">
            饭店
        </div>
        <asp:Repeater runat="server" ID="rptRestaurant" OnItemCommand="rpt_ItemCommand" OnItemDataBound="rpt_ItemDataBound">
            <HeaderTemplate>
                <table>
                    <tr>
                        <td>
                            序号
                        </td>
                        <td>
                            名称
                        </td>
                        <td>
                            查看
                        </td>
                        <td>
                            统计情况
                        </td>
                        <td>
                            账号管理
                        </td>
                        <td>
                            是否纳入奖励范围
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%=i++ %>
                    </td>
                    <td>
                        <%#Eval("Name") %>
                    </td>
                    <td>
                        <a href='EnterpriseDetail.aspx?entid=<%#Eval("Id") %>'>查看企业信息</a>
                    </td>
                   <td>
                        <a href='RewordEnt.aspx?entid=<%#Eval("Id") %>'>查看数据情况</a>
                    </td>
                    <td>
                        <asp:Button ID="BtnCreate" runat="server" Text="创建账号" CssClass="btn" CommandName="SetAdmin" CommandArgument='<%# Eval("Id") %>' />
                        <asp:TextBox ID="laAccount" runat="server"></asp:TextBox>
                        <asp:HiddenField ID="hfuserid" runat="server" />
                        <asp:Label runat="server" ID="labAccount" Visible="false"></asp:Label>
                        <asp:Button ID="BtnUpdate" Text="修改" runat="server" CssClass="btn" CommandName="UpdateAdmin" CommandArgument='<%# Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnSetVerify" CommandArgument='<%#Eval("Id") %>' CssClass="btn"
                            CommandName="SetVerify" />
                        <asp:Label ID="laIsVerify" runat="server" Text="" Visible="false"></asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
        
        <div class="detailtitle">
            宾馆
        </div>
        <asp:Repeater runat="server" ID="rptHotel" OnItemCommand="rpt_ItemCommand" OnItemDataBound="rpt_ItemDataBound">
            <HeaderTemplate>
                <table>
                    <tr>
                        <td>
                            序号
                        </td>
                        <td>
                            名称
                        </td>
                        <td>
                            查看
                        </td>
                        <td>
                            统计情况
                        </td>
                        <td>
                            创建账号
                        </td>
                        <td>
                            是否纳入奖励范围
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%=j++ %>
                    </td>
                    <td>
                        <%#Eval("Name") %>
                    </td>
                    <td>
                        <a href='EnterpriseDetail.aspx?entid=<%#Eval("Id") %>'>查看企业信息</a>
                    </td>
                   <td>
                        <a href='RewordEnt.aspx?entid=<%#Eval("Id") %>'>查看数据情况</a>
                    </td>
                    <td>
                        <asp:Button ID="BtnCreate" runat="server" Text="创建账号" CssClass="btn" CommandName="SetAdmin" CommandArgument='<%# Eval("Id") %>' />
                        <asp:TextBox ID="laAccount" runat="server"></asp:TextBox>
                        <asp:HiddenField ID="hfuserid" runat="server" />
                        <asp:Label runat="server" ID="labAccount" Visible="false"></asp:Label>
                        <asp:Button ID="BtnUpdate" Text="修改" runat="server" CssClass="btn" CommandName="UpdateAdmin" CommandArgument='<%# Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnSetVerify" CommandArgument='<%#Eval("Id") %>' CssClass="btn"
                            CommandName="SetVerify" />
                        <asp:Label ID="laIsVerify" runat="server" Text="" Visible="false"></asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
        
        <div class="detailtitle">
            购物点
        </div>
        <asp:Repeater runat="server" ID="rptShoppingp" OnItemCommand="rpt_ItemCommand" OnItemDataBound="rpt_ItemDataBound">
            <HeaderTemplate>
                <table>
                    <tr>
                        <td>
                            序号
                        </td>
                        <td>
                            名称
                        </td>
                        <td>
                            查看
                        </td>
                        <td>
                            统计情况
                        </td>
                        <td>
                            创建账号
                        </td>
                        <td>
                            是否纳入奖励范围
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%=k++ %>
                    </td>
                    <td>
                        <%#Eval("Name") %>
                    </td>
                    <td>
                        <a href='EnterpriseDetail.aspx?entid=<%#Eval("Id") %>'>查看企业信息</a>
                    </td>
                   <td>
                        <a href='RewordEnt.aspx?entid=<%#Eval("Id") %>'>查看数据情况</a>
                    </td>
                    <td>
                        <asp:Button ID="BtnCreate" runat="server" Text="创建账号" CssClass="btn" CommandName="SetAdmin" CommandArgument='<%# Eval("Id") %>' />
                        <asp:TextBox ID="laAccount" runat="server"></asp:TextBox>
                        <asp:HiddenField ID="hfuserid" runat="server" />
                        <asp:Label runat="server" ID="labAccount" Visible="false"></asp:Label>
                        <asp:Button ID="BtnUpdate" Text="修改" runat="server" CssClass="btn" CommandName="UpdateAdmin" CommandArgument='<%# Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnSetVerify" CommandArgument='<%#Eval("Id") %>' CssClass="btn"
                            CommandName="SetVerify" />
                        <asp:Label ID="laIsVerify" runat="server" Text="" Visible="false"></asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
