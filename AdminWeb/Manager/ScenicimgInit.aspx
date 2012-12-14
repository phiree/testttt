<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="ScenicimgInit.aspx.cs" Inherits="Manager_ScenicimgInit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
    <p>请确认一下信息</p>
    <ul>
        <li>将2个excel文件放在d盘下, 文件名分别为为<b>价格表格式.xlsx</b>,<b>景区表格式.xlsx</b></li>
        <li>在d盘下创建<b>scenicimg</b>文件夹，并在该文件夹中创建<b>mainimg</b>和<b></b></li>
        <li>将各景区图片放在以<b>景区命名</b>的文件夹中, 并将此文件夹放到d盘的<b>图片</b>文件夹中.</li>
    </ul>
    <asp:Button ID="btnExcel" runat="server" Text="导入数据" OnClick="btnExcel_Click" />
</asp:Content>
