<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ScenicManager_Reports_Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <asp:Chart ID="Chart1" runat="server" Palette="Excel">
        <Series>
            <asp:Series Name="Series1" >
            <Points>
            <asp:DataPoint  AxisLabel="a"  YValues="14" />
            <asp:DataPoint AxisLabel="a"  YValues="11" />
            <asp:DataPoint AxisLabel="a"  YValues="11" />
            <asp:DataPoint AxisLabel="a"  YValues="11" />
            <asp:DataPoint AxisLabel="a"  YValues="11" />
            <asp:DataPoint AxisLabel="a"  YValues="11" />
            </Points>
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
</asp:Content>

