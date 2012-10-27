<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Admin_Demo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   <h3>TourOl地接社平台</h3><h4>Demo演示</h4>
    </div>
   
    <fieldset>
        <legend>旅游管理部门</legend>
        <ul>
            <li>
                <asp:Button runat="server" ID="btnDptAdminLogin" Text="管理部门管理员登录" OnClick="btnDptAdminLogin_Click" /></li></ul>
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
    </form>
</body>
</html>
