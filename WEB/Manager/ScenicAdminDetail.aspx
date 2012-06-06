<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="ScenicAdminDetail.aspx.cs" Inherits="Manager_ScenicAdminDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
    <div>
        用户帐号:<%=User.Name %>
        <br />
        <div>
            当前分配的景区:<asp:Label runat="server" ID="lblScenic"></asp:Label>
            <asp:Button runat="server" ID="btnDelete" OnClick="btnDelte_Click" OnClientClick="javascript:return confirm('确定删除?');"
                Text="删除" />
        </div>
        指派景区:
        <br />
        <asp:DropDownList ID="ddlProvince" runat="server" OnTextChanged="ddlProvince_TextChanged"
            AutoPostBack="True">
        </asp:DropDownList>
        <asp:DropDownList ID="ddlCity" runat="server" OnTextChanged="ddlCity_TextChanged"
            AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
        <asp:RadioButtonList RepeatColumns="5" ID="cblSceniclist" runat="server">
        </asp:RadioButtonList>
        <br />
        <asp:Button ID="btnOk" Text="确定" runat="server" OnClick="btnOk_Click" />
        <br />
        <asp:Label ID="lblResult" runat="server" />
    </div>
</asp:Content>
