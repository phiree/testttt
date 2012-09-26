<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="GroupList.aspx.cs" Inherits="LocalTravelAgent_GroupList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Repeater ID="rptGrouplist" runat="server">
        <HeaderTemplate>
            <table border="1" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        团队名称
                    </td>
                    <td>
                        导游
                    </td>
                    <td>
                        人数
                    </td>
                    <td>
                        出发时间
                    </td>
                    <td>
                        修改团队信息
                    </td>
                    <td>
                        查看
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# Eval("Name") %>
                </td>
                <td>
                    <%# Eval("GuideName")%>
                </td>
                <td>
                    <%# ((IList<Model.DJ_TourGroupMember>)Eval("Members")).Count%>
                </td>
                <td>
                    <%# Eval("BeginDate")%>
                </td>
                <td>
                    <a href='/Groups/GroupEdit.aspx?id=<%# Eval("Id") %>'>修改基本信息</a> 
                    <a href='/Groups/GroupMemberid.aspx?id=<%# Eval("Id") %>'>修改组员</a>
                    <a href="#">修改行程</a>
                </td>
                <td>
                    <a href="#">团队信息</a> 
                    <a href="#">消费记录</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
