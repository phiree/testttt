<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Demo.master" CodeFile="Demo.aspx.cs" Inherits="Admin_Demo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">

    <div class="detail_titlebg">
   TourOl地接社平台Demo演示
    </div>
   <div class="detaillist">
    <fieldset>
        <legend>旅游管理部门</legend>
        <ul>
            <li>
                <asp:Button runat="server" ID="btnDptAdminLogin" Text="管理部门管理员登录" OnClick="btnDptAdminLogin_Click" b /></li></ul>
    </fieldset>
    <fieldset>
        <legend>旅行社</legend>
        <ul>
            <li>
            <asp:Button runat="server" Text="旅行社管理员登录" OnClick="btnDjsLogin_Click" ID="btnDjsLogin" /></li>
            <li>
            <asp:Button runat="server" Text="创建一个测试团队" OnClick="btnDjsCreatGroup_Click" ID="btnDjsCreatGroup" />
            </li>
        </ul>
    </fieldset>
      <fieldset>
        <legend>宾馆</legend>
        <ul>
            <li>
                <asp:Button runat="server" Text="宾馆管理员登录" OnClick="btnEntLogin_Click" ID="btnEntLogin" /></li>
        </ul>
    </fieldset>
     <fieldset>
        <legend>网站管理员</legend>
        <ul>
            <li>
                <asp:Button runat="server" ID="btnAdminLogin" Text="管理员登录" OnClick="btnAdminLogin_Click" /></li></ul>
    </fieldset>
    </div>
    </asp:Content>