<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ActivityList.aspx.cs" Inherits="ActivityManager_ActivityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" Runat="Server">
    <ext:Grid runat="server" ID="gridActivityList" ShowBorder="true" ShowHeader="true" Title="活动列表"
         EnableRowNumber="true" EnableCheckBoxSelect="true" ForceFitAllTime="true">
         <Columns>
            <ext:BoundField DataField="Name" HeaderText="活动名称" />
            <ext:BoundField DataField="ActivityCode" HeaderText="活动编号" />
            <ext:TemplateField HeaderText="起止时间">
                <ItemTemplate>
                    <span><%# Eval("BeginDate","{0:yyyy-MM-dd}")%>至<%# Eval("EndDate","{0:yyyy-MM-dd}")%></span>
                </ItemTemplate>
            </ext:TemplateField>
            <ext:HyperLinkField HeaderText="详情" Text="编辑详情" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="/ActivityManager/ActivityEdit.aspx?actId={0}" Target="_self"  />
            <ext:HyperLinkField HeaderText="活动统计" Text="活动统计" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="/ActivityManager/ActivityStatistic.aspx?actId={0}" Target="_self" />
         </Columns>   
     </ext:Grid>
     
</asp:Content>

