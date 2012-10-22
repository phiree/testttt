<%@ Page Title="" Language="C#" MasterPageFile="~/TourManagerDpt/manager.master" AutoEventWireup="true" CodeFile="DjsList.aspx.cs" Inherits="TourManagerDpt_DjsList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="main" Runat="Server">
    <div class="detail_titlebg">
        地接社列表
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            地接社列表
        </div>
        <asp:Repeater runat="server" ID="rpt" OnItemCommand="rpt_ItemCommand" OnItemDataBound="rpt_ItemDataBound">
            <HeaderTemplate>
                <table>
                    <tr>
                        <td>
                            名称
                        </td>
                        <td>
                            查看
                        </td>
                       <td>
                            统计情况
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("Name") %>
                    </td>
                    <td>
                        <a href='EnterpriseDetail.aspx?entid=<%#Eval("Id") %>'>查看企业信息</a>
                    </td>
                    <td>
                        <a href='RewordInfo.aspx?entid=<%#Eval("Id") %>'>查看统计信息</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
    </div>

</asp:Content>

