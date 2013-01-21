<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ScenicSideList.ascx.cs" Inherits="UC_ScenicSideList" %>
 <table class="tbvisitedsc" border="0" cellpadding="0" cellspacing="0">
                    <asp:Repeater ID="rptvisited" runat="server" 
                        onitemdatabound="rptvisited_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                        <td>
                            <img src="/theme/default/image/newversion/jt2.gif" /><a runat="server" id="ahref" href='<%# ResolveUrl(string.Format("/Tickets/{0}/{1}.html", Eval("Area.SeoName"),Eval("SeoName"))) %>'><%# Eval("Name") %></a>
                        </td>
                    </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>