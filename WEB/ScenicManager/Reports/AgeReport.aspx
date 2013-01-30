<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true" CodeFile="AgeReport.aspx.cs" Inherits="ScenicManager_Reports_AgeReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">

 <asp:Chart ID="Chart1" Width="699" Height="900"
        runat="server" Palette="SeaGreen" BackGradientStyle="LeftRight" 
        BorderlineDashStyle="Dot">
        <Series></Series>
        <ChartAreas>
            <asp:ChartArea BorderDashStyle="Dot" Name="ChartArea1" BorderColor="#FF9900" BackGradientStyle="TopBottom">
            <AxisY Title="比例" ></AxisY>
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
</asp:Content>

