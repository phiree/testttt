<%@ Page Title="" Language="C#" MasterPageFile="~/sm.master" AutoEventWireup="true" CodeFile="TicketApply.aspx.cs" Inherits="ScenicManager_OnlineSell_TicketApply" %>
<%@ MasterType VirtualPath="~/sm.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" Runat="Server">
    <link href="/theme/default/css/smdefault.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <p class="fuctitle">
        景区门票信息</p>
    <hr />
    <div id="shprice" style=" min-height:400px">
        <div class="passsh" id="passdiv" runat="server">
                您的上次价格更改，已经通过核对,修改后的价格如下所示，还想修改,请选择<a href="Pricesetting.aspx" style="font-size:14px">修改</a>
        </div>
        <div class="passsh" id="applyingdiv" runat="server">
                正在核对中......<br />当前提交的票价信息为:</div>
        <div class="passsh" id="failurediv" runat="server">
                核对失败,请重新修改以下门票价格,或者核对上传文件的价格和修改价格是否一致，请选择<a class="update" href="Pricesetting.aspx">修改</a></div>
        <asp:Repeater ID="rptprice" runat="server">
                <HeaderTemplate>
                    <table style="width:550px; margin:10px auto;">
                        <thead>
                            <tr>
                                <th style=" text-align:center;">
                                    门票
                                </th>
                                <th style=" text-align:center;">
                                    原价
                                </th>
                                <th style=" text-align:center;">
                                    景区现付价
                                </th>
                                <th style=" text-align:center;">
                                    在线支付价
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th style=" text-align:center;">
                            <%#Eval("Name") %>
                        </th>
                        <td style=" text-align:center;">
                            <%# ((IList<Model.TicketPrice>)Eval("TicketPrice")).Where(x => x.PriceType == Model.PriceType.Normal).First().Price.ToString("0") %>
                        </td>
                        <td style=" text-align:center;">
                            <%# ((IList<Model.TicketPrice>)Eval("TicketPrice")).Where(x => x.PriceType == Model.PriceType.PreOrder).First().Price.ToString("0")%>
                        </td>
                        <td style=" text-align:center;">
                            <%# ((IList<Model.TicketPrice>)Eval("TicketPrice")).Where(x => x.PriceType == Model.PriceType.PayOnline).First().Price.ToString("0")%>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody> </table>
                </FooterTemplate>
            </asp:Repeater>
    </div>
</asp:Content>

