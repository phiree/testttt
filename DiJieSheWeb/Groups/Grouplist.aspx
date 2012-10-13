<%@ Page Title="" Language="C#" MasterPageFile="~/Groups/Groups.master" AutoEventWireup="true"
    CodeFile="Grouplist.aspx.cs" Inherits="Groups_Grouplist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="detail_titlebg">
        团队列表
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            团队列表
        </div>
    <asp:Repeater ID="rptGroups" runat="server">
        <HeaderTemplate>
            <table>
                <thead>
                    <tr>
                        <td>
                        名称
                        </td>
                        <td>
                        时间
                        </td>
                        <td>
                        人数
                        </td>
                        <td>
                        集合点
                        </td>
                        <td>
                        返程点
                        </td>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tbody>
                <tr>
                        <td>
                            <a href='/Groups/GroupDetail.aspx?id=<%#Eval("Id")%>'><%#Eval("Name")%></a>
                        </td>
                        <td>
                        <%#Eval("BeginDate") + "-" + Eval("EndDate")%>
                        </td>
                        <td>
                        <%#int.Parse(Eval("AdultsAmount").ToString()) + int.Parse(Eval("AdultsAmount").ToString())%>
                        </td>
                        <td>
                        <%#Eval("Gether")%>
                        </td>
                        <td>
                        <%#Eval("BackPlace")%>
                        </td>
                </tr>
            </tbody>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    </div>
</asp:Content>
