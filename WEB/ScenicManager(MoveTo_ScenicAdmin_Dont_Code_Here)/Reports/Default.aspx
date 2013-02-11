<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ScenicManager_Reports_Default" %>



<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <asp:Chart ID="Chart1" Width="699" Height="500"  OnCustomize="chart1_custom" 
        runat="server" Palette="Pastel" BackGradientStyle="LeftRight" 
        BorderlineDashStyle="Dot">
       <Titles>
       <asp:Title Text="游客来源地分析"></asp:Title>
       </Titles>
        	<legends>
								<asp:Legend></asp:Legend>
							</legends>
        <Series></Series>
        <ChartAreas>
            <asp:ChartArea BorderDashStyle="Dot"  Name="ChartArea1" BorderColor="#FF9900" BackGradientStyle="TopBottom">
            
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
</asp:Content>

