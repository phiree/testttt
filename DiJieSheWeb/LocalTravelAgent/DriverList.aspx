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
    <div class="detail_titlebg">
        司机管理
    </div>
    <div class="searchdiv">
        姓名:<asp:TextBox ID="txtName_add" runat="server" style="margin-right:100px;margin-left:50px;width:150px;" />
        手机:<asp:TextBox ID="txtPhone_add" runat="server" style="margin-left:50px;width:150px;"  /><br />
        身份证号:<asp:TextBox ID="txtId_add" runat="server" style="margin-right:100px;margin-left:27px;width:150px;"  />
        驾照证号:<asp:TextBox ID="txtDriverid_add" runat="server" style="margin-left:27px;width:150px;" /><br />
        <asp:Button ID="btnQuickadd" Text="快速添加" runat="server" CssClass="btn" OnClick="btnQuickadd_Click" />
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            司机管理
        </div>
        <fieldset style="padding-top: 0px; display: none">
            <legend style="font-size: 12px;">搜索条件：</legend>
            <div class="searchdiv">
                姓名:<asp:TextBox ID="txtName" runat="server" />
                身份证号:<asp:TextBox ID="txtIdcardid" runat="server" />
                驾驶证号:<asp:TextBox ID="txtDrivercardid" runat="server" />
                <asp:Button ID="btnSearch" Text="查询" runat="server" CssClass="btn" OnClick="btnSearch_Click" />
            </div>
        </fieldset>
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
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
        <hr />
    </div>
</asp:Content>
