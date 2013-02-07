<%@ Page Title="" Language="C#" MasterPageFile="~/sm.master" AutoEventWireup="true"
    CodeFile="WorkerAssign.aspx.cs" Inherits="ScenicManager_WorkerAssign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" runat="Server">
<link href="/theme/default/css/smdefault.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <p class="fuctitle">
        工作人员修改</p>
    <hr />
    <div id="xgwk">
        <table border="0" cellpadding="0" cellspacing="0" width="300px">
            <tr>
                <td style="width:80px">
                    <asp:Label ID="Label1" runat="server" Text="用户账号"></asp:Label>
                </td>
                <td>
                    <%=User.Name %>
                </td>
            </tr>
            <tr>
                <td style="width:100px">
                    当前分配的角色
                </td>
                <td>
                    <asp:Label runat="server" ID="lblAdminType"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="vertical-align:top; padding-top:10px;">
                    权限
                </td>
                <td>
                    <asp:CheckBoxList ID="cblAdminType" runat="server" style="margin:0px; padding:0px;">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>
                    
                </td>
                <td>
                    <asp:Button runat="server" ID="btnModify" OnClick="btnModify_Click" CssClass="savebtn" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
