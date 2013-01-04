<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="DriverList.aspx.cs" Inherits="LocalTravelAgent_DriverList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script src="/Scripts/jquery-ui-1.9.2.min.js"></script>
    <script src="/Scripts/VeriIdCard.js" type="text/javascript"></script>
    <link href="/Scripts/jqueryplugin/tablesorter/style.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jqueryplugin/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="/Scripts/jqueryplugin/OrderIndex.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#tbMain").tablesorter();
            $(".IndexTable").orderIndex();
            $("[id$='btnQuickadd']").click(function () {
                var error = test($("[id$='txtId_add']").val());
                $("[id$='hfIdcardError']").val(error);
            });
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
        车牌号:<asp:TextBox ID="txtDriverid_add" runat="server" style="margin-left:38px;width:150px;" /><br />
        所属车队:<asp:TextBox ID="tbxBelong" runat="server" style="margin-left:28px;width:150px;" /><br />
        <asp:Button ID="btnQuickadd" Text="快速添加" runat="server" CssClass="btn2" OnClick="btnQuickadd_Click" />
    </div>
    <div class="detaillist">
        <div class="tabSelect">
            <a class="Select_Tab">司机列表</a>
            
        </div>
        <fieldset style="padding-top: 0px; display: none">
            <legend style="font-size: 12px;">搜索条件：</legend>
            <div class="searchdiv">
                姓名:<asp:TextBox ID="txtName" runat="server" />
                身份证号:<asp:TextBox ID="txtIdcardid" runat="server" />
                车牌号:<asp:TextBox ID="txtDrivercardid" runat="server" />
                <asp:Button ID="btnSearch" Text="查询" runat="server" CssClass="btn2" OnClick="btnSearch_Click" />
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
                                <asp:LinkButton ID="lbldriver" Text="车牌号" runat="server" CommandName="lbldriver" />
                            </th>
                             <th>
                                <asp:LinkButton ID="LinkButton1" Text="所属车队" runat="server" CommandName="lblCompanyBelong" />
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
                        <%#Eval("CompanyBelong")%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
        <hr />
    </div>
    <asp:HiddenField ID="hfIdcardError" runat="server" />
</asp:Content>
