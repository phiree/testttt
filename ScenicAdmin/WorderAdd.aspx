<%@ Page Title="" Language="C#" MasterPageFile="~/sm.master" AutoEventWireup="true"
    CodeFile="WorderAdd.aspx.cs" Inherits="ScenicManager_WorderAdd" %>

<%@ MasterType VirtualPath="~/sm.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" runat="Server">
    <link href="../theme/default/css/smdefault.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <p class="fuctitle">
        增加工作人员</p>
    <hr />
    <div id="addwk">
        <table class="addmain" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:Label ID="Label1" Text="*登录名" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="txtname" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" Text="真实姓名" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="txtRealName" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" Text="*密码" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="txtpsw" runat="server" TextMode="Password" />
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; padding-top: 8px;">
                    <asp:Label ID="Label3" Text="*权限" runat="server" />
                </td>
                <td>
                    <asp:CheckBoxList ID="cblAdminType" runat="server">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button runat="server" ID="btnAdd" CssClass="addwkbtn" OnClick="btnAdd_Click" />
                </td>
            </tr>
        </table>
    </div>
    <p class="wkintr">
        景区总负责人:可以更改工作人员的操作权限，负责资料的审核，账单的审核
    </p>
    <p class="wkintr">
        景区资料员:配合网站前台共同完善景区资料，上传图片等
    </p>
    <p class="wkintr">
        景区财务：账目和订单管理
    </p>
    <p class="wkintr">
        检票员：检票
    </p>
</asp:Content>
