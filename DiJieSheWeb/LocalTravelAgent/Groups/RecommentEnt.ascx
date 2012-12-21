<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecommentEnt.ascx.cs"
    Inherits="LocalTravelAgent_Groups_RecommentEnt" %>
<link href="/Scripts/jqueryplugin/tablesorter/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/OrderIndex.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".tablesorter").tablesorter();
            $(".IndexTable").orderIndex();
        });
        
    </script>
<div class="detail_titlebg">
    奖励政策
</div>
<div class="searchdiv">
行政区域:<asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="ddlProvince_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="ddlCity_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlCountry" runat="server">
                            </asp:DropDownList>

    <asp:Button ID="BtnSearch" runat="server" Text="搜索" onclick="BtnSearch_Click" CssClass="btn2" />
</div>
   
<div class="detaillist">
<div class="tabSelect">
            <a class="Select_Tab">奖励政策列表</a>
            <asp:Button runat="server" ID="btnExport"  Text="导出列表" OnClick="btnExport_Click" CssClass="btn2 Select_Btn"/>
        </div>
<asp:Repeater runat="server" ID="rptRecomEnt" 
        onitemdatabound="rptRecomEnt_ItemDataBound" 
        onitemcommand="rptRecomEnt_ItemCommand">
    <HeaderTemplate>
     <table class="tablesorter IndexTable">
        </table>
        <table class="tablesorter InfoTable">
            <thead>
            <tr>
                <th>
                    名称
                </th>
                <th>
                    奖励政策
                </th>
            </tr>
            </thead>
            <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td style="width:200px">
                <a runat="server"  id="redirtLink"><%#Eval("Name")%></a>
            </td>
            <td>
                <asp:Literal ID="laPolicy" runat="server"></asp:Literal>
                <asp:Button ID="btnUpload" runat="server" Text="下载相关文件" CssClass="btn2" CommandName="upload" Visible="false" />
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
    </tbody>
   
        </table></FooterTemplate>
</asp:Repeater>

</div>