<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/uc.master" AutoEventWireup="true" CodeFile="CommonUserInfo.aspx.cs" Inherits="UserCenter_CommonUserInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="/theme/default/css/ucdefault.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/ucdefault.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ucContent" Runat="Server">
    <div id="cuinfo">
        <div class="culist">
            <asp:Repeater ID="rptcu" runat="server">
                <HeaderTemplate>
                    <table border="0" cellpadding="0" cellspacing="0" width="600px">
                        <tr style=" background-color:#E3DED3; color:#807940;height:25px; line-height:25px;">
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
                    <tr onmousemove="changebg(this)" onmouseout="changebg2(this)">
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
                <asp:Button ID="btnadd" runat="server" CssClass="btnaddcu" Text="新增"
                    onclick="btnadd_Click" />
                <asp:Button ID="btndelete"
                    runat="server" CssClass="btndeletecu" onclick="btndelete_Click" Text="删除"  />
            </div>
            <p style="margin-left:35px">
                希望您能多多邀请您的亲朋好友加入Tourol.cn,我们将带来更多更优惠的打折门票。
            </p>
        </div>
    </div>
</asp:Content>

