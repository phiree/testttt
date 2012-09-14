<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="ScenticManager_Default" %>

<%@ MasterType VirtualPath="~/ScenicManager/sm.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" runat="Server">
    <link href="../Styles/pricesetting.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <asp:LoginName runat="server" />
    ,您好,您是<span><%=ScenicName %></span>的<span><%=RoleNames %></span> ,您可以:
    <div id="dvEditor" runat="server" visible="false">
        查看和管理景区的财务结算信息: 您可以查看 网络订票的详细财务信息,可以在帐目结清之后进行结算操作. 您可以点击这里,打开财务管理界面,或者 点击左侧的"财务管理"链接
    </div>
    <div id="dvAccountManager" runat="server" visible="false">
        管理本景区的工作人员.: 您可以为本景区的管理系统添加帐号,并为每个帐号分配工作职责. 您可以点击这里,打开人员管理界面,或者 点击左侧的"工作人员管理"链接</div>
    <div id="dvChecker" runat="server" visible="false">
        为网络订票用户提供验证和换票服务. 您可以点击这里,打开人验票界面,或者 点击左侧的"验票"链接
    </div>
    <div id="dvFinance" runat="server" visible="false">
        查看和管理景区的财务结算信息: 您可以查看 网络订票的详细财务信息,可以在帐目结清之后进行结算操作. 您可以点击这里,打开财务管理界面,或者 点击左侧的"财务管理"链接
    </div>
</asp:Content>
