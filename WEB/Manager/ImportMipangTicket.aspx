<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="ImportMipangTicket.aspx.cs" Inherits="Manager_ImportMipangTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
<asp:TextBox runat="server" ID="tbxAddress"></asp:TextBox>
<asp:Button runat="server" ID="btnImport" Text="导入"  OnClick="btnImport_Click"/>
<asp:Label runat="server" ID="lblDesc"></asp:Label>
 <asp:Repeater runat="server" ID="rptScenic" >
        <HeaderTemplate>
            <table class="tblist" cellpadding="0" cellspacing="0" border="0">
                <tr class="thead">
                    <td style="width: 200px">
                        名称
                    </td>
                    <td style="width: 200px">
                        地址
                    </td>
                    <td style="width: 30px">
                        等级
                    </td>
                    <td style="width: 200px">
                        审核状态
                    </td>
                    <td style="width: 50px">
                        操作
                    </td>
                    <%-- <td>
                            生成账号
                        </td>
                        <td>
                            账号操作
                        </td>--%>
                </tr>
        </HeaderTemplate>
        <FooterTemplate>
            </table></FooterTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("Name") %>
                </td>
                <td>
                    <%#Eval("Address") %>
                </td>
                <td style="text-align: center">
                    <%#Eval("Level") %>
                </td>
                <td>
                    <asp:Repeater runat="server" ID="rpt_CheckProgress">
                        <ItemTemplate>
                            <div>
                                模块:<%#Eval("Module") %>,状态:<%#Eval("CheckStatus")%></div>
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
                <td style="text-align: center">
                    <a href='ScenicDetail.aspx?id=<%#Eval("Id") %>'>审核</a> <a href='EditScenic.aspx?id=<%#Eval("Id")%>'>
                        编辑</a> <a href='EditTicket.aspx?scenicid=<%#Eval("Id")%>'>管理门票</a>
                </td>
              
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr style="background-color: #F2F2F2">
                <td>
                    <%#Eval("Name") %>
                </td>
                <td>
                    <%#Eval("Address") %>
                </td>
                <td style="text-align: center">
                    <%#Eval("Level") %>
                </td>
                <td>
                    <asp:Repeater runat="server" ID="rpt_CheckProgress">
                        <ItemTemplate>
                            <div>
                                模块:<%#Eval("Module") %>,状态:<%#Eval("CheckStatus")%></div>
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
                <td style="text-align: center">
                    <a href='ScenicDetail.aspx?id=<%#Eval("Id") %>'>审核</a><a href='EditScenic.aspx?id=<%#Eval("Id")%>'>编辑</a>
                    <a href='EditTicket.aspx?scenicid=<%#Eval("Id")%>'>管理门票</a>
                </td>
                <%--<td >
                    <asp:Button ID="btnmake" runat="server" Text="生成" CommandName="make" CommandArgument='<%#Eval("Id") %>' />
                    <asp:Label ID="lblaccount" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btncz" runat="server" Text="重置密码" CommandName="reset" CommandArgument='<%#Eval("Id") %>' />
                </td>--%>
            </tr>
        </AlternatingItemTemplate>
    </asp:Repeater>
</asp:Content>

