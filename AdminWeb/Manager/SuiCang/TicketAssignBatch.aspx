<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="TicketAssignBatch.aspx.cs" Inherits="Manager_QuZhouSpring_TicketAssignBatch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <fieldset>
        <legend>分配规则</legend>
        将剩余门票分配给  <%=DateTime.Now.Date %> 到活动结束 (2月6号) 之间的日期,
        比例可以修改数组:peishuForStartDates
        <div><asp:Button runat="server" ID="btnCal" OnClick="btnSave_Click" Text="保存" /></div>
        
        <asp:Repeater runat="server" ID="rptAssign">
            <HeaderTemplate>
                <table>
                    <tr>
                        <td>
                            景区
                        </td>
                        <td>
                            可支配票量
                        </td>
                        <td>
                            已售票数
                        </td>
                        <td>
                            日期
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                      <asp:Label runat="server"  Text="<%#((object[])Container.DataItem)[0] %>"
                       ID="lblScenicName"></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblTotal"></asp:Label>
                    </td>
                    <td>
                     <asp:Label runat="server" ID="lblSold" Text="   <%#((object[])Container.DataItem)[3] %>"></asp:Label>
                    </td>
                    <td>
                        <asp:Repeater runat="server" ID="rptPartner">
                            <HeaderTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            名称
                                        </td>
                                        <td>
                                            日期分配
                                        </td>
                                    </tr>
                               
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%#Eval("Name")%>分配比例<asp:Label runat="server" ID="lblPartnerPercent"></asp:Label>
                                        <asp:HiddenField runat="server" ID="hiFid" Value='<%#Eval("FriendlyId")%>' />
                                    </td>
                                    <td>
                                        <asp:Repeater runat="server" ID="rptDate">
                                        <HeaderTemplate><table><tr><td>日期</td><td>数量</td></tr></HeaderTemplate>
                                            <ItemTemplate>
                                              <tr><td><%#((DateTime)Container.DataItem).ToString("yyyy-MM-dd") %></td>
                                              <td><asp:TextBox runat="server" ID="tbxAmount"></asp:TextBox></td></tr> 
                                              
                                            </ItemTemplate>
                                            <FooterTemplate>
                                            </table></FooterTemplate>
                                        </asp:Repeater>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </fieldset>
    <div>
    
    </div>
</asp:Content>
