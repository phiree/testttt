<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/uc.master" AutoEventWireup="true" CodeFile="CommonUserInfo.aspx.cs" Inherits="UserCenter_CommonUserInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="/theme/default/css/ucdefault.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ucContent" Runat="Server">
    <div id="cutop">常用联系人管理</div>
    <div id="cuinfo">
        <div class="culist">
            <asp:Repeater ID="rptcu" runat="server">
                <HeaderTemplate>
                    <table border="0" cellpadding="0" cellspacing="0" width="600px">
                        <tr style=" background-color:#82974C; color:White;">
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                联系人姓名   
                            </td>
                            <td>
                                身份证号
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HiddenField ID="hfid" runat="server" Value='<%# Eval("Id") %>' />
                    <tr>
                        <td>
                            <asp:CheckBox ID="ckbselect" runat="server" />
                        </td>
                        <td style="padding:5px">
                            <%# Eval("Name") %>
                        </td>
                        <td style="padding:5px">
                            <%# Eval("IdCard") %>
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkButton1" CssClass="lkbtnxg" runat="server" PostBackUrl='<%# Eval("Id","/UserCenter/UpdateCommonUser.aspx?cuid={0}") %>'></asp:LinkButton><a class="axg" href="/UserCenter/UpdateCommonUser.aspx?cuid=<%#Eval("Id") %>">修改</a>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <div class="xzan">
                <asp:Button ID="btnadd" runat="server" CssClass="btnaddcu" 
                    onclick="btnadd_Click" />
                <asp:Button ID="btndelete"
                    runat="server" CssClass="btndeletecu" onclick="btndelete_Click"  />
            </div>
        </div>
    </div>
</asp:Content>

