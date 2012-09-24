<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="err.aspx.cs" Inherits="err" %>

<html>
<head>
    <style>
        #dvError
        {
            width: 400px;
            margin: 0 auto;
            text-align: left;
        }
        #sorry
        {
          
            line-height: 30px;
        }
        #detail
        {
            font-size: small;
            color: #888;
            margin-bottom: 20px;
        }
    </style>
</head>
<body style="text-align: center">
    <div id="dvError">
        <img src="image/error.jpg" />
        <div id="sorry">
            <img  src="image/errdot.jpg" style=" position:relative;top:12px;  margin-right:10px;float: left;" />
            <h2>出错了</h2>我们将尽快修复.
        <div id="detail">
            技术信息:<asp:Label runat="server" ID="lblMsg"></asp:Label>
        </div>
        <div>
            <a href="/">返回首页</a>
        </div>
    </div>
</body>
</html>
