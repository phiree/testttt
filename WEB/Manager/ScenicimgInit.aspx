<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="ScenicimgInit.aspx.cs" Inherits="Manager_ScenicimgInit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
    <p>请确认一下信息</p>
    <ul>
        <li>将excel放在d盘下, 文件名为"2012年浙江省A级旅游景区汇总统计表.xls"</li>
        <li>在d盘下创建scenicimg文件夹</li>
        <li>将各景区图片放在以景区命名的文件夹中, 并将此文件夹放到d盘的图片文件夹中.</li>
    </ul>
    <asp:Button ID="btnExcel" runat="server" Text="导入数据" OnClick="btnExcel_Click" />
</asp:Content>
