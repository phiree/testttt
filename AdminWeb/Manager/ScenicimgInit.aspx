<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="ScenicimgInit.aspx.cs" Inherits="Manager_ScenicimgInit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphmain" runat="Server">
    <p>请确认一下信息</p>
    <ul>
        <li>将2个excel文件放在d盘下, 文件名分别为为<b>价格表格式.xlsx</b>,<b>景区表格式.xlsx</b></li>
        <li>将<b>testDetailimgLocalizer</b>和<b>testMainimgLocalizer</b>文件夹放到d盘下.</li>
        <li>在d盘下创建<b>scenicimg</b>文件夹，并在该文件夹中创建<b>mainimg</b>和<b>detailimg</b></li>
        <li>初始化完成后, 将<b>testDetailimgLocalizer</b>中的图片拷贝到<b>detailimg</b></li>
        <li>将<b>mainimg</b>里的文件通过工具剪裁到新的<b>small</b>文件夹中</li>
    </ul>
    <asp:Button ID="btnExcel" runat="server" Text="导入数据" OnClick="btnExcel_Click" />
</asp:Content>
