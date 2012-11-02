<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="DriverList.aspx.cs" Inherits="LocalTravelAgent_DriverList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
<div class="detaillist">
    <div class="detailtitle">
        司机管理
    </div>
    <br />
    <div class="searchdiv">
        姓名:<asp:TextBox ID="txtName" runat="server" />
        身份证号:<asp:TextBox ID="txtIdcardid" runat="server" />
        驾驶证号:<asp:TextBox ID="txtDrivercardid" runat="server" />
        <asp:Button ID="btnSearch" Text="查询" runat="server" CssClass="btn" OnClick="btnSearch_Click"/>
    </div>
    <hr />
    <asp:Repeater ID="rptDrivers" runat="server" OnItemDataBound="rptDrivers_ItemDataBound" OnItemCommand="rptDrivers_ItemCommand">
        <HeaderTemplate>
            <table>
                <thead>
                    <tr>
                        <td>
                            <asp:LinkButton Text="姓名" runat="server" CommandName="lblname" />
                        </td>
                        <td>
                            <asp:LinkButton Text="电话" runat="server" CommandName="lblphone" />
                        </td>
                        <td>
                            <asp:LinkButton Text="身份证号" runat="server" CommandName="lblidcard" />
                        </td>
                        <td>
                            <asp:LinkButton Text="驾照证号" runat="server" CommandName="lbldriver" />
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
            <a href='/LocalTravelAgent/DriverDetail.aspx?id=<%#Eval("Id")%>'><%#Eval("Name")%></a>
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
    <hr />
    <div class="searchdiv">
        姓名:<asp:TextBox ID="txtName_add" runat="server" />
        手机:<asp:TextBox ID="txtPhone_add" runat="server" />
        身份证号:<asp:TextBox ID="txtId_add" runat="server" />
        驾照证号:<asp:TextBox ID="txtDriverid_add" runat="server" />
        <asp:Button ID="btnQuickadd" Text="快速添加" runat="server" CssClass="btn" OnClick="btnQuickadd_Click"/>
    </div>
</div>
</asp:Content>
