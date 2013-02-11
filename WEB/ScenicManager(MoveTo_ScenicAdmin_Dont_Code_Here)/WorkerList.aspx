<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true"
    CodeFile="WorkerList.aspx.cs" Inherits="ScenicManager_WorkerList" %>

<%@ MasterType VirtualPath="~/ScenicManager/sm.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" runat="Server">
    <link href="/theme/default/css/smdefault.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <p class="fuctitle">
        工作人员列表</p>
    <hr />
    <div id="wlmain">
        <asp:Repeater ID="rptScenicAdmin" runat="server" OnItemDataBound="rptScenicAdmin_ItemDataBound">
            <HeaderTemplate>
                <table class="wltable" cellpadding="0" cellspacing="0">
                    <tr style="background-color: #E9E9E9">
                        <td style="width: 50px;">
                            &nbsp;
                        </td>
                        <td style="width: 100px">
                            景区工作人员
                        </td>
                        <td style="width: 250px">
                            操作权限
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr style="background-color: #F9F9F9">
                    <td>
                        <asp:CheckBox ID="ckbselect" runat="server" />
                    </td>
                    <td style="background-color: #F9F9F9">
                        <%#Eval("Membership.Name")%>
                    </td>
                    <td style="background-color: #F9F9F9">
                        <asp:Label runat="server" ID="lblAdminType"></asp:Label>
                    </td>
                    <td style="background-color: #F9F9F9">
                        <asp:LinkButton ID="LinkButton1" CssClass="lkbtnxg" runat="server" PostBackUrl='<%# Eval("Membership.Id","/ScenicManager/WorkerAssign.aspx?userid={0}") %>'></asp:LinkButton><a
                            class="axg" href="/ScenicManager/WorkerAssign.aspx?userid=<%#Eval("Membership.Id") %>">修改</a>
                    </td>
                    <asp:HiddenField ID="hfid" runat="server" Value='<%#Eval("Membership.Id") %>' />
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <div class="btndelete">
            <asp:Button ID="btnDelete" runat="server" CssClass="deletebtn" OnClick="btnDelete_Click" />
        </div>
        <uc:AspNetPager runat="server" ID="pager" UrlPaging="true">
        </uc:AspNetPager>
    </div>
</asp:Content>
