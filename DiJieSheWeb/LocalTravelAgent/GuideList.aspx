<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true" CodeFile="GuideList.aspx.cs" Inherits="LocalTravelAgent_GuideList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<div class="detaillist">
    <div class="detailtitle">
        司机管理
    </div>
    <div class="searchdiv">
        姓名:<asp:TextBox ID="txtName" runat="server" />
        身份证号:<asp:TextBox ID="txtIdcardid" runat="server" />
        导游证号:<asp:TextBox ID="txtGuidecardid" runat="server" />
        <asp:Button ID="btnSearch" Text="查询" runat="server" CssClass="btn" OnClick="btnSearch_Click"/>
    </div>
    <asp:Repeater ID="rptGuides" runat="server" OnItemDataBound="rptGuides_ItemDataBound" OnItemCommand="rptGuides_ItemCommand">
        <HeaderTemplate>
            <table>
                <thead>
                    <tr>
                        <td>
                            <asp:LinkButton ID="lblname" Text="姓名" runat="server" CommandName="lblname" />
                        </td>
                        <td>
                            <asp:LinkButton ID="lblphone" Text="电话" runat="server" CommandName="lblphone" />
                        </td>
                        <td>
                            <asp:LinkButton ID="lblidcard" Text="身份证号" runat="server" CommandName="lblidcard" />
                        </td>
                        <td>
                            <asp:LinkButton ID="lblguide" Text="导游证号" runat="server" CommandName="lblguide" />
                        </td>
                        <td>所属地接社
                        </td>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
            <td>
            <a href='/LocalTravelAgent/GuideDetail.aspx?id=<%#Eval("Id")%>'><%#Eval("Name")%></a>
            </td>
            <td>
                <%#Eval("Phone")%>
            </td>
            <td>
                <%#Eval("IDCard")%>
            </td>
            <td>
                <%#Eval("SpecificIdCard")%>
            </td>
            <td>
                <%#Eval("DJ_Dijiesheinfo.Name")%>
            </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody> </table>
        </FooterTemplate>
    </asp:Repeater>
    <div class="searchdiv">
        姓名:<asp:TextBox ID="txtName_add" runat="server" />
        手机:<asp:TextBox ID="txtPhone_add" runat="server" />
        身份证号:<asp:TextBox ID="txtId_add" runat="server" />
        导游证号:<asp:TextBox ID="txtGuideid_add" runat="server" />
        <asp:Button ID="btnQuickadd" Text="快速添加" runat="server" CssClass="btn" OnClick="btnQuickadd_Click"/>
    </div>
</div>
</asp:Content>

