<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="GroupDetail.aspx.cs" Inherits="LocalTravelAgent_GroupDetail" %>

<%-- 在此处添加内容控件 --%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p>
        名称: <asp:Label ID="lblName" Text="" runat="server" />
    </p>
    <p>
        起止时间:BeginDate<asp:Label ID="lblBeginDate" Text="" runat="server" /> 
        至 EndDate<asp:Label ID="lblEndDate" Text="" runat="server" />
    </p>
    <p>
        导游信息: GuideName<asp:Label ID="lblGuideName" Text="" runat="server" />
        [Members.IdCardNo<asp:Label ID="lblIdCardNo" Text="" runat="server" />] 
        GuidePhone<asp:Label ID="lblGuidePhone" Text="" runat="server" />
    </p>
    <p>
        司机信息:DriverName<asp:Label ID="lblDriverName" Text="" runat="server" />
         DriverPhone<asp:Label ID="lblDriverPhone" Text="" runat="server" />
          CarNo<asp:Label ID="lblCarNo" Text="" runat="server" /> </p>
    队员信息:
    <asp:Repeater ID="rptGrouplist" runat="server">
        <HeaderTemplate>
            <table border="1" cellpadding="1" cellspacing="1">
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# Eval("RealName")%>
                </td>
                <td>
                    <%# Eval("IdCardNo")%>
                </td>
                <td>
                    <%# Eval("Gender")%>
                </td>
                <td>
                    <%# Eval("PhoneNum")%>
                </td>
                <td>
                    <%# Eval("PhoneNum")%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
