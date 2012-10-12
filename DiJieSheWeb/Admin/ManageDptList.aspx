<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true"
    CodeFile="ManageDptList.aspx.cs" Inherits="Admin_ManageDptList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="Server">
    <div class="detail_titlebg">
        旅游管理部门列表
    </div>
    <div class="detaillist">
        <a href="ManageDptImport.aspx">从excel文件导入</a>
    <div>
        区域编码筛选<asp:TextBox runat="server" ID="tbxAreaCode"></asp:TextBox><asp:Button ID="Button1" runat="server"
            Text="确定" OnClick="btn_Click" />
    </div>
    <asp:GridView runat="server" ID="gv" AutoGenerateColumns="false" 
        onrowcommand="gv_RowCommand" onrowdatabound="gv_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="名称" />
            <asp:BoundField DataField="Address" HeaderText="地址" />
            <asp:TemplateField HeaderText="所属区域">
                <ItemTemplate>
                    <%#((Model.Area)Eval("Area")).Name %></ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField HeaderText="操作" Text="编辑" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="ManageDptEdit.aspx?dptid={0}" />
            <asp:TemplateField>
            <ItemTemplate>
           <asp:Label runat="server" ID="lblAdmin"></asp:Label>  <asp:Button runat="server" Text="生成管理员" ID="btnSetAdmin" CommandName="SetAdmin" CommandArgument='<%#Eval("Id") %>' />
            </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </div>
    
</asp:Content>
