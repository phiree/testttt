<%@ Page Title="" Language="C#" MasterPageFile="~/LocalTravelAgent/LTA.master" AutoEventWireup="true"
    CodeFile="GuideList.aspx.cs" Inherits="LocalTravelAgent_GuideList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="/Scripts/jqueryplugin/jqueryui/js/jquery-ui-1.9.1.custom.min.js"></script>
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
        导游列表
    </div>
    <div class="detaillist">
        <div class="detailtitle">
            导游管理
        </div>
         <fieldset style="padding-top:0px;">
        <legend style="font-size:12px;">搜索条件：</legend>
        <div class="searchdiv">
            姓名:<asp:TextBox ID="txtName" runat="server" />
            身份证号:<asp:TextBox ID="txtIdcardid" runat="server" />
            导游证号:<asp:TextBox ID="txtGuidecardid" runat="server" />
            <asp:Button ID="btnSearch" Text="查询" runat="server" CssClass="btn" OnClick="btnSearch_Click" />
        </div>
        </fieldset>
        <table class="tablesorter IndexTable">
        </table>
        <asp:Repeater ID="rptGuides" runat="server">
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
                                <asp:LinkButton ID="lblguide" Text="导游证号" runat="server" CommandName="lblguide" />
                            </th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <a href='/LocalTravelAgent/GuideDetail.aspx?id=<%#Eval("Id")%>'>
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
        <fieldset style="padding-top:0px;">
        <legend style="font-size:12px;">快速添加：</legend>
        <div class="searchdiv">
            姓名:<asp:TextBox ID="txtName_add" runat="server" />
            手机:<asp:TextBox ID="txtPhone_add" runat="server" />
            身份证号:<asp:TextBox ID="txtId_add" runat="server" />
            导游证号:<asp:TextBox ID="txtGuideid_add" runat="server" />
            <asp:Button ID="btnQuickadd" Text="快速添加" runat="server" CssClass="btn" OnClick="btnQuickadd_Click" />
        </div>
        </fieldset>
    </div>
</asp:Content>
