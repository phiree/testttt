<%@ Page Title="" Language="C#" MasterPageFile="~/TourEnterprise/TE.master" AutoEventWireup="true" CodeFile="TEStatistics.aspx.cs" Inherits="TourEnterprise_TEStatistics" %>
<%@ MasterType VirtualPath="~/TourEnterprise/TE.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <div class="detail_titlebg">
        统计
    </div>
        <div class="searchdiv">
        <h5>按时间进行查询</h5>
        <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rbolistSelect" OnSelectedIndexChanged="rbolistSelect_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem Text="一个月内" Selected="True" Value="type_1"  />
            <asp:ListItem Text="三个月内" Value="type_2" />
            <asp:ListItem Text="半年内" Value="type_3" />
            <asp:ListItem Text="一年内" Value="type_4" />
        </asp:RadioButtonList>
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            统计列表
        </div>
        <table border="1" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    游玩时间
                </td>
                <td>
                    团队名称
                </td>
                <td>
                    旅行社名称
                </td>
                <td>
                    人数
                </td>
            </tr>
            <asp:Repeater runat="server" ID="rptTgRecord" 
                onitemdatabound="rptTgRecord_ItemDataBound">
                <ItemTemplate>
                   <tr>
                       <td>
                           <%# Eval("BeginDate","{0:yyyy-MM-dd}")%>至<%# Eval("EndDate", "{0:yyyy-MM-dd}")%></td>
                       <td>
                           <%# Eval("Name") %>
                       </td>
                       <td>
                           <%# Eval("DJ_DijiesheInfo.Name")%>
                       </td>
                       <td>
                           成人<%# Eval("AdultsAmount")%>儿童<%# Eval("ChildrenAmount")%></td>
                   </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <tr>
                        <td colspan="4">
                            总计
                        </td>                    
                    </tr>
                    <tr>
                        <td colspan="4">
                            共接待团队数<asp:Literal ID="laGuiderCount" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;
                            其中包括成人<asp:Literal ID="laAdultCount" runat="server"></asp:Literal>儿童<asp:Literal ID="laChildrenCount" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </FooterTemplate>
            </asp:Repeater>
        </table>
        <div id="pager">
            <uc:aspnetpager runat="server" EnableUrlRewriting="true" ID="pagerGot"
                UrlPaging="true" UrlPageIndexName="pgotindex"
                FirstPageText="首页" LastPageText="尾页" PageSize="10" NextPageText="下一页" CurrentPageButtonClass="cpb"
                PrevPageText="上一页">
            </uc:aspnetpager>
            
        </div>
    </div>
</asp:Content>

