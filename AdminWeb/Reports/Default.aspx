<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Reports_Default" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
<asp:Chart ID="Chart1"  runat="server"   Width="700" Height="800" OnCustomize="chart1_custom">
    <ChartAreas>
        <asp:ChartArea  Name="ChartArea1">
        </asp:ChartArea>
    </ChartAreas>
</asp:Chart>
</asp:Content>


