<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="DriverList.aspx.cs" Inherits="LocalTravelAgent_DriverList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/Scripts/jqueryplugin/tablesorter/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/OrderIndex.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#tbMain").tablesorter();
            $(".IndexTable").orderIndex();
        });
    </script>
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
            <asp:Button ID="btnSearch" Text="查询" runat="server" CssClass="btn" OnClick="btnSearch_Click" />
        </div>
        <hr />
        <table class="tablesorter IndexTable">
        </table>
        <asp:Repeater ID="rptDrivers" runat="server">
            <HeaderTemplate>
                <table id="tbMain" class="tablesorter InfoTable">
                    <thead>
                        <tr>
                            <th>
                                <asp:LinkButton ID="lblname" Text="姓名" runat="server" CommandName="lblname" />
                            </th>
                            <th>
                                <asp:LinkButton ID="lblphone" Text="电话" runat="server" CommandName="lblphone" />
                            </th>
                            <th>
                                <asp:LinkButton ID="lblidcard" Text="身份证号" runat="server" CommandName="lblidcard" />
                            </th>
                            <th>
                                <asp:LinkButton ID="lbldriver" Text="驾照证号" runat="server" CommandName="lbldriver" />
                            </th>
                            <th>
                                所属地接社
                            </th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <a href='/LocalTravelAgent/DriverDetail.aspx?id=<%#Eval("Id")%>'>
                            <%#Eval("Name")%></a>
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
            <asp:Button ID="btnQuickadd" Text="快速添加" runat="server" CssClass="btn" OnClick="btnQuickadd_Click" />
        </div>
    </div>
</asp:Content>
