<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true"
    CodeFile="ManageDptList.aspx.cs" Inherits="Admin_ManageDptList" %>
<%@ Register TagPrefix="uc"  Src="~/UC/CityCode.ascx" TagName="dllcitycode"%>
    <asp:Content ID="Content2" ContentPlaceHolderID="cphhead" runat="server">
    <link href="/Scripts/jqueryplugin/tablesorter/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/OrderIndex.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".tablesorter").tablesorter();
            $(".IndexTable").orderIndex();
        });
        
    </script>
    </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="Server">

    <div class="detail_titlebg">
        旅游管理部门列表
    </div>
    <div class="searchdiv">
        
        区域编码筛选
        <uc:dllcitycode ID="ddlarea" runat="server" />
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server"
            Text="确定" OnClick="btn_Click" CssClass="btn" />&nbsp;&nbsp;<asp:Button ID="btn_All" runat="server"
            Text="查看全部" OnClick="btn_All_Click" CssClass="btn" />&nbsp;&nbsp;<a href="ManageDptImport.aspx">从excel文件导入</a>
    </div>
    <div class="detaillist">
    <div class="detaillist">
        <div class="detailtitle">
            统计列表
        </div>
    <table class="tablesorter IndexTable">
        </table>
    <asp:GridView runat="server" ID="gv" AutoGenerateColumns="false" 
    onrowcommand="gv_RowCommand" onrowdatabound="gv_RowDataBound" CssClass="tablesorter InfoTable" CellSpacing="0" CellPadding="2" border="0" BorderWidth="0" BorderStyle="None">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="名称" />
            
            <asp:BoundField DataField="Address" HeaderText="地址" />
            <asp:TemplateField HeaderText="所属区域">
                <ItemTemplate>
                    <%#((Model.Area)Eval("Area")).Code+((Model.Area)Eval("Area")).Name %></ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField HeaderText="编辑" Text="编辑" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="ManageDptEdit.aspx?dptid={0}" />
            <asp:TemplateField HeaderText="操作">
            <ItemTemplate>
           <asp:Label runat="server" ID="lblAdmin"></asp:Label>  <asp:Button runat="server" Text="生成管理员" ID="btnSetAdmin" CommandName="SetAdmin" CommandArgument='<%#Eval("Id") %>' />
            </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </div>
    </div>
</asp:Content>
