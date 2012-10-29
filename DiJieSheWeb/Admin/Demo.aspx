<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Demo.aspx.cs" Inherits="Admin_Demo" %>


<html><body>
<form runat="server">
<style>
input{cursor:pointer;}
</style>
    <div class="detail_titlebg">
   TourOl地接社平台Demo演示
    </div>
   <div class="detaillist">
    <fieldset>
        <legend>旅游管理部门</legend>
        <ul>
            <li>
                <asp:Button runat="server" ID="btnDptAdminLogin" Text="管理部门管理员登录" OnClick="btnDptAdminLogin_Click"  /></li></ul>
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
                <asp:Button runat="server" ID="btnAdminLogin" Text="管理员登录" OnClick="btnAdminLogin_Click" /></li>
                  <li>
            <asp:Button runat="server" Text="生成测试数据" OnClick="btnReport_Click" ID="btnReport" />
            </li>
                </ul>
    </fieldset>
    </div></form>
  </body></html>