<%@ Page Title="" Language="C#" MasterPageFile="~/TourManagerDpt/manager.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="TourManagerDpt_EnterpriseMgr_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-1.9.1.custom.min.js"></script>
    <script language="javascript" type="text/javascript" src="/Scripts/json2.js"></script>

    <script language="javascript" type="text/javascript">
        var entNames = JSON.parse("<%=EntNames %>");
        $(function () {
            $("#<%=tbxName.ClientID %>").autocomplete({
                source: entNames
            });
        });
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <fieldset>
        <legend>增加奖励企业</legend>企业名称:<asp:TextBox runat="server" ID="tbxName"></asp:TextBox>
        管理员帐号:<asp:TextBox runat="server" ID="tbxAccount"></asp:TextBox>
        <asp:Button runat="server" ID="btnAdd" Text="纳入奖励范围" OnClick="btnAdd_Click" />
        <asp:Label runat="server" ID="lblMsg" CssClass="success" Visible=false>操作成功</asp:Label>
    </fieldset>
    <fieldset>
        <legend>
            <div class="searchdiv">
                纳入状态:<asp:CheckBoxList runat="server" ID="cbxState">
                    <asp:ListItem Value="1" Selected="True">已纳入</asp:ListItem>
                    <asp:ListItem Value="2" Selected="True">已移除</asp:ListItem>
                </asp:CheckBoxList>
                <asp:Button runat="server" ID="btnSearch" Text="确定" />
            </div>
            <asp:Repeater runat="server" ID="rptEntList">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <td>
                                名称
                            </td>
                            <td>
                                负责人
                            </td>
                            <td>
                                负责人电话
                            </td>
                            <td>
                                操作
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                         <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table></FooterTemplate>
            </asp:Repeater>
        </legend>
    </fieldset>
</asp:Content>
