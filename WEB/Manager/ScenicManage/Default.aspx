<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Manager/manager.master"
    CodeFile="Default.aspx.cs" EnableEventValidation="false" Inherits="Manager_ScenicinList" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link href="/theme/default/css/Managerdefault.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cphmain">
    <div id="selectdiv">
        <span>筛选:</span>
    </div>
    
    <div class="tbaction">
        
        <asp:DropDownList runat="server" ID="ddlArea">
        </asp:DropDownList>
        <asp:Button runat="server" ID="btnSearch" Text="确定" OnClick="btnSearch_Click" />
    </div>
    <asp:Repeater runat="server" ID="rptScenic" OnItemDataBound="rpt_ItemDataBound" 
        onitemcommand="rptScenic_ItemCommand">
        <HeaderTemplate>
            <table class="tblist" cellpadding="0" cellspacing="0" border="0">
                <thead>
                    <tr>
                        <td>
                            名称
                        </td>
                        <td>
                            地址
                        </td>
                        <td>
                            A级
                        </td>
                        <td>
                            图片
                        </td>
                        <td>
                            审核状态
                        </td>
                        <td>
                            操作
                        </td>
                        <td>
                            生成账号
                        </td>
                        <td>
                            账号操作
                        </td>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <FooterTemplate>
            </tbody> </table></FooterTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("Name") %>
                </td>
                <td>
                    <%#Eval("Address") %>
                </td>
                <td>
                    <%#Eval("Level") %>
                </td>
                <td>
                    <%#Eval("Photo") %>
                </td>
                <td>
                    <asp:Repeater runat="server" ID="rpt_CheckProgress">
                        <ItemTemplate>
                            <div>
                                模块:<%#Eval("Module") %>,状态:<%#Eval("CheckStatus")%></div>
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
                <td>
                    <a href='ScenicDetail.aspx?id=<%#Eval("Id") %>'>审核</a>
                </td>
                <td>
                    <asp:Button ID="btnmake" runat="server" Text="生成" CommandName="make" CommandArgument='<%#Eval("Id") %>' />
                    <asp:Label ID="lblaccount" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btncz" runat="server" Text="重置密码" CommandName="reset" CommandArgument='<%#Eval("Id") %>' />
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
