<%@ page language="C#" autoeventwireup="true" masterpagefile="~/Manager/manager.master" enableeventvalidation="false" inherits="Manager_ScenicinfoCheckaspx, App_Web_yhjf3wuk" %>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Repeater runat="server" ID="rpt" onitemcommand="rpt_ItemCommand" 
        onitemdatabound="rpt_ItemDataBound" >
        <HeaderTemplate>
            <table>
                <tr>
                    <td>
                        名称
                    </td>
                    <td>
                        地址
                    </td>
                    <td>
                        A级
                    </td>
                    <td>
                        图片
                    </td>
                    <td>
                        审核
                    </td>
                </tr>
        </HeaderTemplate>
        <FooterTemplate>
            </table></FooterTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("Name") %>
                </td>
                <td>
                    <%#Eval("Address") %>
                </td>
                <td>
                    <%#Eval("Level") %>
                </td>
                <td>
                    <%#Eval("Photo") %>
                </td>
                <td>
                    <%# ((bool)Eval("Validated"))?"已通过":"未通过"%> 
                    <asp:Button runat="server" ID="btnValidate"  Text="通过" CommandName="validate" CommandArgument='<%#Eval("Id") %>'/>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    <uc:AspNetPager runat="server" ID="pager"  UrlPaging="true">
    </uc:AspNetPager>
  </asp:Content>
