<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="ScenticManager_Default" %>

<%@ MasterType VirtualPath="~/ScenicManager/sm.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" runat="Server">
    <link href="/theme/default/css/smdefault.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <p class="fuctitle">
        欢迎信息</p>
    <hr />
    <div class="weldiv">
        <div><asp:LoginName ID="LoginName1" runat="server" style="font-weight:bold;font-size:14px;" />
    :您好,您是<span><%=ScenicName %></span>的<span><%=RoleNames %></span> ,您可以:
    </div>
    <div id="dvEditor" runat="server" visible="false">
        <span>查看和管理景区的信息</span>: 您可以查看编辑景区的信息,这些信息会显示在景区详情页面. <br /> 您可以<a href="UpdateScenticInfo.aspx">点击这里,打开景区资料管理界面</a>,或者 点击左侧的<b>"景区资料"</b>链接
    </div>
    <div id="dvAccountManager" runat="server" visible="false">
        <span>管理本景区的工作人员</span>: 您可以为本景区的管理系统添加帐号,并为每个帐号分配工作职责.  <br /> 您可以<a href="WorkerList.aspx">点击这里,打开人员管理界面</a>,或者 点击左侧的<b>"工作人员列表"</b>链接</div>
    <div id="dvChecker" runat="server" visible="false">
        <span>为网络订票用户提供验证和换票服务</span> <br /> 您可以<a href="CheckTicket.aspx">点击这里,打开人验票界面</a>,或者 点击左侧的<b>"景区验票"</b>链接
    </div>
    <div id="dvFinance" runat="server" visible="false">
       <span>查看和管理景区的财务结算信息</span> 您可以查看 网络订票的详细财务信息,可以在帐目结清之后进行结算操作.  <br /> 您可以<a href="StatisInfo.aspx">点击这里,打开财务管理界面</a>,或者 点击左侧的<b>"账单管理"</b>链接
      </div>
    </div>
    
</asp:Content>
