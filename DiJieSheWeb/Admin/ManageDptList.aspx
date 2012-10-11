<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true"
    CodeFile="ManageDptList.aspx.cs" Inherits="Admin_ManageDptList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="Server">
    <a href="ManageDptImport.aspx">从excel文件导入</a>
    <div>
        区域编码筛选<asp:TextBox runat="server" ID="tbxAreaCode"></asp:TextBox><asp:Button runat="server"
            Text="确定" OnClick="btn_Click" />
    </div>
    <asp:GridView runat="server" ID="gv" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="名称" />
            <asp:BoundField DataField="Address" HeaderText="地址" />
            <asp:TemplateField HeaderText="所属区域">
                <ItemTemplate>
                    <%#((Model.Area)Eval("Area")).Name %></ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField  HeaderText="操作" Text="编辑" DataNavigateUrlFields="Id" 
            DataNavigateUrlFormatString="ManageDptEdit.aspx?dptid={0}"
             />
            

        </Columns>
    </asp:GridView>
</asp:Content>
